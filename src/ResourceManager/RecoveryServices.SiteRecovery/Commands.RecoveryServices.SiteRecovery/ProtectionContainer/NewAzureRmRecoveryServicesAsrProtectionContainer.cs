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
using Hyak.Common;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///    Creates an Azure Site Recovery Protection Container within the specified fabric.
    /// </summary>
    [Cmdlet(
        VerbsCommon.New,
        "AzureRmRecoveryServicesAsrProtectionContainer",
        DefaultParameterSetName = ASRParameterSets.AzureToAzure,
        SupportsShouldProcess = true)]
    [Alias("New-ASRProtectionContainer")]
    [OutputType(typeof(ASRJob))]
    public class NewAzureRmRecoveryServicesAsrProtectionContainer : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets the name of the protection container.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets fabric in which protection container to be created.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.AzureToAzure, Mandatory = true, ValueFromPipeline = true)]
        [Alias("Fabric")]
        [ValidateNotNullOrEmpty]
        public ASRFabric InputObject { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();
            if (this.ShouldProcess(
                this.Name,
                VerbsCommon.New))
            {
                if (!this.InputObject.FabricType.Equals(Constants.Azure))
                {
                    throw new Exception(
                        string.Format(
                            Resources.IncorrectFabricType,
                            Constants.Azure,
                            this.InputObject.FabricType));
                }

                var input = new CreateProtectionContainerInput()
                {
                    Properties = new CreateProtectionContainerInputProperties()
                };

                var response =
                    RecoveryServicesClient.CreateProtectionContainer(
                        this.InputObject.Name,
                        this.Name,
                        input);

                string jobId = PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location);

                var jobResponse =
                    RecoveryServicesClient
                    .GetAzureSiteRecoveryJobDetails(jobId);

                WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}
