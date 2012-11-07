using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    public class BruteForceSearch : ILocalSearchMethod 
    {
        protected List<int> solution;
        protected IObjectiveFunction objective;
        

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
        public BruteForceSearch(IObjectiveFunction objective, List<int> initialSolution)
        {
            this.objective = objective;
            this.solution = initialSolution;
            this.currentTourLength = objective.Value(initialSolution);
        }


        /// <summary>
        /// Enumerates all solutions.  WARNING: if there are n numbers then
        /// there are n! permutations.  This number gets large very quickly.
        /// Assumes the first and last points in the array are fixed.
        /// </summary>
        public void Solve()
        {
            var initSolution = new List<int>();

            for (int i = 1; i <= solution.Count - 2; i++)
            {
                initSolution.Add(solution[i]);
            }

            var permute = new Permuter<int>(initSolution);
            var results = permute.AllPermutations();

            double bestSolutionCost = objective.Value(solution);
            var bestSolution = solution;

            foreach (var permutation in results)
            {
                permutation.Insert(0, 1);
                permutation.Add(1);

                var cost = this.objective.Value(permutation);

                if (cost < bestSolutionCost)
                {
                    bestSolutionCost = cost;
                    bestSolution = permutation;
                }
            }
        }
    }
}
