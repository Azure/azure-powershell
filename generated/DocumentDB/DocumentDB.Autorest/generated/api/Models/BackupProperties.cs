// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>
    /// The backup properties of the cluster. This includes the earliest restore time and retention settings.
    /// </summary>
    public partial class BackupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EarliestRestoreTime" /> property.</summary>
        private string _earliestRestoreTime;

        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string EarliestRestoreTime { get => this._earliestRestoreTime; }

        /// <summary>Internal Acessors for EarliestRestoreTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IBackupPropertiesInternal.EarliestRestoreTime { get => this._earliestRestoreTime; set { {_earliestRestoreTime = value;} } }

        /// <summary>Creates an new <see cref="BackupProperties" /> instance.</summary>
        public BackupProperties()
        {

        }
    }
    /// The backup properties of the cluster. This includes the earliest restore time and retention settings.
    public partial interface IBackupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Earliest restore timestamp in UTC ISO8601 format.",
        SerializedName = @"earliestRestoreTime",
        PossibleTypes = new [] { typeof(string) })]
        string EarliestRestoreTime { get;  }

    }
    /// The backup properties of the cluster. This includes the earliest restore time and retention settings.
    internal partial interface IBackupPropertiesInternal

    {
        /// <summary>Earliest restore timestamp in UTC ISO8601 format.</summary>
        string EarliestRestoreTime { get; set; }

    }
}