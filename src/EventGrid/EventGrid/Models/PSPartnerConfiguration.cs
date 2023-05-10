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

using Microsoft.Azure.Commands.EventGrid.Utilities;
using Microsoft.Azure.Management.EventGrid.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.EventGrid.Models
{
    public class PSPartnerConfiguration
    {
        public PSPartnerConfiguration(PartnerConfiguration partnerConfiguration)
        {
            this.ResourceGroupName = EventGridUtils.ParseResourceGroupFromId(partnerConfiguration.Id);
            this.Id = partnerConfiguration.Id;
            this.PartnerAuthorization = partnerConfiguration.PartnerAuthorization;
            this.ProvisioningState = partnerConfiguration.ProvisioningState;
            this.SystemData = partnerConfiguration.SystemData;
            this.Location = partnerConfiguration.Location;
            this.Tags = partnerConfiguration.Tags;
        }

        public string ResourceGroupName { get; set; }

        public string Id { get; set; }

        public PartnerAuthorization PartnerAuthorization { get; set; }

        public string ProvisioningState { get; set; }

        public SystemData SystemData { get; private set; }

        public string Location { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Return a string representation of this partner configuration
        /// </summary>
        /// <returns>null</returns>
        public override string ToString()
        {
            return null;
        }
    }
}
