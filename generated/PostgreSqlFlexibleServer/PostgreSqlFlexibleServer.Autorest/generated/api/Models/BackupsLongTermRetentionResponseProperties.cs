// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Response for the pre-backup request.</summary>
    public partial class BackupsLongTermRetentionResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponsePropertiesInternal
    {

        /// <summary>Backing field for <see cref="NumberOfContainer" /> property.</summary>
        private int _numberOfContainer;

        /// <summary>
        /// Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations,
        /// parallelism, or redundancy etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public int NumberOfContainer { get => this._numberOfContainer; set => this._numberOfContainer = value; }

        /// <summary>
        /// Creates an new <see cref="BackupsLongTermRetentionResponseProperties" /> instance.
        /// </summary>
        public BackupsLongTermRetentionResponseProperties()
        {

        }
    }
    /// Response for the pre-backup request.
    public partial interface IBackupsLongTermRetentionResponseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations,
        /// parallelism, or redundancy etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations, parallelism, or redundancy etc.",
        SerializedName = @"numberOfContainers",
        PossibleTypes = new [] { typeof(int) })]
        int NumberOfContainer { get; set; }

    }
    /// Response for the pre-backup request.
    internal partial interface IBackupsLongTermRetentionResponsePropertiesInternal

    {
        /// <summary>
        /// Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations,
        /// parallelism, or redundancy etc.
        /// </summary>
        int NumberOfContainer { get; set; }

    }
}