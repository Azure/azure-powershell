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
    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    /// <summary> 
    /// Base class for all resources cmdlets
    /// </summary>
    public abstract class ResourcesBaseCmdlet : AzurePSCmdlet
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
        /// Gets or sets the resources client
        /// </summary>
        public ResourcesClient ResourcesClient
        {
            get
            {
                if (resourcesClient == null)
                {
                    resourcesClient = new ResourcesClient(CurrentContext)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp,
                        WarningLogger = WriteWarningWithTimestamp
                    };
                }
                return resourcesClient;
            }

            set { resourcesClient = value; }
        }

        /// <summary>
        /// Gets or sets the galary templates client
        /// </summary>
        public GalleryTemplatesClient GalleryTemplatesClient
        {
            get
            {
                if (galleryTemplatesClient == null)
                {
                    galleryTemplatesClient = new GalleryTemplatesClient(CurrentContext);
                }
                return galleryTemplatesClient;
            }

            set { galleryTemplatesClient = value; }
        }

        /// <summary>
        /// Gets or sets the policies client
        /// </summary>
        public AuthorizationClient PoliciesClient
        {
            get
            {
                if (policiesClient == null)
                {
                    policiesClient = new AuthorizationClient(CurrentContext);
                }
                return policiesClient;
            }

            set { policiesClient = value; }
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
