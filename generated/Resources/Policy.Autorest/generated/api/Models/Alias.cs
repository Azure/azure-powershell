// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The alias type.</summary>
    public partial class Alias :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAlias,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal
    {

        /// <summary>Backing field for <see cref="DefaultMetadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata _defaultMetadata;

        /// <summary>
        /// The default alias path metadata. Applies to the default path and to any alias path that doesn't have metadata.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata DefaultMetadata { get => (this._defaultMetadata = this._defaultMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadata()); set => this._defaultMetadata = value; }

        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DefaultMetadataAttribute { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)DefaultMetadata).Attribute; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)DefaultMetadata).Attribute = value ?? null; }

        /// <summary>The type of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DefaultMetadataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)DefaultMetadata).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal)DefaultMetadata).Type = value ?? null; }

        /// <summary>Backing field for <see cref="DefaultPath" /> property.</summary>
        private string _defaultPath;

        /// <summary>The default path for an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string DefaultPath { get => this._defaultPath; set => this._defaultPath = value; }

        /// <summary>Backing field for <see cref="DefaultPattern" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern _defaultPattern;

        /// <summary>The default pattern for an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern DefaultPattern { get => (this._defaultPattern = this._defaultPattern ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPattern()); set => this._defaultPattern = value; }

        /// <summary>The alias pattern phrase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DefaultPatternPhrase { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Phrase; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Phrase = value ?? null; }

        /// <summary>The pattern for an alias path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DefaultPatternType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Type = value ?? null; }

        /// <summary>The alias pattern variable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string DefaultPatternVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Variable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal)DefaultPattern).Variable = value ?? null; }

        /// <summary>Internal Acessors for DefaultMetadata</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal.DefaultMetadata { get => (this._defaultMetadata = this._defaultMetadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPathMetadata()); set { {_defaultMetadata = value;} } }

        /// <summary>Internal Acessors for DefaultPattern</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasInternal.DefaultPattern { get => (this._defaultPattern = this._defaultPattern ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.AliasPattern()); set { {_defaultPattern = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The alias name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath> _path;

        /// <summary>The paths for an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath> Path { get => this._path; set => this._path = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Alias" /> instance.</summary>
        public Alias()
        {

        }
    }
    /// The alias type.
    public partial interface IAlias :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The attributes of the token that the alias path is referring to.",
        SerializedName = @"attributes",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("None", "Modifiable")]
        string DefaultMetadataAttribute { get; set; }
        /// <summary>The type of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of the token that the alias path is referring to.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Any", "String", "Object", "Array", "Integer", "Number", "Boolean")]
        string DefaultMetadataType { get; set; }
        /// <summary>The default path for an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The default path for an alias.",
        SerializedName = @"defaultPath",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultPath { get; set; }
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
        string DefaultPatternPhrase { get; set; }
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
        string DefaultPatternType { get; set; }
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
        string DefaultPatternVariable { get; set; }
        /// <summary>The alias name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The alias name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The paths for an alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The paths for an alias.",
        SerializedName = @"paths",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath> Path { get; set; }
        /// <summary>The type of the alias.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of the alias.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "PlainText", "Mask")]
        string Type { get; set; }

    }
    /// The alias type.
    internal partial interface IAliasInternal

    {
        /// <summary>
        /// The default alias path metadata. Applies to the default path and to any alias path that doesn't have metadata.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata DefaultMetadata { get; set; }
        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("None", "Modifiable")]
        string DefaultMetadataAttribute { get; set; }
        /// <summary>The type of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Any", "String", "Object", "Array", "Integer", "Number", "Boolean")]
        string DefaultMetadataType { get; set; }
        /// <summary>The default path for an alias.</summary>
        string DefaultPath { get; set; }
        /// <summary>The default pattern for an alias.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern DefaultPattern { get; set; }
        /// <summary>The alias pattern phrase.</summary>
        string DefaultPatternPhrase { get; set; }
        /// <summary>The pattern for an alias path.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Extract")]
        string DefaultPatternType { get; set; }
        /// <summary>The alias pattern variable.</summary>
        string DefaultPatternVariable { get; set; }
        /// <summary>The alias name.</summary>
        string Name { get; set; }
        /// <summary>The paths for an alias.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPath> Path { get; set; }
        /// <summary>The type of the alias.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "PlainText", "Mask")]
        string Type { get; set; }

    }
}