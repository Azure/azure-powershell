namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Topology of the specified resource group.</summary>
    public partial class Topology :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopology,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyInternal
    {

        /// <summary>Backing field for <see cref="CreatedDateTime" /> property.</summary>
        private global::System.DateTime? _createdDateTime;

        /// <summary>The datetime when the topology was initially created for the resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedDateTime { get => this._createdDateTime; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>GUID representing the operation id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="LastModified" /> property.</summary>
        private global::System.DateTime? _lastModified;

        /// <summary>The datetime when the topology was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModified { get => this._lastModified; }

        /// <summary>Internal Acessors for CreatedDateTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyInternal.CreatedDateTime { get => this._createdDateTime; set { {_createdDateTime = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for LastModified</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyInternal.LastModified { get => this._lastModified; set { {_lastModified = value;} } }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyResource[] _resource;

        /// <summary>A list of topology resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyResource[] Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="Topology" /> instance.</summary>
        public Topology()
        {

        }
    }
    /// Topology of the specified resource group.
    public partial interface ITopology :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The datetime when the topology was initially created for the resource group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The datetime when the topology was initially created for the resource group.",
        SerializedName = @"createdDateTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDateTime { get;  }
        /// <summary>GUID representing the operation id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"GUID representing the operation id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The datetime when the topology was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The datetime when the topology was last modified.",
        SerializedName = @"lastModified",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModified { get;  }
        /// <summary>A list of topology resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of topology resources.",
        SerializedName = @"resources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyResource[] Resource { get; set; }

    }
    /// Topology of the specified resource group.
    internal partial interface ITopologyInternal

    {
        /// <summary>The datetime when the topology was initially created for the resource group.</summary>
        global::System.DateTime? CreatedDateTime { get; set; }
        /// <summary>GUID representing the operation id.</summary>
        string Id { get; set; }
        /// <summary>The datetime when the topology was last modified.</summary>
        global::System.DateTime? LastModified { get; set; }
        /// <summary>A list of topology resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITopologyResource[] Resource { get; set; }

    }
}