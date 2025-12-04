// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The image download properties</summary>
    public partial class ImageDownloadResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResult,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal
    {

        /// <summary>Backing field for <see cref="CompatibleVersion" /> property.</summary>
        private System.Collections.Generic.List<string> _compatibleVersion;

        /// <summary>The versions that are compatible for this update package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> CompatibleVersion { get => this._compatibleVersion; }

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

        /// <summary>Internal Acessors for CompatibleVersion</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.CompatibleVersion { get => this._compatibleVersion; set { {_compatibleVersion = value;} } }

        /// <summary>Internal Acessors for DownloadLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.DownloadLink { get => this._downloadLink; set { {_downloadLink = value;} } }

        /// <summary>Internal Acessors for LinkExpiry</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.LinkExpiry { get => this._linkExpiry; set { {_linkExpiry = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ReleaseDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ReleaseDate { get => this._releaseDate; set { {_releaseDate = value;} } }

        /// <summary>Internal Acessors for ReleaseDisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ReleaseDisplayName { get => this._releaseDisplayName; set { {_releaseDisplayName = value;} } }

        /// <summary>Internal Acessors for ReleaseNote</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ReleaseNote { get => this._releaseNote; set { {_releaseNote = value;} } }

        /// <summary>Internal Acessors for ReleaseType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ReleaseType { get => this._releaseType; set { {_releaseType = value;} } }

        /// <summary>Internal Acessors for ReleaseVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.ReleaseVersion { get => this._releaseVersion; set { {_releaseVersion = value;} } }

        /// <summary>Internal Acessors for TransactionId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.TransactionId { get => this._transactionId; set { {_transactionId = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The resource provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ReleaseDate" /> property.</summary>
        private global::System.DateTime? _releaseDate;

        /// <summary>The release date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public global::System.DateTime? ReleaseDate { get => this._releaseDate; }

        /// <summary>Backing field for <see cref="ReleaseDisplayName" /> property.</summary>
        private string _releaseDisplayName;

        /// <summary>The release name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ReleaseDisplayName { get => this._releaseDisplayName; }

        /// <summary>Backing field for <see cref="ReleaseNote" /> property.</summary>
        private string _releaseNote;

        /// <summary>The release notes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ReleaseNote { get => this._releaseNote; }

        /// <summary>Backing field for <see cref="ReleaseType" /> property.</summary>
        private string _releaseType;

        /// <summary>The release type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ReleaseType { get => this._releaseType; }

        /// <summary>Backing field for <see cref="ReleaseVersion" /> property.</summary>
        private string _releaseVersion;

        /// <summary>The version of the package in the format 1.1.1</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ReleaseVersion { get => this._releaseVersion; }

        /// <summary>Backing field for <see cref="TransactionId" /> property.</summary>
        private string _transactionId;

        /// <summary>The unique identifier of the download</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string TransactionId { get => this._transactionId; }

        /// <summary>Creates an new <see cref="ImageDownloadResult" /> instance.</summary>
        public ImageDownloadResult()
        {

        }
    }
    /// The image download properties
    public partial interface IImageDownloadResult :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The versions that are compatible for this update package.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The versions that are compatible for this update package.",
        SerializedName = @"compatibleVersions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> CompatibleVersion { get;  }
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
        /// <summary>The release date</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release date",
        SerializedName = @"releaseDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ReleaseDate { get;  }
        /// <summary>The release name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release name",
        SerializedName = @"releaseDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseDisplayName { get;  }
        /// <summary>The release notes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release notes",
        SerializedName = @"releaseNotes",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseNote { get;  }
        /// <summary>The release type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The release type",
        SerializedName = @"releaseType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Install", "Update")]
        string ReleaseType { get;  }
        /// <summary>The version of the package in the format 1.1.1</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The version of the package in the format 1.1.1",
        SerializedName = @"releaseVersion",
        PossibleTypes = new [] { typeof(string) })]
        string ReleaseVersion { get;  }
        /// <summary>The unique identifier of the download</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The unique identifier of the download",
        SerializedName = @"transactionId",
        PossibleTypes = new [] { typeof(string) })]
        string TransactionId { get;  }

    }
    /// The image download properties
    internal partial interface IImageDownloadResultInternal

    {
        /// <summary>The versions that are compatible for this update package.</summary>
        System.Collections.Generic.List<string> CompatibleVersion { get; set; }
        /// <summary>The download URI</summary>
        string DownloadLink { get; set; }
        /// <summary>The download link expiry time</summary>
        global::System.DateTime? LinkExpiry { get; set; }
        /// <summary>The resource provisioning state</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled")]
        string ProvisioningState { get; set; }
        /// <summary>The release date</summary>
        global::System.DateTime? ReleaseDate { get; set; }
        /// <summary>The release name</summary>
        string ReleaseDisplayName { get; set; }
        /// <summary>The release notes</summary>
        string ReleaseNote { get; set; }
        /// <summary>The release type</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Install", "Update")]
        string ReleaseType { get; set; }
        /// <summary>The version of the package in the format 1.1.1</summary>
        string ReleaseVersion { get; set; }
        /// <summary>The unique identifier of the download</summary>
        string TransactionId { get; set; }

    }
}