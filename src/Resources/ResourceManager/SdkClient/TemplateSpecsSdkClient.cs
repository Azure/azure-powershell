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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class TemplateSpecsSdkClient
    {
        public ITemplateSpecsClient TemplateSpecsClient { get; set; }

        private IAzureContext azureContext;

        public TemplateSpecsSdkClient(ITemplateSpecsClient templateSpecsClient)
        {
            this.TemplateSpecsClient = templateSpecsClient;
        }

        /// <summary>
        /// Parameter-less constructor for mocking
        /// </summary>
        public TemplateSpecsSdkClient()
        {
        }

        public TemplateSpecsSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<TemplateSpecsClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;
        }

        public PSTemplateSpec GetTemplateSpec(string templateSpecName,
            string resourceGroupName,
            string templateSpecVersion = null)
        {
            var templateSpec = this.GetAzureSdkTemplateSpec(resourceGroupName, templateSpecName);

            if (templateSpecVersion == null)
            {
                List<TemplateSpecVersion> allVersions = new List<TemplateSpecVersion>();

                var versionPage = TemplateSpecsClient.TemplateSpecVersions.List(resourceGroupName, templateSpecName);
                allVersions.AddRange(versionPage);

                while (versionPage.NextPageLink != null)
                {
                    versionPage = TemplateSpecsClient.TemplateSpecVersions.ListNext(versionPage.NextPageLink);
                    allVersions.AddRange(versionPage);
                }

                return new PSTemplateSpecMultiVersion(templateSpec, allVersions.ToArray());
            }

            // We have a specific version specified:

            TemplateSpecVersion specificVersion = TemplateSpecsClient.TemplateSpecVersions.Get(
                resourceGroupName,
                templateSpecName,
                templateSpecVersion
            );

            return new PSTemplateSpecSingleVersion(templateSpec, specificVersion);
        }

        public IEnumerable<PSTemplateSpec> ListTemplateSpecsBySubscription()
        {
            var list = new List<PSTemplateSpec>();

            var templateSpecs = TemplateSpecsClient.TemplateSpecs.ListBySubscription();

            list.AddRange(templateSpecs.Select(ts=>PSTemplateSpec.FromAzureSDKTemplateSpec(ts)));

            while (templateSpecs.NextPageLink != null)
            {
                templateSpecs =
                    TemplateSpecsClient.TemplateSpecs.ListBySubscriptionNext(templateSpecs.NextPageLink);

                list.AddRange(templateSpecs.Select(ts => PSTemplateSpec.FromAzureSDKTemplateSpec(ts)));
            }

            return list;
        }

        public IEnumerable<PSTemplateSpec> ListTemplateSpecsByResourceGroup(string resourceGroupName)
        {
            var list = new List<PSTemplateSpec>();

            var templateSpecs = TemplateSpecsClient.TemplateSpecs.ListByResourceGroup(resourceGroupName);

            list.AddRange(templateSpecs.Select(ts => PSTemplateSpec.FromAzureSDKTemplateSpec(ts)));

            while (templateSpecs.NextPageLink != null)
            {
                templateSpecs =
                    TemplateSpecsClient.TemplateSpecs.ListByResourceGroupNext(templateSpecs.NextPageLink);
                list.AddRange(templateSpecs.Select(ts => PSTemplateSpec.FromAzureSDKTemplateSpec(ts)));
            }

            return list;
        }

        private TemplateSpec GetAzureSdkTemplateSpec(
            string resourceGroupName,
            string templateSpecName,
            bool throwIfNotExists = true)
        {
            try
            {
                return TemplateSpecsClient.TemplateSpecs.Get(resourceGroupName, templateSpecName);
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists && 
                    ex is DefaultErrorResponseException dex && 
                    dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Template spec does not exist
                    return null;
                }

                throw;
            }
        }

        public PSTemplateSpecSingleVersion CreateOrUpdateTemplateSpecVersion(
            string resourceGroupName,
            string templateSpecName,
            string templateSpecVersion,
            string location,
            PackagedTemplate packagedTemplate,
            string templateSpecDisplayName = null,
            string templateSpecDescription = null,
            string versionDescription = null)
        {
            var templateSpecModel = this.CreateOrUpdateTemplateSpecInternal(
                resourceGroupName,
                templateSpecName,
                location,
                templateSpecDisplayName,
                templateSpecDescription
            );

            var templateSpecVersionModel = new TemplateSpecVersion
            {
                Location = templateSpecModel.Location,
                Template = packagedTemplate.RootTemplate,
                Artifacts = packagedTemplate.Artifacts?.ToList(),
                Description = versionDescription
            };

            templateSpecVersionModel = TemplateSpecsClient.TemplateSpecVersions.CreateOrUpdate(
                resourceGroupName,
                templateSpecName,
                templateSpecVersion,
                templateSpecVersionModel
            );

            return new PSTemplateSpecSingleVersion(templateSpecModel, templateSpecVersionModel);
        }

        public PSTemplateSpec CreateOrUpdateTemplateSpec(
            string resourceGroupName,
            string templateSpecName,
            string location,
            string templateSpecDisplayName = null,
            string templateSpecDescription = null)
        {
            var sdkTemplateSpecModel = this.CreateOrUpdateTemplateSpecInternal(
                resourceGroupName,
                templateSpecName,
                location,
                templateSpecDisplayName,
                templateSpecDescription
            );

            return new PSTemplateSpec(sdkTemplateSpecModel);
        }

        public void DeleteTemplateSpec(
            string resourceGroupName,
            string templateSpecName, 
            string version = null)
        {
            // Note we don't check if version is whitespace or "" because we want to
            // reduce risk of accidental deletes of full template specs...

            if (version != null)
            {
                // We're deleting a specific version within a template spec
                var versionDeleteResponse = TemplateSpecsClient.TemplateSpecVersions
                    .DeleteWithHttpMessagesAsync(resourceGroupName, templateSpecName, version)
                    .GetAwaiter()
                    .GetResult();

                if (versionDeleteResponse.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    // TODO: Localize
                    throw new PSArgumentException(
                        $"Template Spec '{templateSpecName}' version '{version}' in resource group '{resourceGroupName}' not found!"
                    );
                }

                return;
            }

            // We're deleting the entire template spec...
            var templateSpecDeleteResponse = TemplateSpecsClient.TemplateSpecs
                .DeleteWithHttpMessagesAsync(resourceGroupName, templateSpecName)
                .GetAwaiter()
                .GetResult();

            if (templateSpecDeleteResponse.Response.StatusCode == HttpStatusCode.NoContent)
            {
                // TODO: Localize
                throw new PSArgumentException(
                    $"Template Spec '{templateSpecName}' in resource group '{resourceGroupName}' not found!"
                );
            }
        }

        /// <remarks>
        /// Method name is protected and has an 'Internal' suffix because the return type is
        /// the SDK model rather than the model wrapped for PS. See
        /// <see cref="CreateOrUpdateTemplateSpec(string, string, string, string, string)"/>
        /// for the method that returns the wrapped model.
        /// </remarks>
        protected TemplateSpec CreateOrUpdateTemplateSpecInternal(
            string resourceGroupName,
            string templateSpecName,
            string location,
            string templateSpecDisplayName = null,
            string templateSpecDescription = null)
        {
            var existingTemplateSpec = this.GetAzureSdkTemplateSpec(
                resourceGroupName,
                templateSpecName,
                throwIfNotExists: false
            );

            if (location == null)
            {
                if (existingTemplateSpec != null)
                {
                    location = existingTemplateSpec.Location;
                }
                else
                {
                    // TODO: Use the resource group location
                    // TODO: Localize
                    throw new PSInvalidOperationException("Location cannot be inferred and must be specified.");
                }
            }

            var templateSpecModel = new TemplateSpec
            {
                Location = location,
                Description = templateSpecDescription ?? existingTemplateSpec?.Description,
                DisplayName = templateSpecDisplayName ?? existingTemplateSpec?.DisplayName,
                Tags = existingTemplateSpec?.Tags
            };

            templateSpecModel = TemplateSpecsClient.TemplateSpecs.CreateOrUpdate(
                resourceGroupName,
                templateSpecName,
                templateSpecModel
            );

            return templateSpecModel;
        }
    }
}
