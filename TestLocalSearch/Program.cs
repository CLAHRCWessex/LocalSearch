using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalSearch;

namespace TestLocalSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            var permute = new Permuter<string>(new List<string>(){"a", "b", "c", "d"});

            var results = permute.AllPermutations();

            foreach (var list in results)
            {
                foreach (var x in list)
                {
                    Console.Write(x.ToString());
                }
                Console.WriteLine();
            }

            var permute2 = new Permuter<int>(new List<int>(){1, 2, 3, 4, 5, 6});
            var results2 = permute2.AllPermutations();

            foreach (var list in results2)
            {
                foreach (var x in list)
                {
                    Console.Write(x.ToString());
                }
                Console.WriteLine();
            }


            Console.ReadKey();

        }

    }
}
