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
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Gallery Item Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.GalleryItem)]
    [OutputType(typeof(GalleryItemModel))]
    public class GetGalleryItem : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateLength(1, 128)]
        [ValidateNotNull]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false)]
        [ValidateNotNull]
        [ValidateGuidNotEmpty]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.WriteVerbose(Resources.ListingGalleryItems);

                    return string.IsNullOrEmpty(this.ResourceGroup)
                        ? client.GalleryItem.ListWithoutResourceGroup().GalleryItems
                        : client.GalleryItem.List(this.ResourceGroup).GalleryItems;
                }
                else if (string.IsNullOrEmpty(this.ResourceGroup))
                {
                    throw new ValidationMetadataException(Resources.ResourceGroupCannotBeEmpty);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingGalleryItem.FormatArgs(this.Name));
                    return client.GalleryItem.Get(this.ResourceGroup, this.Name).GalleryItem;
                }
            }
        }
    }
}
