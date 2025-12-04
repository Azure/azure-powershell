// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The artifact download properties</summary>
    public partial class ArtifactDownloadResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResult,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal
    {

        /// <summary>Backing field for <see cref="ArtifactOrder" /> property.</summary>
        private int? _artifactOrder;

        /// <summary>The artifact display order</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public int? ArtifactOrder { get => this._artifactOrder; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The artifact description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DownloadLink" /> property.</summary>
        private string _downloadLink;

        /// <summary>The download URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string DownloadLink { get => this._downloadLink; }

        /// <summary>Backing field for <see cref="LinkExpiry" /> property.</summary>
        private global::System.DateTime? _linkExpiry;

        /// <summary>The download link expiry time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public global::System.DateTime? LinkExpiry { get => this._linkExpiry; }

        /// <summary>Internal Acessors for ArtifactOrder</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.ArtifactOrder { get => this._artifactOrder; set { {_artifactOrder = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DownloadLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.DownloadLink { get => this._downloadLink; set { {_downloadLink = value;} } }

        /// <summary>Internal Acessors for LinkExpiry</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.LinkExpiry { get => this._linkExpiry; set { {_linkExpiry = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Size</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.Size { get => this._size; set { {_size = value;} } }

        /// <summary>Internal Acessors for Title</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IArtifactDownloadResultInternal.Title { get => this._title; set { {_title = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Size" /> property.</summary>
        private long? _size;

        /// <summary>The artifact size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public long? Size { get => this._size; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        /// <summary>The artifact title</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Title { get => this._title; }

        /// <summary>Creates an new <see cref="ArtifactDownloadResult" /> instance.</summary>
        public ArtifactDownloadResult()
        {

        }
    }
    /// The artifact download properties
    public partial interface IArtifactDownloadResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The artifact display order</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The artifact display order",
        SerializedName = @"artifactOrder",
        PossibleTypes = new [] { typeof(int) })]
        int? ArtifactOrder { get;  }
        /// <summary>The artifact description</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The artifact description",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>The download URI</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The download URI",
        SerializedName = @"downloadLink",
        PossibleTypes = new [] { typeof(string) })]
        string DownloadLink { get;  }
        /// <summary>The download link expiry time</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The download link expiry time",
        SerializedName = @"linkExpiry",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LinkExpiry { get;  }
        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get;  }
        /// <summary>The artifact size in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The artifact size in MB",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(long) })]
        long? Size { get;  }
        /// <summary>The artifact title</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The artifact title",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get;  }

    }
    /// The artifact download properties
    internal partial interface IArtifactDownloadResultInternal

    {
        /// <summary>The artifact display order</summary>
        int? ArtifactOrder { get; set; }
        /// <summary>The artifact description</summary>
        string Description { get; set; }
        /// <summary>The download URI</summary>
        string DownloadLink { get; set; }
        /// <summary>The download link expiry time</summary>
        global::System.DateTime? LinkExpiry { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The artifact size in MB</summary>
        long? Size { get; set; }
        /// <summary>The artifact title</summary>
        string Title { get; set; }

    }
}