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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery vCenter server.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.ByFabricObject)]
    [Alias("Get-ASRvCenter")]
    [OutputType(typeof(IEnumerable<ASRvCenter>))]
    public class GetAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Fabric server of the vCenter.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true,
            ValueFromPipeline = true)]
        [Parameter(
            ParameterSetName = ASRParameterSets.ByFabricObject,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of the vCenter.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.ByName,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByName:
                    this.GetvCenterByName();
                    break;
                case ASRParameterSets.ByFabricObject:
                    this.GetAllvCentersInFabric();
                    break;
            }
        }

        /// <summary>
        ///     Queries by fabric server.
        /// </summary>
        private void GetAllvCentersInFabric()
        {
            var vCenterListResponse =
                this.RecoveryServicesClient.ListAzureRmSiteRecoveryvCenter(this.Fabric.Name);

            this.WritevCenters(vCenterListResponse);
        }

        /// <summary>
        ///     Queries by vCenter name.
        /// </summary>
        private void GetvCenterByName()
        {
            var vcenterResponse =
                this.RecoveryServicesClient.GetAzureRmSiteRecoveryvCenter(
                    this.Fabric.Name,
                    this.Name);

            this.WritevCenter(vcenterResponse);
        }

        /// <summary>
        ///     Write vCenter.
        /// </summary>
        /// <param name="vcenter">vCenter object</param>
        private void WritevCenter(VCenter vcenter)
        {
            this.WriteObject(new ASRvCenter(vcenter));
        }

        /// <summary>
        ///     Write vCenter Objects.
        /// </summary>
        /// <param name="vcenters">List of vCenters</param>
        private void WritevCenters(IList<VCenter> vcenters)
        {
            this.WriteObject(vcenters.Select(p => new ASRvCenter(p)), true);
        }
    }
}