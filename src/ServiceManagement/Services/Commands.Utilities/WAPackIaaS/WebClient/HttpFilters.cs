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
using System.Text;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal enum WebFilterOptions
    {
        eq = 0,
        ne = 1,
        lt = 2,
        gt = 3,
        le = 4,
        ge = 5
    };


    internal class HttpFilters
    {
        private List<Tuple<string, WebFilterOptions, string>> filters;

        internal HttpFilters()
        {
            filters = new List<Tuple<string, WebFilterOptions, string>>();
        }

        internal void Add(string filterName, WebFilterOptions filterOption, string filterValue)
        {
            var tuple = new Tuple<string, WebFilterOptions, string>(filterName, filterOption, filterValue);

            filters.Add(tuple);
        }

        public override string ToString()
        {
            var filterString = new StringBuilder();

            foreach (var filter in this.filters)
            {
                String appendFormat;

                Guid guid;
                int intValue;

                if (Guid.TryParse(filter.Item3, out guid))
                    appendFormat = "{0} {1} guid'{2}'";
                else if (int.TryParse(filter.Item3, out intValue))
                    appendFormat = "{0} {1} {2}";
                else
                    appendFormat = "{0} {1} '{2}'";

                if (filterString.Length == 0)
                    filterString.Append("$filter=");
                else
                    filterString.Append(" and ");

                filterString.AppendFormat(appendFormat, filter.Item1, filter.Item2.ToString(), filter.Item3);
            }

            return filterString.ToString();
        }
    }
}
