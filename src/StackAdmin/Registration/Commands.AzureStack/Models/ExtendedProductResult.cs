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

namespace Microsoft.Azure.Commands.AzureStack.Models
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AzureStack.Models;

    public class ExtendedProductResult
    {
        public ExtendedProductResult(ExtendedProduct product)
        {
            this.GalleryPackageBlobSasUri = product.GalleryPackageBlobSasUri;
            this.ProductKind = product.ProductKind;
            this.ComputeRole = product.ComputeRole;
            this.IsSystemExtension = product.IsSystemExtension;
            this.UriProperty = product.UriProperty;
            this.SupportMultipleExtensions = product.SupportMultipleExtensions;
            this.Version = product.Version;
            this.VmOsType = product.VmOsType;
            this.VmScaleSetEnabled = product.VmScaleSetEnabled;
            this.OsDiskImage = product.OsDiskImage;
            this.DataDiskImages = product.DataDiskImages;
        }

        public ExtendedProductResult() { }

        public string GalleryPackageBlobSasUri { get; protected set; }

        public string ProductKind { get; protected set; }

        public string ComputeRole { get; protected set; }

        public bool? IsSystemExtension { get; protected set; }

        public string UriProperty { get; protected set; }

        public bool? SupportMultipleExtensions { get; protected set; }

        public string Version { get; protected set; }

        public string VmOsType { get; protected set; }

        public bool? VmScaleSetEnabled { get; protected set; }

        public OsDiskImage OsDiskImage { get; protected set; }

        public IList<DataDiskImage> DataDiskImages { get; protected set; }
    }
}