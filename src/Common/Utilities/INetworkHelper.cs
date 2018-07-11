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

namespace Microsoft.WindowsAzure.Commands.Common.Utilities
{
    /// <summary>
    /// Environment helper to allow mocking the network interface
    /// </summary>
    public interface INetworkHelper
    {
        /// <summary>
        /// Get the mac address of the default nic
        /// </summary>
        /// <returns>A string respresnting the MAC address of the defualt nic, 
        /// or null if none is found</returns>
        string GetMACAddress();
    }
}
