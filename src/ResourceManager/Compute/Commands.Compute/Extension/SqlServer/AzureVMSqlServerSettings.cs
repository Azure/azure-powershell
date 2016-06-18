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

using System.Security;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Storage settings to configure storage on SQL VM
    /// </summary>
    public class AzureVMSqlServerSettings
    {
        /// <summary>
        /// The imageOffer name
        /// </summary>
        public string ImageOffer { get; set; }

        /// <summary>
        /// The imageOfferSku name
        /// </summary>
        public string ImageOfferSku { get; set; }

        /// <summary>
        /// The ImageVersion name
        /// </summary>
        public string ImageVersion { get; set; }
    }
}
