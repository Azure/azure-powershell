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
        public AvailabilitySetReference AvailabilitySetReference { get; set; }

        [JsonIgnore]
        public string AvailabilitySetReferenceText
        {
            get { return JsonConvert.SerializeObject(AvailabilitySetReference, Formatting.Indented); }
        }

        public IList<VirtualMachineExtension> Extensions { get; set; }

        [JsonIgnore]
        public string ExtensionsText
        {
            get { return JsonConvert.SerializeObject(Extensions, Formatting.Indented); }
        }

        public HardwareProfile HardwareProfile { get; set; }

        [JsonIgnore]
        public string HardwareProfileText
        {
            get { return JsonConvert.SerializeObject(HardwareProfile, Formatting.Indented); }
        }

        public string Id { get; set; }

        public VirtualMachineInstanceView InstanceView { get; set; }

        [JsonIgnore]
        public string InstanceViewText
        {
            get { return JsonConvert.SerializeObject(InstanceView, Formatting.Indented); }
        }

        public string Location { get; set; }

        public string Name { get; set; }

        public NetworkProfile NetworkProfile { get; set; }

        [JsonIgnore]
        public string NetworkProfileText
        {
            get { return JsonConvert.SerializeObject(NetworkProfile, Formatting.Indented); }
        }

        public OSProfile OSProfile { get; set; }

        [JsonIgnore]
        public string OSProfileText
        {
            get { return JsonConvert.SerializeObject(OSProfile, Formatting.Indented); }
        }

        public Plan Plan { get; set; }

        [JsonIgnore]
        public string PlanText
        {
            get { return JsonConvert.SerializeObject(Plan, Formatting.Indented); }
        }

        public string ProvisioningState { get; set; }

        public StorageProfile StorageProfile { get; set; }

        [JsonIgnore]
        public string StorageProfileText
        {
            get { return JsonConvert.SerializeObject(StorageProfile, Formatting.Indented); }
        }

        public IDictionary<string, string> Tags { get; set; }

        [JsonIgnore]
        public string TagsText
        {
            get { return JsonConvert.SerializeObject(Tags, Formatting.Indented); }
        }

        public string Type { get; set; }
    }
}

