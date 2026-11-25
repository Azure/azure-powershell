// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The resource functions supported by a manifest.</summary>
    public partial class DataManifestResourceFunctionsDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestResourceFunctionsDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Custom" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> _custom;

        /// <summary>An array of data manifest custom resource definitions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> Custom { get => this._custom; set => this._custom = value; }

        /// <summary>Backing field for <see cref="Standard" /> property.</summary>
        private System.Collections.Generic.List<string> _standard;

        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Standard { get => this._standard; set => this._standard = value; }

        /// <summary>Creates an new <see cref="DataManifestResourceFunctionsDefinition" /> instance.</summary>
        public DataManifestResourceFunctionsDefinition()
        {

        }
    }
    /// The resource functions supported by a manifest.
    public partial interface IDataManifestResourceFunctionsDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
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
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> Custom { get; set; }
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
        System.Collections.Generic.List<string> Standard { get; set; }

    }
    /// The resource functions supported by a manifest.
    internal partial interface IDataManifestResourceFunctionsDefinitionInternal

    {
        /// <summary>An array of data manifest custom resource definitions.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataManifestCustomResourceFunctionDefinition> Custom { get; set; }
        /// <summary>The standard resource functions (subscription and/or resourceGroup).</summary>
        System.Collections.Generic.List<string> Standard { get; set; }

    }
}