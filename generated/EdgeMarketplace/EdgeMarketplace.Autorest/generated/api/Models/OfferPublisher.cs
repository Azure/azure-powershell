// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>The offer publisher</summary>
    public partial class OfferPublisher :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisher,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IOfferPublisherInternal
    {

        /// <summary>Backing field for <see cref="PublisherDisplayName" /> property.</summary>
        private string _publisherDisplayName;

        /// <summary>The publisher name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string PublisherDisplayName { get => this._publisherDisplayName; set => this._publisherDisplayName = value; }

        /// <summary>Backing field for <see cref="PublisherId" /> property.</summary>
        private string _publisherId;

        /// <summary>The publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string PublisherId { get => this._publisherId; set => this._publisherId = value; }

        /// <summary>Creates an new <see cref="OfferPublisher" /> instance.</summary>
        public OfferPublisher()
        {

        }
    }
    /// The offer publisher
    public partial interface IOfferPublisher :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The publisher name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The publisher name",
        SerializedName = @"publisherDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherDisplayName { get; set; }
        /// <summary>The publisher Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The publisher Id",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherId { get; set; }

    }
    /// The offer publisher
    internal partial interface IOfferPublisherInternal

    {
        /// <summary>The publisher name</summary>
        string PublisherDisplayName { get; set; }
        /// <summary>The publisher Id</summary>
        string PublisherId { get; set; }

    }
}