using System;
using System.Collections.Generic;

namespace DAL_TestSystem
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public DateTime UserAnswerDate { get; set; }
        public virtual User GetUserss { get; set; }
        public virtual Answer GetAnswers { get; set; }
        public bool IsAnsweredCorectly { get; set; }
    }
}