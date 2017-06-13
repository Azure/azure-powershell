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
    using System.Management.Automation;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Gallery Item Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.GalleryItem, SupportsShouldProcess = true)]
    [OutputType(typeof(AzureOperationResponse))]
    [Alias("Add-AzureRmGalleryItem")]
    public class AddGalleryItem : AdminApiCmdlet
    {
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
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Add-AzureRmGalleryItem", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Add-AzureRmGalleryItem will be deprecated in a future release. Please use the cmdlet name Add-AzsGalleryItem instead");
            }

            if (ShouldProcess(this.GalleryItemUri, VerbsCommon.Add))
            {
                this.ApiVersion = GalleryAdminApiVersion;
                using (var client = this.GetAzureStackClient())
                {
                    var galleryItemUriPayload = new GalleryItemUriPayload()
                    {
                        GalleryItemUri = this.GalleryItemUri
                    };

                    var uploadParameters = new GalleryItemCreateOrUpdateParameters()
                    {
                        GalleryItemUri = galleryItemUriPayload
                    };
                    var result = client.GalleryItem.CreateOrUpdate(uploadParameters);
                    WriteObject(result);
                }
            }
        }
    }
}
