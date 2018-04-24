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
using System.Management.Automation;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Creates an Azure Site Recovery Fabric.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrFabric",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("New-ASRFabric")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrFabric : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///    Switch parameter indicates creation of azure fabric.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Azure, Mandatory = true)]
        public SwitchParameter Azure { get; set; }

        /// <summary>
        ///     Gets or sets the name of the Azure Site Recovery Fabric.
        /// </summary>
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the fabric to be created")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or Sets the Azure Site Recovery Fabric Type.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(Constants.HyperVSite)]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or Sets the Azure region corresponding to the Fabric object being created.
        ///     The Azure Site Recovery fabric object represents a region. 
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Azure, Mandatory = true)]
        [LocationCompleter("Microsoft.RecoveryServices/vaults")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                var input = new FabricCreationInput();
                input.Properties = new FabricCreationInputProperties();
                
                switch (this.ParameterSetName)
                {
                    case ASRParameterSets.Azure:

                        input.Properties.CustomDetails = new AzureFabricCreationInput()
                        {
                            Location = this.Location
                        };
                        break;

                    case ASRParameterSets.Default:

                        input.Properties.CustomDetails = new FabricSpecificCreationInput();
                        break;
                }

                var response = this.RecoveryServicesClient.CreateAzureSiteRecoveryFabric(
                    this.Name,
                    input);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}