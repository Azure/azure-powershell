namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>
    /// IPConfigurationReference - Describes a IPConfiguration under the virtual network
    /// </summary>
    public partial class ComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItemsInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>IPConfigurationID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>
        /// Creates an new <see cref="ComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems"
        /// /> instance.
        /// </summary>
        public ComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems()
        {

        }
    }
    /// IPConfigurationReference - Describes a IPConfiguration under the virtual network
    public partial interface IComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItems :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>IPConfigurationID</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IPConfigurationID",
        SerializedName = @"ID",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// IPConfigurationReference - Describes a IPConfiguration under the virtual network
    internal partial interface IComponentsCr63WSchemasVirtualnetworkpropertiesPropertiesSubnetsItemsPropertiesIpconfigurationreferencesItemsInternal

    {
        /// <summary>IPConfigurationID</summary>
        string Id { get; set; }

    }
}