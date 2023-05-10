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

using System.Text;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Ssh.Models
{
    /// <summary>
    /// Class that represents an Ssh Configuration file to connect to Azure Resources.
    /// </summary>
    public class PSSshConfigEntry
    {
        /// <summary>
        /// Alias of the host in the config file.
        /// If we know Resource Name and Resource Group, host will be "{rg}-{name}"
        /// If we only know the Ip, host will be "{Ip}"
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Actual host name. Ip address for Azure VMs and resource name for arc servers.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Username.
        /// </summary>
        public string User { get; set; }
        
        /// <summary>
        /// Path to certificate file.
        /// </summary>
        public string CertificateFile { get; set; }

        /// <summary>
        /// Path to private key file.
        /// </summary>
        public string IdentityFile { get; set; }

        /// <summary>
        /// Microsoft.HybridCompute/machines or Microsoft.Compute/virtualMachines.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Command to connect to host via Arc Connectivity Proxy.
        /// </summary>
        public string ProxyCommand { get; set; }

        /// <summary>
        /// Ssh Port.
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Either AAD or LocalUser
        /// </summary>
        public string LoginType { get; set; }

        /// <summary>
        /// String built from the value of this object's properties.
        /// Note 1: If LocalUser login, "-{localusername}" is appended to host.
        /// Note 2: Azure VMs have two entries if resource name and group are known.
        ///         One with {rg}-{name} as host, and one with {ip} as host.
        /// </summary>
        public string ConfigString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(string.Empty);
                if (LoginType.Equals("AAD")) { builder.AppendLine($"Host {this.Host}"); }
                else { builder.AppendLine($"Host {this.Host}-{this.User}"); }

                if (!HostName.Equals(Host))
                {
                    builder.AppendLine($"\tHostName {this.HostName}");
                }
                builder.AppendLine(string.Format("\tUser {0}", this.User));
                this.AppendKeyValuePairToStringBuilderIfNotValueNull("CertificateFile", $"\"{this.CertificateFile}\"", builder);
                this.AppendKeyValuePairToStringBuilderIfNotValueNull("IdentityFile", $"\"{this.IdentityFile}\"", builder);
                this.AppendKeyValuePairToStringBuilderIfNotValueNull("Port", this.Port, builder);
                this.AppendKeyValuePairToStringBuilderIfNotValueNull("ProxyCommand", this.ProxyCommand, builder);

                if (ResourceType.Equals("Microsoft.Compute/virtualMachines") && !HostName.Equals(Host))
                {
                    if (LoginType.Equals("AAD")) { builder.AppendLine($"\nHost {this.HostName}"); }
                    else { builder.AppendLine($"\nHost {this.HostName}-{this.User}"); }
                    
                    builder.AppendLine(string.Format("\tUser {0}", this.User));
                    this.AppendKeyValuePairToStringBuilderIfNotValueNull("CertificateFile", $"\"{this.CertificateFile}\"", builder);
                    this.AppendKeyValuePairToStringBuilderIfNotValueNull("IdentityFile", $"\"{this.IdentityFile}\"", builder);
                    this.AppendKeyValuePairToStringBuilderIfNotValueNull("Port", this.Port, builder);
                }

                return builder.ToString();
            }
        }

        public PSSshConfigEntry(Dictionary<string, string> configEntry)
        {
            this.Host = GetPropertyValueFromConfigDictionary(configEntry, "Host");
            this.HostName = GetPropertyValueFromConfigDictionary(configEntry, "HostName");
            this.ProxyCommand = GetPropertyValueFromConfigDictionary(configEntry, "ProxyCommand");
            this.Port = GetPropertyValueFromConfigDictionary(configEntry, "Port");
            this.User = GetPropertyValueFromConfigDictionary(configEntry, "User");
            this.IdentityFile = GetPropertyValueFromConfigDictionary(configEntry, "IdentityFile");
            this.CertificateFile = GetPropertyValueFromConfigDictionary(configEntry, "CertificateFile");
            this.ResourceType = GetPropertyValueFromConfigDictionary(configEntry, "ResourceType");
            this.LoginType = GetPropertyValueFromConfigDictionary(configEntry, "LoginType");
        }

        private string GetPropertyValueFromConfigDictionary(Dictionary<string, string> configEntry, string KeyName)
        {
            if (configEntry.ContainsKey(KeyName))
            {
                return configEntry[KeyName];
            }
            return null;
        }

        private void AppendKeyValuePairToStringBuilderIfNotValueNull(string key, string value, StringBuilder builder)
        {
            if (value != null)
            {
                if ((key.Equals("CertificateFile") || key.Equals("IdentityFile")) && value.Equals("\"\"")) { return; }
                builder.AppendLine($"\t{key} {value}");
            }
        }

        public override string ToString()
        {
            return this.ConfigString;
        }
    }

}
