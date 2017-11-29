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
using System.ComponentModel;
using System.Management.Automation;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Properties = Microsoft.Azure.Commands.SiteRecovery.Properties;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Creates Azure Site Recovery Fabric object.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSiteRecoveryFabric", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(ASRJob))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "New-AzureRmRecoveryServicesAsrFabric cmdlet from the AzureRm.RecoveryServices.SiteRecovery module instead.",
        false)]
    public class NewAzureRmSiteRecoveryFabric : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the name of the fabric to be created
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = true, HelpMessage = "Name of the fabric to be created")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the Fabric type
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.Default, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.HyperVSite)]
        public string Type { get; set; }

        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            string fabricType = string.IsNullOrEmpty(this.Type) ? FabricProviders.HyperVSite : this.Type;

            LongRunningOperationResponse response =
             RecoveryServicesClient.CreateAzureSiteRecoveryFabric(this.Name, fabricType);

            JobResponse jobResponse =
                RecoveryServicesClient
                .GetAzureSiteRecoveryJobDetails(PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

            WriteObject(new ASRJob(jobResponse.Job));
        }
    }
}
