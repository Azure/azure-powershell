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
using System.IO;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Imports Azure Site Recovery Vault Settings.
    /// </summary>
    [Cmdlet(
        VerbsData.Import,
        "AzureRmRecoveryServicesAsrVaultSettingsFile",
        SupportsShouldProcess = true)]
    [OutputType(typeof(ASRVaultSettings))]
    public class ImportAzureRmRecoveryServicesAsrVaultSettingsFile : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets path to the Azure RecoveryServices Vault Settings file. This file can be
        ///     downloaded from Azure recoveryservices Vault portal and stored locally.
        /// </summary>
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Azure RecoveryServices vault settings file path",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                "Vault Setting file",
                VerbsData.Import))
            {
                this.WriteVerbose("Vault Settings File path: " + this.Path);

                ASRVaultCreds asrVaultCreds = null;

                if (File.Exists(this.Path))
                {
                    try
                    {
                        var serializer = new DataContractSerializer(typeof(ASRVaultCreds));
                        using (var s = new FileStream(
                            this.Path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.Read))
                        {
                            asrVaultCreds = (ASRVaultCreds)serializer.ReadObject(s);
                        }
                    }
                    catch (XmlException xmlException)
                    {
                        throw new XmlException(
                            string.Format(
                                Resources.InvalidXml,
                                xmlException));
                    }
                    catch (SerializationException serializationException)
                    {
                        throw new SerializationException(
                            string.Format(
                                Resources.InvalidXml,
                                serializationException));
                    }
                }
                else
                {
                    throw new FileNotFoundException(
                        Resources.VaultSettingFileNotFound,
                        this.Path);
                }

                // Validate required parameters taken from the Vault settings file.
                if (string.IsNullOrEmpty(asrVaultCreds.ResourceName))
                {
                    throw new ArgumentException(
                        Resources.ResourceNameNullOrEmpty,
                        asrVaultCreds.ResourceName);
                }

                if (string.IsNullOrEmpty(asrVaultCreds.ResourceGroupName))
                {
                    throw new ArgumentException(
                        Resources.CloudServiceNameNullOrEmpty,
                        asrVaultCreds.ResourceGroupName);
                }

                Utilities.UpdateCurrentVaultContext(asrVaultCreds);

                this.RecoveryServicesClient.ValidateVaultSettings(
                    asrVaultCreds.ResourceName,
                    asrVaultCreds.ResourceGroupName);

                this.WriteObject(new ASRVaultSettings(asrVaultCreds));
            }
        }
    }
}