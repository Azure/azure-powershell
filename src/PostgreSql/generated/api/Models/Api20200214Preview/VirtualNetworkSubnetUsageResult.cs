namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Virtual network subnet usage data.</summary>
    public partial class VirtualNetworkSubnetUsageResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IVirtualNetworkSubnetUsageResult,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IVirtualNetworkSubnetUsageResultInternal
    {

        /// <summary>Backing field for <see cref="DelegatedSubnetsUsage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage[] _delegatedSubnetsUsage;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; }

        /// <summary>Internal Acessors for DelegatedSubnetsUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IVirtualNetworkSubnetUsageResultInternal.DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; set { {_delegatedSubnetsUsage = value;} } }

        /// <summary>Creates an new <see cref="VirtualNetworkSubnetUsageResult" /> instance.</summary>
        public VirtualNetworkSubnetUsageResult()
        {

        }
    }
    /// Virtual network subnet usage data.
    public partial interface IVirtualNetworkSubnetUsageResult :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"delegatedSubnetsUsage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get;  }

    }
    /// Virtual network subnet usage data.
    internal partial interface IVirtualNetworkSubnetUsageResultInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get; set; }

    }
}