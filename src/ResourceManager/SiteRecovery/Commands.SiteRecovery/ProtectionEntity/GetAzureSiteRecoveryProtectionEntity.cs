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
    /// Retrieves Azure Site Recovery Protection Entity.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSiteRecoveryProtectionEntity", DefaultParameterSetName = ASRParameterSets.ByObject)]
    [OutputType(typeof(IEnumerable<ASRProtectionEntity>))]
    public class GetAzureSiteRecoveryProtectionEntity : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets Name of the Protection Entity.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets friendly name of the Protection Entity.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets Server Object.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithName, Mandatory = true)]
        [Parameter(ParameterSetName = ASRParameterSets.ByObjectWithFriendlyName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRProtectionContainer ProtectionContainer { get; set; }
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
                    case ASRParameterSets.ByObject:
                        this.GetAll();
                        break;
                    case ASRParameterSets.ByObjectWithName:
                        this.GetByName();
                        break;
                    case ASRParameterSets.ByObjectWithFriendlyName:
                        this.GetByFriendlyName();
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
            ProtectionEntityListResponse protectionEntityListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                this.ProtectionContainer.Name);

            bool found = false;
            foreach (ProtectionEntity pe in protectionEntityListResponse.ProtectionEntities)
            {
                if (0 == string.Compare(this.FriendlyName, pe.Properties.FriendlyName, true))
                {
                    this.WriteProtectionEntity(pe);
                    found = true;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionEntityNotFound,
                    this.FriendlyName,
                    this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        /// Queries by Name.
        /// </summary>
        private void GetByName()
        {
            // Commenting below code as Get PE by Name is faiing for somereason in service.
            // Taking alternate route

            //ProtectionEntityResponse protectionEntityResponse =
            //    RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
            //    this.ProtectionContainer.Name,
            //    this.Name);

            //this.WriteProtectionEntity(protectionEntityResponse.ProtectionEntity);

            ProtectionEntityListResponse protectionEntityListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                this.ProtectionContainer.Name);

            bool found = false;
            foreach (ProtectionEntity pe in protectionEntityListResponse.ProtectionEntities)
            {
                if (0 == string.Compare(this.Name, pe.Name, true))
                {
                    this.WriteProtectionEntity(pe);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                throw new InvalidOperationException(
                    string.Format(
                    Properties.Resources.ProtectionEntityNotFound,
                    this.Name,
                    this.ProtectionContainer.FriendlyName));
            }
        }

        /// <summary>
        /// Queries all Protection Entities under given Protection Container.
        /// </summary>
        private void GetAll()
        {
            ProtectionEntityListResponse protectionEntityListResponse =
                RecoveryServicesClient.GetAzureSiteRecoveryProtectionEntity(
                this.ProtectionContainer.Name);

            this.WriteProtectionEntities(protectionEntityListResponse.ProtectionEntities);
        }

        /// <summary>
        /// Writes Protection Entities.
        /// </summary>
        /// <param name="protectionEntities">Protection Entities</param>
        private void WriteProtectionEntities(IList<ProtectionEntity> protectionEntities)
        {
            this.WriteObject(protectionEntities.Select(pe => new ASRProtectionEntity(pe)), true);
        }

        /// <summary>
        /// Writes Protection Entity.
        /// </summary>
        /// <param name="pe">Protection Entity</param>
        private void WriteProtectionEntity(ProtectionEntity pe)
        {
            this.WriteObject(new ASRProtectionEntity(pe));
        }
    }
}