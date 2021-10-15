using System;

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
    }
}