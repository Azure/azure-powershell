// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>File shares usage result.</summary>
    public partial class FileShareUsageDataOutput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutput,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal
    {

        /// <summary>Backing field for <see cref="LiveShare" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData _liveShare;

        /// <summary>File share usage data for active file shares.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData LiveShare { get => (this._liveShare = this._liveShare ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.LiveSharesUsageData()); set => this._liveShare = value; }

        /// <summary>The number of active file shares.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LiveShareFileShareCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageDataInternal)LiveShare).FileShareCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageDataInternal)LiveShare).FileShareCount = value ; }

        /// <summary>Internal Acessors for LiveShare</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal.LiveShare { get => (this._liveShare = this._liveShare ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.LiveSharesUsageData()); set { {_liveShare = value;} } }

        /// <summary>Creates an new <see cref="FileShareUsageDataOutput" /> instance.</summary>
        public FileShareUsageDataOutput()
        {

        }
    }
    /// File shares usage result.
    public partial interface IFileShareUsageDataOutput :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The number of active file shares.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The number of active file shares.",
        SerializedName = @"fileShareCount",
        PossibleTypes = new [] { typeof(int) })]
        int LiveShareFileShareCount { get; set; }

    }
    /// File shares usage result.
    internal partial interface IFileShareUsageDataOutputInternal

    {
        /// <summary>File share usage data for active file shares.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData LiveShare { get; set; }
        /// <summary>The number of active file shares.</summary>
        int LiveShareFileShareCount { get; set; }

    }
}