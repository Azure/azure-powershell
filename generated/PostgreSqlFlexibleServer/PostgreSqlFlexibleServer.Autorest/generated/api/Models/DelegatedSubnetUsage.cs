// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Delegated subnet usage data.</summary>
    public partial class DelegatedSubnetUsage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsage,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsageInternal
    {

        /// <summary>Internal Acessors for SubnetName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsageInternal.SubnetName { get => this._subnetName; set { {_subnetName = value;} } }

        /// <summary>Internal Acessors for Usage</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDelegatedSubnetUsageInternal.Usage { get => this._usage; set { {_usage = value;} } }

        /// <summary>Backing field for <see cref="SubnetName" /> property.</summary>
        private string _subnetName;

        /// <summary>Name of the delegated subnet for which IP addresses are in use</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string SubnetName { get => this._subnetName; }

        /// <summary>Backing field for <see cref="Usage" /> property.</summary>
        private long? _usage;

        /// <summary>Number of IP addresses used by the delegated subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? Usage { get => this._usage; }

        /// <summary>Creates an new <see cref="DelegatedSubnetUsage" /> instance.</summary>
        public DelegatedSubnetUsage()
        {

        }
    }
    /// Delegated subnet usage data.
    public partial interface IDelegatedSubnetUsage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Name of the delegated subnet for which IP addresses are in use</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name of the delegated subnet for which IP addresses are in use",
        SerializedName = @"subnetName",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get;  }
        /// <summary>Number of IP addresses used by the delegated subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Number of IP addresses used by the delegated subnet",
        SerializedName = @"usage",
        PossibleTypes = new [] { typeof(long) })]
        long? Usage { get;  }

    }
    /// Delegated subnet usage data.
    internal partial interface IDelegatedSubnetUsageInternal

    {
        /// <summary>Name of the delegated subnet for which IP addresses are in use</summary>
        string SubnetName { get; set; }
        /// <summary>Number of IP addresses used by the delegated subnet</summary>
        long? Usage { get; set; }

    }
}