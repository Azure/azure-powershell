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

using Microsoft.Azure.Management.Search.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.Models
{
    public class PSAccessRule
    {
        [Ps1Xml(Label = "Access rule name", Target = ViewControl.List, Position = 0)]
        public string Name { get; private set; }

        [Ps1Xml(Label = "Access rule direction", Target = ViewControl.List, Position = 1)]
        public string Direction { get; private set; }

        [Ps1Xml(Label = "Access rule address prefixes", Target = ViewControl.List, Position = 2)]
        public IList<string> AddressPrefixes { get; private set; }

        [Ps1Xml(Label = "Access rule subscriptions", Target = ViewControl.List, Position = 3)]
        public IList<string> Subscriptions { get; private set; }

        [Ps1Xml(Label = "Access rule network security perimeters", Target = ViewControl.List, Position = 4)]
        public IList<PSNetworkSecurityPerimeter> NetworkSecurityPerimeters { get; private set; }

        [Ps1Xml(Label = "Access rule fully qualified domain names", Target = ViewControl.List, Position = 5)]
        public IList<string> FullyQualifiedDomainNames { get; private set; }

        [Ps1Xml(Label = "Access rule email addresses", Target = ViewControl.List, Position = 6)]
        public IList<string> EmailAddresses { get; private set; }

        [Ps1Xml(Label = "Access rule phone numbers", Target = ViewControl.List, Position = 7)]
        public IList<string> PhoneNumbers { get; private set; }

        public static explicit operator PSAccessRule(AccessRule v)
        {
            return new PSAccessRule()
            {
                Name = v.Name,
                Direction = v.Properties.Direction,
                AddressPrefixes = v.Properties.AddressPrefixes,
                Subscriptions = v.Properties.Subscriptions.Select(subscription => subscription.Id).ToList(),
                NetworkSecurityPerimeters = v.Properties.NetworkSecurityPerimeters.Select(perimeter => (PSNetworkSecurityPerimeter)perimeter).ToList(),
                FullyQualifiedDomainNames = v.Properties.FullyQualifiedDomainNames,
                EmailAddresses = v.Properties.EmailAddresses,
                PhoneNumbers = v.Properties.PhoneNumbers,
            };
        }
    }
}
