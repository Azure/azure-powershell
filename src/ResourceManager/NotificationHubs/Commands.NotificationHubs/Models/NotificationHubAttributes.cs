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

using Microsoft.Azure.Management.NotificationHubs.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NotificationHubs.Models
{

    public class NotificationHubAttributes
    {
        public NotificationHubAttributes(NotificationHubResource nhResource)
        {
            if (nhResource != null)
            {
                Id = nhResource.Id;
                Name = nhResource.Name;
                Type = nhResource.Type;
                Location = nhResource.Location;
                Tags = new Dictionary<string, string>(nhResource.Tags);
                AdmCredential = nhResource.Properties.AdmCredential;
                ApnsCredential = nhResource.Properties.ApnsCredential;
                AuthorizationRules = new List<SharedAccessAuthorizationRuleProperties>(nhResource.Properties.AuthorizationRules);
                BaiduCredential = nhResource.Properties.BaiduCredential;
                GcmCredential = nhResource.Properties.GcmCredential;
                MpnsCredential = nhResource.Properties.MpnsCredential;
                RegistrationTtl = nhResource.Properties.RegistrationTtl;
                WnsCredential = nhResource.Properties.WnsCredential;
            }
        }

        /// <summary>
        /// Gets or sets the Id of the Namespace
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Type of the Namespace
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the location the Namespace is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Namespace.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// The AdmCredential of the created NotificationHub
        /// </summary>
        public AdmCredential AdmCredential { get; set; }

        /// <summary>
        /// The ApnsCredential of the created NotificationHub
        /// </summary>
        public ApnsCredential ApnsCredential { get; set; }

        /// <summary>
        /// The AuthorizationRules of the created NotificationHub
        /// </summary>
        public IList<SharedAccessAuthorizationRuleProperties> AuthorizationRules { get; set; }

        /// <summary>
        /// The BaiduCredential of the created NotificationHub
        /// </summary>
        public BaiduCredential BaiduCredential { get; set; }

        /// <summary>
        /// The GcmCredential of the created NotificationHub
        /// </summary>
        public GcmCredential GcmCredential { get; set; }

        /// <summary>
        /// The MpnsCredential of the created NotificationHub
        /// </summary>
        public MpnsCredential MpnsCredential { get; set; }

        /// <summary>
        /// The NotificationHub name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The RegistrationTtl of the created NotificationHub
        /// </summary>
        public string RegistrationTtl { get; set; }

        /// <summary>
        /// The WnsCredential of the created NotificationHub
        /// </summary>
        public WnsCredential WnsCredential { get; set; }
    }
}
