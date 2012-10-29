using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    public class TwoCitySwapPattern : ICitySwapPattern
    {
        protected List<int> solution;

        public TwoCitySwapPattern(List<int> initialSolution)
        {
            this.solution = initialSolution;
        }


        /// <summary>
        /// Swap the order of two cities
        /// </summary>
        /// <param name="firstCity">List index of 1st city</param>
        /// <param name="secondCity">List index of 2nd city</param>
        public void Swap(int firstCity, int secondCity)
        {
            int temp = this.solution[firstCity];
            this.solution[firstCity] = this.solution[secondCity];
            this.solution[secondCity] = temp;
        }
    }
}
