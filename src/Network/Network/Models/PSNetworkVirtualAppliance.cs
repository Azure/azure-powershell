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
    using Microsoft.Azure.Management.Internal.Network.Common;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;
    using Microsoft.Azure.Management.Network.Models;
    public class PSNetworkVirtualAppliance : PSTopLevelResource
    {
        
        public IList<string> BootStrapConfigurationBlobs { get; set; }
        
        public PSResourceId VirtualHub { get; set; }
        
        public IList<string> CloudInitConfigurationBlobs { get; set; }
        
        public string CloudInitConfiguration { get; set; }
        
        public long? VirtualApplianceAsn { get; set; }
        
        public IList<PSVirtualApplianceNicProperties> VirtualApplianceNics { get; set; }

        public IList<PSResourceId> VirtualApplianceConnections { get; set; }

        public IList<PSResourceId> VirtualApplianceSites { get; set; }

        public string ProvisioningState { get; set; }
        
        public PSManagedServiceIdentity Identity { get; set; }
        
        public PSVirtualApplianceSkuProperties NvaSku { get; set; }

        public IList<PSVirtualApplianceAdditionalNicProperties> AdditionalNics { get; set; }

        public PSNetworkVirtualApplianceDelegationProperties Delegation { get; set; }

        public IList<PSVirtualApplianceInternetIngressIpsProperties> InternetIngressPublicIps { get; set; }

        public PSVirtualApplianceNetworkProfile NetworkProfile { get; set; }
    }
}
