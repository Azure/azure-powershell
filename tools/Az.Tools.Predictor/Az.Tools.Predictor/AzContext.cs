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

using System.Management.Automation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    using PowerShell = System.Management.Automation.PowerShell;

    /// <summary>
    /// The class for the current Azure PowerShell context.
    /// </summary>
    internal sealed class AzContext : IAzContext
    {
        private static readonly Version DefaultVersion = new Version("0.0.0.0");

        /// <inheritdoc/>
        public string UserId { get; private set; } = string.Empty;

        private string _macAddress;
        /// <inheritdoc/>
        public string MacAddress
        {
            get
            {
                if (_macAddress == null)
                {
                    _macAddress = string.Empty;

                    var macAddress = GetMACAddress();
                    if (!string.IsNullOrWhiteSpace(macAddress))
                    {
                        _macAddress = GenerateSha256HashString(macAddress)?.Replace("-", string.Empty).ToLowerInvariant();
                    }
                }

                return _macAddress;
            }
        }

        /// <inheritdoc/>
        public string OSVersion
        {
            get
            {
                return Environment.OSVersion.ToString();
            }
        }

        private Version _powerShellVersion;
        /// <inheritdoc/>
        public Version PowerShellVersion
        {
            get
            {
                if (_powerShellVersion == null)
                {
                    var outputs = AzContext.ExecuteScript<Version>("(Get-Host).Version");

                    _powerShellVersion = outputs.FirstOrDefault();
                }

                return _powerShellVersion ?? AzContext.DefaultVersion;
            }
        }

        private Version _moduleVersion;
        /// <inheritdoc/>
        public Version ModuleVersion
        {
            get
            {
                if (_moduleVersion == null)
                {
                    _moduleVersion = this.GetType().Assembly.GetName().Version;
                }

                return _moduleVersion ?? AzContext.DefaultVersion;
            }
        }

        /// <inheritdoc/>
        public void UpdateContext()
        {
            UserId = GenerateSha256HashString(GetUserAccountId());
        }

        /// <summary>
        /// Gets the user account id if the user logs in, otherwise empty string.
        /// </summary>
        private string GetUserAccountId()
        {
            try
            {
                var output = AzContext.ExecuteScript<string>("(Get-AzContext).Account.Id");
                return output.FirstOrDefault() ?? string.Empty;
            }
            catch (Exception)
            {
            }

            return string.Empty;
        }

        /// <summary>
        /// Executes the PowerShell cmdlet in the current powershell session.
        /// </summary>
        private static List<T> ExecuteScript<T>(string contents)
        {
            List<T> output = new List<T>();

            using (PowerShell powershell = PowerShell.Create(RunspaceMode.NewRunspace))
            {
                powershell.AddScript(contents);
                Collection<T> result = powershell.Invoke<T>();

                if (result != null && result.Count > 0)
                {
                    output.AddRange(result);
                }
            }

            return output;
        }

        /// <summary>
        /// Generate a SHA256 Hash string from the originInput.
        /// </summary>
        /// <param name="originInput"></param>
        /// <returns>The Sha256 hash, or empty if the input is only whitespace</returns>
        private static string GenerateSha256HashString(string originInput)
        {
            if (string.IsNullOrWhiteSpace(originInput))
            {
                return string.Empty;
            }

            string result = string.Empty;
            try
            {
                using (var sha256 = new SHA256CryptoServiceProvider())
                {
                    var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(originInput));
                    result = BitConverter.ToString(bytes);
                }
            }
            catch
            {
                // do not throw if CryptoProvider is not provided
            }

            return result;
        }

        /// <summary>
        /// Get the MAC address of the default NIC, or null if none can be found
        /// </summary>
        /// <returns>The MAC address of the defautl nic, or null if none is found</returns>
        private static string GetMACAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces()?
                                    .FirstOrDefault(nic => nic != null &&
                                                           nic.OperationalStatus == OperationalStatus.Up &&
                                                           !string.IsNullOrWhiteSpace(nic.GetPhysicalAddress()?.ToString()))?
                                    .GetPhysicalAddress()?.ToString();
        }
    }
}
