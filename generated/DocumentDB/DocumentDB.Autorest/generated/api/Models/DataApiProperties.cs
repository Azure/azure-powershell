// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Data API properties.</summary>
    public partial class DataApiProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDataApiPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Mode" /> property.</summary>
        private string _mode;

        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Mode { get => this._mode; set => this._mode = value; }

        /// <summary>Creates an new <see cref="DataApiProperties" /> instance.</summary>
        public DataApiProperties()
        {

        }
    }
    /// Data API properties.
    public partial interface IDataApiProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The mode to indicate whether the Mongo Data API is enabled for a cluster.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Mode { get; set; }

    }
    /// Data API properties.
    internal partial interface IDataApiPropertiesInternal

    {
        /// <summary>The mode to indicate whether the Mongo Data API is enabled for a cluster.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Enabled", "Disabled")]
        string Mode { get; set; }

    }
}