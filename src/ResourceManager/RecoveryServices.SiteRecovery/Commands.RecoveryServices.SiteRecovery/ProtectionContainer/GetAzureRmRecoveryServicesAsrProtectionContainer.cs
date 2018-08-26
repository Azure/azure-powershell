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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery Protection Container.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrProtectionContainer",DefaultParameterSetName = ASRParameterSets.ByFabricObject)]
    [Alias("Get-ASRProtectionContainer")]
    [OutputType(typeof(ASRProtectionContainer))]
    public class GetAzureRmRecoveryServicesAsrProtectionContainer : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets ID of the Protection Container.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets name of the Protection Container.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets Fabric object.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFabricObject,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithName,
            ValueFromPipeline = true,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName,
            ValueFromPipeline = true,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObjectWithName:
                    this.GetByName();
                    break;
                case ASRParameterSets.ByObjectWithFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.ByFabricObject:
                    this.GetByFabric();
                    break;
            }
        }

        /// <summary>
        ///     Queries all Protection Containers under given Fabric.
        /// </summary>
        private void GetByFabric()
        {
            var protectionContainerListResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(
                    this.Fabric.Name);
            this.WriteProtectionContainers(protectionContainerListResponse);
        }

        /// <summary>
        ///     Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            List<ProtectionContainer> protectionContainerListResponse;
            var found = false;

            protectionContainerListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectionContainer(this.Fabric.Name);

            foreach (var protectionContainer in protectionContainerListResponse)
            {
                if (0 ==
                    string.Compare(
                        this.FriendlyName,
                        protectionContainer.Properties.FriendlyName,
                        StringComparison.OrdinalIgnoreCase))
                {
                    var protectionContainerByName = this.RecoveryServicesClient
                        .GetAzureSiteRecoveryProtectionContainer(
                            this.Fabric.Name,
                            protectionContainer.Name);
                    this.WriteProtectionContainer(protectionContainerByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                        Resources.ProtectionContainerNotFound,
                        this.FriendlyName,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        ///     Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectionContainerResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryProtectionContainer(
                        this.Fabric.Name,
                        this.Name);

                if (protectionContainerResponse != null)
                {
                    this.WriteProtectionContainer(protectionContainerResponse);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(
                        ex.Error.Code,
                        "NotFound",
                        StringComparison.OrdinalIgnoreCase) ==
                    0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                            Resources.ProtectionContainerNotFound,
                            this.Name,
                            PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }

                throw;
            }
        }

        /// <summary>
        ///     Write Protection Container.
        /// </summary>
        /// <param name="protectionContainer">Protection Container</param>
        private void WriteProtectionContainer(
            ProtectionContainer protectionContainer)
        {
            var availablePolicies = new List<ASRPolicy>();
            var asrProtectionContainerMappings = new List<ASRProtectionContainerMapping>();

            var protectionContainerMappingListResponse = this.RecoveryServicesClient
                .GetAzureSiteRecoveryProtectionContainerMapping(
                    Utilities.GetValueFromArmId(
                        protectionContainer.Id,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    protectionContainer.Name);
            asrProtectionContainerMappings = protectionContainerMappingListResponse
                .Select(pcm => new ASRProtectionContainerMapping(pcm))
                .ToList();

            foreach (var protectionContainerMapping in protectionContainerMappingListResponse)
            {
                var policyResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryPolicy(
                    Utilities.GetValueFromArmId(
                        protectionContainerMapping.Properties.PolicyId,
                        ARMResourceTypeConstants.ReplicationPolicies));
                availablePolicies.Add(new ASRPolicy(policyResponse));
            }

            this.WriteObject(
                new ASRProtectionContainer(
                    protectionContainer,
                    availablePolicies.Distinct()
                        .ToList(),
                    asrProtectionContainerMappings));
        }

        /// <summary>
        ///     Writes Protection Containers.
        /// </summary>
        /// <param name="protectionContainers">List of Protection Containers</param>
        private void WriteProtectionContainers(
            IList<ProtectionContainer> protectionContainers)
        {
            var asrProtectionContainers = new List<ASRProtectionContainer>();
            var policyCache = new Dictionary<string, ASRPolicy>();

            foreach (var protectionContainer in protectionContainers)
            {
                var availablePolicies = new List<ASRPolicy>();
                var asrProtectionContainerMappings = new List<ASRProtectionContainerMapping>();

                // Check if container is paired then fetch policy details.
                if (0 ==
                    string.Compare(
                        protectionContainer.Properties.PairingStatus,
                        "paired",
                        StringComparison.OrdinalIgnoreCase))
                {
                    // Get all Protection Container Mappings for specific container to find out the policies attached to container.
                    var protectionContainerMappingListResponse = this.RecoveryServicesClient
                        .GetAzureSiteRecoveryProtectionContainerMapping(
                            Utilities.GetValueFromArmId(
                                protectionContainer.Id,
                                ARMResourceTypeConstants.ReplicationFabrics),
                            protectionContainer.Name);

                    asrProtectionContainerMappings = protectionContainerMappingListResponse
                        .Select(pcm => new ASRProtectionContainerMapping(pcm))
                        .ToList();

                    // TODO: This call can be made parallel to speed up processing if required later.
                    foreach (var protectionContainerMapping in
                        protectionContainerMappingListResponse)
                    {
                        var policyName = Utilities.GetValueFromArmId(
                                protectionContainerMapping.Properties.PolicyId,
                                ARMResourceTypeConstants.ReplicationPolicies)
                            .ToLower();
                        ASRPolicy asrPolicy = null;

                        if (policyCache.ContainsKey(policyName))
                        {
                            asrPolicy = policyCache[policyName];
                        }
                        else
                        {
                            // Get all policies and fill up the dictionary once.
                            var policyListResponse =
                                this.RecoveryServicesClient.GetAzureSiteRecoveryPolicy();
                            foreach (var policy in policyListResponse)
                            {
                                asrPolicy = new ASRPolicy(policy);
                                try
                                {
                                    policyCache.Add(
                                        asrPolicy.Name.ToLower(),
                                        asrPolicy);
                                }
                                catch (ArgumentException)
                                {
                                    // In case of item already exist eat the exception.
                                }
                            }

                            // Get the policy from dictionary now.
                            asrPolicy = policyCache[policyName];
                        }

                        availablePolicies.Add(asrPolicy);
                    }
                }

                asrProtectionContainers.Add(
                    new ASRProtectionContainer(
                        protectionContainer,
                        availablePolicies.Distinct()
                            .ToList(),
                        asrProtectionContainerMappings));
            }

            asrProtectionContainers.Sort(
                (
                    x,
                    y) => x.FriendlyName.CompareTo(y.FriendlyName));
            this.WriteObject(
                asrProtectionContainers,
                true);
        }
    }
}
