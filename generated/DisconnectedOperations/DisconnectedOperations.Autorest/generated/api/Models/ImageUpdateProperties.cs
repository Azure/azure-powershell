// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The update properties of the Update Release type Image</summary>
    public partial class ImageUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AgentVersion" /> property.</summary>
        private string _agentVersion;

        /// <summary>The version(s) of the agent software included in this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string AgentVersion { get => this._agentVersion; }

        /// <summary>Backing field for <see cref="FeatureUpdate" /> property.</summary>
        private string _featureUpdate;

        /// <summary>Details of feature updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string FeatureUpdate { get => this._featureUpdate; }

        /// <summary>Internal Acessors for AgentVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal.AgentVersion { get => this._agentVersion; set { {_agentVersion = value;} } }

        /// <summary>Internal Acessors for FeatureUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal.FeatureUpdate { get => this._featureUpdate; set { {_featureUpdate = value;} } }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal.OSVersion { get => this._oSVersion; set { {_oSVersion = value;} } }

        /// <summary>Internal Acessors for SecurityUpdate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal.SecurityUpdate { get => this._securityUpdate; set { {_securityUpdate = value;} } }

        /// <summary>Internal Acessors for SystemReboot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IImageUpdatePropertiesInternal.SystemReboot { get => this._systemReboot; set { {_systemReboot = value;} } }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>The operating system version provided by this image update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; }

        /// <summary>Backing field for <see cref="SecurityUpdate" /> property.</summary>
        private string _securityUpdate;

        /// <summary>Details of security updates included in this image release.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string SecurityUpdate { get => this._securityUpdate; }

        /// <summary>Backing field for <see cref="SystemReboot" /> property.</summary>
        private string _systemReboot;

        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string SystemReboot { get => this._systemReboot; }

        /// <summary>Creates an new <see cref="ImageUpdateProperties" /> instance.</summary>
        public ImageUpdateProperties()
        {

        }
    }
    /// The update properties of the Update Release type Image
    public partial interface IImageUpdateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
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
        string AgentVersion { get;  }
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
        string FeatureUpdate { get;  }
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
        string OSVersion { get;  }
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
        string SecurityUpdate { get;  }
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
        string SystemReboot { get;  }

    }
    /// The update properties of the Update Release type Image
    internal partial interface IImageUpdatePropertiesInternal

    {
        /// <summary>The version(s) of the agent software included in this image update.</summary>
        string AgentVersion { get; set; }
        /// <summary>Details of feature updates included in this image release.</summary>
        string FeatureUpdate { get; set; }
        /// <summary>The operating system version provided by this image update.</summary>
        string OSVersion { get; set; }
        /// <summary>Details of security updates included in this image release.</summary>
        string SecurityUpdate { get; set; }
        /// <summary>Indicates if a system reboot is required after applying the update.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Required", "NotRequired")]
        string SystemReboot { get; set; }

    }
}