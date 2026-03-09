// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>
    /// Response structure for file shares usage in the specified subscription/location.
    /// </summary>
    public partial class FileShareUsageDataResponse :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataResponse,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataResponseInternal
    {

        /// <summary>The number of active file shares.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Inlined)]
        public int LiveShareFileShareCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal)Property).LiveShareFileShareCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal)Property).LiveShareFileShareCount = value ; }

        /// <summary>Internal Acessors for LiveShare</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataResponseInternal.LiveShare { get => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal)Property).LiveShare; set => ((Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutputInternal)Property).LiveShare = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutput Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUsageDataOutput()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutput _property;

        /// <summary>The properties of the file share usage data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutput Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareUsageDataOutput()); set => this._property = value; }

        /// <summary>Creates an new <see cref="FileShareUsageDataResponse" /> instance.</summary>
        public FileShareUsageDataResponse()
        {

        }
    }
    /// Response structure for file shares usage in the specified subscription/location.
    public partial interface IFileShareUsageDataResponse :
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
    /// Response structure for file shares usage in the specified subscription/location.
    internal partial interface IFileShareUsageDataResponseInternal

    {
        /// <summary>File share usage data for active file shares.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.ILiveSharesUsageData LiveShare { get; set; }
        /// <summary>The number of active file shares.</summary>
        int LiveShareFileShareCount { get; set; }
        /// <summary>The properties of the file share usage data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IFileShareUsageDataOutput Property { get; set; }

    }
}