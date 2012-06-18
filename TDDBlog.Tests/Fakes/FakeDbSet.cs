using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TDDBlog.Tests.Fakes
{
    public class FakeDbSet<T> : IDbSet<T>
         where T : class
    {
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            Local = new ObservableCollection<T>();
            _query = Local.AsQueryable();
        }

        public FakeDbSet(IEnumerable<T> items)
        {
            Local = new ObservableCollection<T>(items);
            _query = Local.AsQueryable();
        }

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return Local.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Local.GetEnumerator();
        }

        #endregion

        #region Implementation of IQueryable

        public Expression Expression
        {
            get { return _query.Expression; }
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _query.Provider; }
        }

        #endregion

        #region Implementation of IDbSet<T>

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            Local.Add(entity);

            return entity;
        }

        public T Remove(T entity)
        {
            Local.Remove(entity);

            return entity;
        }

        public T Attach(T entity)
        {
            Local.Add(entity);

            return entity;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local { get; private set; }

        #endregion

        public void Detach(T item)
        {
            Local.Remove(item);
        }

        public static implicit operator DbSet(FakeDbSet<T> entry)
        {
            throw new NotImplementedException("Cannot convert to DBSet");
        }
    }
}
