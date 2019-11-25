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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Attestation.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.JsonWebTokens;
namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationManagementClient
    {
        private readonly Management.Attestation.AttestationManagementClient attestationClient;

        public AttestationManagementClient(IAzureContext context)
        {
            attestationClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Attestation.AttestationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public AttestationManagementClient()
        {
        }

        public Uri ResourceProviderHost
        {
            get
            {
                return attestationClient.BaseUri;
            }
            set { attestationClient.BaseUri = value; }
        }
        public PSAttestation CreateNewAttestation(AttestationCreationParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (string.IsNullOrWhiteSpace(parameters.ProviderName))
            {
                throw new ArgumentNullException("parameters.ProviderName");
            }
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
            {
                throw new ArgumentNullException("parameters.ResourceGroupName");
            }
            AttestationServiceCreationParams _creationParams = new AttestationServiceCreationParams();
            if (!string.IsNullOrEmpty(parameters.AttestationPolicy))
            {
                _creationParams.AttestationPolicy = parameters.AttestationPolicy;
            }
            if (parameters.PolicySigningCertificates != null)
            {
                _creationParams.PolicySigningCertificates = parameters.PolicySigningCertificates;
            }


            var response = attestationClient.AttestationProviders.Create(
                resourceGroupName: parameters.ResourceGroupName,
                providerName: parameters.ProviderName,
                creationParams: _creationParams);
            return new PSAttestation(response);
        }

        public PSAttestation GetAttestation(string attestationName, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(attestationName))
            {
                throw new ArgumentNullException("attestationName");
            }
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            var response = attestationClient.AttestationProviders.Get(resourceGroupName, attestationName);
            return new PSAttestation(response);
        }
        public void DeleteAttestation(string attestationName, string resourceGroupName)
        {
            if (string.IsNullOrEmpty(attestationName))
            {
                throw new ArgumentNullException("attestationName");
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            attestationClient.AttestationProviders.Delete(resourceGroupName, attestationName);
        }

        public X509Certificate2Collection GetX509CertificateFromPEM(string pemString, string section)
        {
            X509Certificate2Collection certificateCollection = new X509Certificate2Collection();
            var header = String.Format("-----BEGIN {0}-----", section);
            var footer = String.Format("-----END {0}-----", section);

            var start = 0;
            var end = 0;
            while (true)
            {
                start = pemString.IndexOf(header, StringComparison.Ordinal);

                if (start < 0)
                    break;
                start += header.Length;
                end = pemString.IndexOf(footer, start, StringComparison.Ordinal) - start;
                if (end < 0)
                    break;
                byte [] certBuffer = Convert.FromBase64String(pemString.Substring(start, end));
                X509Certificate2 certs = new X509Certificate2(certBuffer);
                certificateCollection.Add(certs);
                pemString = pemString.Substring(start + end);
            }
            return certificateCollection;
        }

        public JSONWebKeySet GetJSONWebKeySet(X509Certificate2Collection certificateCollection)
        {
            var jwks = new JSONWebKeySet();
            jwks.Keys = new List<JSONWebKey>();
            foreach (var certificate in certificateCollection)
            {
                var jwk = new JSONWebKey() { Kty = "RSA" };
                jwk.X5c = new List<string>() { System.Convert.ToBase64String(certificate.Export(X509ContentType.Cert)) };
                jwks.Keys.Add(jwk);
            }
            return jwks;
        }
    }
}