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

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.WebClient
{
    internal class HttpQueryParameters
    {
        private Dictionary<string, string> queryParams;

        internal HttpQueryParameters()
        {
            queryParams = new Dictionary<string, string>();
        }

        internal void Add(string name, string value)
        {
            if (queryParams.ContainsKey(name))
            {
                queryParams[name] = value;
            }
            else
            {
                queryParams.Add(name, value);
            }
        }

        //TODO: Use StringBuilder
        public override string ToString()
        {
            string queryString = String.Empty;

            if (this.queryParams != null && this.queryParams.Count != 0)
            {
                foreach (var query in this.queryParams)
                {
                    string currentQuery = query.Key + "=" + query.Value;

                    if (queryString == String.Empty)
                    {
                        queryString = currentQuery;
                    }
                    else
                    {
                        queryString += "&" + currentQuery;
                    }
                }
            }

            return queryString;
        }


    }
}
