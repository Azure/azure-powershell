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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.RestClients;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Tags.Model
{
    public abstract class TagBaseCmdlet : AzureRMCmdlet
    {
        private TagsClient tagsClient;

        private TagsApiClient tagsApiClient;

        public TagsClient TagsClient
        {
            get
            {
                if (tagsClient == null)
                {
                    tagsClient = new TagsClient(this.DefaultContext);
                }

                this.tagsClient.VerboseLogger = this.WriteVerboseWithTimestamp;
                this.tagsClient.ErrorLogger = this.WriteErrorWithTimestamp;
                return tagsClient;
            }

            set { tagsClient = value; }
        }

        public TagsApiClient TagsApiClient
        {
            get
            {
                if (tagsApiClient == null)
                {
                    tagsApiClient = new TagsApiClient(this.DefaultContext, this.GetResourcesClient(), this.WriteVerboseWithTimestamp, this.WriteErrorWithTimestamp);
                }

                return tagsApiClient;
            }

            set { tagsApiClient = value; }
        }

        /// <summary>
        /// Gets a new instance of the <see cref="ResourceManagerRestRestClient"/>.
        /// </summary>
        private ResourceManagerRestRestClient GetResourcesClient()
        {
            var endpoint = DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager);

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ApplicationException(
                    "The endpoint for the Azure Resource Manager service is not set. Please report this issue via GitHub or contact Microsoft customer support.");
            }

            return new ResourceManagerRestRestClient(
                endpointUri: new Uri(endpoint, UriKind.Absolute),
                httpClientHelper: HttpClientHelperFactory.Instance.CreateHttpClientHelper(
                    credentials: AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(this.DefaultContext, AzureEnvironment.Endpoint.ResourceManager),
                    headerValues: AzureSession.Instance.ClientFactory.UserAgents,
                    cmdletHeaderValues: this.GetCmdletHeaders()));
        }

        private Dictionary<string, string> GetCmdletHeaders()
        {
            return new Dictionary<string, string>
            {
                {"ParameterSetName", this.ParameterSetName },
                {"CommandName", this.CommandRuntime.ToString() }
            };
        }
    }
}
