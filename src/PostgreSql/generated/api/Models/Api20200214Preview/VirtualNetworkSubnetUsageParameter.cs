namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Virtual network subnet usage parameter</summary>
    public partial class VirtualNetworkSubnetUsageParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IVirtualNetworkSubnetUsageParameter,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IVirtualNetworkSubnetUsageParameterInternal
    {

        /// <summary>Backing field for <see cref="VirtualNetworkArmResourceId" /> property.</summary>
        private string _virtualNetworkArmResourceId;

        /// <summary>Virtual network resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string VirtualNetworkArmResourceId { get => this._virtualNetworkArmResourceId; set => this._virtualNetworkArmResourceId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkSubnetUsageParameter" /> instance.</summary>
        public VirtualNetworkSubnetUsageParameter()
        {

        }
    }
    /// Virtual network subnet usage parameter
    public partial interface IVirtualNetworkSubnetUsageParameter :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>Virtual network resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual network resource id.",
        SerializedName = @"virtualNetworkArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualNetworkArmResourceId { get; set; }

    }
    /// Virtual network subnet usage parameter
    internal partial interface IVirtualNetworkSubnetUsageParameterInternal

    {
        /// <summary>Virtual network resource id.</summary>
        string VirtualNetworkArmResourceId { get; set; }

    }
}