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

    public class PSIpamPool : PSIpamPoolBaseResource
    {
        [Ps1Xml(Label = "Location", Target = ViewControl.Table, Position = 2)]
        public string Location { get; set; }

        public System.Collections.Generic.IDictionary<string, string> Tags { get; set; }

        public PSIpamPoolProperties Properties { get; set; }

        public string TagsTable
        {
            get { return ResourcesExtensions.ConstructTagsTable(TagsConversionHelper.CreateTagHashtable(Tags)); }
        }

        [JsonIgnore]
        public string PropertiesText
        {
            get { return JsonConvert.SerializeObject(Properties, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
