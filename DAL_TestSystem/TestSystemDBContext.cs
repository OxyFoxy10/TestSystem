using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TestSystem
{
   
        public class TestSystemDBContext : DbContext
        {
            public TestSystemDBContext(string conStr) : base(conStr)
            {
                Database.SetInitializer<TestSystemDBContext>(new TestSystemContextInitializer());
            }
            public DbSet<User> Users { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<TestGroup> TestGroups { get; set; }
            public DbSet<Test> Tests { get; set; }
            public DbSet<Question> Questions { get; set; }
            public DbSet<Answer> Answers { get; set; }
            public DbSet<Result> Results { get; set; }
            public DbSet<UserAnswer> UserAnswers { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            //modelBuilder.Entity<Question>().HasMany(x => x.Answers).WithRequired(x => x.GetQuestion).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Test>().HasMany(x => x.Questions).WithRequired(x => x.GetTest).WillCascadeOnDelete(true);
            //modelBuilder.Entity<User>().HasMany(x => x.Results).WithRequired(x => x.GetUser).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Group>().HasMany(x => x.TestGroups).WithRequired(x => x.GetGroups).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Test>().HasMany(x => x.Results).WithRequired(x => x.GetTest).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Test>().HasMany(x => x.TestGroups).WithRequired(x => x.GetTests).WillCascadeOnDelete(true); modelBuilder.Entity<Question>().HasMany(x => x.Answers).WithRequired(x => x.GetQuestion).WillCascadeOnDelete(true);
            modelBuilder.Entity<Test>().HasMany(x => x.Results);
            modelBuilder.Entity<Test>().HasMany(x => x.TestGroups);
            modelBuilder.Entity<Test>().HasMany(x => x.Questions);
            modelBuilder.Entity<Question>().HasMany(x => x.Answers);
            modelBuilder.Entity<Answer>().HasMany(x => x.UserAnswers);
            modelBuilder.Entity<User>().HasMany(x => x.Results);
            modelBuilder.Entity<User>().HasMany(x => x.Groups);
            modelBuilder.Entity<User>().HasMany(x => x.UserAnswers);
            modelBuilder.Entity<Group>().HasMany(x => x.TestGroups);
            modelBuilder.Entity<Group>().HasMany(x => x.Users);
          //  modelBuilder.Ignore<Result>();
        }
        }    
}
