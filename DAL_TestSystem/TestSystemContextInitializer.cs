using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TestSystem
{
   
        public class TestSystemContextInitializer : CreateDatabaseIfNotExists<TestSystemDBContext>
        {
            protected override void Seed(TestSystemDBContext context)
            {
                User admin = new User() { Login = "sa", Password = "1", IsAdmin = true, FirstName = "admin", LastName = "admin" };
            Group group = new Group() { GroupName = "Administrators" };
            context.Users.Add(admin);
            group.Users.Add(admin);
                context.SaveChanges();
            }
        }
    
}
