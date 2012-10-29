using System;
namespace LocalSearch
{
    /// <summary>
    /// Defines a contract for swapping the order of cities within a tour
    /// </summary>
    public interface ICitySwapPattern
    {
        void Swap(int firstCity, int secondCity);
    }
}
