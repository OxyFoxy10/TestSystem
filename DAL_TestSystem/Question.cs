using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TestSystem
{
   public class Question
    {
        public int Id { get; set; }      
        public int? Number { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Description { get; set; }       
        public int? Difficulty { get; set; }
        public virtual Test GetTest { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
        public override string ToString()
        {
            return $"id {Id}, group {Description}";
        }

    }
}
