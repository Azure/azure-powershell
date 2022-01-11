﻿// ----------------------------------------------------------------------------------
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

using Azure;
using Azure.Security.KeyVault.Keys;

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyRotationPolicy
    {

        //
        // Summary:
        //     Gets the identifier of the Azure.Security.KeyVault.Keys.KeyRotationPolicy.
        public string Id { get; set; }

        public string VaultName { get; set; }

        public string KeyName { get; set; }
        //
        // Summary:
        //     Gets the actions that will be performed by Key Vault over the lifetime of a key.
        public IList<PSKeyRotationLifetimeAction> LifetimeActions { get; set; }
        //
        // Summary:
        //     Gets or sets the System.TimeSpan when the Azure.Security.KeyVault.Keys.KeyRotationPolicy
        //     will expire. It should be at least 28 days.
        public TimeSpan? ExpiresIn { get; set; }
        //
        // Summary:
        //     Gets a System.DateTimeOffset indicating when the Azure.Security.KeyVault.Keys.KeyRotationPolicy
        //     was created.
        public DateTimeOffset? CreatedOn { get; set; }
        //
        // Summary:
        //     Gets a System.DateTimeOffset indicating when the Azure.Security.KeyVault.Keys.KeyRotationPolicy
        //     was last updated.
        public DateTimeOffset? UpdatedOn { get; set; }

        public PSKeyRotationPolicy() { }

        public PSKeyRotationPolicy(KeyRotationPolicy keyRotationPolicy, string vaultName, string keyName)
        {
            Id = keyRotationPolicy.Id?.ToString();
            VaultName = vaultName;
            KeyName = keyName;
            LifetimeActions = new List<PSKeyRotationLifetimeAction>();
            foreach (var action in keyRotationPolicy.LifetimeActions)
            {
                LifetimeActions.Add(new PSKeyRotationLifetimeAction(action));
            }
            ExpiresIn = keyRotationPolicy.ExpiresIn;
            CreatedOn = keyRotationPolicy.CreatedOn;
            UpdatedOn = keyRotationPolicy.UpdatedOn;
        }
    }
} 