namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>
    /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
    /// </summary>
    public partial class VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The Id of the databricks virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork" /> instance.
        /// </summary>
        public VirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork()
        {

        }
    }
    /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
    public partial interface IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>The Id of the databricks virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the databricks virtual network.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// The remote virtual network should be in the same region. See here to learn more (https://docs.microsoft.com/en-us/azure/databricks/administration-guide/cloud-configurations/azure/vnet-peering).
    internal partial interface IVirtualNetworkPeeringPropertiesFormatDatabricksVirtualNetworkInternal

    {
        /// <summary>The Id of the databricks virtual network.</summary>
        string Id { get; set; }

    }
}