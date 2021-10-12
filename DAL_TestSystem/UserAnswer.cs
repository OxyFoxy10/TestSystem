using System;
using System.Collections.Generic;

namespace DAL_TestSystem
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public DateTime UserAnswerDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public UserAnswer()
        {
            Users = new List<User>();
            Answers = new List<Answer>();
        }
    }
}