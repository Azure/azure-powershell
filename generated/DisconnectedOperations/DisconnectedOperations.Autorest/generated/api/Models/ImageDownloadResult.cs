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

        /// <summary>Internal Acessors for UpdateProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdateProperty { get => (this._updateProperty = this._updateProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageUpdateProperties()); set { {_updateProperty = value;} } }

        /// <summary>Internal Acessors for UpdatePropertyAgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdatePropertyAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).AgentVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).AgentVersion = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertyFeatureUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdatePropertyFeatureUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).FeatureUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).FeatureUpdate = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertyOSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdatePropertyOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).OSVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).OSVersion = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertySecurityUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdatePropertySecurityUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SecurityUpdate; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SecurityUpdate = value ?? null; }

        /// <summary>Internal Acessors for UpdatePropertySystemReboot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageDownloadResultInternal.UpdatePropertySystemReboot { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SystemReboot; set => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SystemReboot = value ?? null; }

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

        /// <summary>Backing field for <see cref="UpdateProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties _updateProperty;

        /// <summary>Image update properties for update release type image.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties UpdateProperty { get => (this._updateProperty = this._updateProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ImageUpdateProperties()); }

        /// <summary>The version(s) of the agent software included in this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyAgentVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).AgentVersion; }

        /// <summary>Details of feature updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyFeatureUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).FeatureUpdate; }

        /// <summary>The operating system version provided by this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertyOSVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).OSVersion; }

        /// <summary>Details of security updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertySecurityUpdate { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SecurityUpdate; }

        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Inlined)]
        public string UpdatePropertySystemReboot { get => ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal)UpdateProperty).SystemReboot; }

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
        /// <summary>The version(s) of the agent software included in this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The version(s) of the agent software included in this image update.",
        SerializedName = @"agentVersion",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyAgentVersion { get;  }
        /// <summary>Details of feature updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of feature updates included in this image release.",
        SerializedName = @"featureUpdates",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyFeatureUpdate { get;  }
        /// <summary>The operating system version provided by this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The operating system version provided by this image update.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertyOSVersion { get;  }
        /// <summary>Details of security updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Details of security updates included in this image release.",
        SerializedName = @"securityUpdates",
        PossibleTypes = new [] { typeof(string) })]
        string UpdatePropertySecurityUpdate { get;  }
        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if a system reboot is required after applying the update.",
        SerializedName = @"systemReboot",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Required", "NotRequired")]
        string UpdatePropertySystemReboot { get;  }

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
        /// <summary>Image update properties for update release type image.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties UpdateProperty { get; set; }
        /// <summary>The version(s) of the agent software included in this image update.</summary>
        string UpdatePropertyAgentVersion { get; set; }
        /// <summary>Details of feature updates included in this image release.</summary>
        string UpdatePropertyFeatureUpdate { get; set; }
        /// <summary>The operating system version provided by this image update.</summary>
        string UpdatePropertyOSVersion { get; set; }
        /// <summary>Details of security updates included in this image release.</summary>
        string UpdatePropertySecurityUpdate { get; set; }
        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Required", "NotRequired")]
        string UpdatePropertySystemReboot { get; set; }

    }
}