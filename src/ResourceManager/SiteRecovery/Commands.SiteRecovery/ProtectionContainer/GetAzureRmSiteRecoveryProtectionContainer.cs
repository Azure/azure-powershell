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

using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Protection Container.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryProtectionContainer", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRProtectionContainer>))]
    public class GetAzureRmSiteRecoveryProtectionContainer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Protection Container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithNameLegacy, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Protection Container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyNameLegacy, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Fabric object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByFabricObject, ValueFromPipeline = true, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, ValueFromPipeline = true, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, ValueFromPipeline = true, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByObjectWithNameLegacy:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetByNameLegacy();
                    break;
                case ASRParameterSets.ByObjectWithFriendlyNameLegacy:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetByFriendlyNameLegacy();
                    break;
                case ASRParameterSets.ByObjectWithName:
                    this.GetByName();
                    break;
                case ASRParameterSets.ByObjectWithFriendlyName:
                    this.GetByFriendlyName();
                    break;
                case ASRParameterSets.ByFabricObject:
                    this.GetByFabric();
                    break;
                default:
                    this.WriteWarningWithTimestamp(Properties.Resources.ParameterSetWillBeDeprecatedSoon);
                    this.GetAll();
                    break;
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyNameLegacy()
        {
            ProtectionContainerListResponse protectionContainerListResponse;
            bool found = false;

            FabricListResponse fabricListResponse = RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            foreach (Fabric fabric in fabricListResponse.Fabrics)
            {
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(fabric.Name);

                foreach (
                    ProtectionContainer protectionContainer in
                    protectionContainerListResponse.ProtectionContainers)
                {
                    if (0 == string.Compare(this.FriendlyName, protectionContainer.Properties.FriendlyName, StringComparison.OrdinalIgnoreCase))
                    {
                        var protectionContainerByName = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(fabric.Name, protectionContainer.Name).ProtectionContainer;
                        this.WriteProtectionContainer(protectionContainerByName);

                        found = true;
                        // break; //We can break if we are sure that we have clouds with unique name across fabrics
                    }
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionContainerNotFound,
                    this.FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByNameLegacy()
        {
            ProtectionContainerListResponse protectionContainerListResponse;
            bool found = false;

            FabricListResponse fabricListResponse = RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            foreach (Fabric fabric in fabricListResponse.Fabrics)
            {
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(fabric.Name);

                foreach (
                    ProtectionContainer protectionContainer in
                    protectionContainerListResponse.ProtectionContainers)
                {
                    if (0 == string.Compare(this.Name, protectionContainer.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        var protectionContainerByName = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(fabric.Name, protectionContainer.Name).ProtectionContainer;
                        this.WriteProtectionContainer(protectionContainerByName);

                        found = true;
                        // break; //We can break if we are sure that we have clouds with unique name across fabrics
                    }
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionContainerNotFound,
                    this.Name,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries all Protection Containers (vault level).
        /// </summary>
        private void GetAll()
        {
            ProtectionContainerListResponse protectionContainerListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer();
            this.WriteProtectionContainers(protectionContainerListResponse.ProtectionContainers);
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
        {
            ProtectionContainerListResponse protectionContainerListResponse;
            bool found = false;

            protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(this.Fabric.Name);

            foreach (
                ProtectionContainer protectionContainer in
                protectionContainerListResponse.ProtectionContainers)
            {
                if (0 == string.Compare(this.FriendlyName, protectionContainer.Properties.FriendlyName, StringComparison.OrdinalIgnoreCase))
                {
                    var protectionContainerByName = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(this.Fabric.Name, protectionContainer.Name).ProtectionContainer;
                    WriteProtectionContainer(protectionContainerByName);

                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionContainerNotFound,
                    FriendlyName,
                    PSRecoveryServicesClient.asrVaultCreds.ResourceName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            try
            {
                var protectionContainerResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(this.Fabric.Name, this.Name);

                if (protectionContainerResponse.ProtectionContainer != null)
                {
                    this.WriteProtectionContainer(protectionContainerResponse.ProtectionContainer);
                }
            }
            catch (CloudException ex)
            {
                if (string.Compare(ex.Error.Code, "NotFound", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new InvalidOperationException(
                        string.Format(
                        Properties.Resources.ProtectionContainerNotFound,
                        this.Name,
                        PSRecoveryServicesClient.asrVaultCreds.ResourceName));
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Queries all Protection Containers under given Fabric.
        /// </summary>
        private void GetByFabric()
        {
            ProtectionContainerListResponse protectionContainerListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(this.Fabric.Name);
            this.WriteProtectionContainers(protectionContainerListResponse.ProtectionContainers);
        }

        /// <summary>
        /// Writes Protection Containers.
        /// </summary>
        /// <param name="protectionContainers">List of Protection Containers</param>
        private void WriteProtectionContainers(IList<ProtectionContainer> protectionContainers)
        {
            List<ASRProtectionContainer> asrProtectionContainers = new List<ASRProtectionContainer>();
            Dictionary<string, ASRPolicy> policyCache = new Dictionary<string, ASRPolicy>();

            foreach (ProtectionContainer protectionContainer in protectionContainers)
            {
                List<ASRPolicy> availablePolicies = new List<ASRPolicy>();
                List<ASRProtectionContainerMapping> asrProtectionContainerMappings = new List<ASRProtectionContainerMapping>();

                // Check if container is paired then fetch policy details.
                if (0 == string.Compare(protectionContainer.Properties.PairingStatus, "paired", StringComparison.OrdinalIgnoreCase))
                {
                    // Get all Protection Container Mappings for specific container to find out the policies attached to container.
                    ProtectionContainerMappingListResponse protectionContainerMappingListResponse =
                        RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                        Utilities.GetValueFromArmId(protectionContainer.Id, ARMResourceTypeConstants.ReplicationFabrics),
                        protectionContainer.Name);

                    asrProtectionContainerMappings = protectionContainerMappingListResponse.ProtectionContainerMappings.Select(pcm => new ASRProtectionContainerMapping(pcm)).ToList();

                    // TODO: This call can be made parallel to speed up processing if required later.
                    foreach (ProtectionContainerMapping protectionContainerMapping in protectionContainerMappingListResponse.ProtectionContainerMappings)
                    {
                        string policyName = Utilities.GetValueFromArmId(protectionContainerMapping.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies).ToLower();
                        ASRPolicy asrPolicy = null;

                        if (policyCache.ContainsKey(policyName))
                        {
                            asrPolicy = policyCache[policyName];
                        }
                        else
                        {
                            // Get all policies and fill up the dictionary once.
                            PolicyListResponse policyListResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy();
                            foreach (Policy policy in policyListResponse.Policies)
                            {
                                asrPolicy = new ASRPolicy(policy);
                                try
                                {
                                    policyCache.Add(asrPolicy.Name.ToLower(), asrPolicy);
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

                asrProtectionContainers.Add(new ASRProtectionContainer(protectionContainer, availablePolicies.Distinct().ToList(), asrProtectionContainerMappings));
            }

            asrProtectionContainers.Sort((x, y) => x.FriendlyName.CompareTo(y.FriendlyName));
            this.WriteObject(asrProtectionContainers, true);
        }

        /// <summary>
        /// Write Protection Container.
        /// </summary>
        /// <param name="protectionContainer">Protection Container</param>
        private void WriteProtectionContainer(ProtectionContainer protectionContainer)
        {
            List<ASRPolicy> availablePolicies = new List<ASRPolicy>();
            List<ASRProtectionContainerMapping> asrProtectionContainerMappings = new List<ASRProtectionContainerMapping>();

            ProtectionContainerMappingListResponse protectionContainerMappingListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(
                Utilities.GetValueFromArmId(protectionContainer.Id, ARMResourceTypeConstants.ReplicationFabrics), protectionContainer.Name);
            asrProtectionContainerMappings = protectionContainerMappingListResponse.ProtectionContainerMappings.Select(pcm => new ASRProtectionContainerMapping(pcm)).ToList();

            foreach (ProtectionContainerMapping protectionContainerMapping in protectionContainerMappingListResponse.ProtectionContainerMappings)
            {
                PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(
                    Utilities.GetValueFromArmId(protectionContainerMapping.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies));
                availablePolicies.Add(new ASRPolicy(policyResponse.Policy));
            }

            this.WriteObject(new ASRProtectionContainer(protectionContainer, availablePolicies.Distinct().ToList(), asrProtectionContainerMappings));
        }
    }
}