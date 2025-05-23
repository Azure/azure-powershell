// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Extensions;

    /// <summary>
    /// Information about an offering. A provider offering is an entity that offers Targets to run Azure Quantum Jobs.
    /// </summary>
    public partial class ProviderDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescription,
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal
    {

        /// <summary>Provider's application id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string AadApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadApplicationId; }

        /// <summary>Provider's tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string AadTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadTenantId; }

        /// <summary>Company name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string Company { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Company; }

        /// <summary>Provider's default endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string DefaultEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).DefaultEndpoint; }

        /// <summary>A description about this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Description; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Unique provider's id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Provider's offer id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string ManagedApplicationOfferId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationOfferId; }

        /// <summary>Provider's publisher id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string ManagedApplicationPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationPublisherId; }

        /// <summary>Internal Acessors for Aad</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesAad Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.Aad { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Aad; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Aad = value; }

        /// <summary>Internal Acessors for AadApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.AadApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadApplicationId = value; }

        /// <summary>Internal Acessors for AadTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.AadTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).AadTenantId = value; }

        /// <summary>Internal Acessors for Company</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.Company { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Company; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Company = value; }

        /// <summary>Internal Acessors for DefaultEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.DefaultEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).DefaultEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).DefaultEndpoint = value; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Description = value; }

        /// <summary>Internal Acessors for ManagedApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesManagedApplication Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.ManagedApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplication = value; }

        /// <summary>Internal Acessors for ManagedApplicationOfferId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.ManagedApplicationOfferId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationOfferId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationOfferId = value; }

        /// <summary>Internal Acessors for ManagedApplicationPublisherId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.ManagedApplicationPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationPublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ManagedApplicationPublisherId = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderProperties Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ProviderProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProviderType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderDescriptionInternal.ProviderType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ProviderType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ProviderType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Provider's display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>The list of pricing dimensions from the provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IPricingDimension> PricingDimension { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).PricingDimension; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).PricingDimension = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderProperties _property;

        /// <summary>A list of provider-specific properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ProviderProperties()); set => this._property = value; }

        /// <summary>Provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public string ProviderType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).ProviderType; }

        /// <summary>The list of quota dimensions from the provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuotaDimension> QuotaDimension { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).QuotaDimension; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).QuotaDimension = value ?? null /* arrayOf */; }

        /// <summary>The list of skus available from this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ISkuDescription> Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Sku = value ?? null /* arrayOf */; }

        /// <summary>The list of targets available from this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Origin(Microsoft.Azure.PowerShell.Cmdlets.Quantum.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ITargetDescription> Target { get => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Target; set => ((Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesInternal)Property).Target = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="ProviderDescription" /> instance.</summary>
        public ProviderDescription()
        {

        }
    }
    /// Information about an offering. A provider offering is an entity that offers Targets to run Azure Quantum Jobs.
    public partial interface IProviderDescription :
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.IJsonSerializable
    {
        /// <summary>Provider's application id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's application id.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string AadApplicationId { get;  }
        /// <summary>Provider's tenant id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's tenant id.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string AadTenantId { get;  }
        /// <summary>Company name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Company name.",
        SerializedName = @"company",
        PossibleTypes = new [] { typeof(string) })]
        string Company { get;  }
        /// <summary>Provider's default endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's default endpoint.",
        SerializedName = @"defaultEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultEndpoint { get;  }
        /// <summary>A description about this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"A description about this provider.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Unique provider's id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Unique provider's id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>Provider's offer id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's offer id.",
        SerializedName = @"offerId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedApplicationOfferId { get;  }
        /// <summary>Provider's publisher id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's publisher id.",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string ManagedApplicationPublisherId { get;  }
        /// <summary>Provider's display name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider's display name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The list of pricing dimensions from the provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of pricing dimensions from the provider.",
        SerializedName = @"pricingDimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IPricingDimension) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IPricingDimension> PricingDimension { get; set; }
        /// <summary>Provider type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Provider type.",
        SerializedName = @"providerType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderType { get;  }
        /// <summary>The list of quota dimensions from the provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of quota dimensions from the provider.",
        SerializedName = @"quotaDimensions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuotaDimension) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuotaDimension> QuotaDimension { get; set; }
        /// <summary>The list of skus available from this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of skus available from this provider.",
        SerializedName = @"skus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ISkuDescription) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ISkuDescription> Sku { get; set; }
        /// <summary>The list of targets available from this provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Quantum.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of targets available from this provider.",
        SerializedName = @"targets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ITargetDescription) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ITargetDescription> Target { get; set; }

    }
    /// Information about an offering. A provider offering is an entity that offers Targets to run Azure Quantum Jobs.
    internal partial interface IProviderDescriptionInternal

    {
        /// <summary>Azure Active Directory info.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesAad Aad { get; set; }
        /// <summary>Provider's application id.</summary>
        string AadApplicationId { get; set; }
        /// <summary>Provider's tenant id.</summary>
        string AadTenantId { get; set; }
        /// <summary>Company name.</summary>
        string Company { get; set; }
        /// <summary>Provider's default endpoint.</summary>
        string DefaultEndpoint { get; set; }
        /// <summary>A description about this provider.</summary>
        string Description { get; set; }
        /// <summary>Unique provider's id.</summary>
        string Id { get; set; }
        /// <summary>Provider's Managed-Application info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderPropertiesManagedApplication ManagedApplication { get; set; }
        /// <summary>Provider's offer id.</summary>
        string ManagedApplicationOfferId { get; set; }
        /// <summary>Provider's publisher id.</summary>
        string ManagedApplicationPublisherId { get; set; }
        /// <summary>Provider's display name.</summary>
        string Name { get; set; }
        /// <summary>The list of pricing dimensions from the provider.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IPricingDimension> PricingDimension { get; set; }
        /// <summary>A list of provider-specific properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IProviderProperties Property { get; set; }
        /// <summary>Provider type.</summary>
        string ProviderType { get; set; }
        /// <summary>The list of quota dimensions from the provider.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.IQuotaDimension> QuotaDimension { get; set; }
        /// <summary>The list of skus available from this provider.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ISkuDescription> Sku { get; set; }
        /// <summary>The list of targets available from this provider.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Quantum.Models.ITargetDescription> Target { get; set; }

    }
}