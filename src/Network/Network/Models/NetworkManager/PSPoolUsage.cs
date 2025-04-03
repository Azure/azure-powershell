//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//


namespace Microsoft.Azure.Commands.Network.Models.NetworkManager
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSPoolUsage
    {
        List<PSResourceBasics> ChildPools { get; set; }

        public List<string> AddressPrefixes { get; set; }

        public List<string> AllocatedAddressPrefixes { get; set; }

        public List<string> ReservedAddressPrefixes { get; set; }

        public List<string> AvailableAddressPrefixes { get; set; }

        public string TotalNumberOfIPAddresses { get; set; }

        public string NumberOfAllocatedIPAddresses { get; set; }

        public string NumberOfReservedIPAddresses { get; set; }

        public string NumberOfAvailableIPAddresses { get; set; }

        [JsonIgnore]
        public string AddressPrefixesText
        {
            get { return JsonConvert.SerializeObject(AddressPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AllocatedAddressPrefixesText
        {
            get { return JsonConvert.SerializeObject(AllocatedAddressPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ReservedAddressPrefixesText
        {
            get { return JsonConvert.SerializeObject(ReservedAddressPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AvailableAddressPrefixesText
        {
            get { return JsonConvert.SerializeObject(AvailableAddressPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
