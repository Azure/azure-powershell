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

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayRedirectConfiguration : PSChildResource
    {
        public string RedirectType { get; set; }
        public PSResourceId TargetListener { get; set; }
        public string TargetUrl { get; set; }
        public bool? IncludePath { get; set; }
        public bool? IncludeQueryString { get; set; }
        public List<PSResourceId> RequestRoutingRules { get; set; }
        public List<PSResourceId> UrlPathMaps { get; set; }
        public List<PSResourceId> PathRules { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public string TargetListenerText
        {
            get { return JsonConvert.SerializeObject(TargetListener, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RequestRoutingRulesText
        {
            get { return JsonConvert.SerializeObject(RequestRoutingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string UrlPathMapsText
        {
            get { return JsonConvert.SerializeObject(UrlPathMaps, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PathRulesText
        {
            get { return JsonConvert.SerializeObject(PathRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}