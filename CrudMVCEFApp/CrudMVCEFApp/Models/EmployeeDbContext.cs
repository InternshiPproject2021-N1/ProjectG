using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Web;

namespace CrudMVCEFApp.Models
{
        public class EmployeeDbContext : DbContext
        {
            public EmployeeDbContext() : base("EmployeeContext")
            {

            }

            public DbSet<Employee> Employee { get; set; }
            public DbSet<Department> Department { get; set; }
        }
}