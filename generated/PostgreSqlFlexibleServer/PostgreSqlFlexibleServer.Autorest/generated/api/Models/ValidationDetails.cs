// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Details for the validation for migration.</summary>
    public partial class ValidationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationDetailsInternal
    {

        /// <summary>Backing field for <see cref="DbLevelValidationDetail" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> _dbLevelValidationDetail;

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> DbLevelValidationDetail { get => this._dbLevelValidationDetail; set => this._dbLevelValidationDetail = value; }

        /// <summary>Backing field for <see cref="ServerLevelValidationDetail" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> _serverLevelValidationDetail;

        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ServerLevelValidationDetail { get => this._serverLevelValidationDetail; set => this._serverLevelValidationDetail = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="ValidationEndTimeInUtc" /> property.</summary>
        private global::System.DateTime? _validationEndTimeInUtc;

        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? ValidationEndTimeInUtc { get => this._validationEndTimeInUtc; set => this._validationEndTimeInUtc = value; }

        /// <summary>Backing field for <see cref="ValidationStartTimeInUtc" /> property.</summary>
        private global::System.DateTime? _validationStartTimeInUtc;

        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public global::System.DateTime? ValidationStartTimeInUtc { get => this._validationStartTimeInUtc; set => this._validationStartTimeInUtc = value; }

        /// <summary>Creates an new <see cref="ValidationDetails" /> instance.</summary>
        public ValidationDetails()
        {

        }
    }
    /// Details for the validation for migration.
    public partial interface IValidationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Details of server level validations.",
        SerializedName = @"dbLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> DbLevelValidationDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Details of server level validations.",
        SerializedName = @"serverLevelValidationDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ServerLevelValidationDetail { get; set; }
        /// <summary>Validation status for migration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Validation status for migration.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string Status { get; set; }
        /// <summary>End time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End time (UTC) for validation.",
        SerializedName = @"validationEndTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start time (UTC) for validation.",
        SerializedName = @"validationStartTimeInUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ValidationStartTimeInUtc { get; set; }

    }
    /// Details for the validation for migration.
    internal partial interface IValidationDetailsInternal

    {
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDbLevelValidationStatus> DbLevelValidationDetail { get; set; }
        /// <summary>Details of server level validations.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IValidationSummaryItem> ServerLevelValidationDetail { get; set; }
        /// <summary>Validation status for migration.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Failed", "Succeeded", "Warning")]
        string Status { get; set; }
        /// <summary>End time (UTC) for validation.</summary>
        global::System.DateTime? ValidationEndTimeInUtc { get; set; }
        /// <summary>Start time (UTC) for validation.</summary>
        global::System.DateTime? ValidationStartTimeInUtc { get; set; }

    }
}