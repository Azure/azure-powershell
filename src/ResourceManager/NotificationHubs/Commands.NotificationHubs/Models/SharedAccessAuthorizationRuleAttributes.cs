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
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.NotificationHubs.Models
{

    public class SharedAccessAuthorizationRuleAttributes
    {
        public const string DefaultClaimType = "SharedAccessKey";
        public const string DefaultClaimValue = "None";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public SharedAccessAuthorizationRuleAttributes(SharedAccessAuthorizationRuleResource authRuleResource)
        {
            if (authRuleResource != null)
            {
                Id = authRuleResource.Id;
                Name = authRuleResource.Name;
                Type = authRuleResource.Type;
                Location = authRuleResource.Location;
                Tags = new Dictionary<string, string>(authRuleResource.Tags);
                PrimaryKey = authRuleResource.Properties.PrimaryKey;
                SecondaryKey = authRuleResource.Properties.SecondaryKey;
                ClaimType = authRuleResource.Properties.ClaimType;
                ClaimValue = authRuleResource.Properties.ClaimValue;
                CreatedTime = authRuleResource.Properties.CreatedTime;
                KeyName = authRuleResource.Properties.KeyName;
                ModifiedTime = authRuleResource.Properties.ModifiedTime;
                Revision = authRuleResource.Properties.Revision;
                Rights = authRuleResource.Properties.Rights.ToList();
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
        /// Gets or sets the name of the Namespace
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location the Namespace is in
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Namespace.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// The primary key that was used.
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// The secondary key that was used.
        /// </summary>
        public string SecondaryKey { get; set; }

        /// <summary>
        /// The type of the claim.
        /// </summary>
        public string ClaimType { get; set; }

        /// <summary>
        /// The value of the claim.
        /// </summary>
        public string ClaimValue { get; set; }

        /// <summary>
        /// The time at which the authorization rule was created.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The name of the key that was used.
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// The most recent time the rule was updated.
        /// </summary>
        public DateTime ModifiedTime { get; set; }

        /// <summary>
        /// The revision number for the rule.
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// The rights associated with the rule.
        /// </summary>
        public List<AccessRights> Rights { get; set; }
    }
}
