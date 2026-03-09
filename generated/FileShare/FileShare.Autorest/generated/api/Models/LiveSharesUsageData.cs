// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>Usage data for live shares.</summary>
    public partial class LiveSharesUsageData :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageDataInternal
    {

        /// <summary>Backing field for <see cref="FileShareCount" /> property.</summary>
        private int _fileShareCount;

        /// <summary>The number of active file shares.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public int FileShareCount { get => this._fileShareCount; set => this._fileShareCount = value; }

        /// <summary>Creates an new <see cref="LiveSharesUsageData" /> instance.</summary>
        public LiveSharesUsageData()
        {

        }
    }
    /// Usage data for live shares.
    public partial interface ILiveSharesUsageData :
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
        int FileShareCount { get; set; }

    }
    /// Usage data for live shares.
    internal partial interface ILiveSharesUsageDataInternal

    {
        /// <summary>The number of active file shares.</summary>
        int FileShareCount { get; set; }

    }
}