namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Virtual network subnet usage data.</summary>
    public partial class VirtualNetworkSubnetUsageResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVirtualNetworkSubnetUsageResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVirtualNetworkSubnetUsageResultInternal
    {

        /// <summary>Backing field for <see cref="DelegatedSubnetsUsage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage[] _delegatedSubnetsUsage;

        /// <summary>A list of delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; }

        /// <summary>Internal Acessors for DelegatedSubnetsUsage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IVirtualNetworkSubnetUsageResultInternal.DelegatedSubnetsUsage { get => this._delegatedSubnetsUsage; set { {_delegatedSubnetsUsage = value;} } }

        /// <summary>Creates an new <see cref="VirtualNetworkSubnetUsageResult" /> instance.</summary>
        public VirtualNetworkSubnetUsageResult()
        {

        }
    }
    /// Virtual network subnet usage data.
    public partial interface IVirtualNetworkSubnetUsageResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>A list of delegated subnet usage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of delegated subnet usage",
        SerializedName = @"delegatedSubnetsUsage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get;  }

    }
    /// Virtual network subnet usage data.
    internal partial interface IVirtualNetworkSubnetUsageResultInternal

    {
        /// <summary>A list of delegated subnet usage</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetUsage[] DelegatedSubnetsUsage { get; set; }

    }
}