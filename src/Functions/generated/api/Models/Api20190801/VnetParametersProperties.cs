namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>VnetParameters resource specific properties</summary>
    public partial class VnetParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetParametersProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVnetParametersPropertiesInternal
    {

        /// <summary>Backing field for <see cref="VnetName" /> property.</summary>
        private string _vnetName;

        /// <summary>The name of the VNET to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetName { get => this._vnetName; set => this._vnetName = value; }

        /// <summary>Backing field for <see cref="VnetResourceGroup" /> property.</summary>
        private string _vnetResourceGroup;

        /// <summary>The Resource Group of the VNET to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetResourceGroup { get => this._vnetResourceGroup; set => this._vnetResourceGroup = value; }

        /// <summary>Backing field for <see cref="VnetSubnetName" /> property.</summary>
        private string _vnetSubnetName;

        /// <summary>The subnet name to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetSubnetName { get => this._vnetSubnetName; set => this._vnetSubnetName = value; }

        /// <summary>Creates an new <see cref="VnetParametersProperties" /> instance.</summary>
        public VnetParametersProperties()
        {

        }
    }
    /// VnetParameters resource specific properties
    public partial interface IVnetParametersProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>The name of the VNET to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the VNET to be validated",
        SerializedName = @"vnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetName { get; set; }
        /// <summary>The Resource Group of the VNET to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Resource Group of the VNET to be validated",
        SerializedName = @"vnetResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string VnetResourceGroup { get; set; }
        /// <summary>The subnet name to be validated</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The subnet name to be validated",
        SerializedName = @"vnetSubnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSubnetName { get; set; }

    }
    /// VnetParameters resource specific properties
    internal partial interface IVnetParametersPropertiesInternal

    {
        /// <summary>The name of the VNET to be validated</summary>
        string VnetName { get; set; }
        /// <summary>The Resource Group of the VNET to be validated</summary>
        string VnetResourceGroup { get; set; }
        /// <summary>The subnet name to be validated</summary>
        string VnetSubnetName { get; set; }

    }
}