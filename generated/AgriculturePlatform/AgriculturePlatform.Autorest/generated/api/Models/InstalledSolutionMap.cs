// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Mapping of installed solutions.</summary>
    public partial class InstalledSolutionMap :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMap,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal
    {

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        /// <summary>The key representing the installed solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IInstalledSolutionMapInternal.Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution()); set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution _value;

        /// <summary>The installed solution value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.Solution()); set => this._value = value; }

        /// <summary>Application name of the solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueApplicationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).ApplicationName; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).ApplicationName = value ?? null; }

        /// <summary>Marketplace publisher Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueMarketPlacePublisherId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).MarketPlacePublisherId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).MarketPlacePublisherId = value ?? null; }

        /// <summary>Partner Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValuePartnerId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).PartnerId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).PartnerId = value ?? null; }

        /// <summary>Plan Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValuePlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).PlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).PlanId = value ?? null; }

        /// <summary>Saas subscription Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueSaasSubscriptionId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).SaasSubscriptionId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).SaasSubscriptionId = value ?? null; }

        /// <summary>Saas subscription name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Inlined)]
        public string ValueSaasSubscriptionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).SaasSubscriptionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolutionInternal)Value).SaasSubscriptionName = value ?? null; }

        /// <summary>Creates an new <see cref="InstalledSolutionMap" /> instance.</summary>
        public InstalledSolutionMap()
        {

        }
    }
    /// Mapping of installed solutions.
    public partial interface IInstalledSolutionMap :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>The key representing the installed solution.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The key representing the installed solution.",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }
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
        string ValueApplicationName { get; set; }
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
        string ValueMarketPlacePublisherId { get; set; }
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
        string ValuePartnerId { get; set; }
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
        string ValuePlanId { get; set; }
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
        string ValueSaasSubscriptionId { get; set; }
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
        string ValueSaasSubscriptionName { get; set; }

    }
    /// Mapping of installed solutions.
    internal partial interface IInstalledSolutionMapInternal

    {
        /// <summary>The key representing the installed solution.</summary>
        string Key { get; set; }
        /// <summary>The installed solution value.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.ISolution Value { get; set; }
        /// <summary>Application name of the solution.</summary>
        string ValueApplicationName { get; set; }
        /// <summary>Marketplace publisher Id.</summary>
        string ValueMarketPlacePublisherId { get; set; }
        /// <summary>Partner Id.</summary>
        string ValuePartnerId { get; set; }
        /// <summary>Plan Id.</summary>
        string ValuePlanId { get; set; }
        /// <summary>Saas subscription Id.</summary>
        string ValueSaasSubscriptionId { get; set; }
        /// <summary>Saas subscription name.</summary>
        string ValueSaasSubscriptionName { get; set; }

    }
}