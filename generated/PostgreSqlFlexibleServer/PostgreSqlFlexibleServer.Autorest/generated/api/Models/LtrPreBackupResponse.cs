// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Response for the LTR pre-backup API call.</summary>
    public partial class LtrPreBackupResponse :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupResponse,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupResponseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupResponseInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupsLongTermRetentionResponseProperties()); set { {_property = value;} } }

        /// <summary>
        /// Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations,
        /// parallelism, or redundancy etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public int NumberOfContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponsePropertiesInternal)Property).NumberOfContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponsePropertiesInternal)Property).NumberOfContainer = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseProperties _property;

        /// <summary>Additional Properties for the pre backup response</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.BackupsLongTermRetentionResponseProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="XmsRequestId" /> property.</summary>
        private string _xmsRequestId;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string XmsRequestId { get => this._xmsRequestId; set => this._xmsRequestId = value; }

        /// <summary>Creates an new <see cref="LtrPreBackupResponse" /> instance.</summary>
        public LtrPreBackupResponse()
        {

        }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("x-ms-request-id", out var __xMSRequestIdHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ILtrPreBackupResponseInternal)this).XmsRequestId = System.Linq.Enumerable.FirstOrDefault(__xMSRequestIdHeader0) is string __headerXMSRequestIdHeader0 ? __headerXMSRequestIdHeader0 : (string)null;
            }
        }
    }
    /// Response for the LTR pre-backup API call.
    public partial interface ILtrPreBackupResponse :
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

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"x-ms-request-id",
        PossibleTypes = new [] { typeof(string) })]
        string XmsRequestId { get; set; }

    }
    /// Response for the LTR pre-backup API call.
    internal partial interface ILtrPreBackupResponseInternal

    {
        /// <summary>
        /// Number of storage containers the plugin will use during backup. More than one containers may be used for size limitations,
        /// parallelism, or redundancy etc.
        /// </summary>
        int NumberOfContainer { get; set; }
        /// <summary>Additional Properties for the pre backup response</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IBackupsLongTermRetentionResponseProperties Property { get; set; }

        string XmsRequestId { get; set; }

    }
}