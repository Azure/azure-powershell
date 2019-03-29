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
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LocationMap
    {
        public string AzureRegion { get; set; }

        public string EdgeSite { get; set; }

        private Dictionary<string, string> LocationDictionary { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMap"/> class. 
        /// Constructor
        /// </summary>
        public LocationMap()
        {
            this.LocationDictionary.Add(this.EdgeSite, this.AzureRegion);
        }

    }
}
