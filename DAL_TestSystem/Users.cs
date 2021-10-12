using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TestSystem
{
    public class User
    {    
        public int Id { get; set; }
        [Required, MaxLength(50),MinLength(2)]
        public string FirstName { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string LastName { get; set; }
        [Required, MaxLength(50), MinLength(2), Index(IsUnique=true)]
        public string Login { get; set; }
        [Required, MaxLength(50), MinLength(1)]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }     
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public User()
        {
            Groups = new List<Group>();
            UserAnswers = new List<UserAnswer>();
            Results = new List<Result>();
        }
        public override string ToString()
        {
            return $"id {Id}, user {Login}";
        }
    }
}
