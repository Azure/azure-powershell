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
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WindowsAzure.Commands.Common.Attributes;

    public class PSApplicationGatewayBackendHttpSettings : PSChildResource
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public int Port { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Protocol { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string CookieBasedAffinity { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public int RequestTimeout { get; set; }
        public PSApplicationGatewayConnectionDraining ConnectionDraining { get; set; }
        public PSResourceId Probe { get; set; }
        public List<PSResourceId> AuthenticationCertificates { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string HostName { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public bool? PickHostNameFromBackendAddress { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string AffinityCookieName { get; set; }
        [Obsolete("Property 'ProbeEnabled' is ignored and will be removed from the 'PSApplicationGatewayBackendHttpSettings' type in a future release.")]
        [Ps1Xml(Target = ViewControl.Table)]
        public bool ProbeEnabled { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string Path { get; set; }
        [Ps1Xml(Target = ViewControl.Table)]
        public string ProvisioningState { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public string ConnectionDrainingText
        {
            get { return JsonConvert.SerializeObject(ConnectionDraining, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ProbeText
        {
            get { return JsonConvert.SerializeObject(Probe, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string AuthenticationCertificatesText
        {
            get { return JsonConvert.SerializeObject(AuthenticationCertificates, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializePort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeRequestTimeout()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeAuthenticationCertificates()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
