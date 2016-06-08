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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.IO;
using System.Management.Automation;
using System.Security.Cryptography;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsData.Import, "AzureStorSimpleLegacyApplianceConfig"), OutputType(typeof(LegacyApplianceConfiguration))]
    public class ImportAzureStorSimpleLegacyApplianceConfig : StorSimpleCmdletBase
    {

        [Alias("FilePath")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigFilePath)]
        [ValidateNotNullOrEmpty]
        public string ConfigFilePath { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.MigrationTargetDevice)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceName { get; set; }

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigDecryptionKey)]
        [ValidateNotNullOrEmpty]
        public string ConfigDecryptionKey { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                WriteVerbose(string.Format(Resources.MigrationMsgQueringDeviceId, TargetDeviceName));
                string deviceid = StorSimpleClient.GetDeviceId(TargetDeviceName);
                if (!File.Exists(ConfigFilePath))
                {
                    throw new FileNotFoundException(String.Format(Resources.MigrationConfigFileNotFound,
                        StorSimpleContext.ResourceName, ConfigFilePath));
                }
                else if (string.IsNullOrEmpty(deviceid))
                {
                    throw new ArgumentException(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage,
                        StorSimpleContext.ResourceName, TargetDeviceName));
                }
                else
                {
                    // creating the config file parser instance - parser decrypt the xml and parses the config xml
                    WriteVerbose(string.Format(Resources.MigrationMsgDeviceFound, deviceid));
                    var secretsEncryptor = new ServiceSecretEncryptor(this.StorSimpleClient);
                    var parser = new LegacyApplianceConfigParser(secretsEncryptor);
                    var legacyApplianceMetaData = new LegacyApplianceConfiguration();

                    legacyApplianceMetaData.Details = parser.ParseLegacyApplianceConfig(ConfigFilePath,
                        ConfigDecryptionKey);
                    LegacyApplianceConfig config = legacyApplianceMetaData.Details;
                    legacyApplianceMetaData.LegacyConfigId = Guid.NewGuid().ToString();
                    config.InstanceId = config.Name = legacyApplianceMetaData.LegacyConfigId;
                    legacyApplianceMetaData.ConfigFile = ConfigFilePath;
                    legacyApplianceMetaData.ImportedOn = DateTime.Now;
                    legacyApplianceMetaData.TargetApplianceName = TargetDeviceName;
                    config.DeviceId = deviceid;

                    legacyApplianceMetaData.Result = Resources.ImportLegacyApplianceConfigSuccessMessage;
                    WriteVerbose(Resources.MigrationMsgUploadingConfig);
                    var configList = ConfigSplitHelper.Split(legacyApplianceMetaData.Details);
                    foreach (var singleConfig in configList)
                    {
                        StorSimpleClient.ImportLegacyApplianceConfig(legacyApplianceMetaData.LegacyConfigId,
                            singleConfig);
                    }

                    WriteObject(legacyApplianceMetaData);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Handle exception
        /// </summary>
        /// <param name="exception">Handles the exceptions</param>
        internal override void HandleException(Exception exception)
        {
            // Parser throws missing member exception if any expected fields are missing, handling this as special case.
            if (typeof(MissingMemberException) == exception.GetType())
            {
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.ParserError, null));
            }
            else if (typeof(CryptographicException) == exception.GetType())
            {
                WriteError(
                    new ErrorRecord(
                        new CryptographicException(
                            Resources.MigrationConfigDecryptionFailed), string.Empty, ErrorCategory.AuthenticationError,
                        null));
            }
            else
            {
                base.HandleException(exception);
            }
        }
    }
}