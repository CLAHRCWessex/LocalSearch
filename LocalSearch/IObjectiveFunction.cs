using System;
namespace LocalSearch
{
    public interface IObjectiveFunction
    {
        double Value(System.Collections.Generic.List<int> solution);
               
    }
}
