//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class PsApiManagementIdentityProvider : PsApiManagementArmResource
    {
        public PsApiManagementIdentityProviderType Type { get; set; }

        /// <summary>
        /// Gets or sets client Id of the Application in the external Identity
        /// Provider. It is App ID for Facebook login, Client ID for Google
        /// login, App ID for Microsoft.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets client secret of the Application in external Identity
        /// Provider, used to authenticate login request. For example, it is
        /// App Secret for Facebook login, API Key for Google login, Public Key
        /// for Microsoft.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets list of Allowed Tenants when configuring Azure Active
        /// Directory login.
        /// </summary>
        public string[] AllowedTenants { get; set; }

        /// <summary>
        /// Gets or sets openID Connect discovery endpoint hostname for AAD or
        /// AAD B2C.
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets signup Policy Name. Only applies to AAD B2C Identity
        /// Provider.
        /// </summary>
        public string SignupPolicyName { get; set; }

        /// <summary>
        /// Gets or sets signin Policy Name. Only applies to AAD B2C Identity
        /// Provider.
        /// </summary>
        public string SigninPolicyName { get; set; }

        /// <summary>
        /// Gets or sets profile Editing Policy Name. Only applies to AAD B2C
        /// Identity Provider.
        /// </summary>
        public string ProfileEditingPolicyName { get; set; }

        /// <summary>
        /// Gets or sets password Reset Policy Name. Only applies to AAD B2C
        /// Identity Provider.
        /// </summary>
        public string PasswordResetPolicyName { get; set; }

        /// <summary>
        /// Gets or sets the SignIn Tenant to override the `common` AAD Tenant
        /// configuration.
        /// </summary>
        public string SigninTenant { get; set; }
    }
}