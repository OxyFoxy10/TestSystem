using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL_TestSystem
{
    public class Answer
    {
        public int Id { get; set; }
        [Required, MaxLength(50), MinLength(2)]      
        public string Description { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
        public virtual Question GetQuestion { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public Answer()
        {
            UserAnswers = new List<UserAnswer>();
        }
        public override string ToString()
        {
            return $"id {Id}, group {Description}";
        }
    }
}