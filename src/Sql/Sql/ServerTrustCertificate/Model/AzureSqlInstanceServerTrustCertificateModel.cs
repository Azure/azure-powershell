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

namespace Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model
{
    public class AzureSqlInstanceServerTrustCertificateModel
    {
        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets managed instance name
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets certificate id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets certificate type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets certificate name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets certificate thumbprint
        /// </summary>
        public string Thumbprint { get; set; }

        /// <summary>
        /// Gets or sets certificate public key
        /// </summary>
        public string PublicKey { get; set; }
    }
}
