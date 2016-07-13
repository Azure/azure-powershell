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
using System.Net;
using Microsoft.Azure.Commands.RecoveryServices.Properties;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServices.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Used to initiate a vault create operation.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureSiteRecoveryVault")]
    [OutputType(typeof(VaultOperationOutput))]
    public class CreateAzureSiteRecoveryVault : RecoveryServicesCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets the vault name
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = true, HelpMessage = "Vault Name for which the cred file to be generated")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location of the vault
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByParam, Mandatory = true, HelpMessage = "Geo Location Name")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            try
            {
                this.WriteWarningWithTimestamp(
                    string.Format(
                        Properties.Resources.CmdletWillBeDeprecatedSoon,
                        this.MyInvocation.MyCommand.Name));

                string cloudServiceName = Utilities.GenerateCloudServiceName(this.Location);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(cloudServiceName);
                string base64Label = Convert.ToBase64String(bytes);

                CloudServiceCreateArgs cloudServiceCreateArgs = new CloudServiceCreateArgs()
                {
                    GeoRegion = this.Location,
                    Label = base64Label,
                    Description = base64Label
                };

                RecoveryServicesClient.FindOrCreateCloudService(cloudServiceName, cloudServiceCreateArgs);

                VaultCreateArgs vaultCreateArgs = new VaultCreateArgs()
                {
                    Name = this.Name,
                    Plan = string.Empty,
                    ResourceProviderNamespace = Constants.ResourceNamespace,
                    Type = Constants.ASRVaultType,
                    ETag = Guid.NewGuid().ToString(),
                    SchemaVersion = Constants.RpSchemaVersion
                };

                RecoveryServicesOperationStatusResponse response = RecoveryServicesClient.CreateVault(cloudServiceName, this.Name, vaultCreateArgs);

                VaultOperationOutput output = new VaultOperationOutput()
                {
                    Response = response.StatusCode == HttpStatusCode.OK ? Resources.VaultCreationSuccessMessage : response.StatusCode.ToString()
                };

                this.WriteObject(output, true);
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
