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

using Azure.Security.KeyVault.Administration;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Represents the result of probing an EKM connection (vendor/product metadata),
    /// returned by <c>Test-AzKeyVaultEkmConnection</c>.
    /// </summary>
    public class PSKeyVaultEkmProxyInfo
    {
        /// <summary>
        /// Name of the Managed HSM the connection belongs to.
        /// </summary>
        public string HsmName { get; set; }

        /// <summary>
        /// API version reported by the EKM proxy.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Vendor of the EKM proxy.
        /// </summary>
        public string ProxyVendor { get; set; }

        /// <summary>
        /// Name of the EKM proxy.
        /// </summary>
        public string ProxyName { get; set; }

        /// <summary>
        /// Vendor of the external key manager.
        /// </summary>
        public string EkmVendor { get; set; }

        /// <summary>
        /// Product name of the external key manager.
        /// </summary>
        public string EkmProduct { get; set; }

        public PSKeyVaultEkmProxyInfo() { }

        public PSKeyVaultEkmProxyInfo(EkmProxyInfo info, string hsmName = null)
        {
            if (info != null)
            {
                ApiVersion = info.ApiVersion;
                ProxyVendor = info.ProxyVendor;
                ProxyName = info.ProxyName;
                EkmVendor = info.EkmVendor;
                EkmProduct = info.EkmProduct;
            }
            HsmName = hsmName;
        }
    }
}
