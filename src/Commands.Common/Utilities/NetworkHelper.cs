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

using System.Linq;
using System.Net.NetworkInformation;

namespace Microsoft.WindowsAzure.Commands.Common.Utilities
{
    /// <summary>
    /// Network helper using the .Net NetworkInterface library
    /// </summary>
    public class NetworkHelper : INetworkHelper
    {
        /// <summary>
        /// Get the MAC address of the default NIC, or null if none can be found
        /// </summary>
        /// <returns>The MAC address of the defautl nic, or null if noen is found</returns>
        public string GetMACAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces()?
                                    .FirstOrDefault(nic => nic != null &&
                                                           nic.OperationalStatus == OperationalStatus.Up &&
                                                           !string.IsNullOrWhiteSpace(nic.GetPhysicalAddress()?.ToString()))?
                                    .GetPhysicalAddress()?.ToString();
        }
    }
}
