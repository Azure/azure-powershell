// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Virtual network subnet usage data.</summary>
    public partial class VirtualNetworkSubnetUsageModel :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModel,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModelInternal
    {

        /// <summary>Backing field for <see cref="DelegatedSubnetsUsage" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage> _delegatedSubnetsUsage;

        /// <summary>Array of DelegatedSubnetUsage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage> DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>location of the delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for DelegatedSubnetsUsage</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModelInternal.DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; set { {_delegatedSubnetsUsage = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModelInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for SubscriptionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualNetworkSubnetUsageModelInternal.SubscriptionId { get => this._subscriptionId; set { {_subscriptionId = value;} } }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>subscriptionId of the delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SubscriptionId { get => this._subscriptionId; }

        /// <summary>Creates an new <see cref="VirtualNetworkSubnetUsageModel" /> instance.</summary>
        public VirtualNetworkSubnetUsageModel()
        {

        }
    }
    /// Virtual network subnet usage data.
    public partial interface IVirtualNetworkSubnetUsageModel :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Array of DelegatedSubnetUsage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Array of DelegatedSubnetUsage",
        SerializedName = @"delegatedSubnetsUsage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage> DelegatedSubnetsUsage { get;  }
        /// <summary>location of the delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"location of the delegated subnet usage",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>subscriptionId of the delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"subscriptionId of the delegated subnet usage",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        string SubscriptionId { get;  }

    }
    /// Virtual network subnet usage data.
    internal partial interface IVirtualNetworkSubnetUsageModelInternal

    {
        /// <summary>Array of DelegatedSubnetUsage</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage> DelegatedSubnetsUsage { get; set; }
        /// <summary>location of the delegated subnet usage</summary>
        string Location { get; set; }
        /// <summary>subscriptionId of the delegated subnet usage</summary>
        string SubscriptionId { get; set; }

    }
}