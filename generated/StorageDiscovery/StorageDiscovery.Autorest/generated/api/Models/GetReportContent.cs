// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>Request to get StorageDiscoveryWorkspace data from ADX</summary>
    public partial class GetReportContent :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IGetReportContent,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IGetReportContentInternal
    {

        /// <summary>Backing field for <see cref="Query" /> property.</summary>
        private System.Collections.Generic.List<string> _query;

        /// <summary>
        /// The queries to execute against Storage Discovery data.
        /// Format: Base64-encoded JSON object with structure:
        /// {"queries":[{"name":"queryName","query":"KQL query"}]}
        /// For query syntax and available tables, see: https://aka.ms/storageDiscoveryQuery
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Query { get => this._query; set => this._query = value; }

        /// <summary>Creates an new <see cref="GetReportContent" /> instance.</summary>
        public GetReportContent()
        {

        }
    }
    /// Request to get StorageDiscoveryWorkspace data from ADX
    public partial interface IGetReportContent :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The queries to execute against Storage Discovery data.
        /// Format: Base64-encoded JSON object with structure:
        /// {"queries":[{"name":"queryName","query":"KQL query"}]}
        /// For query syntax and available tables, see: https://aka.ms/storageDiscoveryQuery
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The queries to execute against Storage Discovery data.
        Format: Base64-encoded JSON object with structure:
        {""queries"":[{""name"":""queryName"",""query"":""KQL query""}]}
        For query syntax and available tables, see: https://aka.ms/storageDiscoveryQuery",
        SerializedName = @"queries",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Query { get; set; }

    }
    /// Request to get StorageDiscoveryWorkspace data from ADX
    internal partial interface IGetReportContentInternal

    {
        /// <summary>
        /// The queries to execute against Storage Discovery data.
        /// Format: Base64-encoded JSON object with structure:
        /// {"queries":[{"name":"queryName","query":"KQL query"}]}
        /// For query syntax and available tables, see: https://aka.ms/storageDiscoveryQuery
        /// </summary>
        System.Collections.Generic.List<string> Query { get; set; }

    }
}