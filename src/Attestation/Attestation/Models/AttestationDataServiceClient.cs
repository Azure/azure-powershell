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
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Attestation;
using Microsoft.Azure.Attestation.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationDataServiceClient
    {
        private readonly Management.Attestation.AttestationManagementClient _attestationControlPlaneClient;
        private readonly AttestationClient _attestationDataPlaneClient;
        private static readonly Dictionary<(string, string), string> DataPlaneUriLookup = new Dictionary<(string, string), string>();
        private const string DefaultResetPolicy = "eyJhbGciOiJub25lIn0..";

        public AttestationDataServiceClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Environment == null)
                throw new ArgumentException(nameof(context.Environment));

            ServiceClientCredentials clientCredentials = authFactory.GetServiceClientCredentials(context, AzureEnvironment.ExtendedEndpoint.AzureAttestationServiceEndpointResourceId);
            _attestationDataPlaneClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<AttestationClient>(clientCredentials);
            _attestationControlPlaneClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Attestation.AttestationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public void SetPolicy(string name, string resourceGroupName, string resourceId, string tee, string policyJwt)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));
            if (string.IsNullOrEmpty(policyJwt))
                throw new ArgumentNullException(nameof(policyJwt));

            // Step #1 - Ask service to prepare to set policy
            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) => 
                _attestationDataPlaneClient.Policy.PrepareToSetWithHttpMessagesAsync(tenantUri, tee, policyJwt).Result);
            ThrowOn4xxErrors(serviceCallResult);

            // Step #2 - Validate service response locally
            string policyUpdateJwt = serviceCallResult.Body.ToString();
            var validatedToken = PolicyValidationHelper.ValidateAttestationServiceToken(name, DataPlaneUriLookup[(name, resourceGroupName)], policyUpdateJwt);
            if (!validatedToken.IsValid)
                throw new ArgumentException("policyJwt is not valid");

            // Step #3 - Ask service to set policy
            serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) => 
                _attestationDataPlaneClient.Policy.SetWithHttpMessagesAsync(tenantUri, tee, policyUpdateJwt).Result);
            ThrowOn4xxErrors(serviceCallResult);
        }

        public void ResetToDefaultPolicy(string name, string resourceGroupName, string resourceId, string tee, string policyJwt)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));

            string resetPolicy = string.IsNullOrEmpty(policyJwt) ? DefaultResetPolicy : policyJwt;
            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) => 
                _attestationDataPlaneClient.Policy.ResetWithHttpMessagesAsync(tenantUri, tee, resetPolicy).Result);
            ThrowOn4xxErrors(serviceCallResult);
        }

        public string  GetPolicy(string name, string resourceGroupName, string resourceId, string tee)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));

            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) =>
                _attestationDataPlaneClient.Policy.GetWithHttpMessagesAsync(tenantUri, tee).Result);
            ThrowOn4xxErrors(serviceCallResult);

            return ((AttestationPolicy)serviceCallResult.Body).Policy;
        }

        public string GetPolicySigners(string name, string resourceGroupName, string resourceId)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);

            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) =>
                _attestationDataPlaneClient.PolicyCertificates.GetWithHttpMessagesAsync(tenantUri).Result);
            ThrowOn4xxErrors(serviceCallResult);

            return (string)serviceCallResult.Body;
        }

        public string AddPolicySigner(string name, string resourceGroupName, string resourceId, string signer)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);

            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) =>
                _attestationDataPlaneClient.PolicyCertificates.AddWithHttpMessagesAsync(tenantUri, signer).Result);
            ThrowOn4xxErrors(serviceCallResult);

            return (string)serviceCallResult.Body;
        }

        public string RemovePolicySigner(string name, string resourceGroupName, string resourceId, string signer)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);

            AzureOperationResponse<object> serviceCallResult = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, (tenantUri) =>
                _attestationDataPlaneClient.PolicyCertificates.RemoveWithHttpMessagesAsync(tenantUri, signer).Result);
            ThrowOn4xxErrors(serviceCallResult);

            return (string)serviceCallResult.Body;
        }

        #region Private helper methods

        private void ValidateCommonParameters(ref string name, ref string resourceGroupName, string resourceId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var parsedResourceId = new ResourceIdentifier(resourceId);
                name = parsedResourceId.ResourceName;
                resourceGroupName = parsedResourceId.ResourceGroupName;
            }

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(resourceGroupName))
                throw new ArgumentNullException(nameof(resourceGroupName));
        }

        private string GetDataPlaneUri(string name, string resourceGroupName, bool refreshCache)
        {
            if (refreshCache)
                DataPlaneUriLookup.Remove((name, resourceGroupName));

            if (!DataPlaneUriLookup.ContainsKey((name, resourceGroupName)))
            {
                var response = _attestationControlPlaneClient.AttestationProviders.Get(resourceGroupName, name);
                DataPlaneUriLookup[(name, resourceGroupName)] = response.AttestUri.TrimEnd('/');
            }

            return DataPlaneUriLookup[(name, resourceGroupName)];
        }

        private void ThrowOn4xxErrors(AzureOperationResponse<object> result)
        {
            int statusCode = (int) result.Response.StatusCode;

            if (statusCode >= 400 && statusCode <= 499)
            {
                var responseBody = result.Response.Content.ReadAsStringAsync().Result;
                var errorDetails = $"Operation returned HTTP Status Code {statusCode}";

                // Include response body as either parsed ServerError or string
                if (!string.IsNullOrEmpty(responseBody))
                {
                    try
                    {
                        var error = JsonConvert.DeserializeObject<ServerError>(responseBody).Error;
                        errorDetails += $"\n\rCode: {error.Code}\n\rMessage: {error.Message}\n\r";
                    }
                    catch (Exception)
                    {
                        errorDetails += $"\n\rResponse Body: {responseBody}\n\r";
                    }
                }
                throw new RestException(errorDetails);
            }
        }

        /// <summary>
        /// 
        /// NOTE: Callers of this method must ensure that the service call is idempotent.
        /// 
        /// It's possible that the client deletes and recreates the same attestation provider name in
        /// a different region during a single PowerShell session.  When this happens, we need to
        /// discard our cached URI for the attestation provider and re-fetch it.
        /// 
        /// </summary>
        private AzureOperationResponse<object> RefreshUriCacheAndRetryOnFailure(string name, string resourceGroupName, Func<string, AzureOperationResponse<object>> idempotentServiceCall)
        {
            bool shouldRetry = false;
            AzureOperationResponse<object> serviceCallResult = null;

            try
            {
                string tenantUri = GetDataPlaneUri(name, resourceGroupName, false);
                serviceCallResult = idempotentServiceCall(tenantUri);
                if ((int) serviceCallResult.Response.StatusCode >= 400)
                    shouldRetry = true;
            }
            catch (Exception)
            {
                // Ignore this exception on purpose, since we'll retry below
                shouldRetry = true;
            }

            if (shouldRetry)
            {
                string tenantUri = GetDataPlaneUri(name, resourceGroupName, true);
                serviceCallResult = idempotentServiceCall(tenantUri);
            }

            return serviceCallResult;
        }

        #endregion
    }
}
