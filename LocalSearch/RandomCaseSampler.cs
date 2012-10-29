using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace LocalSearch
{
    /// <summary>
    /// Encapsulates random sample functionality for a data rows 
    /// </summary>
    public class DataTableRandomRowSampler : IDataTableRowSampler
    {
        protected DataTable data;
        protected Random rnd;
        protected List<int> availableSamples;
       
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="seed">A random seed for reproducability of the results</param>
        public DataTableRandomRowSampler(int seed)
        {
            this.rnd = new Random(seed);

        }


        /// <summary>
        /// Overloaded Constructor method
        /// </summary>
        /// <param name="data">The datatable object</param>
        /// <param name="seed">A random seed for reproducability of the results</param>
        public DataTableRandomRowSampler(DataTable data, int seed)
        {
            this.data = data;
            this.rnd = new Random(seed);
            
        }


        
        /// <summary>
        /// Sample rows from the data table without replacement into the sample pool
        /// </summary>
        /// <param name="n">The number of rows to sample</param>
        /// <returns>A datatable of unique records</returns>
        public DataTable SampleWithoutReplacement(int n)
        {

            Validate();

            var results = data.Clone();
            availableSamples = Enumerable.Range(0, this.data.Rows.Count - 1).ToList<int>();

            for (int i = 0; i < n; i++)
            {
                int selection = this.rnd.Next(this.availableSamples.Count - 1);
                CloneRow(results, selection);
                this.availableSamples.RemoveAt(selection);
            }

            return results;

        }

        

        
        /// <summary>
        /// Sample from the datatable with replacement of rows after each sample
        /// </summary>
        /// <param name="n">The number of rows to sample</param>
        /// <returns>A datatable of sampled rows not guaranteed to be unique</returns>
        public DataTable SampleWithReplacement(int n)
        {

            Validate();

            var results = data.Clone();
            availableSamples = Enumerable.Range(0, this.data.Rows.Count - 1).ToList<int>();

            for (int i = 0; i < n; i++)
            {
                int selection = this.rnd.Next(this.availableSamples.Count - 1);
                CloneRow(results, selection);
            }

            return results;

        }


        private void Validate()
        {
            if (data == null)
            {
                throw new NullReferenceException("Sample pool (datatable of cases) needed before sampling can commence");
            }
        }


        /// <summary>
        /// Clone the data row
        /// </summary>
        /// <param name="newTable">Table to add the cloned row to</param>
        /// <param name="selection">The row selected</param>
        private void CloneRow(DataTable newTable, int selection)
        {
            DataRow newRow = newTable.NewRow();
            newRow.ItemArray = data.Rows[availableSamples[selection]].ItemArray;
            newTable.Rows.Add(newRow);
        }


        public void SetSamplePool(DataTable data)
        {
            this.data = data;
        }
    }
}
