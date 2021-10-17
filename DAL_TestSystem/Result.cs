using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TestSystem
{
    public class Result
    {
        [NotMapped]
        private int mark = 0;
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public int? Mark { get { return mark; } set { mark =CalculateResult(); } }
        public virtual User GetUser { get; set; }
        public virtual Test GetTest { get; set; }      
        public override string ToString()
        {
            return $"{Mark}%";
        }

        private int CalculateResult()
        {
            int qcount = GetTest.Questions.Count;
            int maxMark = 0;
            int correctMark = 0;
            foreach (var item in GetTest.Questions)
            {
               // if(testid==GetTest.Id)
                maxMark += item.Difficulty;
            }
            
            foreach (var item in GetUser.UserAnswers)
            {
               // if(userid==GetUser.Id)
                if(item.GetAnswers.IsCorrect==true)
                {
                    if(item.IsAnsweredCorectly==true)
                    correctMark += item.GetAnswers.GetQuestion.Difficulty;
                }
            }
            if (maxMark != 0)
            {
                mark = correctMark * 100 / maxMark;
                return mark;
            }
            else return 0;
        }
    }
}