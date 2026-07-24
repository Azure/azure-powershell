// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Project properties</summary>
    public partial class ProjectProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FoundryProjectEndpoint" /> property.</summary>
        private string _foundryProjectEndpoint;

        /// <summary>Foundry project endpoint URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string FoundryProjectEndpoint { get => this._foundryProjectEndpoint; }

        /// <summary>Internal Acessors for FoundryProjectEndpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectPropertiesInternal.FoundryProjectEndpoint { get => this._foundryProjectEndpoint; set { {_foundryProjectEndpoint = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Setting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettings Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectPropertiesInternal.Setting { get => (this._setting = this._setting ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ProjectSettings()); set { {_setting = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Setting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettings _setting;

        /// <summary>Settings for the project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettings Setting { get => (this._setting = this._setting ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ProjectSettings()); set => this._setting = value; }

        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string SettingBehaviorPreference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettingsInternal)Setting).BehaviorPreference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettingsInternal)Setting).BehaviorPreference = value ?? null; }

        /// <summary>Backing field for <see cref="StorageContainerId" /> property.</summary>
        private System.Collections.Generic.List<string> _storageContainerId;

        /// <summary>Allowed StorageContainers (Control plane resource references).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> StorageContainerId { get => this._storageContainerId; set => this._storageContainerId = value; }

        /// <summary>Creates an new <see cref="ProjectProperties" /> instance.</summary>
        public ProjectProperties()
        {

        }
    }
    /// Project properties
    public partial interface IProjectProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Foundry project endpoint URI.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Foundry project endpoint URI.",
        SerializedName = @"foundryProjectEndpoint",
        PossibleTypes = new [] { typeof(string) })]
        string FoundryProjectEndpoint { get;  }
        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The status of the last operation.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get;  }
        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Default preferences to guide AI behaviors in this project.",
        SerializedName = @"behaviorPreferences",
        PossibleTypes = new [] { typeof(string) })]
        string SettingBehaviorPreference { get; set; }
        /// <summary>Allowed StorageContainers (Control plane resource references).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"Allowed StorageContainers (Control plane resource references).",
        SerializedName = @"storageContainerIds",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> StorageContainerId { get; set; }

    }
    /// Project properties
    internal partial interface IProjectPropertiesInternal

    {
        /// <summary>Foundry project endpoint URI.</summary>
        string FoundryProjectEndpoint { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>Settings for the project.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IProjectSettings Setting { get; set; }
        /// <summary>Default preferences to guide AI behaviors in this project.</summary>
        string SettingBehaviorPreference { get; set; }
        /// <summary>Allowed StorageContainers (Control plane resource references).</summary>
        System.Collections.Generic.List<string> StorageContainerId { get; set; }

    }
}