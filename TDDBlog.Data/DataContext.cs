using System;
using System.Data.Entity;
using Antix.Data.Entity;
using TDDBlog.Data.Properties;

namespace TDDBlog.Data
{
    public class DataContext : DbContext
    {
        #region Constructor
        /// <summary>
        /// Initializes the <see cref="DataContext"/> class.
        /// </summary>
        static DataContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        #endregion

        #region Database initializer
        /// <summary>
        /// Initialize/Update the database
        /// </summary>
        class DatabaseInitializer : IDatabaseInitializer<DataContext>
        {

            public void InitializeDatabase(DataContext context)
            {
                if (context == null) throw new ArgumentNullException("context");

                if (Settings.Default.UpdateDatabaseStructure)
                    context.UpdateDatabaseStructure();
            }
        }
        #endregion

        #region DBSet
        /// <summary>
        /// Gets the blog entries.
        /// </summary>
        public DbSet<BlogEntryData> BlogEntries
        {
            get { return Set<BlogEntryData>(); }
        }
        #endregion
    }
}
