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

using Microsoft.Azure.Management.DataLake.Store.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.DataLakeStore.Models
{
    [Obsolete("This class will be deprecated in a future release.")]
    public class PSDataLakeStoreAccountProperties
    {
        /// <summary>
        /// Gets the status of the Data Lake Store account while being
        /// provisioned. Possible values include: 'Failed', 'Creating',
        /// 'Running', 'Succeeded', 'Patching', 'Suspending', 'Resuming',
        /// 'Deleting', 'Deleted'
        /// </summary>
        public DataLakeStoreAccountStatus? ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the status of the Data Lake Store account after provisioning
        /// has completed. Possible values include: 'active', 'suspended'
        /// </summary>
        public DataLakeStoreAccountState? State { get; private set; }

        /// <summary>
        /// Gets the account creation time.
        /// </summary>
        public DateTime? CreationTime { get; private set; }

        /// <summary>
        /// Gets or sets the current state of encryption for this Data Lake
        /// store account. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        public EncryptionState? EncryptionState { get; set; }

        /// <summary>
        /// Gets the current state of encryption provisioning for this Data
        /// Lake store account. Possible values include: 'Creating',
        /// 'Succeeded'
        /// </summary>
        public EncryptionProvisioningState? EncryptionProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets the Key vault encryption configuration.
        /// </summary>
        public EncryptionConfig EncryptionConfig { get; set; }

        /// <summary>
        /// Gets or sets the current state of the IP address firewall for this
        /// Data Lake store account. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        public FirewallState? FirewallState { get; set; }

        /// <summary>
        /// Gets or sets the list of firewall rules associated with this Data
        /// Lake store account.
        /// </summary>
        public IList<DataLakeStoreFirewallRule> FirewallRules { get; set; }

        /// <summary>
        /// Gets or sets the current state of the trusted identity provider
        /// feature for this Data Lake store account. Possible values
        /// include: 'Enabled', 'Disabled'
        /// </summary>
        public TrustedIdProviderState? TrustedIdProviderState { get; set; }

        /// <summary>
        /// Gets or sets the list of trusted identity providers associated
        /// with this Data Lake store account.
        /// </summary>
        public IList<DataLakeStoreTrustedIdProvider> TrustedIdProviders { get; set; }

        /// <summary>
        /// Gets the account last modified time.
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// Gets or sets the gateway host.
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the default owner group for all new folders and files
        /// created in the Data Lake Store account.
        /// </summary>
        public string DefaultGroup { get; set; }

        public PSDataLakeStoreAccountProperties(DataLakeStoreAccount baseAccount)
        {
            ProvisioningState = baseAccount.ProvisioningState;
            State = baseAccount.State;
            CreationTime = baseAccount.CreationTime;
            EncryptionState = baseAccount.EncryptionState;
            EncryptionProvisioningState = baseAccount.EncryptionProvisioningState;
            EncryptionConfig = baseAccount.EncryptionConfig;
            FirewallState = baseAccount.FirewallState;

            if(baseAccount.FirewallRules != null)
            {
                FirewallRules = new List<DataLakeStoreFirewallRule>(baseAccount.FirewallRules.Count);
                foreach(var entry in baseAccount.FirewallRules)
                {
                    FirewallRules.Add(new DataLakeStoreFirewallRule(entry));
                }
            }

            if (baseAccount.TrustedIdProviders != null)
            {
                TrustedIdProviders = new List<DataLakeStoreTrustedIdProvider>(baseAccount.TrustedIdProviders.Count);
                foreach (var entry in baseAccount.TrustedIdProviders)
                {
                    TrustedIdProviders.Add(new DataLakeStoreTrustedIdProvider(entry));
                }
            }

            TrustedIdProviderState = baseAccount.TrustedIdProviderState;
            LastModifiedTime = baseAccount.LastModifiedTime;
            Endpoint = baseAccount.Endpoint;
            DefaultGroup = baseAccount.DefaultGroup;
        }
    }
}