namespace Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Extensions;

    /// <summary>The container for solution.</summary>
    public partial class ManagementAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociation,
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationInternal
    {

        /// <summary>The applicationId of the appliance for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Inlined)]
        public string ApplicationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationPropertiesInternal)Property).ApplicationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationPropertiesInternal)Property).ApplicationId = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationProperties Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ManagementAssociationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationProperties _property;

        /// <summary>
        /// Properties for ManagementAssociation object supported by the OperationsManagement resource provider.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.ManagementAssociationProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Origin(Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ManagementAssociation" /> instance.</summary>
        public ManagementAssociation()
        {

        }
    }
    /// The container for solution.
    public partial interface IManagementAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.IJsonSerializable
    {
        /// <summary>The applicationId of the appliance for this association.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The applicationId of the appliance for this association.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The container for solution.
    internal partial interface IManagementAssociationInternal

    {
        /// <summary>The applicationId of the appliance for this association.</summary>
        string ApplicationId { get; set; }
        /// <summary>Resource ID.</summary>
        string Id { get; set; }
        /// <summary>Resource location</summary>
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        string Name { get; set; }
        /// <summary>
        /// Properties for ManagementAssociation object supported by the OperationsManagement resource provider.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.MonitoringSolutions.Models.Api20151101Preview.IManagementAssociationProperties Property { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }

    }
}