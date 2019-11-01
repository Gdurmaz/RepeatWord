using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Words
    {
        public int ID { get; set; }
        public string Word { get; set; }
        public int Counter { get; set; }
        public static int IDCounter { get; set; }
        static Words()
        {
            IDCounter = 10;
        }
        public Words()
        {
            ID = IDCounter;
            IDCounter++;
        }
    }
}
