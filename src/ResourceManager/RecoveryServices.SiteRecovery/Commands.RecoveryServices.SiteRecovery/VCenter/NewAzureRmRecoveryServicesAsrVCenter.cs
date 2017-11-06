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
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Retrieves Azure Site Recovery vCenter.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrvCenter",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("New-ASRvCenter")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrvCenter : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets Fabric of the vCenter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRFabric Fabric { get; set; }

        /// <summary>
        ///     Gets or sets friendly name of the vCenter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the account id of the vCenter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRRunAsAccount Account { get; set; }

        /// <summary>
        ///     Gets or sets port number of the vCenter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        /// <summary>
        ///     Gets or sets ip address or hostname of the vCenter.
        /// </summary>
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string IpOrHostName { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(this.Name, VerbsCommon.New))
            {
                Utilities.ValidateIpOrHostName(this.IpOrHostName);
                this.DiscovervCenter();
            }
        }

        /// <summary>
        ///     Discover the vCenter.
        /// </summary>
        private void DiscovervCenter()
        {
            var fabricResponse =
                this.RecoveryServicesClient.GetAzureSiteRecoveryFabric(this.Fabric.Name);

            var vmwareFabricDetails =
                (VMwareDetails)fabricResponse.Properties.CustomDetails;

            var addvCenterRequest = new AddVCenterRequest();

            var addvCenterRequestProperties =
                new AddVCenterRequestProperties();
            addvCenterRequestProperties.FriendlyName = this.Name;
            addvCenterRequestProperties.IpAddress = this.IpOrHostName;
            addvCenterRequestProperties.Port = this.Port.ToString();
            string processServerId = vmwareFabricDetails.ProcessServers.First(
                vmd => (
                vmd.IpAddress.Equals(vmwareFabricDetails.IpAddress)
                || string.Compare(
                    vmwareFabricDetails.HostName,
                    vmd.FriendlyName,
                    StringComparison.OrdinalIgnoreCase) == 0)).Id;
            addvCenterRequestProperties.ProcessServerId = processServerId;
            addvCenterRequestProperties.RunAsAccountId = this.Account.AccountId;

            addvCenterRequest.Properties = addvCenterRequestProperties;

            var response = this.RecoveryServicesClient.NewAzureRmSiteRecoveryvCenter(
                this.Fabric.Name,
                this.Name,
                addvCenterRequest);

            var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            this.WriteObject(new ASRJob(jobResponse));
        }
    }
}