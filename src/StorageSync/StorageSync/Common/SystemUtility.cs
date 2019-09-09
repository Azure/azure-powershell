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

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    using System;
    using System.Net;
    using System.Net.NetworkInformation;

    /// <summary>
    /// Helper class for handling all registry related operations.
    /// </summary>
    public static class SystemUtility
    {
        /// <summary>
        /// Gets the name of the machine.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string GetMachineName()
        {
            var machineName = string.Empty;

            try
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

                if (ipGlobalProperties != null)
                {
                    string hostName = Dns.GetHostName();

                    string domainNameSuffix = $".{ipGlobalProperties.DomainName}";

                    if (!hostName.EndsWith(domainNameSuffix, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(ipGlobalProperties.DomainName))
                    {
                        hostName += domainNameSuffix;
                    }

                    machineName = hostName;
                }
            }
            catch (Exception)
            {
                machineName = Environment.MachineName;
            }

            return machineName;
        }

    }
}