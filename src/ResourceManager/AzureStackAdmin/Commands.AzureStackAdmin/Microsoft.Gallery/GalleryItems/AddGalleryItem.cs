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
    using Microsoft.Azure;
    using Microsoft.AzureStack.Management;
    using Microsoft.AzureStack.Management.Models;
    using Microsoft.WindowsAzure.Commands.Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;

    /// <summary>
    /// Gallery Item Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, Nouns.GalleryItem)]
    [OutputType(typeof(AzureOperationResponse))]
    public class AddGalleryItem : AdminApiCmdlet
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
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
        /// Gets or sets the path. TODO - support directory and file path.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [ValidateNotNull]
        public string Path { get; set; }

        /// <summary>
        /// This queue is used by the tests to assign fixed GalleryPackageId
        /// every time the test runs
        /// </summary>
        public static Queue<Guid> GalleryPackageIds { get; set; }

        static AddGalleryItem()
        {
            GalleryPackageIds = new Queue<Guid>();
        }

        /// <summary>
        /// Executes the API call(s) against Azure Resource Management API(s).
        /// </summary>
        protected override object ExecuteCore()
        {
            this.WriteVerbose(Resources.AddingGalleryItem.FormatArgs(this.Name));

            using (var client = this.GetAzureStackClient(this.SubscriptionId))
            using (var filestream = File.Open(this.Path, FileMode.Open, FileAccess.Read))
            {
                var manifest = client.Package.CreateOrUpdate(
                    this.ResourceGroup,
                    (AddGalleryItem.GalleryPackageIds.Count == 0
                        ? Guid.NewGuid()
                        : AddGalleryItem.GalleryPackageIds.Dequeue()).ToString(),
                    filestream);
                var uploadParameters = new GalleryItemCreateOrUpdateParameters() { Manifest = manifest.Manifest };
                return client.GalleryItem.CreateOrUpdate(this.ResourceGroup, this.Name, uploadParameters);
            }
        }
    }
}
