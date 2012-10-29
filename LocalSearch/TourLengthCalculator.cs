using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LocalSearch
{

    /// <summary>
    /// Represents the length of a tour around multiple cities.
    /// </summary>
    public class SimpleTourLengthCalculator : IObjectiveFunction
    {
        protected DataTable distanceMatrix;

        public SimpleTourLengthCalculator(DataTable distanceMatrix)
        {
            this.distanceMatrix = distanceMatrix;
        }


        /// <summary>
        /// Calculate the tour length.  Assumes that tour is a loop.
        /// </summary>
        /// <param name="solution">A single tour of cities leading back to the start.</param>
        /// <returns></returns>
        public double Value(List<int> solution)
        {
            double length = 0;

            for (int city = 1; city < solution.Count; city++)
            {
                try
                {
                    length += Convert.ToDouble(this.distanceMatrix.Rows[solution[city - 1]][solution[city]]);
                }
                catch(InvalidCastException)
                {
                    throw new InvalidCastException("Error calculating tour length.  The distance matrix contains a non-numeric value");
                }
                
            }

            return length;
        }


    }
}
