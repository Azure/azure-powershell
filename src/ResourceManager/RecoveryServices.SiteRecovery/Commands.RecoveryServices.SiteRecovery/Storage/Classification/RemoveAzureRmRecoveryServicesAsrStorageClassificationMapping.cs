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

using System.IO;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    // <summary>
    /// Pairs storage classification
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        "AzureRmRecoveryServicesAsrStorageClassificationMapping",
        DefaultParameterSetName = ASRParameterSets.Default,
        SupportsShouldProcess = true)]
    [Alias("Remove-ASRStorageClassificationMapping")]
    [OutputType(typeof(ASRJob))]
    public class RemoveAzureRmRecoveryServicesAsrStorageClassificationMapping :
        SiteRecoveryCmdletBase,
        IModuleAssemblyInitializer
    {
        /// <summary>
        ///     Gets or sets primary storage classification.
        /// </summary>
        [Parameter(
            ParameterSetName = ASRParameterSets.Default,
            Mandatory = true,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("StorageClassificationMapping")]
        public ASRStorageClassificationMapping InputObject { get; set; }

        /// <summary>
        ///     Add Site Recovery aliases
        /// </summary>
        public void OnImport()
        {
            try
            {
                AzureSessionInitializer.InitializeAzureSession();
                ResourceManagerProfileProvider.InitializeResourceManagerProfile();

                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(
                    RunspaceMode.CurrentRunspace);
                invoker.AddScript(
                    File.ReadAllText(
                        FileUtilities.GetContentFilePath(
                            Path.GetDirectoryName(
                                Assembly.GetExecutingAssembly()
                                    .Location),
                            "RecoveryServicesAsrStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This may throw exception for tests, ignore.
            }
        }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.Name,
                VerbsCommon.Remove))
            {
                var tokens = this.InputObject.Id.UnFormatArmId(
                    ARMResourceIdPaths.StorageClassificationMappingResourceIdPath);
                var operationResponse = this.RecoveryServicesClient.UnmapStorageClassifications(
                    tokens[0],
                    tokens[1],
                    tokens[2]);
                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient
                        .GetJobIdFromReponseLocation(operationResponse.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }
    }
}