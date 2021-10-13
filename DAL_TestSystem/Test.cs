using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL_TestSystem
{
    public class Test
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string TestName { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Author { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<TestGroup> TestGroups { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public Test()
        {
            Results = new List<Result>();
            TestGroups = new List<TestGroup>();
            Questions = new List<Question>();
        }

        public override string ToString()
        {
            return $"Test {TestName}";
        }
    }
    
}