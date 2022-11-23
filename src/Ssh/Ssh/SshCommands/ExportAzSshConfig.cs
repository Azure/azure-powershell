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
using Microsoft.Azure.Commands.Ssh.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Ssh
{   
    [Cmdlet("Export",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshConfig",
        DefaultParameterSetName = InteractiveParameterSet)]
    [OutputType(typeof(PSSshConfigEntry))]
    public sealed class ExportAzSshConfig : SshBaseCmdlet
    {
        #region Supress Enter-AzVM Parameters
        public override string[] SshArgument
        {
            get
            {
                return null;
            }
        }

        public override SwitchParameter PassThru
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties
        internal string RelayInfoPath { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ValidateParameters();
            SetResourceType();

            ProgressRecord record = new ProgressRecord(0, "Export Azure SSH Config", "Initialize Setup");
            UpdateProgressBar(record, "Preparing to create SSH Config", 0);

            if (!IsArc() && !ParameterSetName.Equals(IpAddressParameterSet))
            {
                GetVmIpAddress();
                UpdateProgressBar(record, "Retrieved target IP address", 50);
            }
            if (IsArc())
            {
                proxyPath = GetClientSideProxy();
                UpdateProgressBar(record, $"Downloaded proxy to {proxyPath}", 25);
                GetRelayInformation();
                UpdateProgressBar(record, "Retrieved relay information", 50);
                CreateRelayInfoFile();
                UpdateProgressBar(record, "Created file containing relay information", 65);
            }
            if (LocalUser == null)
            {
                PrepareAadCredentials(GetKeysDestinationFolder());
                UpdateProgressBar(record, "Generated Certificate File", 90);
                WriteWarning($"Generated AAD Certificate {CertificateFile} is valid until {GetCertificateExpirationTimes()} in local time.");
            }

            PSSshConfigEntry entry = 
                new PSSshConfigEntry(CreateConfigDict());

            try
            {
                StreamWriter configSW = new StreamWriter(ConfigFilePath, !Overwrite);
                configSW.WriteLine(entry.ConfigString);
                configSW.Close();
            }
            catch (System.Exception exception)
            {
                // Write Object to pipeline even if writing to the actual file fails.
                WriteObject(entry);
                throw new AzPSIOException($"Failed to write to file {ConfigFilePath} with error: {exception.Message}");
            }

            record.RecordType = ProgressRecordType.Completed;
            UpdateProgressBar(record, "Successfully wrote SSH config file", 100);

            WriteObject(entry);
        }

        #region Private Methods

        private Dictionary<string, string> CreateConfigDict()
        {
            Dictionary<string, string> Config = new Dictionary<string, string>();
            if (ResourceGroupName != null && Name != null) { Config.Add("Host", $"{ResourceGroupName}-{Name}"); }
            else { Config.Add("Host", Ip); }

            if (IsArc())
            {
                Config.Add("HostName", Name);
                Config.Add("ProxyCommand", $"\"{proxyPath}\" -r \"{RelayInfoPath}\"");
                if (Port != null)
                    Config["ProxyCommand"] = Config["ProxyCommand"] + $" -p {Port}";
            }
            else
            {
                Config.Add("Port", Port);
                if (Ip != null) { Config.Add("HostName", Ip); }
                else { Config.Add("HostName", "*"); }
            }

            Config.Add("User", LocalUser);
            Config.Add("CertificateFile", CertificateFile);
            Config.Add("IdentityFile", PrivateKeyFile);
            Config.Add("ResourceType", ResourceType);

            if (deleteCert) { Config.Add("LoginType", "AAD"); }
            else { Config.Add("LoginType", "LocalUser"); }
            
            return Config;
        }

        private void CreateRelayInfoFile()
        {
            string relayInfoDir = GetKeysDestinationFolder();
            Directory.CreateDirectory(relayInfoDir);

            string relayInfoFilename = ResourceGroupName + "-" + Name + "-relay_info";
            RelayInfoPath = Path.Combine(relayInfoDir, relayInfoFilename);
            DeleteFile(RelayInfoPath);
            StreamWriter relaySW = new StreamWriter(RelayInfoPath);
            relaySW.WriteLine(relayInfo);
            relaySW.Close();

            string expiration = RelayInformationUtils.GetRelayInfoExpiration(relayInformationResource);
            if (!string.IsNullOrEmpty(expiration))
                WriteWarning($"Generated relay information file {RelayInfoPath} is valid until {expiration} in local time.");
            else
                WriteWarning($"Generated relay information file {RelayInfoPath}");
        }

        private string GetKeysDestinationFolder()
        {
            if (KeysDestinationFolder == null)
            {
                string configFolder = Path.GetDirectoryName(ConfigFilePath);
                string keysFolderName = Ip;
                if (ResourceGroupName != null && Name != null)
                {
                    keysFolderName = ResourceGroupName + "-" + Name;
                }

                // If user provides -Ip *, treat this as a special case on Windows.
                if (keysFolderName.Equals("*"))
                {
                    keysFolderName = "all_ips";
                }

                // Make sure that the folder name doesn't have illegal characters
                char[] invalidCharacters = Path.GetInvalidFileNameChars();
                string regexString = "[" + Regex.Escape(new string(invalidCharacters)) + "]";
                Regex containsInvalidCharacter = new Regex(regexString);
                if (containsInvalidCharacter.IsMatch(keysFolderName))
                {
                    // Remove invalid characters, and make sure new name is still valid as a folder name.
                    foreach(char character in invalidCharacters)
                    {
                        keysFolderName = keysFolderName.Replace(character.ToString(), string.Empty);
                    }
                    if (string.IsNullOrEmpty(keysFolderName))
                    {
                        throw new AzPSInvalidOperationException("Unable to create default keys destination folder. Please provide a valid path using -KeysDestinationFolder.");
                    }
                }
            
                return Path.Combine(configFolder, "az_ssh_config", keysFolderName);
            }

            return KeysDestinationFolder;
        }

        #endregion
    }
}
