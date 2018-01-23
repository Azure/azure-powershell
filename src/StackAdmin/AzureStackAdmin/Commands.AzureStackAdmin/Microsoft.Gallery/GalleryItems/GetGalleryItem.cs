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
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;

    /// <summary>
    /// Gallery Item Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.GalleryItem)]
    [OutputType(typeof(GalleryItemModel))]
    [Alias("Get-AzureRmGalleryItem")]
    public class GetGalleryItem : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override void ExecuteCore()
        {
            if (this.MyInvocation.InvocationName.Equals("Get-AzureRmGalleryItem", StringComparison.OrdinalIgnoreCase))
            {
                this.WriteWarning("Alias Get-AzureRmGalleryItem will be deprecated in a future release. Please use the cmdlet name Get-AzsGalleryItem instead");
            }

            this.ApiVersion = GalleryAdminApiVersion;
            using (var client = this.GetAzureStackClient())
            {
                if (string.IsNullOrEmpty(this.Name))
                {
                    this.WriteVerbose(Resources.ListingGalleryItems);

                    var result = client.GalleryItem.List().GalleryItems;
                    WriteObject(result, enumerateCollection: true);
                }
                else
                {
                    this.WriteVerbose(Resources.GettingGalleryItem.FormatArgs(this.Name));
                    var result = client.GalleryItem.Get(this.Name).GalleryItem;
                    WriteObject(result);
                }
            }
        }
    }
}
