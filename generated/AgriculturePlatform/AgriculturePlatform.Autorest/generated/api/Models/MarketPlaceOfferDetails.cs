// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Marketplace offer details of Agri solution.</summary>
    public partial class MarketPlaceOfferDetails :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetailsInternal
    {

        /// <summary>Backing field for <see cref="PublisherId" /> property.</summary>
        private string _publisherId;

        /// <summary>Publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string PublisherId { get => this._publisherId; set => this._publisherId = value; }

        /// <summary>Backing field for <see cref="SaasOfferId" /> property.</summary>
        private string _saasOfferId;

        /// <summary>Saas offer Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SaasOfferId { get => this._saasOfferId; set => this._saasOfferId = value; }

        /// <summary>Creates an new <see cref="MarketPlaceOfferDetails" /> instance.</summary>
        public MarketPlaceOfferDetails()
        {

        }
    }
    /// Marketplace offer details of Agri solution.
    public partial interface IMarketPlaceOfferDetails :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>Publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Publisher Id.",
        SerializedName = @"publisherId",
        PossibleTypes = new [] { typeof(string) })]
        string PublisherId { get; set; }
        /// <summary>Saas offer Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Saas offer Id.",
        SerializedName = @"saasOfferId",
        PossibleTypes = new [] { typeof(string) })]
        string SaasOfferId { get; set; }

    }
    /// Marketplace offer details of Agri solution.
    internal partial interface IMarketPlaceOfferDetailsInternal

    {
        /// <summary>Publisher Id.</summary>
        string PublisherId { get; set; }
        /// <summary>Saas offer Id.</summary>
        string SaasOfferId { get; set; }

    }
}