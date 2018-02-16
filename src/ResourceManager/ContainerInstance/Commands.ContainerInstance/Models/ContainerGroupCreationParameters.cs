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
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Azure.Management.ContainerInstance.Models;

namespace Microsoft.Azure.Commands.ContainerInstance.Models
{
    /// <summary>
    /// Container group creation parameters.
    /// </summary>
    public class ContainerGroupCreationParameters
    {
        /// <summary>
        /// Azure container registry server suffix.
        /// </summary>
        private const string AcrServerSuffix = ".azurecr.io/";

        /// <summary>
        /// The default OS type.
        /// </summary>
        public const string DefaultOsType = OperatingSystemTypes.Linux;

        /// <summary>
        /// The default ports.
        /// </summary>
        public static readonly int[] DefaultPorts = new int[] { 80 };

        /// <summary>
        /// The default CPU.
        /// </summary>
        public const double DefaultCpu = 1.0;
        
        /// <summary>
        /// The default memory.
        /// </summary>
        public const double DefaultMemory = 1.5;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the OS type.
        /// </summary>
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets the restart policy.
        /// </summary>
        public string RestartPolicy { get; set; }

        /// <summary>
        /// Gets or sets the IP address type.
        /// </summary>
        public string IpAddressType { get; set; }

        /// <summary>
        /// Gets or sets the DNS name label.
        /// </summary>
        public string DnsNameLabel { get; set; }

        /// <summary>
        /// Gets or sets the ports.
        /// </summary>
        public int[] Ports { get; set; }

        /// <summary>
        /// Gets or sets the container image.
        /// </summary>
        public string ContainerImage { get; set; }

        /// <summary>
        /// Gets or sets the container command.
        /// </summary>
        public IList<string> ContainerCommand { get; set; }

        /// <summary>
        /// Gets or sets the environment variables.
        /// </summary>
        public IDictionary<string, string> EnvironmentVariables { get; set; }

        /// <summary>
        /// Gets or sets the CPU.
        /// </summary>
        public double Cpu { get; set; }

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        public double MemoryInGb { get; set; }

        /// <summary>
        /// Gets or sets the container registry server.
        /// </summary>
        public string RegistryServer { get; set; }

        /// <summary>
        /// Gets or sets the container registry username.
        /// </summary>
        public string RegistryUsername { get; set; }

        /// <summary>
        /// Gets or sets the container registry password.
        /// </summary>
        public string RegistryPassword { get; set; }

        /// <summary>
        /// Gets or sets the Azure File volume share name.
        /// </summary>
        public string AzureFileVolumeShareName { get; set; }

        /// <summary>
        /// Gets or sets the Azure File volume storage account name.
        /// </summary>
        public string AzureFileVolumeAccountName { get; set; }

        /// <summary>
        /// Gets or sets the Azure File volume storage account key.
        /// </summary>
        public string AzureFileVolumeAccountKey { get; set; }

        /// <summary>
        /// Gets or sets the Azure File volume mount path.
        /// </summary>
        public string AzureFileVolumeMountPath { get; set; }

        /// <summary>
        /// Validates the creation parameters.
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Location))
            {
                throw new ArgumentException("Please specify Location");
            }

            if (!string.IsNullOrEmpty(this.RegistryServer))
            {
                if (string.IsNullOrEmpty(this.RegistryUsername) || string.IsNullOrEmpty(this.RegistryPassword))
                {
                    throw new ArgumentException("Please specify valid RegistryCredential");
                }
            }
            else if (this.ContainerImage.Contains(ContainerGroupCreationParameters.AcrServerSuffix))
            {
                if (string.IsNullOrEmpty(this.RegistryUsername) || string.IsNullOrEmpty(this.RegistryPassword))
                {
                    throw new ArgumentException("Please specify valid RegistryCredential");
                }

                var acrServer = ParseRegistryServer();

                if (string.IsNullOrEmpty(acrServer))
                {
                    throw new ArgumentException("Failed to Azure Container Registry server, please specify RegistryServer explicitly");
                }

                this.RegistryServer = acrServer;
            }

            if (!string.IsNullOrWhiteSpace(this.AzureFileVolumeMountPath) && this.AzureFileVolumeMountPath.Contains(":"))
            {
                throw new ArgumentException("Azure File volume mount path must not contain ':'");
            }
        }

        /// <summary>
        /// Parse ACR server.
        /// </summary>
        private string ParseRegistryServer()
        {
            var parsedImage = this.ContainerImage
                .ToLowerInvariant()
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parsedImage.Any())
            {
                return parsedImage[0];
            }

            return null;
        }

        public static string ConvertToString(SecureString secureString)
        {
            if (secureString == null)
            {
                return null;
            }

            IntPtr stringPointer = IntPtr.Zero;
            try
            {
                stringPointer = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(stringPointer);
            }
            finally
            {
                Marshal.ZeroFreeBSTR(stringPointer);
            }
        }
    }
}
