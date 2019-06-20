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

    public class ProductResult
    {
        public ProductResult(Product product)
        {
            this.Name = product.Name;
            this.Id = product.Id;
            this.PayloadLength = product.PayloadLength;
            this.PrivacyPolicy = product.PrivacyPolicy;
            this.LegalTerms = product.LegalTerms;
            this.Links = product.Links;
            this.IconUris = product.IconUris;
            this.GalleryItemIdentity = product.GalleryItemIdentity;
            this.VmExtensionType = product.VmExtensionType;
            this.BillingPartNumber = product.BillingPartNumber;
            this.Sku = product.Sku;
            this.OfferVersion = product.OfferVersion;
            this.Offer = product.Offer;
            this.PublisherIdentifier = product.PublisherIdentifier;
            this.PublisherDisplayName = product.PublisherDisplayName;
            this.Description = product.Description;
            this.DisplayName = product.DisplayName;
            this.ProductKind = product.ProductKind;
            this.ProductProperties = product.ProductProperties;
        }

        public ProductResult() { }

        public string Name { get; protected set; }

        public string Id { get; protected set; }

        public long? PayloadLength { get; protected set; }

        public string PrivacyPolicy { get; protected set; }

        public string LegalTerms { get; protected set; }

        public IList<ProductLink> Links { get; protected set; }

        public IconUris IconUris { get; protected set; }

        public string GalleryItemIdentity { get; protected set; }

        public string VmExtensionType { get; protected set; }

        public string BillingPartNumber { get; protected set; }

        public string Sku { get; protected set; }

        public string OfferVersion { get; protected set; }

        public string Offer { get; protected set; }

        public string PublisherIdentifier { get; protected set; }

        public string PublisherDisplayName { get; protected set; }

        public string Description { get; protected set; }

        public string DisplayName { get; protected set; }

        public string ProductKind { get; protected set; }

        public ProductProperties ProductProperties { get; protected set; }
    }
}