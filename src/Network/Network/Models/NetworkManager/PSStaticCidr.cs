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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Internal.Resources.Utilities;
    using Newtonsoft.Json;
    using System.Collections;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSStaticCidr : PSResourceId
    {
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 3)]
        public string Name { get; set; }

        [Ps1Xml(Label = "PoolName", Target = ViewControl.Table, Position = 2)]
        public string PoolName { get; set; }

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table, Position = 0)]
        public string ResourceGroupName { get; set; }

        [Ps1Xml(Label = "NetworkManagerName", Target = ViewControl.Table, Position = 1)]
        public string NetworkManagerName { get; set; }
        public PSStaticCidrProperties Properties { get; set; }

        public string Type { get; set; }

        public PSSystemData SystemData { get;  set; }

        [JsonIgnore]
        public string SystemDataText
        {
            get { return JsonConvert.SerializeObject(SystemData, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}