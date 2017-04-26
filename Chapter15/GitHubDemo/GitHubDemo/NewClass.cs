using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubDemo
{
    class NewClass
    {
        public int CountDown(int factor)
        {
            int second = DateTime.Now.Second;
            return second * factor;
        }
    }
}
