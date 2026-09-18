// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The properties of the data policy manifest.</summary>
    public partial class DataPolicyManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Effect" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> _effect;

        /// <summary>The effect definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get => this._effect; set => this._effect = value; }

        /// <summary>Backing field for <see cref="FieldValue" /> property.</summary>
        private System.Collections.Generic.List<string> _fieldValue;

        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> FieldValue { get => this._fieldValue; set => this._fieldValue = value; }

        /// <summary>Backing field for <see cref="IsBuiltInOnly" /> property.</summary>
        private bool? _isBuiltInOnly;

        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public bool? IsBuiltInOnly { get => this._isBuiltInOnly; set => this._isBuiltInOnly = value; }

        /// <summary>Internal Acessors for ResourceFunction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataPolicyManifestPropertiesInternal.ResourceFunction { get => (this._resourceFunction = this._resourceFunction ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestResourceFunctionsDefinition()); set { {_resourceFunction = value;} } }

        /// <summary>Backing field for <see cref="Namespace" /> property.</summary>
        private System.Collections.Generic.List<string> _namespace;

        /// <summary>The list of namespaces for the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Namespace { get => this._namespace; set => this._namespace = value; }

        /// <summary>Backing field for <see cref="PolicyMode" /> property.</summary>
        private string _policyMode;

        /// <summary>The policy mode of the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string PolicyMode { get => this._policyMode; set => this._policyMode = value; }

        /// <summary>Backing field for <see cref="ResourceFunction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition _resourceFunction;

        /// <summary>The resource functions definition specified in the data manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition ResourceFunction { get => (this._resourceFunction = this._resourceFunction ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.DataManifestResourceFunctionsDefinition()); set => this._resourceFunction = value; }

        /// <summary>An array of data manifest custom resource definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinitionInternal)ResourceFunction).Custom; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinitionInternal)ResourceFunction).Custom = value ?? null /* arrayOf */; }

        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> ResourceFunctionStandard { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinitionInternal)ResourceFunction).Standard; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinitionInternal)ResourceFunction).Standard = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="ResourceTypeAlias" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> _resourceTypeAlias;

        /// <summary>An array of resource type aliases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get => this._resourceTypeAlias; set => this._resourceTypeAlias = value; }

        /// <summary>Creates an new <see cref="DataPolicyManifestProperties" /> instance.</summary>
        public DataPolicyManifestProperties()
        {

        }
    }
    /// The properties of the data policy manifest.
    public partial interface IDataPolicyManifestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The effect definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The effect definition.",
        SerializedName = @"effects",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get; set; }
        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The non-alias field accessor values that can be used in the policy rule.",
        SerializedName = @"fieldValues",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> FieldValue { get; set; }
        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"A value indicating whether policy mode is allowed only in built-in definitions.",
        SerializedName = @"isBuiltInOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsBuiltInOnly { get; set; }
        /// <summary>The list of namespaces for the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The list of namespaces for the data policy manifest.",
        SerializedName = @"namespaces",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Namespace { get; set; }
        /// <summary>The policy mode of the data policy manifest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The policy mode of the data policy manifest.",
        SerializedName = @"policyMode",
        PossibleTypes = new [] { typeof(string) })]
        string PolicyMode { get; set; }
        /// <summary>An array of data manifest custom resource definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of data manifest custom resource definitions.",
        SerializedName = @"custom",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get; set; }
        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The standard resource functions (subscription and/or resourceGroup).",
        SerializedName = @"standard",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ResourceFunctionStandard { get; set; }
        /// <summary>An array of resource type aliases.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"An array of resource type aliases.",
        SerializedName = @"resourceTypeAliases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get; set; }

    }
    /// The properties of the data policy manifest.
    internal partial interface IDataPolicyManifestPropertiesInternal

    {
        /// <summary>The effect definition.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect> Effect { get; set; }
        /// <summary>The non-alias field accessor values that can be used in the policy rule.</summary>
        System.Collections.Generic.List<string> FieldValue { get; set; }
        /// <summary>A value indicating whether policy mode is allowed only in built-in definitions.</summary>
        bool? IsBuiltInOnly { get; set; }
        /// <summary>The list of namespaces for the data policy manifest.</summary>
        System.Collections.Generic.List<string> Namespace { get; set; }
        /// <summary>The policy mode of the data policy manifest.</summary>
        string PolicyMode { get; set; }
        /// <summary>The resource functions definition specified in the data manifest.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition ResourceFunction { get; set; }
        /// <summary>An array of data manifest custom resource definitions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> ResourceFunctionCustom { get; set; }
        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        System.Collections.Generic.List<string> ResourceFunctionStandard { get; set; }
        /// <summary>An array of resource type aliases.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IResourceTypeAliases> ResourceTypeAlias { get; set; }

    }
}