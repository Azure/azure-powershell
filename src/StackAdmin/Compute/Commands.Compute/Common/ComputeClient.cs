﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Compute;
using System;
using System.Net.Http;

namespace Microsoft.Azure.Commands.Compute
{
    public class ComputeClient
    {
        public IComputeManagementClient ComputeManagementClient { get; private set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public ComputeClient(IAzureContext context) {
            // Factories
            var authFactory = AzureSession.Instance.AuthenticationFactory;
            var clientFactory = AzureSession.Instance.ClientFactory;

            var endpoint = AzureEnvironment.Endpoint.ResourceManager;

            // Get parameters
            var handler = new DelegatingHandler[] { new DoubleFetchHandler() };
            var creds = authFactory.GetServiceClientCredentials(context, endpoint);
            var baseUri = context.Environment.GetEndpointAsUri(endpoint);

            // Construct client
            ComputeManagementClient = clientFactory.CreateCustomArmClient<ComputeManagementClient>(baseUri, creds, handler);
            ComputeManagementClient.SubscriptionId = context.Subscription.Id.ToString();
        }

        public ComputeClient(IComputeManagementClient computeManagementClient) {
            ComputeManagementClient = computeManagementClient;
        }
    }
}