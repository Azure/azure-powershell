// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The type of the pattern for an alias path.</summary>
    public partial class AliasPattern :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPattern,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAliasPatternInternal
    {

        /// <summary>Backing field for <see cref="Phrase" /> property.</summary>
        private string _phrase;

        /// <summary>The alias pattern phrase.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Phrase { get => this._phrase; set => this._phrase = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The pattern for an alias path.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Variable" /> property.</summary>
        private string _variable;

        /// <summary>The alias pattern variable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Variable { get => this._variable; set => this._variable = value; }

        /// <summary>Creates an new <see cref="AliasPattern" /> instance.</summary>
        public AliasPattern()
        {

        }
    }
    /// The type of the pattern for an alias path.
    public partial interface IAliasPattern :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
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
        string Phrase { get; set; }
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
        string Type { get; set; }
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
        string Variable { get; set; }

    }
    /// The type of the pattern for an alias path.
    internal partial interface IAliasPatternInternal

    {
        /// <summary>The alias pattern phrase.</summary>
        string Phrase { get; set; }
        /// <summary>The pattern for an alias path.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.Policy.PSArgumentCompleterAttribute("NotSpecified", "Extract")]
        string Type { get; set; }
        /// <summary>The alias pattern variable.</summary>
        string Variable { get; set; }

    }
}