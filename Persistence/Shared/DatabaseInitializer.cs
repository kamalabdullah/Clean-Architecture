using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CleanArchitecture. Persistence.Shared
{
    public class DatabaseInitializer
       : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext database)
        {
            base.Seed(database);
        }
    }

}
