using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCrawler
{
    class AddItems
    {
        public int AddGold(int _min, int _max, Random rnd)
        {
            if (rnd.Next(0,2) > 0)
            {
                return rnd.Next(_min, _max);
            } else
            {
                return 0;
            }

        }
    }
}
