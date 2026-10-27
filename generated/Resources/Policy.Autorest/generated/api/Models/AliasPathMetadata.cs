// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The alias path metadata.</summary>
    public partial class AliasPathMetadata :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadata,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPathMetadataInternal
    {

        /// <summary>Backing field for <see cref="Attribute" /> property.</summary>
        private string _attribute;

        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Attribute { get => this._attribute; set => this._attribute = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the token that the alias path is referring to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="AliasPathMetadata" /> instance.</summary>
        public AliasPathMetadata()
        {

        }
    }
    /// The alias path metadata.
    public partial interface IAliasPathMetadata :
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
        string Attribute { get; set; }
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
        string Type { get; set; }

    }
    /// The alias path metadata.
    internal partial interface IAliasPathMetadataInternal

    {
        /// <summary>The attributes of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("None", "Modifiable")]
        string Attribute { get; set; }
        /// <summary>The type of the token that the alias path is referring to.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Any", "String", "Object", "Array", "Integer", "Number", "Boolean")]
        string Type { get; set; }

    }
}