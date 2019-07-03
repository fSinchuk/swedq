using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.DAL.Test
{
    public static class Helpers
    {
        public static DashboardContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<DashboardContext>()
                .UseInMemoryDatabase(name).Options;
            return new DashboardContext(dbOptions);
        }
    }
}
