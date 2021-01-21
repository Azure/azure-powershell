namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class that contains virtual network definition.</summary>
    public partial class VirtualNetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IVirtualNetworkConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IVirtualNetworkConfigurationInternal
    {

        /// <summary>Backing field for <see cref="DataManagementPublicIPId" /> property.</summary>
        private string _dataManagementPublicIPId;

        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string DataManagementPublicIPId { get => this._dataManagementPublicIPId; set => this._dataManagementPublicIPId = value; }

        /// <summary>Backing field for <see cref="EnginePublicIPId" /> property.</summary>
        private string _enginePublicIPId;

        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string EnginePublicIPId { get => this._enginePublicIPId; set => this._enginePublicIPId = value; }

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Creates an new <see cref="VirtualNetworkConfiguration" /> instance.</summary>
        public VirtualNetworkConfiguration()
        {

        }
    }
    /// A class that contains virtual network definition.
    public partial interface IVirtualNetworkConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Data management's service public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Data management's service public IP address resource id.",
        SerializedName = @"dataManagementPublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string DataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Engine service's public IP address resource id.",
        SerializedName = @"enginePublicIpId",
        PossibleTypes = new [] { typeof(string) })]
        string EnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The subnet resource id.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// A class that contains virtual network definition.
    internal partial interface IVirtualNetworkConfigurationInternal

    {
        /// <summary>Data management's service public IP address resource id.</summary>
        string DataManagementPublicIPId { get; set; }
        /// <summary>Engine service's public IP address resource id.</summary>
        string EnginePublicIPId { get; set; }
        /// <summary>The subnet resource id.</summary>
        string SubnetId { get; set; }

    }
}