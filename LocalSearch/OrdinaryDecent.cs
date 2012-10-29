using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LocalSearch
{
    public class OrdinaryDecent : ILocalSearchMethod 
    {
        
        protected List<int> solution;
        protected IObjectiveFunction objective;
        protected ICitySwapPattern swapPattern;

        protected double currentTourLength;

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
        public OrdinaryDecent(IObjectiveFunction objective, List<int> initialSolution)
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
        public OrdinaryDecent(IObjectiveFunction objective, List<int> initialSolution, ICitySwapPattern swapMethod)
        {
            this.objective = objective;
            this.solution = initialSolution;
            this.currentTourLength = objective.Value(initialSolution);
            this.swapPattern = swapMethod;
        }


        /// <summary>
        /// Uses the nearest first improvement local search method to find a short tour.
        /// Assumes first and last points of tour are the same and fixed.
        /// Stopping criterion:  No improvement in objective found after a full iteration.
        /// </summary>
        public void Solve()
        {
            bool improvement;
                     
            do
            {
                improvement = false;
               
                for (int city = 1; city <= this.solution.Count - 2; city++)
                {
                    for (int secondCity = city + 1; secondCity <= this.solution.Count - 2; secondCity++)
                    {
                        this.swapPattern.Swap(city, secondCity);

                        double newValue = objective.Value(this.solution);

                        if (Improvement(newValue))
                        {
                            this.swapPattern.Swap(city, secondCity);
                        }
                        else
                        {
                            //exit loop
                            currentTourLength = newValue;
                            improvement = true;
                            secondCity = this.solution.Count;
                        }
                    }
                }

            } while (improvement == true);

            
        }

        private bool Improvement(double newValue)
        {
            return newValue >= currentTourLength;
        }

       

    }
}
