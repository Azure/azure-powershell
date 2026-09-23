// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The response of the report operation</summary>
    public partial class GetReportResult :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IGetReportResult,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IGetReportResultInternal
    {

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet> _result;

        /// <summary>One or more result sets, in the same order as the queries in the request body</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet> Result { get => this._result; set => this._result = value; }

        /// <summary>Creates an new <see cref="GetReportResult" /> instance.</summary>
        public GetReportResult()
        {

        }
    }
    /// The response of the report operation
    public partial interface IGetReportResult :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>One or more result sets, in the same order as the queries in the request body</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"One or more result sets, in the same order as the queries in the request body",
        SerializedName = @"results",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet> Result { get; set; }

    }
    /// The response of the report operation
    internal partial interface IGetReportResultInternal

    {
        /// <summary>One or more result sets, in the same order as the queries in the request body</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IReportResultSet> Result { get; set; }

    }
}