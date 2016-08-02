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

namespace Microsoft.Azure.Commands.Scheduler.Models
{
    public class PSHttpJobAuthenticationParams
    {
        /// <summary>
        /// Gets or sets http authentication type. (None, Basic, ClientCertificate, ActiveDirectoryOAuth)
        /// </summary>
        public string HttpAuthType { get; set; }

        #region ClientCertificate Authentication
        
        /// <summary>
        /// Gets or sets client certificate pfx.
        /// </summary>
        public string ClientCertPfx { get; set; }

        /// <summary>
        /// Gets or sets client certificate password.
        /// </summary>
        public string ClientCertPassword { get; set; }

        #endregion

        #region Basic Authentication

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region ActiveDirectoryOAuth Authentication

        /// <summary>
        /// Gets or sets secrect.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets TenantId.
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets Audience.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        public string ClientId { get; set; }

        #endregion


    }
}
