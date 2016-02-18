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
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Resources.Models.ProviderFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

    /// <summary>
    /// Helper client for performing operations on features
    /// </summary>
    public class ProviderFeatureClient
    {
        /// <summary>
        /// The Registered state
        /// </summary>
        public const string RegisteredStateName = "Registered";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderFeatureClient"/> class.
        /// </summary>
        public ProviderFeatureClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProviderFeatureClient"/> class.
        /// </summary>
        /// <param name="context">The azure context</param>
        public ProviderFeatureClient(AzureContext context)
        {
            this.FeaturesManagementClient = AzureSession.ClientFactory.CreateClient<Management.Resources.FeatureClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        /// <summary>
        /// The features management client
        /// </summary>
        public IFeatureClient FeaturesManagementClient { get; set; }


        /// <summary>
        /// Lists the features that ARM knows about
        /// </summary>
        /// <param name="resourceProviderNamespace">When specified, returns all features that are defined by this resource provider namespace</param>
        /// <param name="featureName">When specified, returns all features that have this name</param>
        public virtual PSProviderFeature[] ListPSProviderFeatures(string resourceProviderNamespace = null, string featureName = null)
        {
            return this.ListPSProviderFeatures(resourceProviderNamespace: resourceProviderNamespace, featureName: featureName, listAvailable: false);
        }

        /// <summary>
        /// Lists the features that ARM knows about
        /// </summary>
        /// <param name="resourceProviderNamespace">When specified, returns all features that are defined by this resource provider namespace</param>
        /// <param name="listAvailable">When set to true, lists all features that are available including those not registered on the current subscription</param>
        public virtual PSProviderFeature[] ListPSProviderFeatures(bool listAvailable, string resourceProviderNamespace = null)
        {
            return this.ListPSProviderFeatures(resourceProviderNamespace: resourceProviderNamespace, listAvailable: listAvailable, featureName: null);
        }

        /// <summary>
        /// Lists the features that ARM knows about
        /// </summary>
        /// <param name="resourceProviderNamespace">When specified, returns all features that are defined by this resource provider namespace</param>
        /// <param name="featureName">When specified, returns all features that have this name</param>
        /// <param name="listAvailable">When set to true, lists all features that are available including those not registered on the current subscription</param>
        private PSProviderFeature[] ListPSProviderFeatures(string resourceProviderNamespace = null, string featureName = null, bool listAvailable = false)
        {
            if (!string.IsNullOrEmpty(featureName) && !string.IsNullOrWhiteSpace(resourceProviderNamespace))
            {
                var featureResponse = this.FeaturesManagementClient.Features.Get(resourceProviderNamespace: resourceProviderNamespace, featureName: featureName);

                if (featureResponse == null)
                {
                    throw new KeyNotFoundException(string.Format(ProjectResources.FeatureNotFound, featureName, resourceProviderNamespace));
                }

                return new [] { featureResponse.ToPSProviderFeature() };
            }
            else
            {
                Func<FeatureOperationsListResult> listFunc;
                Func<string, FeatureOperationsListResult> listNextFunc;

                if (string.IsNullOrWhiteSpace(resourceProviderNamespace))
                {
                    listFunc = () => this.FeaturesManagementClient.Features.ListAll();
                    listNextFunc = next => this.FeaturesManagementClient.Features.ListAllNext(next);
                }
                else
                {
                    listFunc = () => this.FeaturesManagementClient.Features.List(resourceProviderNamespace);
                    listNextFunc = next => this.FeaturesManagementClient.Features.ListNext(next);
                }

                var returnList = new List<FeatureResponse>(); 
                var tempResult = listFunc();

                returnList.AddRange(tempResult.Features);

                while(!string.IsNullOrWhiteSpace(tempResult.NextLink))
                {
                    tempResult = listNextFunc(tempResult.NextLink);
                    returnList.AddRange(tempResult.Features);
                }

                var retVal = listAvailable
                    ? returnList
                    : returnList.Where(this.IsFeatureRegistered);

                return retVal
                    .Select(val => val.ToPSProviderFeature())
                    .ToArray();
            }
        }

        /// <summary>
        /// Registers a feature on the current subscription
        /// </summary>
        /// <param name="providerName">The name of the resource provider</param>
        /// <param name="featureName">The name of the feature</param>
        public PSProviderFeature RegisterProviderFeature(string providerName, string featureName)
        {
            return this.FeaturesManagementClient.Features.Register(providerName, featureName).ToPSProviderFeature();
        }

        /// <summary>
        /// Checks if a feature is registered with the current subscription
        /// </summary>
        /// <param name="feature">The feature</param>
        private bool IsFeatureRegistered(FeatureResponse feature)
        {
            return string.Equals(feature.Properties.State, ProviderFeatureClient.RegisteredStateName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
