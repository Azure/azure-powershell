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

namespace Microsoft.AzureStack.Commands.Security
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Specialized;
    using System.Management.Automation;
    using System.Net;

    /// <summary>
    /// Get Token Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.Token, ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = "ADFS")]
    public class GetToken : Cmdlet
    {
        //// TODO: Some of these properties are configurable in customer environments; resolve design

        /// <summary>
        /// The cmdlet behavior.
        /// </summary>
        private const PromptBehavior CmdletBehavior = PromptBehavior.Always;

        /// <summary>
        /// Indicates whether to validate the authority.
        /// </summary>
        private const bool ValidateAuthority = false;

        /// <summary>
        /// The authority template URI.
        /// </summary>
        private static readonly UriTemplate AuthorityTemplateUri = new UriTemplate("/{authority_type}/");

        /// <summary>
        /// The authority bindings.
        /// </summary>
        private static readonly NameValueCollection AuthorityBindings = new NameValueCollection()
        {
            { "authority_type", "adfs" }
        };

        /// <summary>
        /// The redirect URI.
        /// </summary>
        private static readonly Uri NoOpRedirectUri = new Uri(SharedConstants.AzureStackPowerShell.RedirectUri);

        /// <summary>
        /// Gets or sets URI of the issuing authority.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0)]
        [ValidateNotNull]
        public string Authority { get; set; }

        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        [Parameter(ParameterSetName = "AAD", Mandatory = true)]
        [ValidateNotNull]
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets credentials used to request access token.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public PSCredential Credential { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to disable certificate validation.
        /// </summary>
        [Parameter]
        public SwitchParameter DisableCertificateValidation { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            var originalValidateCallback = ServicePointManager.ServerCertificateValidationCallback;
            AuthenticationResult result;

            try
            {
                // TODO (bryanr) - Evaluate if this should be removed entirely
                if (this.DisableCertificateValidation)
                {
                    this.WriteWarning(Resources.WarningDisableCertificateValidation);
                    ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                }

                this.Resource = this.Resource ?? SharedConstants.ResourceManager.ClientId;
                this.ClientId = this.ClientId ?? SharedConstants.AzureStackPowerShell.ClientId;

                if (this.IsInteractiveTokenRequest())
                {
                    result = this.GetSecurityTokenWithInteractiveFlow();
                }
                else
                {
                    result = this.GetSecurityTokenWithNonInteractiveFlow();
                }
            }
            finally
            {
                if (this.DisableCertificateValidation)
                {
                    ServicePointManager.ServerCertificateValidationCallback = originalValidateCallback;
                }
            }

            // Write the object to the pipeline only after the certificate validation callback has been restored.
            // This will prevent other cmdlets in the pipeline from inheriting this security vulnerability.
            this.WriteObject(result.AccessToken);
        }

        /// <summary>
        /// Gets the security token with non interactive flow.
        /// </summary>
        private AuthenticationResult GetSecurityTokenWithNonInteractiveFlow()
        {
            var uriString = this.BuildAuthorityUriString();
            var userCredential = new UserCredential(this.Credential.UserName, this.Credential.Password);
            var result = default(AuthenticationResult);

            if (this.IsRequestForAadToken())
            {
                var context = new AuthenticationContext(authority: uriString, validateAuthority: ValidateAuthority);
                result = context.AcquireToken(resource: this.Resource, clientId: this.ClientId, userCredential: userCredential);
            }
            else
            {
                // NOTE: This is a case of using non-public APIs of ADAL.NET via reflection to acquire token (not officially supported by ADAL.NET team).
                result = AuthenticationContextExtensions.AcquireTokenForAdfs(authority: uriString, resource: this.Resource, clientId: this.ClientId, userCredential: userCredential);
            }
            return result;
        }

        /// <summary>
        /// Determines whether this is an interactive token request.
        /// </summary>
        private bool IsInteractiveTokenRequest()
        {
            return this.Credential == null;
        }

        /// <summary>
        /// Gets the security token with interactive flow.
        /// </summary>
        private AuthenticationResult GetSecurityTokenWithInteractiveFlow()
        {
            var uriString = this.BuildAuthorityUriString();
            var context = new AuthenticationContext(authority: uriString, validateAuthority: ValidateAuthority);
            var result = context.AcquireToken(resource: this.Resource, clientId: this.ClientId, redirectUri: NoOpRedirectUri, promptBehavior: CmdletBehavior);
            return result;
        }

        /// <summary>
        /// Builds the authority URI string.
        /// </summary>
        private string BuildAuthorityUriString()
        {
            var baseAddressUri = new Uri(this.Authority);

            if (this.IsRequestForAadToken())
            {
                return new UriTemplate("/{tenant_id}/").BindByPosition(baseAddressUri, this.AadTenantId).OriginalString;
            }
            else
            {
                return AuthorityTemplateUri.BindByName(baseAddressUri, AuthorityBindings).OriginalString;
            }
        }

        /// <summary>
        /// Determines whether we are retrieving a token for AAD.
        /// </summary>
        private bool IsRequestForAadToken()
        {
            return !string.IsNullOrEmpty(this.AadTenantId);
        }

    }
}
