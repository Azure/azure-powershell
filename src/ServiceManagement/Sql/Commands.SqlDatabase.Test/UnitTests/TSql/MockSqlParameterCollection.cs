// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    /// <summary>
    /// Represents a collection of parameters for the sql statement
    /// </summary>
    internal class MockSqlParameterCollection : DbParameterCollection
    {
        /// <summary>
        /// Internal storage of parameters
        /// </summary>
        private List<MockSqlParameter> internalCollection = new List<MockSqlParameter>();

        /// <summary>
        /// Adds a parameter to the list. Must be of type MockSqlParameterd
        /// </summary>
        /// <param name="value">The parameter value</param>
        /// <returns>The number of parameters in the collection</returns>
        public override int Add(object value)
        {
            this.internalCollection.Add((MockSqlParameter)value);
            return (this.internalCollection.Count - 1);
        }

        /// <summary>
        /// Adds a range of values.  Must be of type MockSqlParameter
        /// </summary>
        /// <param name="values">An array of parameter values</param>
        public override void AddRange(Array values)
        {
            foreach (MockSqlParameter parameter in values)
            {
                this.internalCollection.Add(parameter);
            }
        }

        /// <summary>
        /// Clears the collection of all parameters
        /// </summary>
        public override void Clear()
        {
            this.internalCollection.Clear();
        }

        /// <summary>
        /// Checks to see if a value exists in the collection
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>True if the value exists in the collection</returns>
        public override bool Contains(string value)
        {
            return (-1 != this.IndexOf(value));
        }

        /// <summary>
        /// Checks to see if a value exists in the collection
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>True if the value exists in the collection</returns>
        public override bool Contains(object value)
        {
            return (-1 != this.IndexOf(value));
        }

        /// <summary>
        /// Copies the contents of array to the internal parameter collection.
        /// </summary>
        /// <param name="array">The parameters to copy</param>
        /// <param name="index">Where to insert the array in the internal collection</param>
        public override void CopyTo(Array array, int index)
        {
            this.internalCollection.CopyTo((MockSqlParameter[])array, index);
        }

        /// <summary>
        /// Gets how many parameters are in the collection
        /// </summary>
        public override int Count
        {
            get { return this.internalCollection.Count(); }
        }

        /// <summary>
        /// Gets an enumerator over the parameter collection
        /// </summary>
        /// <returns></returns>
        public override System.Collections.IEnumerator GetEnumerator()
        {
            return this.internalCollection.GetEnumerator();
        }

        /// <summary>
        /// Get a parameter by name
        /// </summary>
        /// <param name="parameterName">The name of the parameter to retrieve</param>
        /// <returns>The parameter object or IndexOutOfRangeException</returns>
        protected override DbParameter GetParameter(string parameterName)
        {
            int index = this.IndexOf(parameterName);
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return this.internalCollection[index];
        }

        /// <summary>
        /// Gets the parameter by index
        /// </summary>
        /// <param name="index">The index of the parameter to retrieve</param>
        /// <returns>The parameter object</returns>
        protected override DbParameter GetParameter(int index)
        {
            return this.internalCollection[index];
        }

        /// <summary>
        /// Gets the index of a parameter
        /// </summary>
        /// <param name="parameterName">The name of the parameter</param>
        /// <returns>The index of the parameter with the given name</returns>
        public override int IndexOf(string parameterName)
        {
            for (int i = 0; i < this.internalCollection.Count; ++i)
            {
                if (parameterName == this.internalCollection[i].ParameterName)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Gets the index of the parameter
        /// </summary>
        /// <param name="value">The parameter to find the index of</param>
        /// <returns>The index of the parameter</returns>
        public override int IndexOf(object value)
        {
            return this.internalCollection.IndexOf((MockSqlParameter)value);
        }

        /// <summary>
        /// Adds a parameter at a given location
        /// </summary>
        /// <param name="index">Where to insert the parameter</param>
        /// <param name="value">The parameter to insert</param>
        public override void Insert(int index, object value)
        {
            this.internalCollection.Insert(index, (MockSqlParameter)value);
        }

        /// <summary>
        /// Gets whether or not the parameter collection is of fixed size
        /// </summary>
        public override bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether the parameter collection is fixed size or not
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets whether or not the parameter collection is synchronized
        /// </summary>
        public override bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Removes a parameter from the collection
        /// </summary>
        /// <param name="value">The parameter to remove</param>
        public override void Remove(object value)
        {
            int index = this.IndexOf(value);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            RemoveAt(index);
        }

        /// <summary>
        /// Remote a parameter with given name
        /// </summary>
        /// <param name="parameterName">The name of the parameter to remove</param>
        public override void RemoveAt(string parameterName)
        {
            int index = this.IndexOf(parameterName);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            RemoveAt(index);
        }

        /// <summary>
        /// Remove a parameter at given index
        /// </summary>
        /// <param name="index">The index of the parameter to remove</param>
        public override void RemoveAt(int index)
        {
            this.internalCollection.RemoveAt(index);
        }

        /// <summary>
        /// Change the value of a parameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter to change</param>
        /// <param name="value">The new value</param>
        protected override void SetParameter(string parameterName, DbParameter value)
        {
            int index = this.IndexOf(parameterName);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.internalCollection[index].Value = value;
        }

        /// <summary>
        /// Change the value of a parameter
        /// </summary>
        /// <param name="index">The index of the parameter to change</param>
        /// <param name="value">The new value of the parameter</param>
        protected override void SetParameter(int index, DbParameter value)
        {
            this.internalCollection[index].Value = value;
        }

        /// <summary>
        /// Object for syncronization
        /// </summary>
        public override object SyncRoot
        {
            get { return null; }
        }
    }
}
