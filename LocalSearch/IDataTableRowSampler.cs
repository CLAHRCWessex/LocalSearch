using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LocalSearch
{
    public interface IDataTableRowSampler
    {
        DataTable SampleWithReplacement(int sampleSize);
        DataTable SampleWithoutReplacement(int sampleSize);
        void SetSamplePool(DataTable data);
    }
}
