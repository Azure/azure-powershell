// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Installed data manager for Agriculture solution detail.</summary>
    public partial class Solution :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal
    {

        /// <summary>Backing field for <see cref="ApplicationName" /> property.</summary>
        private string _applicationName;

        /// <summary>Application name of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string ApplicationName { get => this._applicationName; set => this._applicationName = value; }

        /// <summary>Backing field for <see cref="MarketPlacePublisherId" /> property.</summary>
        private string _marketPlacePublisherId;

        /// <summary>Marketplace publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string MarketPlacePublisherId { get => this._marketPlacePublisherId; set => this._marketPlacePublisherId = value; }

        /// <summary>Backing field for <see cref="PartnerId" /> property.</summary>
        private string _partnerId;

        /// <summary>Partner Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string PartnerId { get => this._partnerId; set => this._partnerId = value; }

        /// <summary>Backing field for <see cref="PlanId" /> property.</summary>
        private string _planId;

        /// <summary>Plan Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string PlanId { get => this._planId; set => this._planId = value; }

        /// <summary>Backing field for <see cref="SaasSubscriptionId" /> property.</summary>
        private string _saasSubscriptionId;

        /// <summary>Saas subscription Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SaasSubscriptionId { get => this._saasSubscriptionId; set => this._saasSubscriptionId = value; }

        /// <summary>Backing field for <see cref="SaasSubscriptionName" /> property.</summary>
        private string _saasSubscriptionName;

        /// <summary>Saas subscription name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string SaasSubscriptionName { get => this._saasSubscriptionName; set => this._saasSubscriptionName = value; }

        /// <summary>Creates an new <see cref="Solution" /> instance.</summary>
        public Solution()
        {

        }
    }
    /// Installed data manager for Agriculture solution detail.
    public partial interface ISolution :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>Application name of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Application name of the solution.",
        SerializedName = @"applicationName",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationName { get; set; }
        /// <summary>Marketplace publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Marketplace publisher Id.",
        SerializedName = @"marketPlacePublisherId",
        PossibleTypes = new [] { typeof(string) })]
        string MarketPlacePublisherId { get; set; }
        /// <summary>Partner Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Partner Id.",
        SerializedName = @"partnerId",
        PossibleTypes = new [] { typeof(string) })]
        string PartnerId { get; set; }
        /// <summary>Plan Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Plan Id.",
        SerializedName = @"planId",
        PossibleTypes = new [] { typeof(string) })]
        string PlanId { get; set; }
        /// <summary>Saas subscription Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Saas subscription Id.",
        SerializedName = @"saasSubscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SaasSubscriptionId { get; set; }
        /// <summary>Saas subscription name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Saas subscription name.",
        SerializedName = @"saasSubscriptionName",
        PossibleTypes = new [] { typeof(string) })]
        string SaasSubscriptionName { get; set; }

    }
    /// Installed data manager for Agriculture solution detail.
    internal partial interface ISolutionInternal

    {
        /// <summary>Application name of the solution.</summary>
        string ApplicationName { get; set; }
        /// <summary>Marketplace publisher Id.</summary>
        string MarketPlacePublisherId { get; set; }
        /// <summary>Partner Id.</summary>
        string PartnerId { get; set; }
        /// <summary>Plan Id.</summary>
        string PlanId { get; set; }
        /// <summary>Saas subscription Id.</summary>
        string SaasSubscriptionId { get; set; }
        /// <summary>Saas subscription name.</summary>
        string SaasSubscriptionName { get; set; }

    }
}