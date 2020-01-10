namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Information about a hop between the source and the destination.</summary>
    public partial class ConnectivityHop :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHop,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal
    {

        /// <summary>Backing field for <see cref="Address" /> property.</summary>
        private string _address;

        /// <summary>The IP address of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Address { get => this._address; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Issue" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue[] _issue;

        /// <summary>List of issues.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue[] Issue { get => this._issue; }

        /// <summary>Internal Acessors for Address</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.Address { get => this._address; set { {_address = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Issue</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.Issue { get => this._issue; set { {_issue = value;} } }

        /// <summary>Internal Acessors for NextHopId</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.NextHopId { get => this._nextHopId; set { {_nextHopId = value;} } }

        /// <summary>Internal Acessors for ResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.ResourceId { get => this._resourceId; set { {_resourceId = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityHopInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="NextHopId" /> property.</summary>
        private string[] _nextHopId;

        /// <summary>List of next hop identifiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] NextHopId { get => this._nextHopId; }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The ID of the resource corresponding to this hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ConnectivityHop" /> instance.</summary>
        public ConnectivityHop()
        {

        }
    }
    /// Information about a hop between the source and the destination.
    public partial interface IConnectivityHop :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The IP address of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The IP address of the hop.",
        SerializedName = @"address",
        PossibleTypes = new [] { typeof(string) })]
        string Address { get;  }
        /// <summary>The ID of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ID of the hop.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>List of issues.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of issues.",
        SerializedName = @"issues",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue[] Issue { get;  }
        /// <summary>List of next hop identifiers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of next hop identifiers.",
        SerializedName = @"nextHopIds",
        PossibleTypes = new [] { typeof(string) })]
        string[] NextHopId { get;  }
        /// <summary>The ID of the resource corresponding to this hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ID of the resource corresponding to this hop.",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get;  }
        /// <summary>The type of the hop.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of the hop.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Information about a hop between the source and the destination.
    internal partial interface IConnectivityHopInternal

    {
        /// <summary>The IP address of the hop.</summary>
        string Address { get; set; }
        /// <summary>The ID of the hop.</summary>
        string Id { get; set; }
        /// <summary>List of issues.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue[] Issue { get; set; }
        /// <summary>List of next hop identifiers.</summary>
        string[] NextHopId { get; set; }
        /// <summary>The ID of the resource corresponding to this hop.</summary>
        string ResourceId { get; set; }
        /// <summary>The type of the hop.</summary>
        string Type { get; set; }

    }
}