using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    /// <summary>
    /// Enumerates all permutations of the the list passed in.  Typically this is a list of integers of strings.
    /// </summary>
    /// <typeparam name="T">The type of data to be enumerated</typeparam>
    public class Permuter<T>
    {
        protected List<T> points;
        protected List<List<T>> permutations;

        public Permuter(List<T> points)
        {
            this.points = points;
            this.permutations = new List<List<T>>();
        }

        /// <summary>
        /// Calculate all permulations of the data 
        /// </summary>
        /// <returns>A list of all permutations of the points</returns>
        public List<List<T>> AllPermutations()
        {
            
            Execute(points, 0, points.Count - 1);

            return this.permutations;

        }

        private void Execute(List<T> currentList, int currentPoint, int totalPoints)
        {

            if (currentPoint == totalPoints)
            {
                var newList = new List<T>();
                this.points.ForEach(x => newList.Add(x));
                permutations.Add(newList);
            }
            else
            {
                for (int i = currentPoint; i <= totalPoints; i++)
                {
                    Swap(ref this.points, currentPoint, i);
                    Execute(this.points, currentPoint + 1, totalPoints);
                    Swap(ref this.points, currentPoint, i);
                    
                }
            }
        }

        private void Swap(ref List<T> currentList, int index1, int index2)
        {
            if (index1 == index2) return;

            T temp = currentList[index1];
            currentList[index1] = currentList[index2];
            currentList[index2] = temp;
            
        }

 


    }
}
