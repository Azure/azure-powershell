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

namespace Microsoft.Azure.Commands.Network
{
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using MNM = Microsoft.Azure.Management.Network.Models;

    public class AddressPrefixSetBaseCmdlet : NetworkBaseCmdlet
    {
        protected const string ByApplicationSecurityGroupName = "ByApplicationSecurityGroupName";
        protected const string ByApplicationSecurityGroupObject = "ByApplicationSecurityGroupObject";
        protected const string ByApplicationSecurityGroupResourceId = "ByApplicationSecurityGroupResourceId";
        protected const string ByAddressPrefixSetObject = "ByAddressPrefixSetObject";
        protected const string ByAddressPrefixSetResourceId = "ByAddressPrefixSetResourceId";

        public IAddressPrefixSetsOperations AddressPrefixSetClient
        {
            get { return this.NetworkClient.NetworkManagementClient.AddressPrefixSets; }
        }

        public PSAddressPrefixSet GetAddressPrefixSet(string resourceGroupName, string applicationSecurityGroupName, string name)
        {
            return this.ToPsAddressPrefixSet(this.AddressPrefixSetClient.Get(resourceGroupName, applicationSecurityGroupName, name));
        }

        public List<PSAddressPrefixSet> ListAddressPrefixSets(string resourceGroupName, string applicationSecurityGroupName)
        {
            var page = this.AddressPrefixSetClient.List(resourceGroupName, applicationSecurityGroupName);
            var resources = ListNextLink<MNM.AddressPrefixSet>.GetAllResourcesByPollingNextLink(
                page,
                this.AddressPrefixSetClient.ListNext);
            var result = new List<PSAddressPrefixSet>();
            foreach (var resource in resources)
            {
                result.Add(this.ToPsAddressPrefixSet(resource));
            }

            return result;
        }

        public PSAddressPrefixSet CreateOrUpdateAddressPrefixSet(
            string resourceGroupName,
            string applicationSecurityGroupName,
            string name,
            IList<string> addressPrefixes)
        {
            var resource = new MNM.AddressPrefixSet
            {
                Properties = new MNM.AddressPrefixSetPropertiesFormat(addressPrefixes)
            };

            return this.ToPsAddressPrefixSet(
                this.AddressPrefixSetClient.CreateOrUpdate(resourceGroupName, applicationSecurityGroupName, name, resource));
        }

        public void EnsureApplicationSecurityGroupExists(string resourceGroupName, string applicationSecurityGroupName)
        {
            this.NetworkClient.NetworkManagementClient.ApplicationSecurityGroups.Get(resourceGroupName, applicationSecurityGroupName);
        }

        private PSAddressPrefixSet ToPsAddressPrefixSet(MNM.AddressPrefixSet resource)
        {
            return new PSAddressPrefixSet
            {
                Id = resource.Id,
                Name = resource.Name,
                Etag = resource.Etag,
                AddressPrefixes = resource.Properties?.AddressPrefixes,
                ProvisioningState = resource.Properties?.ProvisioningState
            };
        }
    }
}
