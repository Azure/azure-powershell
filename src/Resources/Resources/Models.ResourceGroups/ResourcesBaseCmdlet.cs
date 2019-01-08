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
    using Authorization;
    using ResourceManager.Common;

    /// <summary> 
    /// Base class for all resources cmdlets
    /// </summary>
    public abstract class ResourcesBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// Field that holds the resource client instance
        /// </summary>
        private ResourcesClient _resourcesClient;

// TODO: Remove IfDef code
#if !NETSTANDARD
        /// <summary>
        /// Field that holds the gallery templates client instance
        /// </summary>
        private GalleryTemplatesClient _galleryTemplatesClient;
#endif

        /// <summary>
        /// Field that holds the policies client instance
        /// </summary>
        private AuthorizationClient _policiesClient;

        /// <summary>
        /// Field that holds the subscriptions client instance
        /// </summary>
        private SubscriptionsClient _subscriptionsClient;

        /// <summary>
        /// Gets or sets the resources client
        /// </summary>
        public ResourcesClient ResourcesClient
        {
            get
            {
                return _resourcesClient ?? (_resourcesClient = new ResourcesClient(DefaultContext)
                {
                    VerboseLogger = WriteVerboseWithTimestamp,
                    ErrorLogger = WriteErrorWithTimestamp,
                    WarningLogger = WriteWarningWithTimestamp
                });
            }

            set { _resourcesClient = value; }
        }

// TODO: Remove IfDef code
#if !NETSTANDARD
        /// <summary>
        /// Gets or sets the gallery templates client
        /// </summary>
        public GalleryTemplatesClient GalleryTemplatesClient
        {
            get
            {
                if (_galleryTemplatesClient == null)
                {
                    // since this accessor can be called before BeginProcessing, use GetCurrentContext if no 
                    // profile is passed in
                    _galleryTemplatesClient = new GalleryTemplatesClient(DefaultContext);
                }

                return _galleryTemplatesClient;
            }

            set { _galleryTemplatesClient = value; }
        }
#endif

        /// <summary>
        /// Gets or sets the policies client
        /// </summary>
        public AuthorizationClient PoliciesClient
        {
            get { return _policiesClient ?? (_policiesClient = new AuthorizationClient(DefaultContext)); }

            set { _policiesClient = value; }
        }

        /// <summary>
        /// Gets or sets the subscriptions client
        /// </summary>
        public SubscriptionsClient SubscriptionsClient
        {
            get { return _subscriptionsClient ?? (_subscriptionsClient = new SubscriptionsClient(DefaultContext)); }

            set { _subscriptionsClient = value; }
        }

        /// <summary>
        /// Determines the parameter set name.
        /// </summary>
        public virtual string DetermineParameterSetName()
        {
            return ParameterSetName;
        }
    }
}
