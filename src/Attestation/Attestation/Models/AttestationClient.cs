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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Attestation;
using Microsoft.Azure.Management.Attestation.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationClient
    {
        private readonly AttestationManagementClient attestationClient;

        public AttestationClient(IAzureContext context)
        {
            attestationClient = AzureSession.Instance.ClientFactory.CreateArmClient<AttestationManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public AttestationClient()
        {
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
            if (string.IsNullOrWhiteSpace(attestationName))
            {
                throw new ArgumentNullException("attestationName");
            }

            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            attestationClient.AttestationProviders.Delete(resourceGroupName, attestationName);
        }
    }
}