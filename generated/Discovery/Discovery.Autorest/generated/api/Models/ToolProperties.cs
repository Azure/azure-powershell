// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Discovery Tool list item properties</summary>
    public partial class ToolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DefinitionContent" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesDefinitionContent _definitionContent;

        /// <summary>The JSON content for defining a resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesDefinitionContent DefinitionContent { get => (this._definitionContent = this._definitionContent ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ToolPropertiesDefinitionContent()); set => this._definitionContent = value; }

        /// <summary>Backing field for <see cref="EnvironmentVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesEnvironmentVariables _environmentVariable;

        /// <summary>Environment variables to make available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesEnvironmentVariables EnvironmentVariable { get => (this._environmentVariable = this._environmentVariable ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ToolPropertiesEnvironmentVariables()); set => this._environmentVariable = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The status of the last operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The version of a resource definition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string Version { get => this._version; set => this._version = value; }

        /// <summary>Creates an new <see cref="ToolProperties" /> instance.</summary>
        public ToolProperties()
        {

        }
    }
    /// Discovery Tool list item properties
    public partial interface IToolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The JSON content for defining a resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The JSON content for defining a resource",
        SerializedName = @"definitionContent",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesDefinitionContent) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesDefinitionContent DefinitionContent { get; set; }
        /// <summary>Environment variables to make available</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Environment variables to make available",
        SerializedName = @"environmentVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesEnvironmentVariables) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesEnvironmentVariables EnvironmentVariable { get; set; }
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
        /// <summary>The version of a resource definition</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The version of a resource definition",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get; set; }

    }
    /// Discovery Tool list item properties
    internal partial interface IToolPropertiesInternal

    {
        /// <summary>The JSON content for defining a resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesDefinitionContent DefinitionContent { get; set; }
        /// <summary>Environment variables to make available</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IToolPropertiesEnvironmentVariables EnvironmentVariable { get; set; }
        /// <summary>The status of the last operation.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Discovery.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "Accepted", "Provisioning", "Updating", "Deleting")]
        string ProvisioningState { get; set; }
        /// <summary>The version of a resource definition</summary>
        string Version { get; set; }

    }
}