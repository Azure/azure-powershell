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
using Microsoft.Azure.Commands.Common.Authentication;

using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    /// <summary>
    /// OpenID configuration doc parser
    /// </summary>
    public interface IOpenIDConfiguration
    {
        /// <summary>
        /// Get async Issuer of a OpenID configuration doc from server.
        /// </summary>
        /// <param name="httpOperationsFactory">HTTP client factory to retrieve OpenID configuration from server.</param>
        Task<string> GetIssuerAsync(IHttpOperationsFactory httpOperationsFactory);

        /// <summary>
        /// Tenant Id parsed from OpenID configuration doc
        /// </summary>
        string TenantId
        {
            get;
        }

        /// <summary>
        /// Uri to retrieve the OpenID configuration doc.
        /// </summary>
        string AbsoluteUri
        {
            get;
        }

        /// <summary>
        /// OpenID configuration doc in Json format
        /// </summary>
        string OpenIDConfigDoc
        {
            get;
        }
    }
}
