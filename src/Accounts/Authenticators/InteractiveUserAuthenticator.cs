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

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensibility;

namespace Microsoft.Azure.PowerShell.Authenticators
{
    /// <summary>
    /// Authenticator for user interactive authentication
    /// </summary>
    public class InteractiveUserAuthenticator : DelegatingAuthenticator
    {
        // possible ports for adfs: [8405, 8408)
        // worked with stack team to pre-configure this in their deployment
        private const int AdfsPortStart = 8405;
        private const int AdfsPortEnd = 8408;
        // possible ports for aad: [8400, 9000)
        private const int AadPortStart = 8400;
        private const int AadPortEnd = 9000;

        public override Task<IAccessToken> Authenticate(AuthenticationParameters parameters, CancellationToken cancellationToken)
        {
            var interactiveParameters = parameters as InteractiveParameters;
            var onPremise = interactiveParameters.Environment.OnPremise;
            var authenticationClientFactory = interactiveParameters.AuthenticationClientFactory;
            IPublicClientApplication publicClient = null;
            var resource = interactiveParameters.Environment.GetEndpoint(interactiveParameters.ResourceId);
            var scopes = AuthenticationHelpers.GetScope(onPremise, resource);

            try
            {
                var replyUrl = GetReplyUrl(onPremise, interactiveParameters);

                if (!string.IsNullOrEmpty(replyUrl))
                {
                    var clientId = AuthenticationHelpers.PowerShellClientId;
                    var authority = onPremise ?
                                        interactiveParameters.Environment.ActiveDirectoryAuthority :
                                        AuthenticationHelpers.GetAuthority(parameters.Environment, parameters.TenantId);
                    TracingAdapter.Information(string.Format("[InteractiveUserAuthenticator] Creating IPublicClientApplication - ClientId: '{0}', Authority: '{1}', ReplyUrl: '{2}' UseAdfs: '{3}'", clientId, authority, replyUrl, onPremise));
                    publicClient = authenticationClientFactory.CreatePublicClient(clientId: clientId, authority: authority, redirectUri: replyUrl, useAdfs: onPremise);
                    TracingAdapter.Information(string.Format("[InteractiveUserAuthenticator] Calling AcquireTokenInteractive - Scopes: '{0}'", string.Join(",", scopes)));
                    var interactiveResponse = publicClient.AcquireTokenInteractive(scopes)
                        .WithCustomWebUi(new CustomWebUi())
                        .ExecuteAsync(cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    return AuthenticationResultToken.GetAccessTokenAsync(interactiveResponse);
                }
            }
            catch
            {
                interactiveParameters.PromptAction("Unable to authenticate using interactive login. Defaulting back to device code flow.");
            }

            return null;
        }

        private string GetReplyUrl(bool onPremise, InteractiveParameters interactiveParameters)
        {
            return string.Format("http://localhost:{0}", GetReplyUrlPort(onPremise, interactiveParameters));
        }

        private int GetReplyUrlPort(bool onPremise, InteractiveParameters interactiveParameters)
        {
            int portStart = onPremise ? AdfsPortStart : AadPortStart;
            int portEnd = onPremise ? AdfsPortEnd : AadPortEnd;

            int port = portStart;
            TcpListener listener = null;

            do
            {
                try
                {
                    listener = new TcpListener(IPAddress.Loopback, port);
                    listener.Start();
                    listener.Stop();
                    return port;
                }
                catch (Exception ex)
                {
                    interactiveParameters.PromptAction(string.Format("Port {0} is taken with exception '{1}'; trying to connect to the next port.", port, ex.Message));
                    listener?.Stop();
                }
            }
            while (++port < portEnd);

            throw new Exception("Cannot find an open port.");
        }

        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return (parameters as InteractiveParameters) != null;
        }
    }
}
