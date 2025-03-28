// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Data Manager for Agriculture solution.</summary>
    public partial class DataManagerForAgricultureSolution :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolution,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal
    {

        /// <summary>
        /// Backing field for <see cref="AccessAzureDataManagerForAgricultureApplicationId" /> property.
        /// </summary>
        private string _accessAzureDataManagerForAgricultureApplicationId;

        /// <summary>
        /// Entra application Id used to access azure data manager for agriculture instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string AccessAzureDataManagerForAgricultureApplicationId { get => this._accessAzureDataManagerForAgricultureApplicationId; set => this._accessAzureDataManagerForAgricultureApplicationId = value; }

        /// <summary>
        /// Backing field for <see cref="AccessAzureDataManagerForAgricultureApplicationName" /> property.
        /// </summary>
        private string _accessAzureDataManagerForAgricultureApplicationName;

        /// <summary>
        /// Entra application name used to access azure data manager for agriculture instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string AccessAzureDataManagerForAgricultureApplicationName { get => this._accessAzureDataManagerForAgricultureApplicationName; set => this._accessAzureDataManagerForAgricultureApplicationName = value; }

        /// <summary>Backing field for <see cref="DataAccessScope" /> property.</summary>
        private System.Collections.Generic.List<string> _dataAccessScope;

        /// <summary>Data access scopes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DataAccessScope { get => this._dataAccessScope; set => this._dataAccessScope = value; }

        /// <summary>Backing field for <see cref="IsValidateInput" /> property.</summary>
        private bool _isValidateInput;

        /// <summary>Whether solution inference will validate input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public bool IsValidateInput { get => this._isValidateInput; set => this._isValidateInput = value; }

        /// <summary>Backing field for <see cref="MarketPlaceOfferDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails _marketPlaceOfferDetail;

        /// <summary>Marketplace offer details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails MarketPlaceOfferDetail { get => (this._marketPlaceOfferDetail = this._marketPlaceOfferDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MarketPlaceOfferDetails()); set => this._marketPlaceOfferDetail = value; }

        /// <summary>Publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string MarketPlaceOfferDetailPublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetailsInternal)MarketPlaceOfferDetail).PublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetailsInternal)MarketPlaceOfferDetail).PublisherId = value ; }

        /// <summary>Saas offer Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string MarketPlaceOfferDetailSaasOfferId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetailsInternal)MarketPlaceOfferDetail).SaasOfferId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetailsInternal)MarketPlaceOfferDetail).SaasOfferId = value ; }

        /// <summary>Internal Acessors for MarketPlaceOfferDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IDataManagerForAgricultureSolutionInternal.MarketPlaceOfferDetail { get => (this._marketPlaceOfferDetail = this._marketPlaceOfferDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.MarketPlaceOfferDetails()); set { {_marketPlaceOfferDetail = value;} } }

        /// <summary>Backing field for <see cref="PartnerId" /> property.</summary>
        private string _partnerId;

        /// <summary>Partner Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string PartnerId { get => this._partnerId; set => this._partnerId = value; }

        /// <summary>Backing field for <see cref="PartnerTenantId" /> property.</summary>
        private string _partnerTenantId;

        /// <summary>Partner tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string PartnerTenantId { get => this._partnerTenantId; set => this._partnerTenantId = value; }

        /// <summary>Backing field for <see cref="SaasApplicationId" /> property.</summary>
        private string _saasApplicationId;

        /// <summary>Saas application Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SaasApplicationId { get => this._saasApplicationId; set => this._saasApplicationId = value; }

        /// <summary>Backing field for <see cref="SolutionId" /> property.</summary>
        private string _solutionId;

        /// <summary>Solution Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SolutionId { get => this._solutionId; set => this._solutionId = value; }

        /// <summary>Creates an new <see cref="DataManagerForAgricultureSolution" /> instance.</summary>
        public DataManagerForAgricultureSolution()
        {

        }
    }
    /// Data Manager for Agriculture solution.
    public partial interface IDataManagerForAgricultureSolution :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Entra application Id used to access azure data manager for agriculture instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Entra application Id used to access azure data manager for agriculture instance.",
        SerializedName = @"accessAzureDataManagerForAgricultureApplicationId",
        PossibleTypes = new [] { typeof(string) })]
        string AccessAzureDataManagerForAgricultureApplicationId { get; set; }
        /// <summary>
        /// Entra application name used to access azure data manager for agriculture instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Entra application name used to access azure data manager for agriculture instance.",
        SerializedName = @"accessAzureDataManagerForAgricultureApplicationName",
        PossibleTypes = new [] { typeof(string) })]
        string AccessAzureDataManagerForAgricultureApplicationName { get; set; }
        /// <summary>Data access scopes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Data access scopes.",
        SerializedName = @"dataAccessScopes",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DataAccessScope { get; set; }
        /// <summary>Whether solution inference will validate input.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Whether solution inference will validate input.",
        SerializedName = @"isValidateInput",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsValidateInput { get; set; }
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
        string MarketPlaceOfferDetailPublisherId { get; set; }
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
        string MarketPlaceOfferDetailSaasOfferId { get; set; }
        /// <summary>Partner Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Partner Id.",
        SerializedName = @"partnerId",
        PossibleTypes = new [] { typeof(string) })]
        string PartnerId { get; set; }
        /// <summary>Partner tenant Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Partner tenant Id.",
        SerializedName = @"partnerTenantId",
        PossibleTypes = new [] { typeof(string) })]
        string PartnerTenantId { get; set; }
        /// <summary>Saas application Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Saas application Id.",
        SerializedName = @"saasApplicationId",
        PossibleTypes = new [] { typeof(string) })]
        string SaasApplicationId { get; set; }
        /// <summary>Solution Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Solution Id.",
        SerializedName = @"solutionId",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionId { get; set; }

    }
    /// Data Manager for Agriculture solution.
    internal partial interface IDataManagerForAgricultureSolutionInternal

    {
        /// <summary>
        /// Entra application Id used to access azure data manager for agriculture instance.
        /// </summary>
        string AccessAzureDataManagerForAgricultureApplicationId { get; set; }
        /// <summary>
        /// Entra application name used to access azure data manager for agriculture instance.
        /// </summary>
        string AccessAzureDataManagerForAgricultureApplicationName { get; set; }
        /// <summary>Data access scopes.</summary>
        System.Collections.Generic.List<string> DataAccessScope { get; set; }
        /// <summary>Whether solution inference will validate input.</summary>
        bool IsValidateInput { get; set; }
        /// <summary>Marketplace offer details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMarketPlaceOfferDetails MarketPlaceOfferDetail { get; set; }
        /// <summary>Publisher Id.</summary>
        string MarketPlaceOfferDetailPublisherId { get; set; }
        /// <summary>Saas offer Id.</summary>
        string MarketPlaceOfferDetailSaasOfferId { get; set; }
        /// <summary>Partner Id.</summary>
        string PartnerId { get; set; }
        /// <summary>Partner tenant Id.</summary>
        string PartnerTenantId { get; set; }
        /// <summary>Saas application Id.</summary>
        string SaasApplicationId { get; set; }
        /// <summary>Solution Id.</summary>
        string SolutionId { get; set; }

    }
}