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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.EventHub.Models
{

    public class PSListKeysAttributes
    {
        public const string DefaultClaimType = "SharedAccessKey";
        public const string DefaultClaimValue = "None";
        internal const string DefaultNamespaceAuthorizationRule = "RootManageSharedAccessKey";

        public PSListKeysAttributes(AccessKeys listKeysResource)
        {
            if (listKeysResource != null)
            {
                PrimaryConnectionString = listKeysResource.PrimaryConnectionString;
                SecondaryConnectionString = listKeysResource.SecondaryConnectionString;
                PrimaryKey = listKeysResource.PrimaryKey;
                SecondaryKey = listKeysResource.SecondaryKey;
                KeyName = listKeysResource.KeyName;
                AliasPrimaryConnectionString = listKeysResource.AliasPrimaryConnectionString;
                AliasSecondaryConnectionString = listKeysResource.AliasSecondaryConnectionString;
            };
        }

        /// <summary>
        /// AliasPrimaryConnectionString of the created Alias AuthorizationRule.
        /// </summary>
        public string AliasPrimaryConnectionString { get; set; }

        /// <summary>
        /// AliasSecondaryConnectionString of the created Alias
        /// </summary>
        public string AliasSecondaryConnectionString { get; set; }

        /// <summary>
        /// PrimaryConnectionString of the created Namespace AuthorizationRule.
        /// </summary>
        public string PrimaryConnectionString { get; set; }

        /// <summary>
        /// SecondaryConnectionString of the created Namespace
        /// AuthorizationRule
        /// </summary>
        public string SecondaryConnectionString { get; set; }

        /// <summary>
        /// A base64-encoded 256-bit primary key for signing and validating
        /// the SAS token
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// A base64-encoded 256-bit primary key for signing and validating
        /// the SAS token
        /// </summary>
        public string SecondaryKey { get; set; }

        /// <summary>
        /// A string that describes the authorization rule
        /// </summary>
        public string KeyName { get; set; }

    }
}
