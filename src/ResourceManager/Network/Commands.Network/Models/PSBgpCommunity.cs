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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSBgpCommunity
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string ServiceSupportedRegion { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string CommunityName { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string CommunityValue { get; set; }

        public List<string> CommunityPrefixes { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool IsAuthorizedToUse { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string ServiceGroup { get; set; }

        [JsonIgnore]
        public string CommunityPrefixesText
        {
            get { return JsonConvert.SerializeObject(CommunityPrefixes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
