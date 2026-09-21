// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The custom resource function definition.</summary>
    public partial class DataManifestCustomResourceFunctionDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinitionInternal
    {

        /// <summary>Backing field for <see cref="AllowCustomProperty" /> property.</summary>
        private bool? _allowCustomProperty;

        /// <summary>
        /// A value indicating whether the custom properties within the property bag are allowed. Needs api-version to be specified
        /// in the policy rule eg - vault('2019-06-01').
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public bool? AllowCustomProperty { get => this._allowCustomProperty; set => this._allowCustomProperty = value; }

        /// <summary>Backing field for <see cref="DefaultProperty" /> property.</summary>
        private System.Collections.Generic.List<string> _defaultProperty;

        /// <summary>
        /// The top-level properties that can be selected on the function's output. eg - [ \"name\", \"location\" ] if vault().name
        /// and vault().location are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> DefaultProperty { get => this._defaultProperty; set => this._defaultProperty = value; }

        /// <summary>Backing field for <see cref="FullyQualifiedResourceType" /> property.</summary>
        private string _fullyQualifiedResourceType;

        /// <summary>
        /// The fully qualified control plane resource type that this function represents. eg - 'Microsoft.KeyVault/vaults'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string FullyQualifiedResourceType { get => this._fullyQualifiedResourceType; set => this._fullyQualifiedResourceType = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The function name as it will appear in the policy rule. eg - 'vault'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Creates an new <see cref="DataManifestCustomResourceFunctionDefinition" /> instance.
        /// </summary>
        public DataManifestCustomResourceFunctionDefinition()
        {

        }
    }
    /// The custom resource function definition.
    public partial interface IDataManifestCustomResourceFunctionDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A value indicating whether the custom properties within the property bag are allowed. Needs api-version to be specified
        /// in the policy rule eg - vault('2019-06-01').
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A value indicating whether the custom properties within the property bag are allowed. Needs api-version to be specified in the policy rule eg - vault('2019-06-01').",
        SerializedName = @"allowCustomProperties",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowCustomProperty { get; set; }
        /// <summary>
        /// The top-level properties that can be selected on the function's output. eg - [ \"name\", \"location\" ] if vault().name
        /// and vault().location are supported.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The top-level properties that can be selected on the function's output. eg - [ \""name\"", \""location\"" ] if vault().name and vault().location are supported.",
        SerializedName = @"defaultProperties",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> DefaultProperty { get; set; }
        /// <summary>
        /// The fully qualified control plane resource type that this function represents. eg - 'Microsoft.KeyVault/vaults'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The fully qualified control plane resource type that this function represents. eg - 'Microsoft.KeyVault/vaults'.",
        SerializedName = @"fullyQualifiedResourceType",
        PossibleTypes = new [] { typeof(string) })]
        string FullyQualifiedResourceType { get; set; }
        /// <summary>The function name as it will appear in the policy rule. eg - 'vault'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The function name as it will appear in the policy rule. eg - 'vault'.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The custom resource function definition.
    internal partial interface IDataManifestCustomResourceFunctionDefinitionInternal

    {
        /// <summary>
        /// A value indicating whether the custom properties within the property bag are allowed. Needs api-version to be specified
        /// in the policy rule eg - vault('2019-06-01').
        /// </summary>
        bool? AllowCustomProperty { get; set; }
        /// <summary>
        /// The top-level properties that can be selected on the function's output. eg - [ \"name\", \"location\" ] if vault().name
        /// and vault().location are supported.
        /// </summary>
        System.Collections.Generic.List<string> DefaultProperty { get; set; }
        /// <summary>
        /// The fully qualified control plane resource type that this function represents. eg - 'Microsoft.KeyVault/vaults'.
        /// </summary>
        string FullyQualifiedResourceType { get; set; }
        /// <summary>The function name as it will appear in the policy rule. eg - 'vault'.</summary>
        string Name { get; set; }

    }
}