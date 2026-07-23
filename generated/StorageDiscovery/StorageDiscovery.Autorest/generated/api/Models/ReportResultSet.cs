// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The result set of the report operation</summary>
    public partial class ReportResultSet :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSetInternal
    {

        /// <summary>Backing field for <see cref="Column" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultColumn> _column;

        /// <summary>Array of columns object, present only if the query succeeded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultColumn> Column { get => this._column; set => this._column = value; }

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>Provides an error about the query, present only if the query fails</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="Row" /> property.</summary>
        private System.Collections.Generic.List<System.Collections.Generic.List<string>> _row;

        /// <summary>Array of all rows from ADX, present only if the query succeeded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<System.Collections.Generic.List<string>> Row { get => this._row; set => this._row = value; }

        /// <summary>Creates an new <see cref="ReportResultSet" /> instance.</summary>
        public ReportResultSet()
        {

        }
    }
    /// The result set of the report operation
    public partial interface IReportResultSet :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>Array of columns object, present only if the query succeeded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Array of columns object, present only if the query succeeded",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultColumn) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultColumn> Column { get; set; }
        /// <summary>Provides an error about the query, present only if the query fails</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Provides an error about the query, present only if the query fails",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get; set; }
        /// <summary>Array of all rows from ADX, present only if the query succeeded</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Array of all rows from ADX, present only if the query succeeded",
        SerializedName = @"rows",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<System.Collections.Generic.List<string>> Row { get; set; }

    }
    /// The result set of the report operation
    internal partial interface IReportResultSetInternal

    {
        /// <summary>Array of columns object, present only if the query succeeded</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultColumn> Column { get; set; }
        /// <summary>Provides an error about the query, present only if the query fails</summary>
        string ErrorCode { get; set; }
        /// <summary>Array of all rows from ADX, present only if the query succeeded</summary>
        System.Collections.Generic.List<System.Collections.Generic.List<string>> Row { get; set; }

    }
}