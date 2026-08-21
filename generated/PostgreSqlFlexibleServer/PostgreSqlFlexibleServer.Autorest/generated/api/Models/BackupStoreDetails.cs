// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Details about the target where the backup content will be stored.</summary>
    public partial class BackupStoreDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupStoreDetailsInternal
    {

        /// <summary>Backing field for <see cref="SasUriList" /> property.</summary>
        private System.Collections.Generic.List<System.Security.SecureString> _sasUriList;

        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<System.Security.SecureString> SasUriList { get => this._sasUriList; set => this._sasUriList = value; }

        /// <summary>Creates an new <see cref="BackupStoreDetails" /> instance.</summary>
        public BackupStoreDetails()
        {

        }
    }
    /// Details about the target where the backup content will be stored.
    public partial interface IBackupStoreDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of SAS uri of storage containers where backup data is to be streamed/copied.",
        SerializedName = @"sasUriList",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Collections.Generic.List<System.Security.SecureString> SasUriList { get; set; }

    }
    /// Details about the target where the backup content will be stored.
    internal partial interface IBackupStoreDetailsInternal

    {
        /// <summary>
        /// List of SAS uri of storage containers where backup data is to be streamed/copied.
        /// </summary>
        System.Collections.Generic.List<System.Security.SecureString> SasUriList { get; set; }

    }
}