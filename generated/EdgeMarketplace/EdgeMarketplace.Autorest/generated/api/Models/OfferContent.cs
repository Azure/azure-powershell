// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The offer content</summary>
    public partial class OfferContent :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContent,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal
    {

        /// <summary>Backing field for <see cref="Availability" /> property.</summary>
        private string _availability;

        /// <summary>The availability of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Availability { get => this._availability; set => this._availability = value; }

        /// <summary>Backing field for <see cref="CategoryId" /> property.</summary>
        private System.Collections.Generic.List<string> _categoryId;

        /// <summary>The category ids</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> CategoryId { get => this._categoryId; set => this._categoryId = value; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>The display name of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="IconFileUri" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris _iconFileUri;

        /// <summary>The icon files</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris IconFileUri { get => (this._iconFileUri = this._iconFileUri ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IconFileUris()); set => this._iconFileUri = value; }

        /// <summary>uri of large icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string IconFileUriLarge { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Large; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Large = value ?? null; }

        /// <summary>uri of medium icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string IconFileUriMedium { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Medium; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Medium = value ?? null; }

        /// <summary>uri of small icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string IconFileUriSmall { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Small; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Small = value ?? null; }

        /// <summary>uri of wide icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string IconFileUriWide { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Wide; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUrisInternal)IconFileUri).Wide = value ?? null; }

        /// <summary>Backing field for <see cref="LongSummary" /> property.</summary>
        private string _longSummary;

        /// <summary>The long summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string LongSummary { get => this._longSummary; set => this._longSummary = value; }

        /// <summary>Internal Acessors for IconFileUri</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal.IconFileUri { get => (this._iconFileUri = this._iconFileUri ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IconFileUris()); set { {_iconFileUri = value;} } }

        /// <summary>Internal Acessors for OfferPublisher</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal.OfferPublisher { get => (this._offerPublisher = this._offerPublisher ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferPublisher()); set { {_offerPublisher = value;} } }

        /// <summary>Internal Acessors for TermsAndCondition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferContentInternal.TermsAndCondition { get => (this._termsAndCondition = this._termsAndCondition ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.TermsAndConditions()); set { {_termsAndCondition = value;} } }

        /// <summary>Backing field for <see cref="OfferId" /> property.</summary>
        private string _offerId;

        /// <summary>The offer id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string OfferId { get => this._offerId; set => this._offerId = value; }

        /// <summary>Backing field for <see cref="OfferPublisher" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher _offerPublisher;

        /// <summary>The publisher of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher OfferPublisher { get => (this._offerPublisher = this._offerPublisher ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.OfferPublisher()); set => this._offerPublisher = value; }

        /// <summary>The publisher name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string OfferPublisherDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisherInternal)OfferPublisher).PublisherDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisherInternal)OfferPublisher).PublisherDisplayName = value ?? null; }

        /// <summary>The publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string OfferPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisherInternal)OfferPublisher).PublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisherInternal)OfferPublisher).PublisherId = value ?? null; }

        /// <summary>Backing field for <see cref="OfferType" /> property.</summary>
        private string _offerType;

        /// <summary>The offer type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string OfferType { get => this._offerType; set => this._offerType = value; }

        /// <summary>Backing field for <see cref="OperatingSystem" /> property.</summary>
        private System.Collections.Generic.List<string> _operatingSystem;

        /// <summary>The operating systems</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> OperatingSystem { get => this._operatingSystem; set => this._operatingSystem = value; }

        /// <summary>Backing field for <see cref="Popularity" /> property.</summary>
        private int? _popularity;

        /// <summary>The popularity of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public int? Popularity { get => this._popularity; set => this._popularity = value; }

        /// <summary>Backing field for <see cref="ReleaseType" /> property.</summary>
        private string _releaseType;

        /// <summary>The release type of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string ReleaseType { get => this._releaseType; set => this._releaseType = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private string _summary;

        /// <summary>The summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Backing field for <see cref="SupportUri" /> property.</summary>
        private string _supportUri;

        /// <summary>The support uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string SupportUri { get => this._supportUri; set => this._supportUri = value; }

        /// <summary>The type of legal terms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string TermAndConditionLegalTermsType { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).LegalTermsType; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).LegalTermsType = value ?? null; }

        /// <summary>The legal terms and conditions uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string TermAndConditionLegalTermsUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).LegalTermsUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).LegalTermsUri = value ?? null; }

        /// <summary>The privacy policy uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Inlined)]
        public string TermAndConditionPrivacyPolicyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).PrivacyPolicyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal)TermsAndCondition).PrivacyPolicyUri = value ?? null; }

        /// <summary>Backing field for <see cref="TermsAndCondition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions _termsAndCondition;

        /// <summary>The terms and conditions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions TermsAndCondition { get => (this._termsAndCondition = this._termsAndCondition ?? new Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.TermsAndConditions()); set => this._termsAndCondition = value; }

        /// <summary>Creates an new <see cref="OfferContent" /> instance.</summary>
        public OfferContent()
        {

        }
    }
    /// The offer content
    public partial interface IOfferContent :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The availability of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The availability of the offer",
        SerializedName = @"availability",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Private", "Public")]
        string Availability { get; set; }
        /// <summary>The category ids</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The category ids ",
        SerializedName = @"categoryIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> CategoryId { get; set; }
        /// <summary>The description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The display name of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The display name of the offer",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>uri of large icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of large icon",
        SerializedName = @"large",
        PossibleTypes = new [] { typeof(string) })]
        string IconFileUriLarge { get; set; }
        /// <summary>uri of medium icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of medium icon",
        SerializedName = @"medium",
        PossibleTypes = new [] { typeof(string) })]
        string IconFileUriMedium { get; set; }
        /// <summary>uri of small icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of small icon",
        SerializedName = @"small",
        PossibleTypes = new [] { typeof(string) })]
        string IconFileUriSmall { get; set; }
        /// <summary>uri of wide icon</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"uri of wide icon",
        SerializedName = @"wide",
        PossibleTypes = new [] { typeof(string) })]
        string IconFileUriWide { get; set; }
        /// <summary>The long summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The long summary",
        SerializedName = @"longSummary",
        PossibleTypes = new [] { typeof(string) })]
        string LongSummary { get; set; }
        /// <summary>The offer id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The offer id",
        SerializedName = @"offerId",
        PossibleTypes = new [] { typeof(string) })]
        string OfferId { get; set; }
        /// <summary>The publisher name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The publisher name",
        SerializedName = @"publisherDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string OfferPublisherDisplayName { get; set; }
        /// <summary>The publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The publisher Id",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string OfferPublisherId { get; set; }
        /// <summary>The offer type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The offer type",
        SerializedName = @"offerType",
        PossibleTypes = new [] { typeof(string) })]
        string OfferType { get; set; }
        /// <summary>The operating systems</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The operating systems",
        SerializedName = @"operatingSystems",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> OperatingSystem { get; set; }
        /// <summary>The popularity of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The popularity of the offer",
        SerializedName = @"popularity",
        PossibleTypes = new [] { typeof(int) })]
        int? Popularity { get; set; }
        /// <summary>The release type of the offer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The release type of the offer",
        SerializedName = @"releaseType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Preview", "GA")]
        string ReleaseType { get; set; }
        /// <summary>The summary</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The summary",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(string) })]
        string Summary { get; set; }
        /// <summary>The support uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The support uri",
        SerializedName = @"supportUri",
        PossibleTypes = new [] { typeof(string) })]
        string SupportUri { get; set; }
        /// <summary>The type of legal terms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of legal terms",
        SerializedName = @"legalTermsType",
        PossibleTypes = new [] { typeof(string) })]
        string TermAndConditionLegalTermsType { get; set; }
        /// <summary>The legal terms and conditions uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The legal terms and conditions uri",
        SerializedName = @"legalTermsUri",
        PossibleTypes = new [] { typeof(string) })]
        string TermAndConditionLegalTermsUri { get; set; }
        /// <summary>The privacy policy uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The privacy policy uri",
        SerializedName = @"privacyPolicyUri",
        PossibleTypes = new [] { typeof(string) })]
        string TermAndConditionPrivacyPolicyUri { get; set; }

    }
    /// The offer content
    internal partial interface IOfferContentInternal

    {
        /// <summary>The availability of the offer</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Private", "Public")]
        string Availability { get; set; }
        /// <summary>The category ids</summary>
        System.Collections.Generic.List<string> CategoryId { get; set; }
        /// <summary>The description</summary>
        string Description { get; set; }
        /// <summary>The display name of the offer</summary>
        string DisplayName { get; set; }
        /// <summary>The icon files</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IIconFileUris IconFileUri { get; set; }
        /// <summary>uri of large icon</summary>
        string IconFileUriLarge { get; set; }
        /// <summary>uri of medium icon</summary>
        string IconFileUriMedium { get; set; }
        /// <summary>uri of small icon</summary>
        string IconFileUriSmall { get; set; }
        /// <summary>uri of wide icon</summary>
        string IconFileUriWide { get; set; }
        /// <summary>The long summary</summary>
        string LongSummary { get; set; }
        /// <summary>The offer id</summary>
        string OfferId { get; set; }
        /// <summary>The publisher of the offer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher OfferPublisher { get; set; }
        /// <summary>The publisher name</summary>
        string OfferPublisherDisplayName { get; set; }
        /// <summary>The publisher Id</summary>
        string OfferPublisherId { get; set; }
        /// <summary>The offer type</summary>
        string OfferType { get; set; }
        /// <summary>The operating systems</summary>
        System.Collections.Generic.List<string> OperatingSystem { get; set; }
        /// <summary>The popularity of the offer</summary>
        int? Popularity { get; set; }
        /// <summary>The release type of the offer</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PSArgumentCompleterAttribute("Preview", "GA")]
        string ReleaseType { get; set; }
        /// <summary>The summary</summary>
        string Summary { get; set; }
        /// <summary>The support uri</summary>
        string SupportUri { get; set; }
        /// <summary>The type of legal terms</summary>
        string TermAndConditionLegalTermsType { get; set; }
        /// <summary>The legal terms and conditions uri</summary>
        string TermAndConditionLegalTermsUri { get; set; }
        /// <summary>The privacy policy uri</summary>
        string TermAndConditionPrivacyPolicyUri { get; set; }
        /// <summary>The terms and conditions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions TermsAndCondition { get; set; }

    }
}