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

namespace Microsoft.AzureStack.Commands
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Gallery Item Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.GalleryItem)]
    [OutputType(typeof(AzureOperationResponse))]
    public class AddGalleryItem : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [ValidateNotNull]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the resource manager location.
        /// </summary>
        [ValidateNotNull]
        public string ArmLocation { get; set; } // TODO - use API to get CSM location?

        /// <summary>
        /// Gets or sets the gallery item uri.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string GalleryItemUri { get; set; }

        static AddGalleryItem()
        {
        }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            if (!string.IsNullOrEmpty(this.ArmLocation))
            {
                WriteWarning("ArmLocation parameter will be removed in a future release of AzureStackAdmin module.");
            }

            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                var galleryItemUriPayload = new GalleryItemUriPayload()
                {
                        GalleryItemUri = this.GalleryItemUri
                };

                var uploadParameters = new GalleryItemCreateOrUpdateParameters() { GalleryItemUri = galleryItemUriPayload };
                return client.GalleryItem.CreateOrUpdate(uploadParameters);
            }
        }
    }
}
