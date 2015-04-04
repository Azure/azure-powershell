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

namespace Microsoft.Azure.Commands.NetworkResourceProvider.Models
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class PSNetworkSecurityGroup : PSTopLevelResource
     {
         public List<PSSecurityRule> SecurityRules { get; set; }

         public List<PSSecurityRule> DefaultSecurityRules { get; set; }

         public List<PSResourceId> NetworkInterfaces { get; set; }

         public List<PSResourceId> Subnets { get; set; }

         public string ProvisioningState { get; set; }

         [JsonIgnore]
         public string SecurityRulesText
         {
             get { return JsonConvert.SerializeObject(SecurityRules, Formatting.Indented); }
         }

         [JsonIgnore]
         public string DefaultSecurityRulesText
         {
             get { return JsonConvert.SerializeObject(DefaultSecurityRules, Formatting.Indented); }
         }

         [JsonIgnore]
         public string NetworkInterfacesText
         {
             get { return JsonConvert.SerializeObject(NetworkInterfaces, Formatting.Indented); }
         }

         [JsonIgnore]
         public string SubnetsText
         {
             get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented); }
         }
     }
}
