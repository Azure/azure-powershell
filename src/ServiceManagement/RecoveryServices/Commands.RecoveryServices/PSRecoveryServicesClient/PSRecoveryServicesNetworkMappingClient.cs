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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Target network type.
    /// </summary>
    public enum NetworkTargetType
    {
        /// <summary>
        /// SCVMM VM Network.
        /// </summary>
        SCVMM = 0,

        /// <summary>
        /// Azure VM Network.
        /// </summary>
        Azure,
    }

    /// <summary>
    /// Create network mapping input.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateNetworkMappingInput
    {
        /// <summary>
        /// Gets or sets Primary Server Id.
        /// </summary>
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary Network Id.
        /// </summary>
        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Server Id.
        /// </summary>
        [DataMember(Order = 3)]
        public string RecoveryServerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Network Id.
        /// </summary>
        [DataMember(Order = 4)]
        public string RecoveryNetworkId { get; set; }
    }

    /// <summary>
    /// Create Azure network mapping input.
    /// </summary>
    [SuppressMessage(
       "Microsoft.StyleCop.CSharp.MaintainabilityRules",
       "SA1402:FileMayOnlyContainASingleClass",
       Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateAzureNetworkMappingInput
    {
        /// <summary>
        /// Gets or sets Primary Server Id.
        /// </summary>
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary Network Id.
        /// </summary>
        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [DataMember(Order = 3)]
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network name.
        /// </summary>
        [DataMember(Order = 4)]
        public string RecoveryNetworkName { get; set; }
    }

    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Network mappings.
        /// </summary>
        /// <param name="primaryServerId">Primary server ID</param>
        /// <param name="recoveryServerId">Recovery server ID</param>
        /// <returns>Network mapping list response</returns>
        public NetworkMappingListResponse GetAzureSiteRecoveryNetworkMappings(
            string primaryServerId, 
            string recoveryServerId)
        {
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .List(primaryServerId, recoveryServerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryNetworkId">Recovery network Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId,
            string recoveryNetworkId)
        {
            CreateNetworkMappingInput createNetworkMappingInput =
                new CreateNetworkMappingInput();
            createNetworkMappingInput.PrimaryServerId = primaryServerId;
            createNetworkMappingInput.PrimaryNetworkId = primaryNetworkId;
            createNetworkMappingInput.RecoveryServerId = recoveryServerId;
            createNetworkMappingInput.RecoveryNetworkId = recoveryNetworkId;

            NetworkMappingInput networkMappingInput = new NetworkMappingInput();
            networkMappingInput.NetworkTargetType = NetworkTargetType.SCVMM.ToString();
            networkMappingInput.CreateNetworkMappingInput =
                DataContractUtils.Serialize<CreateNetworkMappingInput>(createNetworkMappingInput);
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Create(networkMappingInput, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Azure Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryNetworkName">Recovery server Id</param>
        /// <param name="recoveryNetworkId">Recovery network Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryAzureNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryNetworkName,
            string recoveryNetworkId)
        {
            CreateAzureNetworkMappingInput createAzureNetworkMappingInput =
                new CreateAzureNetworkMappingInput();
            createAzureNetworkMappingInput.PrimaryServerId = primaryServerId;
            createAzureNetworkMappingInput.PrimaryNetworkId = primaryNetworkId;
            createAzureNetworkMappingInput.RecoveryNetworkName = recoveryNetworkName;
            createAzureNetworkMappingInput.RecoveryNetworkId = recoveryNetworkId;

            NetworkMappingInput networkMappingInput = new NetworkMappingInput();
            networkMappingInput.NetworkTargetType = NetworkTargetType.Azure.ToString();
            networkMappingInput.CreateNetworkMappingInput =
                DataContractUtils.Serialize<CreateAzureNetworkMappingInput>(createAzureNetworkMappingInput);
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Create(networkMappingInput, this.GetRequestHeaders());
        }

        /// <summary>
        /// Validates whether the Azure VM Network is associated with the subscription or not.
        /// </summary>
        /// <param name="azureSubscriptionId">Subscription Id</param>
        /// <param name="azureVMNetworkId">Azure VM Network Id</param>
        /// <param name="azureVMNetworkName">Azure VM Network name</param>
        public void ValidateVMNetworkSubscriptionAssociation(
            string azureSubscriptionId,
            string azureVMNetworkId,
            out string azureVMNetworkName)
        {
            bool associatedVMNetwork = false;
            azureVMNetworkName = string.Empty;

            AzureNetworkListResponse azureNetworkListResponse =
                this.GetSiteRecoveryClient().Networks.ListAzureNetworks(azureSubscriptionId);

            foreach (AzureNetworkListResponse.VirtualNetworkSite site in azureNetworkListResponse.VirtualNetworkSites)
            {
                if (azureVMNetworkId.Equals(site.Id))
                {
                    associatedVMNetwork = true;
                    azureVMNetworkName = site.Name;
                    break;
                }
            }

            if (!associatedVMNetwork)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.AzureVMNetworkIsNotAssociatedWithTheSubscription,
                    azureVMNetworkId,
                    azureSubscriptionId));
            }
        }

        /// <summary>
        /// Delete Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId)
        {
            NetworkUnMappingInput networkUnMappingInput = new NetworkUnMappingInput();
            networkUnMappingInput.PrimaryServerId = primaryServerId;
            networkUnMappingInput.PrimaryNetworkId = primaryNetworkId;
            networkUnMappingInput.RecoveryServerId = recoveryServerId;

            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Delete(networkUnMappingInput, this.GetRequestHeaders());
        }
    }
}