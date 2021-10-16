using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TestSystem
{
    public class Result
    {        
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public int? Mark { get; set; }
        public virtual User GetUser { get; set; }
        public virtual Test GetTest { get; set; }      
        public override string ToString()
        {
            return $"{Mark}%";
        }

        private void CalculateResult()
        {
            int qcount = GetTest.Questions.Count;
            int maxMark = 0;
            int correctMark = 0;
            foreach (var item in GetTest.Questions)
            {
                maxMark += item.Difficulty;
            }
            foreach (var item in GetUser.UserAnswers)
            {
                if(item.GetAnswers.IsCorrect==true)
                {
                    correctMark += item.GetAnswers.GetQuestion.Difficulty;
                }
            }
            Mark = correctMark * 100 / maxMark;
        }
    }
}