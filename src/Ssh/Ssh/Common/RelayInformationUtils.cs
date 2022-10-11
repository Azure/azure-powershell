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
using System.Text;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity;
using Microsoft.Azure.PowerShell.Cmdlets.Ssh.AzureClients;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.PowerShell.Ssh.Helpers.HybridConnectivity.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.Ssh.Common
{
    internal class RelayInformationUtils
    {
        #region Fields
        private HybridConnectivityClient _hyridConnectivityClient;
        private IAzureContext _context;
        #endregion

        #region Properties
        private HybridConnectivityClient HybridConnectivityClient
        {
            get
            {
                if (_hyridConnectivityClient == null)
                {
                    _hyridConnectivityClient = new HybridConnectivityClient(_context);
                }
                return _hyridConnectivityClient;
            }
        }

        private IEndpointsOperations EndpointsClient
        {
            get
            {
                return HybridConnectivityClient.HybridConectivityManagementClient.Endpoints;
            }
        }
        #endregion

        public RelayInformationUtils(IAzureContext context)
        {
            _context = context;
        }

        #region Internal Methods
        public EndpointAccessResource GetRelayInformation(string rgName, string vmName, out string exceptionMessage)
        {
            // Make this not hardcoded in the future.
            string id = $"/subscriptions/{_context.Subscription.Id}/resourceGroups/{rgName}/providers/Microsoft.HybridCompute/machines/{vmName}";
            return GetRelayInformation(id, out exceptionMessage);
        }
        
        internal EndpointAccessResource GetRelayInformation(string id, out string exceptionMessage)
        {
            exceptionMessage = "";
            System.Net.HttpStatusCode code;

            EndpointAccessResource cred = CallListCredentials(id, out code);

            if (cred == null &&
                code == System.Net.HttpStatusCode.NotFound &&
                CreateDefaultEndpoint(id, out exceptionMessage))
            {
                cred = CallListCredentials(id, out code);
            }

            if (cred == null && string.IsNullOrEmpty(exceptionMessage))
            {
                exceptionMessage = $"ListCredentials operation failed with error code '{code.ToString()}'.";
            }

            return cred;
        }
        #endregion

        #region Private Methods
        private EndpointAccessResource CallListCredentials(
            string id,
            out System.Net.HttpStatusCode code)
        {
            try
            {
                var result = EndpointsClient.ListCredentialsWithHttpMessagesAsync(id, "default", 3600)
                    .GetAwaiter().GetResult();
                code = result.Response.StatusCode;
                if (result.Response.IsSuccessStatusCode) { return result.Body; }
            }
            catch (ErrorResponseException exception)
            {
                code = exception.Response.StatusCode;
                return null;
            }

            return null;
        }

        private bool CreateDefaultEndpoint(string id, out string exceptionMessage)
        {
            exceptionMessage = "";

            try
            {
                EndpointResource endpoint = new EndpointResource("default", id);
                var result = EndpointsClient.CreateOrUpdateWithHttpMessagesAsync(id, "default", endpoint)
                    .GetAwaiter().GetResult();

                if (result.Response.IsSuccessStatusCode) { return true; }

            }
            catch (ErrorResponseException exception)
            {
                exceptionMessage = $"Unable to create default endpoint for the target Arc Server with error: {exception}. " +
                    $"Contact Owner/Contributor of the resource.";
            }

            return false;
        }

        public string GetRelayInfoExpiration(EndpointAccessResource cred)
        {
            if (cred != null && cred.ExpiresOn != null)
            {
                long expiresOn = (long)cred.ExpiresOn;
                string relayExpiration = DateTimeOffset.FromUnixTimeSeconds(expiresOn).DateTime.ToLocalTime().ToString();
                return relayExpiration;
            }
            return null;
        }

        public string ConvertEndpointAccessToBase64String(EndpointAccessResource cred)
        {
            if (cred == null) { return null; }

            string relayString = "{\"relay\": {" +
                $"\"namespaceName\": \"{cred.NamespaceName}\", " +
                $"\"namespaceNameSuffix\": \"{cred.NamespaceNameSuffix}\", " +
                $"\"hybridConnectionName\": \"{cred.HybridConnectionName}\", " +
                $"\"accessKey\": \"{cred.AccessKey}\", " +
                $"\"expiresOn\": {cred.ExpiresOn}" +
                "}}";

            var bytes = Encoding.UTF8.GetBytes(relayString);
            var encodedString = Convert.ToBase64String(bytes);

            return encodedString;
        }
        #endregion

    }
}
