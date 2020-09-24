using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;
using Microsoft.IdentityModel.Tokens;
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

        private const string _securityDomainPathFragment = "SecurityDomain";
        private DataServiceCredential _credentials;
        private VaultUriHelper _uriHelper;
        private readonly JsonSerializerSettings _serializationSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        private readonly Action<string> _writeDebug;

        /// <summary>
        /// Download security domain data.
        /// </summary>
        /// <param name="hsmName">Name of the HSM</param>
        /// <param name="certificates">Certificates used to encrypt the security domain data</param>
        /// <param name="quorum">Specify how many keys are required to decrypt the data</param>
        /// <returns>Encrypted HSM security domain data in string</returns>
        public async Task<string> DownloadSecurityDomainAsync(string hsmName, IEnumerable<X509Certificate2> certificates, int quorum)
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

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new UriBuilder(_uriHelper.CreateManagedHsmUri(hsmName))
                {
                    Path = $"/{_securityDomainPathFragment}/download"
                }.Uri,
                Content = new StringContent(requestBody)
            };

            PrepareRequest(httpRequest);

            var httpResponseMessage = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                var securityDomainWrapper = JsonConvert.DeserializeObject<SecurityDomainWrapper>(response);
                ValidateDownloadSecurityDomainResponse(securityDomainWrapper);
                return securityDomainWrapper.value;
            }
            else
            {
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                //_writeDebug($"Invalid security domain response: {response}");
                throw new Exception("Failed to download security domain data.");
            }
        }

        private void ValidateDownloadSecurityDomainResponse(SecurityDomainWrapper securityDomainWrapper)
        {
            if (string.IsNullOrEmpty(securityDomainWrapper.value) || !ValidateSecurityDomainData(securityDomainWrapper.value))
            {
                //_writeDebug($"Invalid security domain response: {securityDomainWrapper.value}");
                throw new Exception("Failed to download security domain data.");
            }
        }

        /// <summary>
        /// Prepare common headers for the request.
        /// Such as content-type and authorization.
        /// </summary>
        /// <param name="httpRequest"></param>
        private void PrepareRequest(HttpRequestMessage httpRequest)
        {
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            try
            {
                var token = _credentials.GetAccessToken();
                token.AuthorizeRequest((tokenType, tokenValue) =>
                {
                    httpRequest.Headers.Authorization = new AuthenticationHeaderValue(tokenType, tokenValue);
                });
            }
            catch (Exception ex)
            {
                throw new AuthenticationException(Resources.InvalidSubscriptionState, ex);
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

        public async Task<X509Certificate2> DownloadSecurityDomainExchangeKeyAsync(string hsmName)
        {
            if (string.IsNullOrWhiteSpace(hsmName))
            {
                throw new ArgumentException(nameof(hsmName));
            }

            try
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = new HttpMethod("GET"),
                    RequestUri = new UriBuilder(_uriHelper.CreateManagedHsmUri(hsmName))
                    {
                        Path = $"/{_securityDomainPathFragment}/upload"
                    }.Uri,
                };

                PrepareRequest(httpRequest);

                HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    var key = JsonConvert.DeserializeObject<SecurityDomainTransferKey>(response);

                    switch (key.KeyFormat)
                    {
                        case "pem":
                            // Transitional, remove later
                            return Utils.CertficateFromPem(key.TransferKey);
                        case "jwk":
                            // handle below
                            break; 
                        default:
                            return null;
                    }

                    // The transfer key is a JWK, need to parse it, and return the cert
                    JWK jwk = JsonConvert.DeserializeObject<JWK>(key.TransferKey);
                    return Utils.CertficateFromPem(jwk.GetX5cAsPem());
                }

                return null;
            }
            catch (Exception err)
            {
                Console.WriteLine($"DownloadSecurityDomainTransferKey failed = {err.Message}");
                Console.WriteLine(err);
                return null;
            }
        }

        public string EncryptSecurityDomainByCert(KeyPath[] keys, SecurityDomainData data, X509Certificate2 restore_cert)
        {
            try
            {
                string restore_data = GetSecurityDomainRestore(restore_cert, data, keys);

                if (restore_data == null)
                {
                    Console.WriteLine("Unable to create security domain restore");
                    return null;
                }

                return restore_data;
            }
            catch (Exception err)
            {
                Console.WriteLine("Unable to decrypt security domain " + err.Message);
                return null;
            }
        }

        private string GetSecurityDomainRestore(X509Certificate2 restoreCert, SecurityDomainData data, KeyPath[] keys)
        {
            PlaintextList plaintextList = Decrypt(data, keys);
            SecurityDomainRestoreData restoreData = EncryptForRestore(restoreCert, plaintextList);
            return JsonConvert.SerializeObject(restoreData);
        }

        private PlaintextList Decrypt(SecurityDomainData data, KeyPath[] paths)
        {
            CertKeys certKeys = new CertKeys();
            certKeys.LoadKeys(paths);

            if (certKeys.Count() < 2)
            {
                Console.WriteLine("Cannot load two certificates and keys");
                return null;
            }

            return Decrypt(data, certKeys);
        }

        // Internal worker function
        private PlaintextList Decrypt(SecurityDomainData data, CertKeys certKeys)
        {
            if (data == null ||
                certKeys.Count() < 2 ||
                (data.version == 2 && certKeys.Count() < data.SharedKeys.required))
            {
                Console.WriteLine("Invalid arguments");
                return null;
            }

            byte[] master_key = null;

            if (data.version == 1)
            {
                // ensure that the key splitting algorithm
                // is known, currently only one we know about
                if (data.SplitKeys.key_algorithm != "xor_split")
                {
                    Console.WriteLine("Unknown SplitKey algorithm");
                    return null;
                }

                KeyPair decode_key_pair = null;
                CertKey certKey1 = null;
                CertKey certKey2 = null;
                foreach (KeyPair key_pair in data.SplitKeys.keys)
                {
                    certKey1 = certKeys.Find(key_pair.key1.x5t_256);

                    if (certKey1 == null)
                        continue;

                    certKey2 = certKeys.Find(key_pair.key2.x5t_256);

                    if (certKey2 != null)
                    {
                        decode_key_pair = key_pair;
                        break;
                    }
                }

                if (decode_key_pair == null)
                {
                    Console.WriteLine("Cannot find matching certs and keys for security domain");
                    return null;
                }

                master_key = DecryptMasterKey(decode_key_pair, certKey1, certKey2);
            }
            else if (data.version == 2)
            {
                if (data.SharedKeys.key_algorithm != "shamir_share")
                {
                    Console.WriteLine("Unknown SharedKeys algorithm");
                    return null;
                }

                UInt32 shares_found = 0;
                List<UInt16[]> share_arrays = new List<UInt16[]>();

                foreach (Key key in data.SharedKeys.enc_shares)
                {
                    CertKey cert_key = certKeys.Find(key.x5t_256);

                    if (cert_key != null)
                    {
                        JWE jwe = new JWE(key.enc_key);
                        byte[] share = jwe.Decrypt(cert_key.get_key());

                        shares_found++;
                        share_arrays.Add(Utils.ConvertToUint16(share));
                    }

                    if (share_arrays.Count == data.SharedKeys.required)
                        break;
                }

                if (share_arrays.Count < data.SharedKeys.required)
                {
                    Console.WriteLine("Insufficient shares available");
                    return null;
                }

                shamir_share_net.shared_secret secret = new shamir_share_net.shared_secret((UInt16)data.SharedKeys.required);
                master_key = secret.get_secret(share_arrays);
            }
            else
            {
                Console.WriteLine("Unknown domain version");
                return null;
            }

            PlaintextList plaintextList = new PlaintextList();

            // Need to check KDF
            foreach (Datum enc_data in data.EncData.data)
            {
                Plaintext p = new Plaintext();
                HMACSHA512 hmac = new HMACSHA512();
                byte[] enc_key = KDF.sp800_108(master_key, enc_data.tag, "", hmac, 512);
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
            byte[] xor_key = jwe1.Decrypt(certKey1.get_key());

            JWE jwe2 = new JWE(decode_key_pair.key2.enc_key);
            byte[] derived_key = jwe2.Decrypt(certKey2.get_key());

            // Now, XOR to get the master key back
            byte[] master_key = new byte[xor_key.Length];

            for (Int32 i = 0; i < xor_key.Length; ++i)
            {
                master_key[i] = (byte)(xor_key[i] ^ derived_key[i]);
            }
            return master_key;
        }

        private SecurityDomainRestoreData EncryptForRestore(X509Certificate2 cert, PlaintextList plaintextList)
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
            securityDomainRestoreData.WrappedKey.x5t_256 = Base64UrlEncoder.Encode(Utils.Sha256Thumbprint(cert));
            return securityDomainRestoreData;
        }

        public async Task<bool> RestoreSecurityDomainAsync(string hsmName, string securityDomainData)
        {
            if (string.IsNullOrWhiteSpace(hsmName))
            {
                throw new ArgumentException(nameof(hsmName));
            }

            if (string.IsNullOrEmpty(securityDomainData))
                throw new ArgumentNullException(nameof(securityDomainData));

            string securityDomain = JsonConvert.SerializeObject(new SecurityDomainWrapper
            {
                value = securityDomainData
            });

            try
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new UriBuilder(_uriHelper.CreateManagedHsmUri(hsmName))
                    {
                        Path = $"/{_securityDomainPathFragment}/upload"
                    }.Uri,
                    Content = new StringContent(securityDomain)
                };

                PrepareRequest(httpRequest);

                var httpResponseMessage = await HttpClient.SendAsync(httpRequest).ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return !string.IsNullOrEmpty(await httpResponseMessage.Content.ReadAsStringAsync());
                }

                return false;
            }
            catch (Exception err)
            {
                Console.WriteLine($"RequestSecurityDomain failed = {err.Message}");
                Console.WriteLine(err);
                return false;
            }
        }
    }
}
