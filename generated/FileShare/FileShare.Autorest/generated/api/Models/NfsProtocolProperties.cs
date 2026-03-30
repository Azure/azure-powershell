// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>Properties specific to the NFS protocol.</summary>
    public partial class NfsProtocolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.INfsProtocolPropertiesInternal
    {

        /// <summary>Backing field for <see cref="RootSquash" /> property.</summary>
        private string _rootSquash;

        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public string RootSquash { get => this._rootSquash; set => this._rootSquash = value; }

        /// <summary>Creates an new <see cref="NfsProtocolProperties" /> instance.</summary>
        public NfsProtocolProperties()
        {

        }
    }
    /// Properties specific to the NFS protocol.
    public partial interface INfsProtocolProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Root squash defines how root users on clients are mapped to the NFS share.",
        SerializedName = @"rootSquash",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string RootSquash { get; set; }

    }
    /// Properties specific to the NFS protocol.
    internal partial interface INfsProtocolPropertiesInternal

    {
        /// <summary>Root squash defines how root users on clients are mapped to the NFS share.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.FileShare.PSArgumentCompleterAttribute("NoRootSquash", "RootSquash", "AllSquash")]
        string RootSquash { get; set; }

    }
}