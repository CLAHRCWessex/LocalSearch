using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    public class SteepestDecent : ILocalSearchMethod 
    {
        protected List<int> solution;
        protected IObjectiveFunction objective;
        protected ICitySwapPattern swapPattern;

        protected double currentTourLength;

        protected int bestSwapIndex1;
        protected int bestSwapIndex2;
        protected double bestTourLength;

        /// <summary>
        /// Return the solution as a ordered list of cities
        /// </summary>
        public List<int> Solution { get { return this.solution; } }
        
        /// <summary>
        /// Return the length of the tour around the n cities 
        /// </summary>
        public double Cost { get { return this.currentTourLength; } }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="objective">A tour length objectiveulator object</param>
        /// <param name="initialSolution">An initial solution</param>
        public SteepestDecent(IObjectiveFunction objective, List<int> initialSolution)
        {
            this.objective = objective;
            this.solution = initialSolution;
            this.currentTourLength = objective.Value(initialSolution);
            this.swapPattern = new TwoCitySwapPattern(initialSolution);
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="objective">A tour length objectiveulator object</param>
        /// <param name="initialSolution">An initial solution</param>
        /// <param name="swapPattern">A method for swapping the order of cities</param>
        public SteepestDecent(IObjectiveFunction objective, List<int> initialSolution, ICitySwapPattern swapMethod)
        {
            this.objective = objective;
            this.solution = initialSolution;
            this.currentTourLength = objective.Value(initialSolution);
            this.swapPattern = swapMethod;
        }


        /// <summary>
        /// Uses the steepest decent local search method to find a short tour.
        /// Assumes first and last points of tour are the same and fixed.
        /// </summary>
        public void Solve()
        {

            bool improvement;
            int pass = 0;
                        
            do
            {
                improvement = false;
                pass++;

                for (int city = 1; city <= this.solution.Count - 2; city++)
                {
                    bestTourLength = currentTourLength;

                    for (int secondCity = city + 1; secondCity <= this.solution.Count - 2; secondCity++)
                    {
                        this.swapPattern.Swap(city, secondCity);

                        double length = objective.Value(this.solution);

                        if (Improvement(length))
                        {
                            //remember the best;
                            bestTourLength = length;
                            bestSwapIndex1 = city;
                            bestSwapIndex2 = secondCity;
                            improvement = true;
                        }

                        this.swapPattern.Swap(city, secondCity);

                    }

                    this.swapPattern.Swap(bestSwapIndex1, bestSwapIndex2);
                    this.currentTourLength = bestTourLength;
                    bestSwapIndex1 = 0;
                    bestSwapIndex2 = 0;
                }

            } while (improvement == true);

            
        }

        private bool Improvement(double length)
        {
            return length < bestTourLength;
        }
    }
}
