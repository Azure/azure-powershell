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


namespace Microsoft.Azure.Commands.Resources.Models
{
    using Microsoft.Azure.Commands.Resources.Models.Authorization;
    using ResourceManager.Common;

    /// <summary> 
    /// Base class for all resources cmdlets
    /// </summary>
    public abstract class ResourcesBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// Field that holds the resource client instance
        /// </summary>
        private ResourcesClient resourcesClient;

        /// <summary>
        /// Field that holds the gallery templates client instance
        /// </summary>
        private GalleryTemplatesClient galleryTemplatesClient;

        /// <summary>
        /// Field that holds the policies client instance
        /// </summary>
        private AuthorizationClient policiesClient;

        /// <summary>
        /// Field that holds the subscripotions client instance
        /// </summary>
        private SubscriptionsClient subscriptionsClient;

        /// <summary>
        /// Gets or sets the resources client
        /// </summary>
        public ResourcesClient ResourcesClient
        {
            get
            {
                if (this.resourcesClient == null)
                {
                    this.resourcesClient = new ResourcesClient(DefaultContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return this.resourcesClient;
            }

            set { this.resourcesClient = value; }
        }

        /// <summary>
        /// Gets or sets the gallery templates client
        /// </summary>
        public GalleryTemplatesClient GalleryTemplatesClient
        {
            get
            {
                if (this.galleryTemplatesClient == null)
                {
                    // since this accessor can be called before BeginProcessing, use GetCurrentContext if no 
                    // profile is passed in
                    this.galleryTemplatesClient = new GalleryTemplatesClient(DefaultContext);
                }

                return this.galleryTemplatesClient;
            }

            set { this.galleryTemplatesClient = value; }
        }

        /// <summary>
        /// Gets or sets the policies client
        /// </summary>
        public AuthorizationClient PoliciesClient
        {
            get
            {
                if (this.policiesClient == null)
                {
                    this.policiesClient = new AuthorizationClient(DefaultContext);
                }
                return this.policiesClient;
            }

            set { this.policiesClient = value; }
        }

        /// <summary>
        /// Gets or sets the subscriptions client
        /// </summary>
        public SubscriptionsClient SubscriptionsClient
        {
            get
            {
                if (this.subscriptionsClient == null)
                {
                    this.subscriptionsClient = new SubscriptionsClient(DefaultContext);
                }
                return this.subscriptionsClient;
            }

            set { this.subscriptionsClient = value; }
        }

        /// <summary>
        /// Determines the parameter set name.
        /// </summary>
        public virtual string DetermineParameterSetName()
        {
            return this.ParameterSetName;
        }
    }
}
