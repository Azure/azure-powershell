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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.KeyVault.Client.Authentication;
using Microsoft.Azure.Commands.KeyVault.Client.Protocol;
using Microsoft.Azure.Commands.KeyVault.WebKey;
using Newtonsoft.Json;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Client
{
    /// <summary>
    /// Contains the KMS supported cryptographic key operations, vault operations and signing
    /// </summary>
    /// <remarks>
    /// Instance methods on this class are not thread safe.
    /// </remarks>
    public class KeyVaultClient
    {
        private const string ApiVersion              = "?api-version=2014-12-08-preview";
        private const string HttpAuthorizationHeader = "Authorization";
        private const string HttpMethodHeader        = "X-HTTP-Method";
        private const string HttpRequestIdHeader     = "client-request-id";
        private const string JsonMediaType           = "application/json";

        /// <summary>
        /// Thread-safe, shared singleton of the JsonSerializer
        /// </summary>
        protected static JsonSerializer _serializer = new JsonSerializer();

        /// <summary>
        /// The authentication callback delegate which is to be implemented by the client codes
        /// </summary>
        /// <param name="authority"> the authority URL </param>
        /// <param name="resource"> resource URL </param>
        /// <param name="scope"> scope </param>
        /// <returns> access token </returns>
        public delegate string AuthenticationCallback(string authority, string resource, string scope);

        /// <summary>
        /// Logs the request that is being sent along with its invocation id
        /// </summary>
        /// <param name="correlationId"> invocation identifier </param>
        /// <param name="request"> request that is sent </param>
        public delegate void SendRequestCallback(string correlationId, HttpRequestMessage request);

        /// <summary>
        /// Logs the response that is received along with its invocation id
        /// </summary>
        /// <param name="correlationId"> invocation identifier </param>
        /// <param name="response"> response that is received </param>
        public delegate void ReceiveResponseCallback(string correlationId, HttpResponseMessage response);

        /// <summary>
        /// Sets request Uri to a different network URI
        /// It is used for development testing.
        /// </summary>
        /// <param name="requestUri"> the request URI </param>
        /// <param name="httpClient"> the http client </param>
        /// <returns> new uri to be used as the target end point </returns>
        public delegate Uri SetRequestUriCallback(Uri requestUri, HttpClient httpClient);

        public event AuthenticationCallback OnAuthenticate     = null;
        public event SendRequestCallback OnSendRequest         = null;
        public event ReceiveResponseCallback OnReceiveResponse = null;
        public event SetRequestUriCallback OnSetRequestUri     = null;

        protected HttpClient _client;

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyVaultClient(HttpClient httpClient = null)
        {
            _client = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationCallback"> the authentication callback </param>
        /// <param name="sendRequestCallback"> the send request callback to log request that is sent </param>
        /// <param name="receiveResponseCallback"> the receive response callback to log response that is received </param>
        /// <param name="httpClient"> customized http client </param>
        /// <param name="setRequestUriCallback"> the callback to replace requst URI with a different URI </param>
        public KeyVaultClient(
            AuthenticationCallback authenticationCallback,
            SendRequestCallback sendRequestCallback = null,
            ReceiveResponseCallback receiveResponseCallback = null,
            HttpClient httpClient = null,
            SetRequestUriCallback setRequestUriCallback = null)
            : this(httpClient)
        {
            if (authenticationCallback == null)
                throw new ArgumentNullException("authenticationCallback");

            OnAuthenticate = authenticationCallback;
            OnSendRequest = sendRequestCallback;
            OnReceiveResponse = receiveResponseCallback;
            OnSetRequestUri = setRequestUriCallback;
        }

        public bool UseHttpPost { get; set; }

        #region Authentication

        /// <summary>
        /// Hook point for customizing the request Uri; used for testing in custom environments.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        protected virtual Uri SetRequestUri(Uri requestUri)
        {
            return requestUri;
        }

        /// <summary>
        /// Attempts to pre-authenticate a request to the specified vault or key URL using
        /// the Bearer challenge cache and the application supplied AuthenticationCallback.
        /// </summary>
        /// <param name="url">The vault or key URL</param>
        /// <returns>The access token to use for the request</returns>
        protected string PreAuthenticate(Uri url)
        {
            if (OnAuthenticate != null)
            {
                var challenge = HttpBearerChallengeCache.GetInstance().GetChallengeForURL(url);

                if (challenge != null)
                {
                    return OnAuthenticate(challenge.AuthorizationServer, challenge.Resource, challenge.Scope);
                }
            }

            return null;
        }

        /// <summary>
        /// Attempts to post-authenticate a request given an unauthorized response using
        /// the Bearer challenge cache and the application supplied AuthenticationCallback.
        /// </summary>
        /// <param name="url">The unauthorized response</param>
        /// <returns>The access token to use for the request</returns>
        protected string PostAuthenticate(HttpResponseMessage response)
        {
            // An HTTP 401 Not Authorized error; handle if an authentication callback has been supplied
            if (OnAuthenticate != null)
            {
                // Extract the WWW-Authenticate header and determine if it represents an OAuth2 Bearer challenge
                var authenticateHeader = response.Headers.WwwAuthenticate.ElementAt(0).ToString();

                if (HttpBearerChallenge.IsBearerChallenge(authenticateHeader))
                {
                    var challenge = new HttpBearerChallenge(response.RequestMessage.RequestUri, authenticateHeader);

                    if (challenge != null)
                    {
                        // Update challenge cache
                        HttpBearerChallengeCache.GetInstance().SetChallengeForURL(response.RequestMessage.RequestUri, challenge);

                        // We have an authentication challenge, use it to get a new authorization token
                        return OnAuthenticate(challenge.AuthorizationServer, challenge.Resource, challenge.Scope);
                    }
                }
            }

            return null;
        }

        #endregion

        #region Key Management

        /// <summary>
        /// Requests that a backup of the specified key be downloaded to the client.
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <returns>The backup blob containing the backed up key</returns>
        public async Task<byte[]> BackupKeyAsync(string vault, string keyName)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var keyIdentifier = new KeyIdentifier(vault, keyName);

            using (var httpResponse = await this.SendAsync<HttpRequestMessage>("POST", 
                CreateKeyUrl(keyIdentifier.BaseIdentifier, "backup")).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var backupResponse = await DeserializeAsync<BackupKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return backupResponse.Value;
            }
        }

        /// <summary>
        /// Restores the backup key in to a vault 
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyBundleBackup"> the backup blob associated with a key bundle </param>
        /// <returns> Restored key bundle in the vault </returns>
        public async Task<KeyBundle> RestoreKeyAsync(string vault, byte[] keyBundleBackup)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (keyBundleBackup == null)
                throw new ArgumentNullException("keyBundleBackup");

            var request  = new RestoreKeyRequestMessage { Value = keyBundleBackup };

            using (var httpResponse = await this.SendAsync<RestoreKeyRequestMessage>("POST", 
                CreateKeyVaultUrl(vault, "restore"), request).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        /// <summary>
        /// Creates a new, named, key in the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault in which the key is to be created.</param>
        /// <param name="keyName">The name for the key</param>
        /// <param name="keyType">The type of key to create (one of the valid WebKeyTypes)</param>
        /// <param name="keyAttributes">The attributes of the key</param>
        /// <returns>A key bundle containing the result of the create request</returns>
        public async Task<KeyBundle> CreateKeyAsync(string vault, string keyName, string keyType, 
            int? keySize = null, string[] key_ops = null, KeyAttributes keyAttributes = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (string.IsNullOrEmpty(keyType))
                throw new ArgumentNullException("keyType");

            if (!JsonWebKeyType.AllTypes.Contains(keyType))
                throw new ArgumentOutOfRangeException("keyType");

            var keyIdentifier = new KeyIdentifier(vault, keyName);
            var request       = new CreateKeyRequestMessage { Kty = keyType, KeySize = keySize, KeyOps = key_ops, Attributes = keyAttributes };

            using (var httpResponse = await this.SendAsync<CreateKeyRequestMessage>("POST", 
                CreateKeyUrl(keyIdentifier.BaseIdentifier, "create"), request).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        /// <summary>
        /// Deletes the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <returns>The public part of the deleted key</returns>
        public async Task<KeyBundle> DeleteKeyAsync(string vault, string keyName)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var identifier = new KeyIdentifier(vault, keyName);

            using (var httpResponse = await this.SendAsync<HttpRequestMessage>("DELETE", 
                CreateKeyUrl(identifier.BaseIdentifier)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyVersion">The key version</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public async Task<KeyBundle> GetKeyAsync(string vault, string keyName, string keyVersion = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            var keyIdentifier = new KeyIdentifier(vault, keyName, keyVersion);

            return await GetKeyAsync(keyIdentifier.Identifier).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the public portion of a key plus its attributes
        /// </summary>
        /// <param name="keyIdentifier">The key identifier</param>
        /// <returns>A KeyBundle of the key and its attributes</returns>
        public async Task<KeyBundle> GetKeyAsync(string keyIdentifier)
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            using (var httpResponse = await this.SendAsync<HttpRequestMessage>("GET", 
                CreateKeyUrl(keyIdentifier, string.Empty)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        /// <summary>
        /// Gets all the key in the specified vault
        /// </summary>
        /// <param name="vault"> the vault URL </param>
        /// <returns> a collection of keys that are available in the vault </returns>
        public async Task<IEnumerable<KeyItem>> GetKeysAsync(string vault)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            using (var response = await this.SendAsync<HttpRequestMessage>("GET", 
                CreateKeyVaultUrl(vault)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                return await DeserializeAsync<KeyItem[]>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Imports a key into the specified vault
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyBundle"> Key bundle </param>
        /// <param name="importToHardware">Whether to import as a hardware key (HSM) or software key </param>
        /// <returns> Imported key bundle to the vault </returns>
        public async Task<KeyBundle> ImportKeyAsync(string vault, string keyName, KeyBundle keyBundle, bool? importToHardware = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (keyBundle == null)
                throw new ArgumentNullException("keyBundle");

            var identifier = new KeyIdentifier(vault, keyName);
            var request    = new ImportKeyRequestMessage { Hsm = importToHardware, 
                Key = keyBundle.Key, Attributes = keyBundle.Attributes };

            using (var httpResponse = await this.SendAsync<ImportKeyRequestMessage>("PUT", 
                CreateKeyUrl(identifier.BaseIdentifier, "import"), request).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyOps">Json web key operations</param>
        /// <param name="attributes">The new attributes for the key</param>
        /// <returns> The updated key </returns>
        public async Task<KeyBundle> UpdateKeyAsync(string vault, string keyName, 
            string[] keyOps = null, KeyAttributes attributes = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vault");

            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentNullException("keyName");

            if (attributes == null && keyOps == null)
                throw new ArgumentException("Must provide one of keyOps or attributes");

            var keyIdentifier = new KeyIdentifier(vault, keyName);

            return await UpdateKeyAsync(keyIdentifier.Identifier, keyOps, attributes).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the Key Attributes associated with the specified key
        /// </summary>
        /// <param name="vault">The vault name, e.g. https://myvault.vault.azure.net</param>
        /// <param name="keyName">The key name</param>
        /// <param name="keyOps">Json web key operations</param>
        /// <param name="attributes">The new attributes for the key</param>
        /// <returns> The updated key </returns>
        public async Task<KeyBundle> UpdateKeyAsync(string keyIdentifier, string[] keyOps = null, KeyAttributes attributes = null)
        {
            if (string.IsNullOrEmpty(keyIdentifier))
                throw new ArgumentNullException("keyIdentifier");

            var request = new UpdateKeyRequestMessage { KeyOps = keyOps, Attributes = attributes };

            using (var httpResponse = await this.SendAsync<UpdateKeyRequestMessage>("PATCH",
                        CreateKeyUrl(keyIdentifier, "update"), request).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(httpResponse).ConfigureAwait(false);

                var response = await DeserializeAsync<GetKeyResponseMessage>(httpResponse).ConfigureAwait(false);

                return new KeyBundle
                {
                    Attributes = response.Attributes,
                    Key = response.Key,
                };
            }
        }

        #endregion

        #region Secrets Management

        /// <summary>
        /// Lists all of the secrets in the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <returns>A response message containing a list of all secrets in the vault</returns>
        public async Task<IEnumerable<SecretItem>> GetSecretsAsync(string vault)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vaultAddress");

            using (var response = await this.SendAsync<HttpRequestMessage>("GET", 
                CreateSecretVaultUrl(vault)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                return await DeserializeAsync<SecretItem[]>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="secretVersion">The version of the secret (optional)</param>
        /// <returns>A response message containing the secret</returns>
        public async Task<Secret> GetSecretAsync(string vault, string secretName, string secretVersion = null)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vaultAddress");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var identifier = new SecretIdentifier(vault, secretName, secretVersion);

            using (var response = await this.SendAsync<HttpRequestMessage>("GET", 
                CreateSecretUrl(identifier.Identifier)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                return await DeserializeAsync<Secret>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets a secret.
        /// </summary>
        /// <param name="secretIdentifier">The URL for the secret.</param>
        /// <returns>A response message containing the secret</returns>
        public async Task<Secret> GetSecretAsync(string secretIdentifier)
        {
            if (string.IsNullOrEmpty(secretIdentifier))
                throw new ArgumentNullException("secretIdentifier");

            using (var response = await this.SendAsync<HttpRequestMessage>("GET", 
                CreateSecretUrl(secretIdentifier)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                return await DeserializeAsync<Secret>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sets a secret in the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <param name="value">The value of the secret.</param>
        /// <returns>A response message containing the updated secret</returns>
        public async Task<Secret> SetSecretAsync(string vault, string secretName, SecureString value)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vaultAddress");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var identifier = new SecretIdentifier(vault, secretName);
            var request    = new SecretRequestMessage() { Value = value };

            using (var response   = await this.SendAsync<SecretRequestMessage>("PUT", 
                CreateSecretUrl(identifier.BaseIdentifier), request).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                var putResponse = await DeserializeAsync<SecretResponseMessage>(response).ConfigureAwait(false);

                return new Secret() { Id = putResponse.Id, SecureValue = putResponse.Value };
            }
        }

        /// <summary>
        /// Deletes a secret from the specified vault.
        /// </summary>
        /// <param name="vault">The URL for the vault containing the secrets.</param>
        /// <param name="secretName">The name the secret in the given vault.</param>
        /// <returns>The deleted secret</returns>
        public async Task<Secret> DeleteSecretAsync(string vault, string secretName)
        {
            if (string.IsNullOrEmpty(vault))
                throw new ArgumentNullException("vaultAddress");

            if (string.IsNullOrEmpty(secretName))
                throw new ArgumentNullException("secretName");

            var identifier = new SecretIdentifier(vault, secretName);

            using (var response   = await this.SendAsync<HttpRequestMessage>("DELETE", 
                CreateSecretUrl(identifier.BaseIdentifier)).ConfigureAwait(false))
            {
                await EnsureSuccessStatusCode(response).ConfigureAwait(false);

                return await DeserializeAsync<Secret>(response).ConfigureAwait(false);
            }
        }

        #endregion

        protected virtual Func<TBody, HttpContent> GetRequestWriter<TBody>() where TBody : class
        {
            ByteArrayContent content = null;

            return (TBody body) =>
            {
                // TODO: BSON support
                using (var stream = new MemoryStream())
                {
                    var writer = new JsonTextWriter(new StreamWriter(stream));

                    _serializer.Serialize(writer, body, typeof(TBody));

                    writer.Flush();

                    content = new ByteArrayContent(stream.ToArray());
                }

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //content.Headers.Add( "ContentType", "application/json" );

                return content;
            };
        }

        protected virtual async Task<TResult> DeserializeAsync<TResult>(HttpResponseMessage response) where TResult : class
        {
            TResult result;
            using (var stream = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)))
            {
                using (JsonReader reader = new JsonTextReader(stream))
                {
                    result = _serializer.Deserialize<TResult>(reader);
                }
            }
            return result;
        }

        #region URL Construction

        protected Uri CreateKeyUrl(string keyIdentifier, string operation = null)
        {
            var baseUri = new Uri(keyIdentifier).AbsoluteUri.TrimEnd('/');

            return new Uri(baseUri + "/" + operation + ApiVersion);
        }

        protected Uri CreateKeyVaultUrl(string vault, string operation = null)
        {
            var baseUri = new Uri(vault).AbsoluteUri.TrimEnd('/');

            return new Uri(baseUri + "/keys/" + operation + ApiVersion);
        }

        protected Uri CreateSecretUrl(string secretIdentifier)
        {
            return new Uri(secretIdentifier + ApiVersion);
        }

        protected Uri CreateSecretVaultUrl(string vault, string operation = null)
        {
            var baseUri = new Uri(vault).AbsoluteUri.TrimEnd('/');

            return new Uri(baseUri + "/secrets/" + operation + ApiVersion);
        }

        #endregion

        protected virtual async Task<bool> EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                ErrorResponseMessage error = null;

                if (response.Content.Headers.ContentType != null &&
                    response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    // Attempt to read the error data from the service.
                    var errorText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    try
                    {
                        error = JsonConvert.DeserializeObject<ErrorResponseMessage>(errorText);
                    }
                    catch (Exception)
                    {
                        // Error deserialization failed, attempt to get some data for the client
                        error = new ErrorResponseMessage()
                        {
                            Error = new Error()
                            {
                                Code = "Unknown",
                                Message = errorText,
                            },
                        };
                    }
                }
                else
                {
                    // Unrecognized content type
                    error = new ErrorResponseMessage()
                    {
                        Error = new Error()
                        {
                            Code = response.StatusCode.ToString(),
                            Message = string.Format("HTTP {0} Error: ", response.StatusCode.ToString(), response.ReasonPhrase),
                        },
                    };
                }

                throw new KeyVaultClientException(response.StatusCode, response.RequestMessage.RequestUri, error != null ? error.Error : null);
            }

            return true;
        }


        #region HTTP Methods

        protected virtual async Task<HttpResponseMessage> SendAsync<TBody>(string httpMethod, Uri requestUri, TBody body = null) where TBody : class
        {
            string correlationId = Guid.NewGuid().ToString("D");

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add((new MediaTypeWithQualityHeaderValue(JsonMediaType)));
            _client.DefaultRequestHeaders.Add(HttpRequestIdHeader, correlationId);

            // Override URL for Azure Development Fabric
            var targetUri = SetRequestUri(requestUri);
            if (OnSetRequestUri != null)
            {
                targetUri = OnSetRequestUri(requestUri, _client);
            }

            // PreAuthenticate
            var accessToken = PreAuthenticate(requestUri);

            if (!string.IsNullOrEmpty(accessToken))
                _client.DefaultRequestHeaders.Add(HttpAuthorizationHeader, "Bearer " + accessToken);

            // Switch method if required
            var method  = httpMethod.ToUpperInvariant();

            switch (method)
            {
                case "DELETE":
                case "PATCH":
                case "PUT":
                    _client.DefaultRequestHeaders.Add(HttpMethodHeader, method);
                    method = "POST";
                    break;
            }

            HttpResponseMessage response;
            using (var request = new HttpRequestMessage(new HttpMethod(method), targetUri))
            {

                if (body != null)
                {
                    var writer = GetRequestWriter<TBody>();
                    request.Content = writer(body);
                }

                // Record the request that is to be sent
                if (OnSendRequest != null)
                {
                    OnSendRequest(correlationId, request);
                }

                response = await _client.SendAsync(request).ConfigureAwait(false);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                accessToken = PostAuthenticate(response);

                if (!string.IsNullOrEmpty(accessToken))
                {
                    _client.DefaultRequestHeaders.Add(HttpAuthorizationHeader, "Bearer " + accessToken);

                    using (var request = new HttpRequestMessage(new HttpMethod(method), targetUri))
                    {

                        if (body != null)
                        {
                            var writer = GetRequestWriter<TBody>();
                            request.Content = writer(body);
                        }

                        response = await _client.SendAsync(request).ConfigureAwait(false);
                    }
                }
            }

            // Record the response that is received
            if (OnReceiveResponse != null)
            {
                OnReceiveResponse(correlationId, response);
            }

            return response;
        }

        #endregion
    }
}
