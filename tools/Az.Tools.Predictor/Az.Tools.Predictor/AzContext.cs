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
        private const string InternalUserSuffix = "@microsoft.com";
        private static readonly Version DefaultVersion = new Version("0.0.0.0");

        /// <inheritdoc/>
        public Version AzVersion { get; private set; } = DefaultVersion;

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
        public bool IsInternal { get; internal set; }

        /// <summary>
        /// The survey session id appended to the survey.
        /// </summary>
        /// <remarks>
        /// We only collect this information in the preview and it'll be removed in GA. That's why it's not defined in the
        /// interface IAzContext and it's internal.
        /// </remarks>
        internal string SurveyId { get; set; }

        /// <inheritdoc/>
        public void UpdateContext()
        {
            AzVersion = GetAzVersion();
            RawUserId = GetUserAccountId();
            UserId = GenerateSha256HashString(RawUserId);

            if (!IsInternal)
            {
                IsInternal = RawUserId.EndsWith(AzContext.InternalUserSuffix, StringComparison.OrdinalIgnoreCase);
            }
        }

        internal string RawUserId { get; set; }

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
        /// Gets the latest version from the loaded Az modules.
        /// </summary>
        private Version GetAzVersion()
        {
            Version latestAz = DefaultVersion;

            try
            {
                var outputs = AzContext.ExecuteScript<PSObject>("Get-Module -Name Az -ListAvailable");
                foreach (PSObject obj in outputs)
                {
                    string psVersion = obj.Properties["Version"].Value.ToString();
                    int pos = psVersion.IndexOf('-');
                    Version currentAz = (pos == -1) ? new Version(psVersion) : new Version(psVersion.Substring(0, pos));
                    if (currentAz > latestAz)
                    {
                        latestAz = currentAz;
                    }
                }
            }
            catch (Exception)
            {
            }

            return latestAz;
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
        /// Get the MAC address of the default NIC, or null if none can be found.
        /// </summary>
        /// <returns>The MAC address of the defautl nic, or null if none is found.</returns>
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
