// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Validation status summary for a database.</summary>
    public partial class DbLevelValidationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatusInternal
    {

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>Name of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; set => this._databaseName = value; }

        /// <summary>Backing field for <see cref="EndedOn" /> property.</summary>
        private global::System.DateTime? _endedOn;

        /// <summary>End time of a database level validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? EndedOn { get => this._endedOn; set => this._endedOn = value; }

        /// <summary>Backing field for <see cref="StartedOn" /> property.</summary>
        private global::System.DateTime? _startedOn;

        /// <summary>Start time of a database level validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? StartedOn { get => this._startedOn; set => this._startedOn = value; }

        /// <summary>Backing field for <see cref="Summary" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> _summary;

        /// <summary>Summary of database level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Summary { get => this._summary; set => this._summary = value; }

        /// <summary>Creates an new <see cref="DbLevelValidationStatus" /> instance.</summary>
        public DbLevelValidationStatus()
        {

        }
    }
    /// Validation status summary for a database.
    public partial interface IDbLevelValidationStatus :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Name of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of database.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>End time of a database level validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time of a database level validation.",
        SerializedName = @"endedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndedOn { get; set; }
        /// <summary>Start time of a database level validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time of a database level validation.",
        SerializedName = @"startedOn",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartedOn { get; set; }
        /// <summary>Summary of database level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Summary of database level validations.",
        SerializedName = @"summary",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Summary { get; set; }

    }
    /// Validation status summary for a database.
    internal partial interface IDbLevelValidationStatusInternal

    {
        /// <summary>Name of database.</summary>
        string DatabaseName { get; set; }
        /// <summary>End time of a database level validation.</summary>
        global::System.DateTime? EndedOn { get; set; }
        /// <summary>Start time of a database level validation.</summary>
        global::System.DateTime? StartedOn { get; set; }
        /// <summary>Summary of database level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> Summary { get; set; }

    }
}