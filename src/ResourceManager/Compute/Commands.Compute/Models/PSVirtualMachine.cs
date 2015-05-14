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

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachine
    {
        // Gets or sets the property of 'Id'
        public string Id { get; set; }

        // Gets or sets the property of 'Name'
        public string Name { get; set; }

        // Gets or sets the property of 'Type'
        public string Type { get; set; }

        // Gets or sets the property of 'Location'
        public string Location { get; set; }

        // Gets or sets the property of 'Tags'
        public IDictionary<string,string> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(Tags, Formatting.Indented); }
        }

        // Gets or sets the property of 'AvailabilitySetReference'
        public AvailabilitySetReference AvailabilitySetReference { get; set; }

        [JsonIgnore]
        public string AvailabilitySetReferenceText
        {
            get { return JsonConvert.SerializeObject(AvailabilitySetReference, Formatting.Indented); }
        }

        // Gets or sets the property of 'Extensions'
        public IList<VirtualMachineExtension> Extensions { get; set; }

        [JsonIgnore]
        public string ExtensionsText
        {
            get { return JsonConvert.SerializeObject(Extensions, Formatting.Indented); }
        }

        // Gets or sets the property of 'HardwareProfile'
        public HardwareProfile HardwareProfile { get; set; }

        [JsonIgnore]
        public string HardwareProfileText
        {
            get { return JsonConvert.SerializeObject(HardwareProfile, Formatting.Indented); }
        }

        // Gets or sets the property of 'InstanceView'
        public VirtualMachineInstanceView InstanceView { get; set; }

        [JsonIgnore]
        public string InstanceViewText
        {
            get { return JsonConvert.SerializeObject(InstanceView, Formatting.Indented); }
        }

        // Gets or sets the property of 'NetworkProfile'
        public NetworkProfile NetworkProfile { get; set; }

        [JsonIgnore]
        public string NetworkProfileText
        {
            get { return JsonConvert.SerializeObject(NetworkProfile, Formatting.Indented); }
        }

        // Gets or sets the property of 'OSProfile'
        public OSProfile OSProfile { get; set; }

        [JsonIgnore]
        public string OSProfileText
        {
            get { return JsonConvert.SerializeObject(OSProfile, Formatting.Indented); }
        }

        // Gets or sets the property of 'Plan'
        public Plan Plan { get; set; }

        [JsonIgnore]
        public string PlanText
        {
            get { return JsonConvert.SerializeObject(Plan, Formatting.Indented); }
        }

        // Gets or sets the property of 'ProvisioningState'
        public string ProvisioningState { get; set; }

        // Gets or sets the property of 'StorageProfile'
        public StorageProfile StorageProfile { get; set; }

        [JsonIgnore]
        public string StorageProfileText
        {
            get { return JsonConvert.SerializeObject(StorageProfile, Formatting.Indented); }
        }
    }
}
