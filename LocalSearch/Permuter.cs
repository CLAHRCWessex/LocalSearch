using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    public class Permuter<T>
    {
        protected List<T> points;
        protected List<List<T>> permutations;

        public Permuter(List<T> points)
        {
            this.points = points;
            this.permutations = new List<List<T>>();
        }

        public void AllPermutations()
        {
            
            Execute(points, 0, points.Count - 1);

        }

        private void Execute(List<T> currentList, int currentPoint, int totalPoints)
        {

            if (currentPoint == totalPoints)
            {
                permutations.Add(currentList);
            }
            else
            {
                for (int i = currentPoint; i <= totalPoints; i++)
                {
                    var newList = new List<T>();
                    currentList.ForEach(x => newList.Add(x));
                    Swap(currentPoint + 1, i);
                    Execute(newList, currentPoint, totalPoints);
                    Swap(currentPoint, i);
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = this.points[index1];
            this.points[index1] = this.points[index2];
            this.points[index2] = temp;
        }


    }
}
