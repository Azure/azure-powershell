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

using Microsoft.Azure.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSQueryResponse
    {
        // Private constructor so no one else can make one
        private PSQueryResponse() {}

        internal static PSQueryResponse Create(QueryResults response)
        {
            var psResponse = new PSQueryResponse()
            {
                Results = GetResultEnumerable(response.Results),
                Render = response.Render,
                Statistics = response.Statistics,
            };

            return psResponse;
        }

        public IEnumerable<PSObject> Results { get; protected set; }
        public IDictionary<string, string> Render { get; protected set; }
        public IDictionary<string, object> Statistics { get; protected set; }

        private static IEnumerable<PSObject> GetResultEnumerable(IEnumerable<IDictionary<string, string>> rows)
        {
            foreach (var row in rows)
            {
                var psObject = new PSObject();
                foreach (var cell in row)
                {
                    psObject.Properties.Add(new PSNoteProperty(cell.Key, cell.Value));
                }
                yield return psObject;
            }
        }
    }
}
