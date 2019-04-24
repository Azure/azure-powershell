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
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Security;
using System.Security.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Properties;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    /// <summary>
    /// A token provider that uses ADAL to retrieve
    /// tokens from Azure Active Directory for user
    /// credentials.
    /// </summary>
    internal class UserTokenProvider : ITokenProvider
    {
        public UserTokenProvider()
        {
        }

        public IAccessToken GetAccessToken(
            AdalConfiguration config,
            string promptBehavior,
            Action<string> promptAction,
            string userId,
            SecureString password,
            string credentialType)
        {
            if (credentialType != AzureAccount.AccountType.User)
            {
                throw new ArgumentException(string.Format(Resources.InvalidCredentialType, "User"), "credentialType");
            }

            return new AdalAccessToken(AcquireToken(config, promptAction, userId, password), this, config);
        }

        private readonly static TimeSpan expirationThreshold = TimeSpan.FromMinutes(5);

        private bool IsExpired(AdalAccessToken token)
        {
#if DEBUG
            if (Environment.GetEnvironmentVariable("FORCE_EXPIRED_ACCESS_TOKEN") != null)
            {
                return true;
            }
#endif
            var expiration = token.AuthResult.ExpiresOn;
            var currentTime = DateTimeOffset.UtcNow;
            var timeUntilExpiration = expiration - currentTime;
            TracingAdapter.Information(Resources.UPNTokenExpirationCheckTrace, expiration, currentTime, expirationThreshold,
                timeUntilExpiration);
            return timeUntilExpiration < expirationThreshold;
        }

        private void Renew(AdalAccessToken token)
        {
            TracingAdapter.Information(
                Resources.UPNRenewTokenTrace,
                token.AuthResult.AccessTokenType,
                token.AuthResult.ExpiresOn,
                true,
                token.AuthResult.TenantId,
                token.UserId);

            var user = token.AuthResult.UserInfo;
            if (user != null)
            {
                TracingAdapter.Information(
                    Resources.UPNRenewTokenUserInfoTrace,
                    user.DisplayableId,
                    user.FamilyName,
                    user.GivenName,
                    user.IdentityProvider,
                    user.UniqueId);
            }
            if (IsExpired(token))
            {
                TracingAdapter.Information(Resources.UPNExpiredTokenTrace);
                AuthenticationResult result = AcquireToken(token.Configuration, null, token.UserId, null, true);

                if (result == null)
                {
                    throw new AuthenticationException(Resources.ExpiredRefreshToken);
                }
                else
                {
                    token.AuthResult = result;
                }
            }
        }

        private AuthenticationContext CreateContext(AdalConfiguration config)
        {
            return new AuthenticationContext(config.AdEndpoint + config.AdDomain,
                config.ValidateAuthority, config.TokenCache);
        }

        // We have to run this in a separate thread to guarantee that it's STA. This method
        // handles the threading details.
        private AuthenticationResult AcquireToken(AdalConfiguration config, Action<string> promptAction,
            string userId, SecureString password, bool renew = false)
        {
            AuthenticationResult result = null;
            Exception ex = null;
            result = SafeAquireToken(config, promptAction, userId, password, out ex);
            if (ex != null)
            {
                var adex = ex as AdalException;
                if (adex != null)
                {
                    if (adex.ErrorCode == AdalError.AuthenticationCanceled)
                    {
                        throw new AadAuthenticationCanceledException(adex.Message, adex);
                    }
                }
                if (ex is AadAuthenticationException)
                {
                    throw ex;
                }
                throw new AadAuthenticationFailedException(GetExceptionMessage(ex), ex);
            }

            return result;
        }

        private AuthenticationResult SafeAquireToken(
            AdalConfiguration config,
            Action<string> promptAction,
            string userId,
            SecureString password,
            out Exception ex)
        {
            try
            {
                ex = null;

                return DoAcquireToken(config, userId, password, promptAction);
            }
            catch (AdalException adalEx)
            {
                if (adalEx.ErrorCode == AdalError.UserInteractionRequired ||
                    adalEx.ErrorCode == AdalError.MultipleTokensMatched)
                {
                    string message = Resources.AdalUserInteractionRequired;
                    if (adalEx.ErrorCode == AdalError.MultipleTokensMatched)
                    {
                        message = Resources.AdalMultipleTokens;
                    }

                    ex = new AadAuthenticationFailedWithoutPopupException(message, adalEx);
                }
                else if (adalEx.ErrorCode == AdalError.MissingFederationMetadataUrl ||
                         adalEx.ErrorCode == AdalError.FederatedServiceReturnedError)
                {
                    ex = new AadAuthenticationFailedException(Resources.CredentialOrganizationIdMessage, adalEx);
                }
                else
                {
                    ex = adalEx;
                }
            }
            catch (Exception threadEx)
            {
                ex = threadEx;
            }
            return null;
        }

        private AuthenticationResult DoAcquireToken(
            AdalConfiguration config,
            string userId,
            SecureString password,
            Action<string> promptAction,
            bool renew = false)
        {
            AuthenticationResult result;
            var context = CreateContext(config);

            TracingAdapter.Information(
                Resources.UPNAcquireTokenContextTrace,
                context.Authority,
                context.CorrelationId,
                context.ValidateAuthority);
            TracingAdapter.Information(
                Resources.UPNAcquireTokenConfigTrace,
                config.AdDomain,
                config.AdEndpoint,
                config.ClientId,
                config.ClientRedirectUri);
            if (promptAction == null || renew)
            {
                result =context.AcquireTokenSilentAsync(config.ResourceClientUri, config.ClientId,
                    new UserIdentifier(userId, UserIdentifierType.OptionalDisplayableId))
                    .ConfigureAwait(false).GetAwaiter().GetResult();
            }
            else if (string.IsNullOrEmpty(userId) || password == null)
            {
                var code = context.AcquireDeviceCodeAsync(config.ResourceClientUri, config.ClientId)
                    .ConfigureAwait(false).GetAwaiter().GetResult();
                promptAction(code?.Message);

                result = context.AcquireTokenByDeviceCodeAsync(code)
                    .ConfigureAwait(false).GetAwaiter().GetResult();
            }
            else
            {
                    UserCredential credential = new UserCredential(userId);
                    result = context.AcquireTokenAsync(config.ResourceClientUri, config.ClientId, credential)
                        .ConfigureAwait(false).GetAwaiter().GetResult();
            }

            return result;
        }

        private string GetExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
            {
                message += ": " + ex.InnerException.Message;
            }
            return message;
        }

        public IAccessToken GetAccessTokenWithCertificate(AdalConfiguration config, string principalId, string certificateThumbprint, string credentialType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementation of <see cref="IRenewableToken"/> using data from ADAL
        /// </summary>
        private class AdalAccessToken : IRenewableToken
        {
            internal readonly AdalConfiguration Configuration;
            internal AuthenticationResult AuthResult;
            private readonly UserTokenProvider tokenProvider;

            public AdalAccessToken(AuthenticationResult authResult, UserTokenProvider tokenProvider, AdalConfiguration configuration)
            {
                AuthResult = authResult;
                this.tokenProvider = tokenProvider;
                Configuration = configuration;
            }

            public void AuthorizeRequest(Action<string, string> authTokenSetter)
            {
                tokenProvider.Renew(this);
                authTokenSetter(AuthResult.AccessTokenType, AuthResult.AccessToken);
            }

            public string AccessToken { get { return AuthResult.AccessToken; } }

            public string UserId { get { return AuthResult.UserInfo.DisplayableId; } }

            public string TenantId { get { return AuthResult.TenantId; } }

            public string LoginType
            {
                get
                {
                    if (AuthResult.UserInfo.IdentityProvider != null)
                    {
                        return Common.Authentication.LoginType.LiveId;
                    }
                    return Common.Authentication.LoginType.OrgId;
                }
            }

            public DateTimeOffset ExpiresOn { get { return AuthResult.ExpiresOn; } }
        }
    }
}
