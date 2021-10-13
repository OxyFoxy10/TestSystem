using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL_TestSystem
{
    public class Group
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string GroupName { get; set; }     
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<TestGroup> TestGroups { get; set; }
        public Group()
        {
            Users = new List<User>();
            TestGroups = new List<TestGroup>();
        }

        public override string ToString()
        {
            return $"{GroupName}";
        }
    }
}