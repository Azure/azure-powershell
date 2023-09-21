using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Crypto;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class SecurityDomainClient : ServiceClient<SecurityDomainClient>, ISecurityDomainClient
    {
        public SecurityDomainClient(IAuthenticationFactory authenticationFactory, IAzureContext defaultContext, Action<string> debugWriter)
        {
            _credentials = new DataServiceCredential(authenticationFactory, defaultContext, ExtendedEndpoint.ManagedHsmServiceEndpointResourceId);

            _uriHelper = new VaultUriHelper(
                defaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.AzureKeyVaultDnsSuffix),
                defaultContext.Environment.GetEndpoint(ExtendedEndpoint.ManagedHsmServiceEndpointSuffix));

            HttpClient.DefaultRequestHeaders.TransferEncodingChunked = false;

            _writeDebug = debugWriter;
        }

        private const string _securityDomain = "securitydomain";
        private const string _apiVersion = "7.2-preview";
        private readonly DataServiceCredential _credentials;
        private readonly VaultUriHelper _uriHelper;
        private readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly Action<string> _writeDebug;

        /// <summary>
        /// Download security domain data for restore.
        /// Data is encrypted with the certificates (public keys) user passes in.
        /// </summary>
        /// <param name="hsmName">Name of the HSM</param>
        /// <param name="certificates">Certificates used to encrypt the security domain data</param>
        /// <param name="quorum">Specify how many keys are required to decrypt the data</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Encrypted HSM security domain data in string</returns>
        public string DownloadSecurityDomain(string hsmName, IEnumerable<X509Certificate2> certificates, int quorum, CancellationToken cancellationToken)
        {
            var downloadRequest = new DownloadRequest
            {
                Required = quorum
            };
            certificates.ForEach(cert => downloadRequest.Certificates.Add(new JWK(cert)));

            string requestBody = JsonConvert.SerializeObject(
                downloadRequest,
                Formatting.None,
                _serializationSettings);

            var httpRequest = CreateRequest(HttpMethod.Post, hsmName, $"/{_securityDomain}/download", new StringContent(requestBody));
            try
            {
                var securityDomain = JsonConvert.DeserializeObject<SecurityDomainWrapper>(PollAsyncOperation(httpRequest, cancellationToken));
                ValidateDownloadSecurityDomainResponse(securityDomain);
                return securityDomain.value;
            } catch (Exception ex) {
                _writeDebug($"Invalid security domain response: {ex.Message}");
                throw new AzPSException(Resources.DownloadSecurityDomainFail, ErrorKind.ServiceError, ex);
            }
        }

        /// <summary>
        /// Create security domain HTTP request
        /// </summary>
        /// <param name="method"></param>
        /// <param name="hsmName"></param>
        /// <param name="path">e.g. /securitydomain/download</param>
        /// <param name="content">optional request body</param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequest(HttpMethod method, string hsmName, string path, HttpContent content = null)
        {
            var uri = new UriBuilder(_uriHelper.CreateManagedHsmUri(hsmName))
            {
                Path = path,
                Query = $"api-version={_apiVersion}"
            }.Uri;

            var request = new HttpRequestMessage(method, uri)
            {
                Content = content
            };

            // add content-type header
            if (request.Content != null)
            {
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }

            // add authorization header
            try
            {
                var token = _credentials.GetAccessToken();
                token.AuthorizeRequest((tokenType, tokenValue) =>
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(tokenType, tokenValue);
                });
            }
            catch (Exception ex)
            {
                throw new AzPSException(Resources.InvalidSubscriptionState, ErrorKind.InternalError, ex);
            }

            return request;
        }

        /// <summary>
        /// Polls the async operation request, returns the content as string
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private string PollAsyncOperation(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage _response = null;
            string firstResponseContent;
            try
            {
                _writeDebug(GeneralUtilities.GetLog(request));
                _response = HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                _writeDebug(GeneralUtilities.GetLog(_response));

                if (_response.StatusCode == System.Net.HttpStatusCode.OK) {
                    // 200: sync operation
                    return _response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                }


                // cache first response, and start polling until a terminal state
                firstResponseContent = _response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                var asyncOperation = string.Empty;
                while (true)
                {
                    // get the delay before polling. (default to 30 seconds if not present)
                    int delay = (int)(_response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 30);
                    _writeDebug($"Delaying {delay} seconds before polling.");

                    // start the delay timer (we'll await later...)
                    var waiting = Task.Delay(delay * 1000, cancellationToken);

                    // while we wait, let's grab the headers and get ready to poll.
                    if (!System.String.IsNullOrEmpty(_response.GetFirstHeader(@"Azure-AsyncOperation")))
                    {
                        asyncOperation = _response.GetFirstHeader(@"Azure-AsyncOperation");
                    }
                    var _uri = asyncOperation;
                    request = request.CloneAndDispose(new global::System.Uri(_uri), HttpMethod.Get);

                    waiting.ConfigureAwait(false).GetAwaiter().GetResult();

                    // check for cancellation
                    if (cancellationToken.IsCancellationRequested) { return null; }

                    // drop the old response
                    _response?.Dispose();

                    // make the polling call
                    _writeDebug(GeneralUtilities.GetLog(request));
                    _response = HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
                    _writeDebug(GeneralUtilities.GetLog(_response));

                    // take a peek inside and see if it's done
                    var error = false;
                    string pollingResponseContent;
                    try
                    {
                        pollingResponseContent = _response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                        var result = JsonConvert.DeserializeObject<PollingResult>(pollingResponseContent);
                        if (result != null)
                        {
                            var state = result.Status;
                            if (string.IsNullOrEmpty(state))
                            {
                                // the body doesn't contain any information that has the state of the LRO
                                // we're going to just get out, and let the consumer have the result
                                break;
                            }

                            switch (state?.ToString()?.ToLower())
                            {
                                case "failed":
                                    error = true;
                                    break;
                                case "succeeded":
                                case "success":
                                    // we're done polling.
                                    return firstResponseContent;
                                default:
                                    // need to keep polling!
                                    continue;
                            }
                        }
                    }
                    catch
                    {
                        // if we run into a problem peeking into the result,
                        // we really don't want to do anything special.
                    }

                    if (error)
                    {
                        throw new Exception(firstResponseContent);
                    }
                }

                return firstResponseContent;
            }
            finally
            {
                // finally statements
                _response?.Dispose();
                request?.Dispose();
            }
        }

        private void ValidateDownloadSecurityDomainResponse(SecurityDomainWrapper securityDomainWrapper)
        {
            if (string.IsNullOrEmpty(securityDomainWrapper.value) || !ValidateSecurityDomainData(securityDomainWrapper.value))
            {
                _writeDebug($"Invalid security domain response: {securityDomainWrapper.value}");
                throw new Exception(Resources.DownloadSecurityDomainFail);
            }
        }

        private bool ValidateSecurityDomainData(string securityDomainData)
        {
            var securityDomain = JsonConvert.DeserializeObject<SecurityDomainData>(securityDomainData);

            // DeserializeObject isn't very picky, need to validate further
            bool valid = false;

            // Note - this is very rudimentary, should
            // do more comprehensive checking.
            if (securityDomain.EncData != null)
            {
                switch (securityDomain.version)
                {
                    case 1:
                        if (securityDomain.SplitKeys != null)
                            valid = true;
                        break;

                    case 2:
                        if (securityDomain.SharedKeys != null)
                            valid = true;
                        break;

                    default:
                        break;
                }
            }

            return valid;
        }

        /// <summary>
        /// Download a security domain exchange key.
        /// This key is used to encrypt SD data before uploading to the HSM where SD is going to be restored.
        /// </summary>
        /// <param name="hsmName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public X509Certificate2 DownloadSecurityDomainExchangeKey(string hsmName, CancellationToken cancellationToken)
        {
            try
            {
                var httpRequest = CreateRequest(HttpMethod.Get, hsmName, $"/{_securityDomain}/upload");

                HttpResponseMessage httpResponseMessage = HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    var key = JsonConvert.DeserializeObject<SecurityDomainTransferKey>(response);

                    switch (key.KeyFormat)
                    {
                        case "pem":
                            // Transitional, remove later
                            return Utils.CertificateFromPem(key.TransferKey);
                        case "jwk":
                            // handle below
                            break;
                        default:
                            throw new Exception($"Unexpected key type {key.KeyFormat}");
                    }

                    // The transfer key is a JWK, need to parse it, and return the cert
                    JWK jwk = JsonConvert.DeserializeObject<JWK>(key.TransferKey);
                    return Utils.CertificateFromPem(jwk.GetX5cAsPem());
                }
                else
                {
                    string response = httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    _writeDebug($"Invalid security domain response: {response}");
                    throw new Exception(Resources.DownloadSecurityDomainKeyFail);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Resources.DownloadSecurityDomainKeyFail, ex);
            }
        }

        /// <summary>
        /// Decrypt security domain data.
        /// User must specify public key / private key / password* groups to decrypt SD.
        /// *password MAY be optional.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public PlaintextList DecryptSecurityDomain(SecurityDomainData data, KeyPath[] paths)
        {
            CertKeys certKeys = new CertKeys();
            try
            {
                certKeys.LoadKeys(paths);
                return Decrypt(data, certKeys);
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.DecryptSecurityDomainFailure, ex);
            }
        }

        // Internal worker function
        private PlaintextList Decrypt(SecurityDomainData data, CertKeys certKeys)
        {
            if (data.version == 2 && certKeys.Count() < data.SharedKeys.required)
            {
                throw new ArgumentException(string.Format(Resources.DecryptSecurityDomainKeyNotEnough, data.SharedKeys.required, certKeys.Count()));
            }

            byte[] masterKey;
            if (data.version == 1)
            {
                // ensure that the key splitting algorithm
                // is known, currently only one we know about
                if (data.SplitKeys.key_algorithm != "xor_split")
                {
                    throw new Exception($"Unknown SplitKey algorithm {data.SplitKeys.key_algorithm}.");
                }

                KeyPair decodeKeyPair = null;
                CertKey certKey1 = null;
                CertKey certKey2 = null;
                foreach (KeyPair keyPair in data.SplitKeys.keys)
                {
                    certKey1 = certKeys.Find(keyPair.key1.x5t_256);

                    if (certKey1 == null)
                        continue;

                    certKey2 = certKeys.Find(keyPair.key2.x5t_256);

                    if (certKey2 != null)
                    {
                        decodeKeyPair = keyPair;
                        break;
                    }
                }

                if (decodeKeyPair == null)
                {
                    throw new Exception("Cannot find matching certs and keys for security domain");
                }

                masterKey = DecryptMasterKey(decodeKeyPair, certKey1, certKey2);
            }
            else if (data.version == 2)
            {
                if (data.SharedKeys.key_algorithm != "shamir_share")
                {
                    throw new Exception($"Unknown SharedKeys algorithm {data.SharedKeys.key_algorithm}");
                }

                UInt32 shares_found = 0;
                List<UInt16[]> share_arrays = new List<UInt16[]>();

                foreach (Key key in data.SharedKeys.enc_shares)
                {
                    CertKey cert_key = certKeys.Find(key.x5t_256);

                    if (cert_key != null)
                    {
                        JWE jwe = new JWE(key.enc_key);
                        byte[] share = jwe.Decrypt(cert_key.GetKey());

                        shares_found++;
                        share_arrays.Add(Utils.ConvertToUint16(share));
                    }

                    if (share_arrays.Count == data.SharedKeys.required)
                        break;
                }

                if (share_arrays.Count < data.SharedKeys.required)
                {
                    throw new Exception($"Insufficient shares available. {data.SharedKeys.required} required, got {share_arrays.Count}.");
                }

                shared_secret secret = new shared_secret((UInt16)data.SharedKeys.required);
                masterKey = secret.get_secret(share_arrays);
            }
            else
            {
                throw new Exception($"Unknown domain version {data.version}.");
            }

            PlaintextList plaintextList = new PlaintextList();

            // Need to check KDF
            foreach (Datum enc_data in data.EncData.data)
            {
                Plaintext p = new Plaintext();
                HMACSHA512 hmac = new HMACSHA512();
                byte[] enc_key = KDF.sp800_108(masterKey, enc_data.tag, "", hmac, 512);
                JWE jwe_data = new JWE(enc_data.compact_jwe);
                p.plaintext = jwe_data.Decrypt(enc_key);
                p.tag = enc_data.tag;

                plaintextList.Add(p);
            }

            return plaintextList;
        }

        private byte[] DecryptMasterKey(KeyPair decode_key_pair, CertKey certKey1, CertKey certKey2)
        {
            JWE jwe1 = new JWE(decode_key_pair.key1.enc_key);
            byte[] xor_key = jwe1.Decrypt(certKey1.GetKey());

            JWE jwe2 = new JWE(decode_key_pair.key2.enc_key);
            byte[] derived_key = jwe2.Decrypt(certKey2.GetKey());

            // Now, XOR to get the master key back
            byte[] master_key = new byte[xor_key.Length];

            for (Int32 i = 0; i < xor_key.Length; ++i)
            {
                master_key[i] = (byte)(xor_key[i] ^ derived_key[i]);
            }
            return master_key;
        }

        /// <summary>
        /// Encrypt SD data with exchange key.
        /// </summary>
        /// <param name="plaintextList"></param>
        /// <param name="cert">Exchange key</param>
        /// <returns></returns>
        public SecurityDomainRestoreData EncryptForRestore(PlaintextList plaintextList, X509Certificate2 cert)
        {
            try
            {
                SecurityDomainRestoreData securityDomainRestoreData = new SecurityDomainRestoreData();
                securityDomainRestoreData.EncData.kdf = "sp108_kdf";

                byte[] master_key = Utils.GetRandom(32);

                foreach (Plaintext p in plaintextList.list)
                {
                    Datum datum = new Datum();
                    HMACSHA512 hmac = new HMACSHA512();
                    byte[] enc_key = KDF.sp800_108(master_key, p.tag, "", hmac, 512);

                    datum.tag = p.tag;
                    JWE jwe = new JWE();
                    jwe.Encrypt(enc_key, p.plaintext, "A256CBC-HS512", p.tag);
                    datum.compact_jwe = jwe.EncodeCompact();
                    securityDomainRestoreData.EncData.data.Add(datum);
                }

                // Now go make the wrapped key
                JWE jwe_wrapped = new JWE();
                jwe_wrapped.Encrypt(cert, master_key);
                securityDomainRestoreData.WrappedKey.enc_key = jwe_wrapped.EncodeCompact();
                securityDomainRestoreData.WrappedKey.x5t_256 = Base64UrlHelper.Encode(Utils.Sha256Thumbprint(cert));
                return securityDomainRestoreData;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to encrypt security domain data for restoring.", ex);
            }

        }

        /// <summary>
        /// Upload security domain data and initiate restoring.
        /// </summary>
        /// <param name="hsmName"></param>
        /// <param name="securityDomainData">Encrypted by exchange key</param>
        /// <param name="cancellationToken"></param>
        public void RestoreSecurityDomain(string hsmName, SecurityDomainRestoreData securityDomainData, CancellationToken cancellationToken)
        {
            string securityDomain = JsonConvert.SerializeObject(new SecurityDomainWrapper
            {
                value = JsonConvert.SerializeObject(securityDomainData)
            });

            try
            {
                var httpRequest = CreateRequest(HttpMethod.Post, hsmName, $"/{_securityDomain}/upload", new StringContent(securityDomain));
                PollAsyncOperation(httpRequest, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.RestoreSecurityDomainFailure, ex);
            }
        }
    }
}
