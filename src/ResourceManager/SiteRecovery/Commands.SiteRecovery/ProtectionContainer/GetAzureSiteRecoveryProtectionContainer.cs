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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery Protection Container.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryProtectionContainer", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRProtectionContainer>))]
    public class GetAzureSiteRecoveryProtectionContainer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets ID of the Protection Container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets name of the Protection Container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.ByObjectWithName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.ByObjectWithFriendlyName:
                        this.GetByFriendlyName();
                        break;
                    default:
                        this.GetAll();
                        break;
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Queries by friendly name.
        /// </summary>
        private void GetByFriendlyName()
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
                    if (0 == string.Compare(this.FriendlyName, protectionContainer.Properties.FriendlyName, true))
                    {
                        this.WriteProtectionContainer(protectionContainer);
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
        private void GetByName()
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
                    if (0 == string.Compare(this.Name, protectionContainer.Name, true))
                    {
                        this.WriteProtectionContainer(protectionContainer);
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
        /// Queries all Protection Containers under given Fabric.
        /// </summary>
        private void GetAll()
        {
            ProtectionContainerListResponse protectionContainerListResponse;

            FabricListResponse fabricListResponse = RecoveryServicesClient.GetAzureSiteRecoveryFabric();

            foreach (Fabric fabric in fabricListResponse.Fabrics)
            {
                // Do not process for fabrictype other than Vmm|HyperVSite 
                if (String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.VMM) != 0 && String.Compare(fabric.Properties.CustomDetails.InstanceType, Constants.HyperVSite) != 0)
                    continue;

                protectionContainerListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainer(fabric.Name);

                this.WriteProtectionContainers(protectionContainerListResponse.ProtectionContainers);
            }            
        }

        /// <summary>
        /// Writes Protection Containers.
        /// </summary>
        /// <param name="protectionContainers">List of Protection Containers</param>
        private void WriteProtectionContainers(IList<ProtectionContainer> protectionContainers)
        {           
            List<ASRProtectionContainer> asrProtectionContainers = new List<ASRProtectionContainer>();

            foreach (ProtectionContainer protectionContainer in protectionContainers)
            {
                List<ASRPolicy> availablePolicies = new List<ASRPolicy>();

                ProtectionContainerMappingListResponse protectionContainerMappingListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(Utilities.GetValueFromArmId(protectionContainer.Id, ARMResourceTypeConstants.ReplicationFabrics), protectionContainer.Name);
                foreach (ProtectionContainerMapping protectionContainerMapping in protectionContainerMappingListResponse.ProtectionContainerMappings)
                {
                    PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(protectionContainerMapping.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies));
                    availablePolicies.Add(new ASRPolicy(policyResponse.Policy));          
                }
                
                asrProtectionContainers.Add(new ASRProtectionContainer(protectionContainer, availablePolicies));
            }

            this.WriteObject(asrProtectionContainers, true);
        }

        /// <summary>
        /// Write Protection Container.
        /// </summary>
        /// <param name="protectionContainer">Protection Container</param>
        private void WriteProtectionContainer(ProtectionContainer protectionContainer)
        {
            List<ASRPolicy> availablePolicies = new List<ASRPolicy>();

            ProtectionContainerMappingListResponse protectionContainerMappingListResponse = RecoveryServicesClient.GetAzureSiteRecoveryProtectionContainerMapping(Utilities.GetValueFromArmId(protectionContainer.Id, ARMResourceTypeConstants.ReplicationFabrics), protectionContainer.Name);
            foreach (ProtectionContainerMapping protectionContainerMapping in protectionContainerMappingListResponse.ProtectionContainerMappings)
            {
                PolicyResponse policyResponse = RecoveryServicesClient.GetAzureSiteRecoveryPolicy(Utilities.GetValueFromArmId(protectionContainerMapping.Properties.PolicyId, ARMResourceTypeConstants.ReplicationPolicies));
                availablePolicies.Add(new ASRPolicy(policyResponse.Policy));
            }

            this.WriteObject(new ASRProtectionContainer(protectionContainer, availablePolicies));
        }
    }
}