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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Imports Azure Site Recovery Vault Settings.
    /// </summary>
    [Cmdlet(VerbsData.Import, "AzureSiteRecoveryVaultSettingsFile")]
    [OutputType(typeof(ASRVaultSettings))]
    public class ImportAzureSiteRecoveryVaultSettingsFile : RecoveryServicesCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets path to the Azure site Recovery Vault Settings file. This file can be 
        /// downloaded from Azure site recovery Vault portal and stored locally.
        /// </summary>
        [Parameter(
            Position = 0, 
            Mandatory = true, 
            HelpMessage = "AzureSiteRecovery vault settings file path", 
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }
        #endregion Parameters

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            this.WriteVerbose("Vault Settings File path: " + this.Path);

            ASRVaultCreds asrVaultCreds = null;
            if (File.Exists(this.Path))
            {
                try
                {
                    this.WriteWarningWithTimestamp(
                        string.Format(
                            Properties.Resources.CmdletWillBeDeprecatedSoon,
                            this.MyInvocation.MyCommand.Name));

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
                        string.Format(Properties.Resources.InvalidXml, xmlException));
                }
                catch (SerializationException serializationException)
                {
                    throw new SerializationException(
                        string.Format(Properties.Resources.InvalidXml, serializationException));
                }
            }
            else
            {
                throw new FileNotFoundException(
                    Properties.Resources.VaultSettingFileNotFound,
                    this.Path);
            }

            // Validate required parameters taken from the Vault settings file.
            if (string.IsNullOrEmpty(asrVaultCreds.ResourceName))
            {
                throw new ArgumentException(
                    Properties.Resources.ResourceNameNullOrEmpty,
                    asrVaultCreds.ResourceName);
            }

            if (string.IsNullOrEmpty(asrVaultCreds.CloudServiceName))
            {
                throw new ArgumentException(
                    Properties.Resources.CloudServiceNameNullOrEmpty,
                    asrVaultCreds.CloudServiceName);
            }

            try
            {
                RecoveryServicesClient.ValidateVaultSettings(
                    asrVaultCreds.ResourceName,
                    asrVaultCreds.CloudServiceName);

                Utilities.UpdateVaultSettings(asrVaultCreds);
                this.WriteObject(new ASRVaultSettings(
                    asrVaultCreds.ResourceName,
                    asrVaultCreds.CloudServiceName));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}