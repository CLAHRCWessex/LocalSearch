using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalSearch
{
    public interface ILocalSearchMethod
    {
        List<int> Solution { get; }
        double Cost { get; }
        void Solve();
    }
}
