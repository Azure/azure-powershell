// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a log file.</summary>
    public partial class CapturedLogProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapturedLogProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapturedLogPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreatedTime" /> property.</summary>
        private global::System.DateTime? _createdTime;

        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? CreatedTime { get => this._createdTime; set => this._createdTime = value; }

        /// <summary>Backing field for <see cref="LastModifiedTime" /> property.</summary>
        private global::System.DateTime? _lastModifiedTime;

        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTime { get => this._lastModifiedTime; set => this._lastModifiedTime = value; }

        /// <summary>Backing field for <see cref="SizeInKb" /> property.</summary>
        private long? _sizeInKb;

        /// <summary>Size (in KB) of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public long? SizeInKb { get => this._sizeInKb; set => this._sizeInKb = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="Url" /> property.</summary>
        private string _url;

        /// <summary>URL to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Url { get => this._url; set => this._url = value; }

        /// <summary>Creates an new <see cref="CapturedLogProperties" /> instance.</summary>
        public CapturedLogProperties()
        {

        }
    }
    /// Properties of a log file.
    public partial interface ICapturedLogProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Creation timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Creation timestamp of the log file.",
        SerializedName = @"createdTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Last modified timestamp of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Last modified timestamp of the log file.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTime { get; set; }
        /// <summary>Size (in KB) of the log file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Size (in KB) of the log file.",
        SerializedName = @"sizeInKb",
        PossibleTypes = new [] { typeof(long) })]
        long? SizeInKb { get; set; }
        /// <summary>Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>URL to download the log file from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"URL to download the log file from.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string Url { get; set; }

    }
    /// Properties of a log file.
    internal partial interface ICapturedLogPropertiesInternal

    {
        /// <summary>Creation timestamp of the log file.</summary>
        global::System.DateTime? CreatedTime { get; set; }
        /// <summary>Last modified timestamp of the log file.</summary>
        global::System.DateTime? LastModifiedTime { get; set; }
        /// <summary>Size (in KB) of the log file.</summary>
        long? SizeInKb { get; set; }
        /// <summary>Type of log file. Can be 'ServerLogs' or 'UpgradeLogs'.</summary>
        string Type { get; set; }
        /// <summary>URL to download the log file from.</summary>
        string Url { get; set; }

    }
}