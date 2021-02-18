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
        public PSAttestation CreateNewAttestation(AttestationCreationParameters newServiceParams)
        {
            if (newServiceParams == null)
            {
                throw new ArgumentNullException(nameof(newServiceParams));
            }
            if (string.IsNullOrEmpty(newServiceParams.ProviderName))
            {
                throw new ArgumentNullException(nameof(newServiceParams.ProviderName));
            }
            if (string.IsNullOrEmpty(newServiceParams.ResourceGroupName))
            {
                throw new ArgumentNullException(nameof(newServiceParams.ResourceGroupName));
            }
            var response = attestationClient.AttestationProviders.Create(
                resourceGroupName: newServiceParams.ResourceGroupName,
                providerName: newServiceParams.ProviderName,
                creationParams: newServiceParams.CreationParameters);
            return new PSAttestation(response);
        }

        public PSAttestation GetAttestation(string attestationName, string resourceGroupName)
        {
            if (string.IsNullOrEmpty(attestationName))
            {
                throw new ArgumentNullException(nameof(attestationName));
            }
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            var response = attestationClient.AttestationProviders.Get(resourceGroupName, attestationName);
            return new PSAttestation(response);
        }

        public PSAttestation GetDefaultAttestationByLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException(nameof(location));
            }
            var response = attestationClient.AttestationProviders.GetDefaultByLocation(location);
            return new PSAttestation(response);
        }

        public List<PSAttestation> ListDefaultAttestation()
        {
            List<PSAttestation> result = new List<PSAttestation>();
            var response = attestationClient.AttestationProviders.ListDefault();
            foreach (var defaultProvider in response.Value)
            {
                result.Add(new PSAttestation(defaultProvider));
            }
            return result;
        }

        public void DeleteAttestation(string attestationName, string resourceGroupName)
        {
            if (string.IsNullOrEmpty(attestationName))
            {
                throw new ArgumentNullException(nameof(attestationName));
            }

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            attestationClient.AttestationProviders.Delete(resourceGroupName, attestationName);
        }

    }
}