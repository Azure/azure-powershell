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

namespace Microsoft.Azure.Commands.Intune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;    
    using Rest.Azure;
    
    /// <summary>
    /// Class to make multiple calls for different types of resources in generic way
    /// </summary>
    /// <typeparam name="T">Resource type</typeparam>
    public class MultiPageGetter<T>: PSCmdlet
    {
        /// <summary>
        /// Gets all pages
        /// </summary>
        /// <param name="GetFirstPage">Method (with 4 input parameters) to get first pageful</param>
        /// <param name="GetNextPage">Method to get subsequent pagefuls</param>
        /// <param name="asuHostName">host name</param>
        /// <param name="filter">Rest API query filter </param>
        /// <returns>List of resources returned</returns>
        public List<T> GetAllResources(
            Func<string, string, int?, string, IPage<T>> GetFirstPage, 
            Func<string, IPage<T>> GetNextPage,
            string asuHostName,
            string filter = null,
            int? top = null,
            string select = null)
        {
            var resources = GetFirstPage(asuHostName, filter, top, select);

            return GetOtherPageResults(resources, GetNextPage);
        }

        /// <summary>
        /// Gets all pages
        /// </summary>
        /// <param name="GetFirstPage">Method (with 2 input parameters) to get first pageful</param>
        /// <param name="GetNextPage">Method to get subsequent pagefuls</param>
        /// <param name="asuHostName">host name</param>
        /// <param name="policyId">Rest API query filter </param>
        /// <returns>List of resources returned</returns>
        internal List<T> GetAllResources(Func<string, string, IPage<T>> GetFirstPage, 
            Func<string, IPage<T>> GetNextPage, 
            string asuHostName, 
            string policyId)
        {

            var resources = GetFirstPage(asuHostName, policyId);
            return GetOtherPageResults(resources, GetNextPage);
        }

        /// <summary>
        /// Gets all pages
        /// </summary>
        /// <param name="GetFirstPage">Method (with 5 input parameters) to get first pageful</param>
        /// <param name="GetNextPage">Method to get subsequent pagefuls</param>
        /// <param name="asuHostName">host name</param>
        /// <param name="policyId"> The policy Id</param>
        /// <param name="filter">Rest API query filter </param>
        /// <param name="top"> Restricting number of results.</param>
        /// <param name="select"> select fields query.</param>
        /// <returns>List of resources returned</returns>
        public List<T> GetAllResources(
            Func<string, string, string, int?, string, IPage<T>> GetFirstPage,
            Func<string, IPage<T>> GetNextPage,
            string asuHostName,
            string policyId,
            string filter = null,
            int? top = null,
            string select = null)
        {
            var resources = GetFirstPage(asuHostName, policyId, filter, top, select);
            return GetOtherPageResults(resources, GetNextPage);
        }
        
        /// <summary>
        /// Method used for getting other page results.
        /// </summary>
        /// <param name="resources">Result obtained from first page call</param>
        /// <param name="GetNextPage">Method to get next page in sequence</param>
        /// <returns>List of objects</returns>
        private List<T> GetOtherPageResults(IPage<T> resources, Func<string, IPage<T>> GetNextPage)
        {
            List<T> items = new List<T>();
            if (resources != null)
            {
                items.AddRange(resources.ToList());
                while (resources.NextPageLink != null)
                {
                    resources = GetNextPage(resources.NextPageLink);
                    items.AddRange(resources.ToList());
                }
            }
            return items;
        }
    }
}
