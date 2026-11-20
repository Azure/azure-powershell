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
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.Attestation;
using Microsoft.Azure.Commands.Attestation.Properties;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationDataServiceClient
    {
        internal const string ServiceApiVersion = "2025-06-01";
        internal const string LegacyApiVersion = "2018-09-01-preview";
        internal const string PolicyClaim = "x-ms-policy";
        internal const string AttestationPolicyClaim = "AttestationPolicy";
        internal const string PolicyCertificateClaim = "policyCertificate";
        internal const string LegacyPolicyCertificateClaim = "maa-policyCertificate";

        /// <summary>
        /// Earlier versions of these cmdlets used an API version that called the TPM policy "VBSEnclave".
        /// The current API version calls the same policy "Tpm".
        /// </summary>
        internal const string LegacyVbsEnclaveTee = "VBSEnclave";

        private static readonly HashSet<string> LegacyApiTees = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "AzureGuest", "OpenEnclave", "SevSnpVm", "SgxEnclave", LegacyVbsEnclaveTee, "VSMEnclave"
        };

        private static readonly Regex Base64UrlPattern = new Regex("^[A-Za-z0-9_-]*$", RegexOptions.Compiled);

        private const string AttestationScope = "https://attest.azure.net/.default";
        private const string JwtContentType = "text/plain";
        private const string JsonContentType = "application/json";

        /// <summary>
        /// Allowed difference, in seconds, between the local clock and the attestation service's clock when validating
        /// service tokens. Matches the 5 minute default these cmdlets used before; the SDK default is 5 seconds.
        /// </summary>
        internal const long TokenTimeValidationSlack = 300;

        private readonly Management.Attestation.AttestationManagementClient _attestationControlPlaneClient;
        private readonly IAuthenticationFactory _authFactory;
        private readonly IAzureContext _context;
        private readonly HttpPipelineTransport _transport;
        private readonly Func<string, string, bool, string, string> _dataPlaneUriResolver;
        private TokenCredential _credential;
        private static readonly Dictionary<(string, string), string> DataPlaneUriLookup = new Dictionary<(string, string), string>();
        private static readonly Dictionary<string, string> DefaultProviderDataPlaneUriLookup = new Dictionary<string, string>();

        public AttestationDataServiceClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            if (authFactory == null)
                throw new ArgumentNullException(nameof(authFactory));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (context.Environment == null)
                throw new ArgumentException(nameof(context.Environment));

            _authFactory = authFactory;
            _context = context;
            _attestationControlPlaneClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Attestation.AttestationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// Creates a client that sends requests with the given transport to the endpoint the resolver returns. Used by tests.
        /// </summary>
        internal AttestationDataServiceClient(TokenCredential credential, HttpPipelineTransport transport, Func<string, string, bool, string, string> dataPlaneUriResolver)
        {
            _credential = credential ?? throw new ArgumentNullException(nameof(credential));
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _dataPlaneUriResolver = dataPlaneUriResolver ?? throw new ArgumentNullException(nameof(dataPlaneUriResolver));
        }

        private TokenCredential Credential => _credential ?? (_credential = new AttestationTokenCredential(_authFactory, _context));

        /// <summary>
        /// Receives warnings, such as the use of a deprecated token format.
        /// </summary>
        public Action<string> WarningWriter { get; set; }

        public void SetPolicy(string name, string resourceGroupName, string resourceId, string tee, string userSpecifiedPolicy, string policyFormat)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));
            if (string.IsNullOrEmpty(userSpecifiedPolicy))
                throw new ArgumentNullException(nameof(userSpecifiedPolicy));

            var attestationType = ToServiceAttestationType(tee);

            if (string.IsNullOrEmpty(policyFormat) ||
                SetAzureAttestationPolicy.TextPolicyFormat.Equals(policyFormat, StringComparison.InvariantCultureIgnoreCase))
            {
                SendWriteAndValidate(name, resourceGroupName, endpoint =>
                    SendSdkWrite(endpoint, client => client.SetPolicy(attestationType, userSpecifiedPolicy)));
            }
            else if (SetAzureAttestationPolicy.JwtPolicyFormat.Equals(policyFormat, StringComparison.InvariantCultureIgnoreCase))
            {
                // The policy JWT may already be signed by the caller, so it is sent as is.
                var policyJwt = userSpecifiedPolicy.Trim();
                if (HasUnencodedPolicy(policyJwt))
                {
                    var legacyTee = ToLegacyTee(tee);
                    WriteWarning(Resources.UnencodedPolicyWarning);
                    RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, endpoint =>
                        SetPolicyWithLegacyApi(endpoint, legacyTee, policyJwt));
                }
                else
                {
                    SendWriteAndValidate(name, resourceGroupName, endpoint =>
                        SendCallerToken(endpoint, RequestMethod.Put, $"/policies/{attestationType}", JwtContentType, policyJwt));
                }
            }
            else
            {
                throw new ArgumentException(nameof(policyFormat));
            }
        }

        public void ResetToDefaultPolicy(string name, string resourceGroupName, string resourceId, string tee, string policyJwt)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));

            var attestationType = ToServiceAttestationType(tee);

            if (string.IsNullOrEmpty(policyJwt))
            {
                SendWriteAndValidate(name, resourceGroupName, endpoint =>
                    SendSdkWrite(endpoint, client => client.ResetPolicy(attestationType)));
            }
            else if (HasUnencodedPolicy(policyJwt.Trim()))
            {
                var legacyTee = ToLegacyTee(tee);
                WriteWarning(Resources.UnencodedPolicyWarning);
                RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, endpoint =>
                    SendRequest(endpoint, RequestMethod.Post, "/operations/policy/current", LegacyApiVersion, legacyTee, JwtContentType, policyJwt.Trim()));
            }
            else
            {
                SendWriteAndValidate(name, resourceGroupName, endpoint =>
                    SendCallerToken(endpoint, RequestMethod.Post, $"/policies/{attestationType}:reset", JwtContentType, policyJwt.Trim()));
            }
        }

        public string GetPolicy(string name, string resourceGroupName, string resourceId, string tee, bool isDefaultProvider = false, string location = "")
        {
            if (string.IsNullOrEmpty(tee))
                throw new ArgumentNullException(nameof(tee));

            if (isDefaultProvider && string.IsNullOrEmpty(location))
                throw new ArgumentNullException(nameof(location));

            if (!isDefaultProvider)
            {
                ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            }

            var attestationType = ToServiceAttestationType(tee);

            // The SDK's GetPolicy cannot read a stored policy that is not Base64Url encoded, which earlier API
            // versions accepted, so the policy is read from the validated service token instead.
            var token = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, endpoint =>
            {
                var serviceToken = DeserializeServiceToken(ReadResponseToken(
                    SendRequest(endpoint, RequestMethod.Get, $"/policies/{attestationType}", ServiceApiVersion, null, null, null)));
                ValidateServiceToken(endpoint, serviceToken);
                return serviceToken;
            }, isDefaultProvider, location);

            return GetStringClaim(token, PolicyClaim);
        }

        public string GetPolicySigners(string name, string resourceGroupName, string resourceId, bool isDefaultProvider = false, string location = "")
        {
            if (isDefaultProvider && string.IsNullOrEmpty(location))
                throw new ArgumentNullException(nameof(location));

            if (!isDefaultProvider)
            {
                ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            }

            var response = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, endpoint =>
                ValidateServiceToken(endpoint, CreateAdministrationClient(endpoint).GetPolicyManagementCertificates()), isDefaultProvider, location);

            return response.Token.Serialize();
        }

        public string AddPolicySigner(string name, string resourceGroupName, string resourceId, string signer)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(signer))
                throw new ArgumentNullException(nameof(signer));

            if (UsesLegacyPolicyCertificateClaim(signer))
            {
                WriteWarning(Resources.LegacyPolicyCertificateClaimWarning);
                return SendWriteAndValidate(name, resourceGroupName, endpoint => ReadLegacyResponseToken(
                    SendRequest(endpoint, RequestMethod.Put, "/operations/policy/certificates", LegacyApiVersion, null, JsonContentType, CreatePolicyCertificateContent(signer)))).Serialize();
            }

            SendWriteAndValidate(name, resourceGroupName, endpoint =>
                SendCallerToken(endpoint, RequestMethod.Post, "/certificates:add", JsonContentType, CreatePolicyCertificateContent(signer)));

            // The current API version's response describes only the changed certificate, so the signers are read again.
            return ReadPolicySignersAfterChange(name, resourceGroupName);
        }

        public string RemovePolicySigner(string name, string resourceGroupName, string resourceId, string signer)
        {
            ValidateCommonParameters(ref name, ref resourceGroupName, resourceId);
            if (string.IsNullOrEmpty(signer))
                throw new ArgumentNullException(nameof(signer));

            if (UsesLegacyPolicyCertificateClaim(signer))
            {
                WriteWarning(Resources.LegacyPolicyCertificateClaimWarning);
                return SendWriteAndValidate(name, resourceGroupName, endpoint => ReadLegacyResponseToken(
                    SendRequest(endpoint, RequestMethod.Post, "/operations/policy/certificates", LegacyApiVersion, null, JsonContentType, CreatePolicyCertificateContent(signer)))).Serialize();
            }

            SendWriteAndValidate(name, resourceGroupName, endpoint =>
                SendCallerToken(endpoint, RequestMethod.Post, "/certificates:remove", JsonContentType, CreatePolicyCertificateContent(signer)));

            return ReadPolicySignersAfterChange(name, resourceGroupName);
        }

        #region Internal helpers

        internal static AttestationType ToServiceAttestationType(string tee)
        {
            return string.Equals(tee, LegacyVbsEnclaveTee, StringComparison.OrdinalIgnoreCase)
                ? AttestationType.Tpm
                : new AttestationType(tee);
        }

        /// <summary>
        /// Gets the TEE name the earlier API version uses, which accepts tokens in formats the current API version rejects.
        /// </summary>
        internal static string ToLegacyTee(string tee)
        {
            if (string.Equals(tee, AttestationType.Tpm.ToString(), StringComparison.OrdinalIgnoreCase))
                return LegacyVbsEnclaveTee;
            if (LegacyApiTees.Contains(tee))
                return tee;

            throw new ArgumentException(string.Format(Resources.UnencodedPolicyNotSupported, tee));
        }

        /// <summary>
        /// Whether the caller's signer token uses the claim name of the earlier API version.
        /// The token is only inspected to choose the API; the service verifies its signature.
        /// </summary>
        internal static bool UsesLegacyPolicyCertificateClaim(string signerJwt)
        {
            var body = TryReadTokenBody(signerJwt);
            return body != null && body[LegacyPolicyCertificateClaim] != null && body[PolicyCertificateClaim] == null;
        }

        /// <summary>
        /// Whether the caller's policy token contains a policy that is not Base64Url encoded, which only the earlier API version accepts.
        /// The token is only inspected to choose the API; the service verifies its signature.
        /// </summary>
        internal static bool HasUnencodedPolicy(string policyJwt)
        {
            var policy = TryReadTokenBody(policyJwt)?[AttestationPolicyClaim];
            if (policy == null || policy.Type != JTokenType.String)
                return false;

            var value = policy.ToString();
            return value.Length > 0 && !Base64UrlPattern.IsMatch(value);
        }

        internal static JObject TryReadTokenBody(string jwt)
        {
            try
            {
                var parts = jwt.Trim().Split('.');
                return parts.Length < 2 ? null : JObject.Parse(Base64Url.DecodeString(parts[1]));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// The policy certificate operations take the caller's signed JWT as a JSON string.
        /// </summary>
        internal static string CreatePolicyCertificateContent(string signer)
        {
            return JsonConvert.SerializeObject(signer.Trim());
        }

        internal static string GetStringClaim(AttestationToken token, string claim)
        {
            var body = JObject.Parse(Encoding.UTF8.GetString(token.TokenBodyBytes.ToArray()));
            return body[claim]?.ToString();
        }

        /// <summary>
        /// Reads the token in a response from the current API version, which returns it in a JSON object.
        /// </summary>
        /// <exception cref="MissingServiceTokenException">The response is not JSON or contains no token.</exception>
        internal static string ReadResponseToken(string responseBody)
        {
            string token;
            try
            {
                token = JObject.Parse(responseBody)["token"]?.ToString();
            }
            catch (Exception ex)
            {
                throw new MissingServiceTokenException(ex);
            }

            if (string.IsNullOrEmpty(token))
                throw new MissingServiceTokenException();
            return token;
        }

        /// <summary>
        /// Reads the token in a response from the earlier API version, which returns the token as a JSON string.
        /// </summary>
        internal static AttestationToken ReadLegacyResponseToken(string responseBody)
        {
            try
            {
                var token = responseBody?.Trim();
                if (token != null && token.StartsWith("\"", StringComparison.Ordinal))
                    token = JsonConvert.DeserializeObject<string>(token);
                if (string.IsNullOrEmpty(token))
                    throw new MissingServiceTokenException();
                return AttestationToken.Deserialize(token);
            }
            catch (Exception ex) when (!(ex is MissingServiceTokenException))
            {
                throw new MissingServiceTokenException(ex);
            }
        }

        internal static RestException ToRestException(RequestFailedException exception)
        {
            var errorDetails = $"Operation returned HTTP Status Code {exception.Status}";
            var responseBody = exception.GetRawResponse()?.Content?.ToString();

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

            return new RestException(errorDetails, exception);
        }

        #endregion

        #region Private helper methods

        private AttestationAdministrationClient CreateAdministrationClient(string endpoint, HttpPipelinePolicy perCallPolicy = null)
        {
            return new AttestationAdministrationClient(new Uri(endpoint), Credential, CreateClientOptions(perCallPolicy));
        }

        /// <summary>
        /// The SDK clients don't validate service tokens; every token is validated by <see cref="ValidateServiceToken"/>,
        /// so validation failures can be told apart from other failures. Azure.Core doesn't send a request again
        /// after a successful response, see <see cref="NoRetryAfterSuccessfulResponsePolicy"/>.
        /// </summary>
        private AttestationClientOptions CreateClientOptions(HttpPipelinePolicy perCallPolicy = null)
        {
            var options = new AttestationClientOptions(tokenOptions: new AttestationTokenValidationOptions { ValidateToken = false });
            if (_transport != null)
                options.Transport = _transport;
            if (perCallPolicy != null)
                options.AddPolicy(perCallPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(new NoRetryAfterSuccessfulResponsePolicy(), HttpPipelinePosition.PerRetry);
            return options;
        }

        /// <summary>
        /// Sends a token created by the caller, which may be signed with the caller's own key, and returns the token
        /// the service returns. The SDK's convenience methods for these operations take a signing key instead.
        /// </summary>
        private AttestationToken SendCallerToken(string endpoint, RequestMethod method, string path, string contentType, string content)
        {
            var responseBody = SendRequest(endpoint, method, path, ServiceApiVersion, null, contentType, content);
            return DeserializeServiceToken(ReadResponseToken(responseBody));
        }

        /// <exception cref="MissingServiceTokenException">The token is not a JSON Web Token.</exception>
        private static AttestationToken DeserializeServiceToken(string token)
        {
            try
            {
                return AttestationToken.Deserialize(token);
            }
            catch (Exception ex)
            {
                throw new MissingServiceTokenException(ex);
            }
        }

        /// <summary>
        /// Sends a write and validates the token the service returns. The token is validated after the retry, so a
        /// failure while validating it, such as a failed request for the provider's signing certificates, doesn't
        /// send the write again.
        /// </summary>
        /// <exception cref="UnconfirmedChangeException">The service accepted the write, but the response token is
        /// missing or could not be validated.</exception>
        private AttestationToken SendWriteAndValidate(string name, string resourceGroupName, Func<string, AttestationToken> write)
        {
            string endpoint;
            AttestationToken token;
            try
            {
                (endpoint, token) = RefreshUriCacheAndRetryOnFailure(name, resourceGroupName, e => (e, write(e)));
            }
            catch (MissingServiceTokenException ex)
            {
                throw new UnconfirmedChangeException(ex);
            }

            try
            {
                ValidateServiceToken(endpoint, token);
            }
            catch (Exception ex)
            {
                throw new UnconfirmedChangeException(ex);
            }

            return token;
        }

        /// <summary>
        /// Reads the policy signers after the service accepted a change to them.
        /// </summary>
        /// <exception cref="UnconfirmedChangeException">The signers could not be read.</exception>
        private string ReadPolicySignersAfterChange(string name, string resourceGroupName)
        {
            try
            {
                return GetPolicySigners(name, resourceGroupName, null);
            }
            catch (Exception ex)
            {
                throw new UnconfirmedChangeException(ex);
            }
        }

        /// <summary>
        /// Sends a policy write with the SDK and returns the token from the service's response. The SDK fails with an
        /// unrelated exception, such as a NullReferenceException, when a successful response has no valid token; that
        /// failure is reported as a missing token. Failures before a successful response, such as failing to get an
        /// access token, are not changed.
        /// </summary>
        private AttestationToken SendSdkWrite<T>(string endpoint, Func<AttestationAdministrationClient, AttestationResponse<T>> write) where T : class
        {
            var responseStatus = new ResponseStatusPolicy();
            try
            {
                return write(CreateAdministrationClient(endpoint, responseStatus)).Token;
            }
            catch (Exception ex) when (responseStatus.ReceivedSuccessfulResponse && !IsRequestFailure(ex))
            {
                throw new MissingServiceTokenException(ex);
            }
        }

        /// <summary>
        /// Records whether the service returned a successful response. Added before the SDK's authentication policy,
        /// so it sees only responses the service actually returned.
        /// </summary>
        private sealed class ResponseStatusPolicy : HttpPipelineSynchronousPolicy
        {
            public bool ReceivedSuccessfulResponse { get; private set; }

            public override void OnReceivedResponse(HttpMessage message)
            {
                ReceivedSuccessfulResponse = message.HasResponse && !message.Response.IsError;
            }
        }

        /// <summary>
        /// Sets a policy with the earlier API version, the same way earlier versions of this cmdlet did: the service
        /// prepares the policy update, the update token is validated, and the service then applies it.
        /// </summary>
        private object SetPolicyWithLegacyApi(string endpoint, string legacyTee, string policyJwt)
        {
            var updateToken = ReadLegacyResponseToken(
                SendRequest(endpoint, RequestMethod.Post, "/operations/policy/updatepolicy", LegacyApiVersion, legacyTee, JwtContentType, policyJwt));

            ValidateServiceToken(endpoint, updateToken);
            return SendRequest(endpoint, RequestMethod.Put, "/operations/policy/current", LegacyApiVersion, legacyTee, JwtContentType, updateToken.Serialize());
        }

        private string SendRequest(string endpoint, RequestMethod method, string path, string apiVersion, string legacyTee, string contentType, string content)
        {
            var pipeline = HttpPipelineBuilder.Build(CreateClientOptions(), new BearerTokenAuthenticationPolicy(Credential, AttestationScope));

            using (HttpMessage message = pipeline.CreateMessage())
            {
                var request = message.Request;
                request.Method = method;
                request.Uri.Reset(new Uri(endpoint));
                request.Uri.AppendPath(path, false);
                request.Uri.AppendQuery("api-version", apiVersion, true);
                if (legacyTee != null)
                    request.Uri.AppendQuery("tee", legacyTee, true);
                request.Headers.SetValue("Accept", JsonContentType);
                if (content != null)
                {
                    request.Headers.SetValue("Content-Type", contentType);
                    request.Content = RequestContent.Create(BinaryData.FromString(content));
                }

                pipeline.Send(message, CancellationToken.None);

                var response = message.Response;
                if (response.IsError)
                    throw new RequestFailedException(response);

                return response.Content.ToString();
            }
        }

        private AttestationResponse<T> ValidateServiceToken<T>(string endpoint, AttestationResponse<T> response) where T : class
        {
            ValidateServiceToken(endpoint, response.Token);
            return response;
        }

        /// <summary>
        /// Checks that a token is signed by the provider, was issued by it, and is within its validity period.
        /// </summary>
        /// <exception cref="ServiceTokenValidationException">The token is not valid.</exception>
        private void ValidateServiceToken(string endpoint, AttestationToken token)
        {
            IReadOnlyList<AttestationSigner> signers;
            try
            {
                signers = new AttestationClient(new Uri(endpoint), Credential, CreateClientOptions()).GetSigningCertificates().Value;
            }
            catch (RequestFailedException ex)
            {
                throw ToRestException(ex);
            }

            var validationOptions = new AttestationTokenValidationOptions { ExpectedIssuer = endpoint, TimeValidationSlack = TokenTimeValidationSlack };
            bool isValid;
            try
            {
                isValid = token.ValidateToken(validationOptions, signers);
            }
            // The SDK reports validation failures, such as an unknown signer or issuer, as System.Exception.
            catch (Exception ex) when (ex.GetType() == typeof(Exception))
            {
                throw new ServiceTokenValidationException(ex.Message, ex);
            }

            if (!isValid)
                throw new ServiceTokenValidationException(string.Empty);
        }

        private void WriteWarning(string message)
        {
            WarningWriter?.Invoke(message);
        }

        private void ValidateCommonParameters(ref string name, ref string resourceGroupName, string resourceId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var parsedResourceId = new Microsoft.Azure.Management.Internal.Resources.Utilities.Models.ResourceIdentifier(resourceId);
                name = parsedResourceId.ResourceName;
                resourceGroupName = parsedResourceId.ResourceGroupName;
            }

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(resourceGroupName))
                throw new ArgumentNullException(nameof(resourceGroupName));
        }

        private string GetDataPlaneUri(string name, string resourceGroupName, bool isDefaultProvider, string location, bool refreshCache)
        {
            if (_dataPlaneUriResolver != null)
                return _dataPlaneUriResolver(name, resourceGroupName, isDefaultProvider, location);

            if (isDefaultProvider)
            {
                if (refreshCache)
                    DefaultProviderDataPlaneUriLookup.Remove(location);

                if (!DefaultProviderDataPlaneUriLookup.ContainsKey(location))
                {
                    var response = _attestationControlPlaneClient.AttestationProviders.GetDefaultByLocation(location);
                    DefaultProviderDataPlaneUriLookup[location] = response.AttestUri.TrimEnd('/');
                }

                return DefaultProviderDataPlaneUriLookup[location];
            }

            if (refreshCache)
                DataPlaneUriLookup.Remove((name, resourceGroupName));

            if (!DataPlaneUriLookup.ContainsKey((name, resourceGroupName)))
            {
                var response = _attestationControlPlaneClient.AttestationProviders.Get(resourceGroupName, name);
                DataPlaneUriLookup[(name, resourceGroupName)] = response.AttestUri.TrimEnd('/');
            }

            return DataPlaneUriLookup[(name, resourceGroupName)];
        }

        /// <summary>
        /// 
        /// NOTE: Callers of this method must ensure that the service call is idempotent.
        /// 
        /// It's possible that the client deletes and recreates the same attestation provider name in
        /// a different region during a single PowerShell session.  When this happens, we need to
        /// discard our cached URI for the attestation provider and re-fetch it.
        /// 
        /// The call is retried only when the request itself failed. A failure after the service responded
        /// successfully, such as a response that can't be read or a token that fails validation, is not retried,
        /// because for a write the service has already applied the change.
        /// 
        /// </summary>
        private T RefreshUriCacheAndRetryOnFailure<T>(string name, string resourceGroupName, Func<string, T> idempotentServiceCall, bool isDefaultProvider = false, string location = "")
        {
            string cachedEndpoint = null;
            try
            {
                cachedEndpoint = GetDataPlaneUri(name, resourceGroupName, isDefaultProvider, location, false);
            }
            catch (Exception)
            {
                // Ignore this exception on purpose, since the provider's URI is looked up again below
            }

            if (cachedEndpoint != null)
            {
                try
                {
                    return idempotentServiceCall(cachedEndpoint);
                }
                catch (Exception ex) when (IsRequestFailure(ex))
                {
                    // Ignore this exception on purpose, since we'll retry below
                }
                catch (AggregateException ex) when (FindUnreadableResponse(ex) != null)
                {
                    throw FindUnreadableResponse(ex);
                }
            }

            try
            {
                return idempotentServiceCall(GetDataPlaneUri(name, resourceGroupName, isDefaultProvider, location, true));
            }
            catch (RequestFailedException ex)
            {
                throw ToRestException(ex);
            }
            catch (AggregateException ex) when (FindUnreadableResponse(ex) != null)
            {
                throw FindUnreadableResponse(ex);
            }
        }

        /// <summary>
        /// Whether a request failed without a successful response: the service returned an error status, or the
        /// request couldn't be sent, which Azure.Core reports as an AggregateException after its own retries. An
        /// AggregateException that includes a successful response that couldn't be read is not a request failure.
        /// </summary>
        private static bool IsRequestFailure(Exception exception)
        {
            return exception is RequestFailedException ||
                (exception is AggregateException aggregate && FindUnreadableResponse(aggregate) == null);
        }

        /// <summary>
        /// Azure.Core reports a successful response that couldn't be read inside an AggregateException when an earlier
        /// attempt failed and was retried.
        /// </summary>
        private static UnreadableServiceResponseException FindUnreadableResponse(AggregateException exception)
        {
            return exception.InnerExceptions.OfType<UnreadableServiceResponseException>().FirstOrDefault();
        }

        #endregion
    }
}
