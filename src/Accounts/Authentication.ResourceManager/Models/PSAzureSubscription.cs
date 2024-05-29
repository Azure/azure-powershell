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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Profile.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Profile.Models
{
    /// <summary>
    /// Azure subscription details.
    /// </summary>
    public class PSAzureSubscription : IAzureSubscription
    {
        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator PSAzureSubscription(AzureSubscription other)
        {
            if (other == null)
            {
                return null;
            }

            return new PSAzureSubscription(other);
        }

        /// <summary>
        /// Convert between formats of AzureSubscription information.
        /// </summary>
        /// <param name="other">The subscription to convert.</param>
        /// <returns>The converted subscription.</returns>
        public static implicit operator AzureSubscription(PSAzureSubscription other)
        {
            if (other == null)
            {
                return null;
            }

            var subscription = new AzureSubscription();
            subscription.CopyFrom(other);
            return subscription;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PSAzureSubscription()
        {

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other">Environment to copy from</param>
        public PSAzureSubscription(IAzureSubscription other)
        {
            this.CopyFrom(other);
        }

        /// <summary>
        /// Convert a subscription from a PSObject
        /// </summary>
        /// <param name="other">ThePSObject to poulate this subscription from</param>
        public PSAzureSubscription(PSObject other)
        {
            this.Id = other.GetProperty<string>(nameof(Id));
            this.Name = other.GetProperty<string>(nameof(Name));
            this.State = other.GetProperty<string>(nameof(State));
            this.PopulateExtensions(other);
        }

        /// <inheritdoc />
        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 0)]
        public string Name { get; set; }

        /// <inheritdoc />
        [Ps1Xml(Label = "Id", Target = ViewControl.Table, Position = 1)]
        public string Id { get; set; }

        /// <inheritdoc />
        [Ps1Xml(Label = "State", Target = ViewControl.Table, Position = 2)]
        public string State { get; set; }

        /// <summary>
        /// For legacy support - return the subscription Id
        /// </summary>
        public string SubscriptionId { get { return Id; } }

        /// <summary>
        /// The tenant home for the subscription.
        /// </summary>
        [Ps1Xml(Label = "TenantId", GroupByThis = true, Target = ViewControl.Table)]
        public string TenantId
        {
            get
            {
                return this.GetTenant();
            }
            set
            {
                this.SetTenant(value);
            }
        }

        public string HomeTenantId
        {
            get
            {
                return this.GetHomeTenant();
            }
            set
            {
                this.SetHomeTenant(value);
            }
        }

        public string[] ManagedByTenantIds
        {
            get
            {
                return this.GetManagedByTenants();
            }
            set
            {
                this.SetManagedByTenants(value);
            }
        }

        public string CurrentStorageAccountName
        {
            get
            {
                return GetAccountName(CurrentStorageAccount);
            }
        }

        private PSAzureSubscriptionPolicy _subscriptionPolicies;

        public PSAzureSubscriptionPolicy SubscriptionPolicies {
            get
            {
                if (this._subscriptionPolicies == null)
                {
                    this._subscriptionPolicies= new PSAzureSubscriptionPolicy(this.GetSubscriptionPolicies());
                }
                return this._subscriptionPolicies;
            }
        }

        public IDictionary<string, string> ExtendedProperties { get; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public string CurrentStorageAccount
        {
            get
            {
                return this.GetStorageAccount();
            }
            set
            {
                this.SetStorageAccount(value);
            }
        }

        public override string ToString()
        {
            return this.GetId().ToString();
        }

        public static string GetAccountName(string connectionString)
        {
            var result = connectionString;
            if (!string.IsNullOrWhiteSpace(result))
            {
                try
                {
                    var pairs = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var pair in pairs)
                    {
                        var sides = pair.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (string.Equals("AccountName", sides[0].Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            result = sides[1].Trim();
                            break;
                        }
                    }
                }
                catch
                {
                    // if there are any errors, return the unchanged account name
                }
            }

            return result;
        }

        public string AuthorizationSource
        {
            get
            {
                return this.GetProperty(AzureSubscription.Property.AuthorizationSource);
            }
        }

        public Dictionary<string, string> Tags
        {
            get
            {
                return this.GetTags();
            }
        }
    }
}
