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

                context.Database.Connection.ConnectionString =
                    "Server=abb310fd-3fb4-484e-8f8f-a07100a1d825.sqlserver.sequelizer.com;Database=dbabb310fd3fb4484e8f8fa07100a1d825;User ID=kmvwsqhdvlgeckmv;Password=p5adijLt7AwkPtisdV8cAZ5xH6XtJvgxGxua4PJoZF5qqgzEr5hszzwwaKCmtsSJ;";
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
