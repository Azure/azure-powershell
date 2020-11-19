﻿//
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
    using Microsoft.WindowsAzure.Commands.Common.Attributes;
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class PSNetworkWatcherConnectionMonitorEndpointScope
    {
        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorEndpointScopeItem> Include { get; set; }

        [Ps1Xml(Target = ViewControl.List)]
        public List<PSNetworkWatcherConnectionMonitorEndpointScopeItem> Exclude { get; set; }

        [JsonIgnore]
        public string IncludeText
        {
            get { return JsonConvert.SerializeObject(this.Include, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ExcludeText
        {
            get { return JsonConvert.SerializeObject(this.Exclude, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}
