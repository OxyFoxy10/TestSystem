using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TestSystem
{
    public class TestGroup
    {
        public int Id { get; set; }
        public DateTime TestDate { get; set; }
        public virtual Group GetGroups { get; set; }
        public virtual Test GetTests { get; set; }
        public override string ToString()
        {
            return $"{GetTests}";
        }
    }
}
