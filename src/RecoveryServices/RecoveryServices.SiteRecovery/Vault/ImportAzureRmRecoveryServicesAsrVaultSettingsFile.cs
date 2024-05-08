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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Imports the specified ASR vault settings file to set the vault context(PowerShell session context)
    ///     for subsequent ASR operations in the PowerShell session. 
    /// </summary>
    [Cmdlet("Import", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrVaultSettingsFile",SupportsShouldProcess = true)]
    [OutputType(typeof(ASRVaultSettings))]
    [Alias(
        "Import-ASRVaultSettingsFile")]
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

            Path = this.ResolveUserPath(Path);

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
                        if (FileUtilities.DataStore.ReadFileAsText(this.Path).ToLower().Contains("<asrvaultcreds"))
                        {
                            asrVaultCreds = ReadAcsASRVaultCreds();
                        }
                        else
                        {
                            asrVaultCreds = ReadAadASRVaultCreds();
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

        private ASRVaultCreds ReadAcsASRVaultCreds()
        {
            ASRVaultCreds asrVaultCreds;
            var serializer = new DataContractSerializer(typeof(ASRVaultCreds));
                using (var s = new FileStream(
                    this.Path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    asrVaultCreds = (ASRVaultCreds)serializer.ReadObject(s);
                }
            return asrVaultCreds;
        }

        private ASRVaultCreds ReadAadASRVaultCreds()
        {
            ASRVaultCreds asrVaultCreds;
            var serializer = new DataContractSerializer(typeof(RSVaultAsrCreds));
            using (var s = new FileStream(
                this.Path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read))
            {
                RSVaultAsrCreds aadCreds = (RSVaultAsrCreds)serializer.ReadObject(s);
                asrVaultCreds = new ASRVaultCreds();
                asrVaultCreds.ChannelIntegrityKey = aadCreds.ChannelIntegrityKey;
                asrVaultCreds.ResourceGroupName = aadCreds.VaultDetails.ResourceGroup;
                asrVaultCreds.Version = aadCreds.Version;
                asrVaultCreds.SiteId = aadCreds.SiteId;
                asrVaultCreds.SiteName = aadCreds.SiteName;
                asrVaultCreds.ResourceNamespace = aadCreds.VaultDetails.ProviderNamespace;
                asrVaultCreds.ARMResourceType = aadCreds.VaultDetails.ResourceType;
                asrVaultCreds.ResourceName = aadCreds.VaultDetails.ResourceName;
                asrVaultCreds.PrivateEndpointStateForSiteRecovery = aadCreds.PrivateEndpointStateForSiteRecovery;
            }
            return asrVaultCreds;
        }
    }
}
