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
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    internal class PolicyValidationHelper
    {
        public static TokenValidationResult ValidateAttestationServiceToken (string tenantName, string tenantAttestUri, string policyJwt)
        {
            ValidateInputParameters(tenantName, tenantAttestUri, policyJwt);

            var jwksTrustedSigningKeys = RetrieveTrustedSigningKeys(policyJwt, tenantName);
            var validatedToken = ValidateSignedToken(policyJwt, jwksTrustedSigningKeys);
            EnforceJwtIssuerIsTenant(validatedToken, tenantAttestUri);
            EnforceSigningCertIssuerMatchesJwtIssuer(validatedToken);

            return validatedToken;
        }

        #region Internal implementation details

        private static void EnforceSigningCertIssuerMatchesJwtIssuer(TokenValidationResult validatedToken)
        {
            var jwtTokenIssuerClaim = validatedToken.ClaimsIdentity.Claims.First(c => c.Type == "iss");

            // Ensure that the JWT signing certificate is issued by the same issuer as the JWT itself
            var validatedKey = validatedToken.SecurityToken.SigningKey;
            if (!(validatedKey is X509SecurityKey))
            {
                throw new ArgumentException("Policy JWT is not valid (signing key is not an X509 security key)");
            }
            var signingCertificate = (validatedKey as X509SecurityKey).Certificate;
            if (!string.Equals(signingCertificate.Issuer, "CN=" + jwtTokenIssuerClaim.Value, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Policy JWT is not valid (signing certificate issuer does not match JWT issuer)");
            }
        }

        private static void EnforceJwtIssuerIsTenant(TokenValidationResult validatedToken, string tenantAttestUri)
        {
            // Verify that the JWT issuer is indeed the tenantAttestUri (tenant specific URI)
            var jwtTokenIssuerClaim = validatedToken.ClaimsIdentity.Claims.First(c => c.Type == "iss");
            if (!string.Equals(tenantAttestUri, jwtTokenIssuerClaim.Value, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Policy JWT is not valid (iss claim does not match attest URI)");
            }
        }

        private static TokenValidationResult ValidateSignedToken(string policyJwt, JsonWebKeySet jwksTrustedSigningKeys)
        {
            // Now validate the JWT using the signing keys we just discovered
            TokenValidationParameters tokenValidationParams = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKeys = jwksTrustedSigningKeys.GetSigningKeys()
            };
            var jwtHandler = new JsonWebTokenHandler();
            var validatedToken = jwtHandler.ValidateToken(policyJwt, tokenValidationParams);
            if (!validatedToken.IsValid)
            {
                throw new ArgumentException("Policy JWT is not valid (signature verification failed)");
            }

            return validatedToken;
        }

        private static JsonWebKeySet RetrieveTrustedSigningKeys(string policyJwt, string tenantName)
        {
            // Parse attestation service trusted signing key discovery endpoint from JWT header jku field
            var jwt = new JsonWebToken(policyJwt);
            var jsonHeaderBytes = Base64Url.DecodeBytes(jwt.EncodedHeader);
            var jsonHeaderString = Encoding.UTF8.GetString(jsonHeaderBytes);
            var jsonHeader = JObject.Parse(jsonHeaderString);
            var jkuUri = jsonHeader.SelectToken("jku");
            Uri keyUrl = new Uri(jkuUri.ToString());

            // Retrieve trusted signing keys from the attestation service
            var webClient = new WebClient();
            webClient.Headers.Add("tenantName", tenantName.Length > 24 ? tenantName.Remove(24) : tenantName);
            var jwksValue = webClient.DownloadString(keyUrl);

            return new JsonWebKeySet(jwksValue);
        }

        private static void ValidateInputParameters(string tenantName, string tenantAttestUri, string policyJwt)
        {
            // Parameter validation
            if (string.IsNullOrEmpty(tenantName))
            {
                throw new ArgumentException(nameof(tenantName));
            }

            if (string.IsNullOrEmpty(tenantAttestUri))
            {
                throw new ArgumentException(nameof(tenantAttestUri));
            }

            if (string.IsNullOrEmpty(policyJwt))
            {
                throw new ArgumentException(nameof(policyJwt));
            }
        }

        #endregion
    }
}
