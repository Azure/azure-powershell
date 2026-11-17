// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The type of the paths for alias.</summary>
    public partial class AliasPath :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathInternal
    {

        /// <summary>Backing field for <see cref="ApiVersion" /> property.</summary>
        private System.Collections.Generic.List<string> _apiVersion;

        /// <summary>The API versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ApiVersion { get => this._apiVersion; set => this._apiVersion = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata _metadata;

        /// <summary>
        /// The metadata of the alias path. If missing, fall back to the default metadata of the alias.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadata()); }

        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string MetadataAttribute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Attribute; }

        /// <summary>The type of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string MetadataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Type; }

        /// <summary>Internal Acessors for Metadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathInternal.Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadata()); set { {_metadata = value;} } }

        /// <summary>Internal Acessors for MetadataAttribute</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathInternal.MetadataAttribute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Attribute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Attribute = value ?? null; }

        /// <summary>Internal Acessors for MetadataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathInternal.MetadataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)Metadata).Type = value ?? null; }

        /// <summary>Internal Acessors for Pattern</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathInternal.Pattern { get => (this._pattern = this._pattern ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPattern()); set { {_pattern = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        /// <summary>The path of an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Pattern" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern _pattern;

        /// <summary>The pattern for an alias path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern Pattern { get => (this._pattern = this._pattern ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPattern()); set => this._pattern = value; }

        /// <summary>The alias pattern phrase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PatternPhrase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Phrase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Phrase = value ?? null; }

        /// <summary>The pattern for an alias path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PatternType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Type = value ?? null; }

        /// <summary>The alias pattern variable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string PatternVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Variable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)Pattern).Variable = value ?? null; }

        /// <summary>Creates an new <see cref="AliasPath" /> instance.</summary>
        public AliasPath()
        {

        }
    }
    /// The type of the paths for alias.
    public partial interface IAliasPath :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The API versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The API versions.",
        SerializedName = @"apiVersions",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ApiVersion { get; set; }
        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The attributes of the token that the alias path is referring to.",
        SerializedName = @"attributes",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("None", "Modifiable")]
        string MetadataAttribute { get;  }
        /// <summary>The type of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The type of the token that the alias path is referring to.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Any", "String", "Object", "Array", "Integer", "Number", "Boolean")]
        string MetadataType { get;  }
        /// <summary>The path of an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The path of an alias.",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>The alias pattern phrase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The alias pattern phrase.",
        SerializedName = @"phrase",
        PossibleTypes = new [] { typeof(string) })]
        string PatternPhrase { get; set; }
        /// <summary>The pattern for an alias path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The pattern for an alias path.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Extract")]
        string PatternType { get; set; }
        /// <summary>The alias pattern variable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The alias pattern variable.",
        SerializedName = @"variable",
        PossibleTypes = new [] { typeof(string) })]
        string PatternVariable { get; set; }

    }
    /// The type of the paths for alias.
    internal partial interface IAliasPathInternal

    {
        /// <summary>The API versions.</summary>
        System.Collections.Generic.List<string> ApiVersion { get; set; }
        /// <summary>
        /// The metadata of the alias path. If missing, fall back to the default metadata of the alias.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata Metadata { get; set; }
        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("None", "Modifiable")]
        string MetadataAttribute { get; set; }
        /// <summary>The type of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Any", "String", "Object", "Array", "Integer", "Number", "Boolean")]
        string MetadataType { get; set; }
        /// <summary>The path of an alias.</summary>
        string Path { get; set; }
        /// <summary>The pattern for an alias path.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern Pattern { get; set; }
        /// <summary>The alias pattern phrase.</summary>
        string PatternPhrase { get; set; }
        /// <summary>The pattern for an alias path.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Extract")]
        string PatternType { get; set; }
        /// <summary>The alias pattern variable.</summary>
        string PatternVariable { get; set; }

    }
}