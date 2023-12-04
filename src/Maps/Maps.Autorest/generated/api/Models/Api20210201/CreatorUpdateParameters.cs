namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>Parameters used to update an existing Creator resource.</summary>
    public partial class CreatorUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.CreatorProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties _property;

        /// <summary>Creator resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.CreatorProperties()); set => this._property = value; }

        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public int? StorageUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).StorageUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).StorageUnit = value ?? default(int); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags _tag;

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.CreatorUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="CreatorUpdateParameters" /> instance.</summary>
        public CreatorUpdateParameters()
        {

        }
    }
    /// Parameters used to update an existing Creator resource.
    public partial interface ICreatorUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The storage units to be allocated. Integer values from 1 to 100, inclusive.",
        SerializedName = @"storageUnits",
        PossibleTypes = new [] { typeof(int) })]
        int? StorageUnit { get; set; }
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater than 128 characters and value no greater than 256 characters.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags Tag { get; set; }

    }
    /// Parameters used to update an existing Creator resource.
    internal partial interface ICreatorUpdateParametersInternal

    {
        /// <summary>Creator resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Property { get; set; }
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        int? StorageUnit { get; set; }
        /// <summary>
        /// Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this
        /// resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater
        /// than 128 characters and value no greater than 256 characters.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorUpdateParametersTags Tag { get; set; }

    }
}