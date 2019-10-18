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

namespace Microsoft.Azure.Commands.Network.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.Attributes;

    public class PSVirtualHubRoute
    {
        private string _destType; 

        private string _nextHopType; 

        [Ps1Xml(Label = "Address Prefixes", Target = ViewControl.Table)]
        public List<string> AddressPrefixes { 
            get { return this.Destinations; }
            set { this.Destinations = new List<string> (value); } 
        }

        [Ps1Xml(Label = "Next Hop IpAddress", Target = ViewControl.Table)]
        public string NextHopIpAddress {
            get { return this.NextHops.FirstOrDefault(); } 
            set { 
                if (this.NextHops == null)
                {
                    this.NextHops = new List<string>();
                }
                this.NextHops.Add(value); 
            } 
        }

        [Ps1Xml(Label = "Destination Type", Target = ViewControl.Table)]
        public string DestinationType {
            get { 
                return this._destType; 
            }
            set {
                this._destType = value ?? "CIDR";
            }
        }

        [Ps1Xml(Label = "Destinations", Target = ViewControl.Table)]
        public List<string> Destinations { get; set; }
        
        [Ps1Xml(Label = "Next Hop Type", Target = ViewControl.Table)]
        public string NextHopType
        {
            get
            {
                return this._nextHopType;
            }
            set
            {
                this._nextHopType = value ?? "IPAddress";
            }
        }

        [Ps1Xml(Label = "Next Hops", Target = ViewControl.Table)]
        public List<string> NextHops { get; set; }
    }
}