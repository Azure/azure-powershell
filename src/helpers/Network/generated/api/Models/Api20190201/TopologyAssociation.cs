namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Resources that have an association with the parent resource.</summary>
    public partial class TopologyAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyAssociation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyAssociationInternal
    {

        /// <summary>Backing field for <see cref="AssociationType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType? _associationType;

        /// <summary>The association type of the child resource to the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType? AssociationType { get => this._associationType; set => this._associationType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the resource that is associated with the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The ID of the resource that is associated with the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; set => this._resourceId = value; }

        /// <summary>Creates an new <see cref="TopologyAssociation" /> instance.</summary>
        public TopologyAssociation()
        {

        }
    }
    /// Resources that have an association with the parent resource.
    public partial interface ITopologyAssociation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The association type of the child resource to the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The association type of the child resource to the parent resource.",
        SerializedName = @"associationType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType? AssociationType { get; set; }
        /// <summary>The name of the resource that is associated with the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is associated with the parent resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The ID of the resource that is associated with the parent resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the resource that is associated with the parent resource.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get; set; }

    }
    /// Resources that have an association with the parent resource.
    internal partial interface ITopologyAssociationInternal

    {
        /// <summary>The association type of the child resource to the parent resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AssociationType? AssociationType { get; set; }
        /// <summary>The name of the resource that is associated with the parent resource.</summary>
        string Name { get; set; }
        /// <summary>The ID of the resource that is associated with the parent resource.</summary>
        string ResourceId { get; set; }

    }
}