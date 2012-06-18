using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Antix;
using Antix.Data.Entity.Interface;

namespace TDDBlog.Tests.Fakes
{
    public abstract class FakeDataContextBase : IDataContext
    {
        #region Implementation of IDataContext

        private int _nextId = 10000;

        private IDictionary<Type, IQueryable> _sets;

        /// <summary>
        ///   <para>Get a set for the type passed</para>
        /// </summary>
        IQueryable<T> IDataContext.GetQuery<T>(Type entityType)
        {
            entityType = entityType ?? typeof(T);

            if (!entityType.IsClass)
            {
                var concreteType = GetConcreteType(entityType);
                if (concreteType != null)
                    return ((IDataContext)this).GetQuery<T>(concreteType);

                throw new NotSupportedException(
                    string.Format("Concrete class required, GetQuery<{0}>", entityType.Name));
            }

            if (_sets == null) _sets = new Dictionary<Type, IQueryable>();
            if (!_sets.ContainsKey(entityType))
                _sets.Add(
                    entityType, (IQueryable)Activator.CreateInstance(
                        typeof(FakeDbSet<>).MakeGenericType(entityType))
                    );

            return (IQueryable<T>)_sets[entityType];
        }

        /// <summary>
        ///   <para>Save changes to the database</para>
        /// </summary>
        /// <returns> The number of objects in an Added, Modified, or Deleted state when SaveChanges was called </returns>
        [DebuggerHidden]
        public int SaveChanges()
        {
            Action<object> fixup = null;

            // ReSharper disable AccessToModifiedClosure
            // recursive delegate
            fixup =
                (o => o.GetType().GetProperties()
                          .Where(p => p.PropertyType.IsEnumerable<IData>())
                          .ForEach(p =>
                          {
                              var sos = (IEnumerable<IData>)p.GetValue(o, null);
                              if (sos == null) return;

                              sos
                                  .Where(so => so.Id == 0)
                                  .ForEach(so =>
                                  {
                                      so.Id = _nextId++;
                                      fixup(so);
                                  });

                              var sps = p.PropertyType.GetProperties();
                              foreach (var sp in sps
                                  .Where(x => x.PropertyType.IsEnumerable<IData>()))
                              {
                                  var spId = sps.SingleOrDefault(x => x.Name == p.Name + "Id");
                                  if (spId != null)
                                  {
                                      sp.SetValue(sos, null, null);
                                  }
                              }
                          }));
            // ReSharper restore AccessToModifiedClosure

            fixup(this);

            return 1;
        }

        protected abstract Type GetConcreteType(Type entityType);

        #endregion

        /// <summary>
        ///   <para>System Session</para>
        /// </summary>
        public bool IsSystemSession { get; set; }

        #region IDataContext Members

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }

        #endregion
    }
}
