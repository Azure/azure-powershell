// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The data effect definition.</summary>
    public partial class DataEffect :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffect,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IDataEffectInternal
    {

        /// <summary>Backing field for <see cref="DetailsSchema" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _detailsSchema;

        /// <summary>The data effect details schema.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny DetailsSchema { get => (this._detailsSchema = this._detailsSchema ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._detailsSchema = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The data effect name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="DataEffect" /> instance.</summary>
        public DataEffect()
        {

        }
    }
    /// The data effect definition.
    public partial interface IDataEffect :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The data effect details schema.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The data effect details schema.",
        SerializedName = @"detailsSchema",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny DetailsSchema { get; set; }
        /// <summary>The data effect name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The data effect name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// The data effect definition.
    internal partial interface IDataEffectInternal

    {
        /// <summary>The data effect details schema.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny DetailsSchema { get; set; }
        /// <summary>The data effect name.</summary>
        string Name { get; set; }

    }
}