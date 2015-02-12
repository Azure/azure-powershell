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

using Microsoft.WindowsAzure.Commands.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsData.Import, "AzureStorSimpleLegacyApplianceConfig")]
    public class ImportAzureStorSimpleLegacyApplianceConfig : StorSimpleCmdletBase
    {

        [Alias("FilePath")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigFilePath)]
        [ValidateNotNullOrEmpty]
        public string ConfigFilePath { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationTargetDevice)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigDecryptionKey)]
        public string ConfigDecryptionKey { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                WriteVerbose(string.Format("Getting device id for device {0}", TargetDeviceName));
                string deviceid = StorSimpleClient.GetDeviceId(TargetDeviceName);
                if (!File.Exists(ConfigFilePath))
                {
                    WriteVerbose(String.Format(Resources.MigrationConfigFileNotFound, StorSimpleContext.ResourceName, ConfigFilePath));
                    WriteObject(null);
                }
                else if (string.IsNullOrEmpty(deviceid))
                {
                    WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, TargetDeviceName));
                    WriteObject(null);
                }                
                else
                {
                    // creating the config file parser instance - parser decrypt the xml and parses the config xml
                    WriteVerbose(string.Format("Device id obtained {0}", deviceid));
                    ServiceSecretEncryptor secretsEncryptor = new ServiceSecretEncryptor(this.StorSimpleClient);
                    LegacyApplianceConfigParser parser = new LegacyApplianceConfigParser(secretsEncryptor); 
                    LegacyApplianceConfiguration legacyApplianceMetaData = new LegacyApplianceConfiguration();

                    legacyApplianceMetaData.Details = parser.ParseLegacyApplianceConfig(filePath: ConfigFilePath, decryptionKey: ConfigDecryptionKey);
                    LegacyApplianceConfig config = legacyApplianceMetaData.Details;
                    legacyApplianceMetaData.ConfigId = Guid.NewGuid().ToString();
                    config.InstanceId = config.Name = legacyApplianceMetaData.ConfigId;
                    legacyApplianceMetaData.ConfigFile = ConfigFilePath;
                    legacyApplianceMetaData.ImportedOn = DateTime.UtcNow;
                    legacyApplianceMetaData.TargetApplianceName = TargetDeviceName;
                    config.DeviceId = deviceid;

                    legacyApplianceMetaData.Result = this.ProcessParserResultText(parser.ParserMessages);
                    WriteVerbose("Making service call to import config");
                    StorSimpleClient.ImportLegacyApplianceConfig(legacyApplianceMetaData.ConfigId, config);
                    WriteObject(legacyApplianceMetaData);
                }
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }

        /// <summary>
        /// Process the parser messages and generates a result string from the message
        /// </summary>
        /// <param name="parserMsg">parser message</param>
        /// <returns>process parser message</returns>
        private string ProcessParserResultText(List<LegacyParserMessage> parserMsg)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine(Resources.ImportLegacyApplianceConfigSuccessMessage);
            parserMsg.Sort(CompareMsgBasedOnType);
            foreach(LegacyParserMessage msg in parserMsg)
            {
                resultBuilder.AppendLine(string.Format("[{0}] : {1}", msg.Type.ToString(), msg.Reason));
                foreach (string customMsg in msg.CustomMessageList)
                {
                    resultBuilder.AppendLine("\t" + customMsg);
                }
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// Function compares the parser message based on category, to sort and group based on msg type
        /// </summary>
        /// <param name="lMsg">message for comparison</param>
        /// <param name="rMsg">message to be compared with</param>
        /// <returns>result of comparison</returns>
        private int CompareMsgBasedOnType(LegacyParserMessage lMsg, LegacyParserMessage rMsg)
        {
            return lMsg.Type.CompareTo(rMsg);
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
                WriteVerbose(exception.Message);
                WriteError(new ErrorRecord(exception, string.Empty, ErrorCategory.ParserError, null));
            }
            else
            {
                base.HandleException(exception);
            }
        }
    }

    #if COMMENTED

    [Cmdlet(VerbsData.Import, "AzureStorSimpleLegacyApplianceConfig2")]
    public class ImportAzureStorSimpleLegacyApplianceConfig2 : PSCmdlet
    {
        [Alias("FilePath")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigFilePath)]
        [ValidateNotNullOrEmpty]
        public string ConfigFilePath { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationTargetDevice)]
        [ValidateNotNullOrEmpty]
        public string TargetDeviceName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageMigrationConfigDecryptionKey)]
        public string ConfigDecryptionKey { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                WriteVerbose(string.Format("Getting device id for device {0}", TargetDeviceName));
                string deviceid = "12345";
                if (!File.Exists(ConfigFilePath))
                {
                    WriteVerbose(String.Format(Resources.MigrationConfigFileNotFound, StorSimpleContext.ResourceName, ConfigFilePath));
                    WriteObject(null);
                }
                else if (string.IsNullOrEmpty(deviceid))
                {
                    WriteVerbose(String.Format(Resources.NoDeviceFoundWithGivenNameInResourceMessage, StorSimpleContext.ResourceName, TargetDeviceName));
                    WriteObject(null);
                }                
                else
                {
                    // creating the config file parser instance - parser decrypt the xml and parses the config xml
                    TestSecretEncryptor secretsEncryptor = new TestSecretEncryptor();
                    LegacyApplianceConfigParser parser = new LegacyApplianceConfigParser(secretsEncryptor); 
                    LegacyApplianceConfiguration legacyApplianceMetaData = new LegacyApplianceConfiguration();

                    legacyApplianceMetaData.Details = parser.ParseLegacyApplianceConfig(filePath: ConfigFilePath, decryptionKey: ConfigDecryptionKey);
                    LegacyApplianceConfig config = (LegacyApplianceConfig)legacyApplianceMetaData.Details;
                    legacyApplianceMetaData.ConfigId = Guid.NewGuid().ToString();
                    config.InstanceId = config.Name = legacyApplianceMetaData.ConfigId;
                    legacyApplianceMetaData.ConfigFile = ConfigFilePath;
                    legacyApplianceMetaData.ImportedOn = DateTime.UtcNow;
                    legacyApplianceMetaData.TargetApplianceName = TargetDeviceName;
                    config.DeviceId = deviceid;

                    legacyApplianceMetaData.Result = this.ProcessParserResultText(parser.ParserMessages);

                    WriteObject(legacyApplianceMetaData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Process the parser messages and generates a result string from the message
        /// </summary>
        /// <param name="parserMsg">parser message</param>
        /// <returns>process parser message</returns>
        private string ProcessParserResultText(List<LegacyParserMessage> parserMsg)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine(Resources.ImportLegacyApplianceConfigSuccessMessage);
            parserMsg.Sort(CompareMsgBasedOnType);
            foreach(LegacyParserMessage msg in parserMsg)
            {
                resultBuilder.AppendLine(string.Format("[{0}] : {1}", msg.Type.ToString(), msg.Reason));
                foreach (string customMsg in msg.CustomMessageList)
                {
                    if (!string.IsNullOrEmpty(customMsg))
                    {
                        resultBuilder.AppendLine("\t" + customMsg);
                    }
                }
            }

            return resultBuilder.ToString();
        }

        /// <summary>
        /// Function compares the parser message based on category, to sort and group based on msg type
        /// </summary>
        /// <param name="lMsg">message for comparison</param>
        /// <param name="rMsg">message to be compared with</param>
        /// <returns>result of comparison</returns>
        private int CompareMsgBasedOnType(LegacyParserMessage lMsg, LegacyParserMessage rMsg)
        {
            return lMsg.Type.CompareTo(rMsg.Type);
        }
    }

    public class TestSecretEncryptor : IServiceSecretEncryptor
    {
        const string dummySecretsEncryptionThumbprint = "123456378570545808024949949";
        public string EncryptSecret(string secretToBeEncrypted)
        {
            return secretToBeEncrypted;
        }

        public string GetSecretsEncryptionThumbprint()
        {
            return dummySecretsEncryptionThumbprint;
        }
    }

    #endif
}