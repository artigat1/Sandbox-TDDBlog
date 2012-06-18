using System;
using System.Collections.Generic;
using System.Linq;
using Antix.Data.Entity.Interface;
using TDDBlog.Data;

namespace TDDBlog.Tests.Fakes
{
    public class FakeDataContext : FakeDataContextBase, ITddBlogContext
    {

        private ITddBlogContext This
        {
            get { return this; }
        }

        #region Implementation of ITddBlogContext

        /// <summary>
        /// Gets the blog entries.
        /// </summary>
        IQueryable<IBlogEntryData> ITddBlogContext.BlogEntries
        {
            get { return null; }
        }

        #endregion

        #region Implementation of ICoreUnitOfWork

        /// <summary>
        /// Commit
        /// </summary>
        void ICoreUnitOfWork.Commit()
        {
            SaveChanges();
        }

        #endregion

        #region Overrides of FakeDataContextBase

        /// <summary>
        /// Gets the type of the concrete.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <returns></returns>
        protected override Type GetConcreteType(Type entityType)
        {
            return entityType;
        }

        #endregion
    }
}
