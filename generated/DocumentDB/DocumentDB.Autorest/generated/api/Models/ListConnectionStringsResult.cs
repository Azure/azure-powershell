// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The connection strings for the given mongo cluster.</summary>
    public partial class ListConnectionStringsResult :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IListConnectionStringsResult,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IListConnectionStringsResultInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString> _connectionString;

        /// <summary>An array that contains the connection strings for a mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString> ConnectionString { get => this._connectionString; }

        /// <summary>Internal Acessors for ConnectionString</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString> Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IListConnectionStringsResultInternal.ConnectionString { get => this._connectionString; set { {_connectionString = value;} } }

        /// <summary>Creates an new <see cref="ListConnectionStringsResult" /> instance.</summary>
        public ListConnectionStringsResult()
        {

        }
    }
    /// The connection strings for the given mongo cluster.
    public partial interface IListConnectionStringsResult :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>An array that contains the connection strings for a mongo cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"An array that contains the connection strings for a mongo cluster.",
        SerializedName = @"connectionStrings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString> ConnectionString { get;  }

    }
    /// The connection strings for the given mongo cluster.
    internal partial interface IListConnectionStringsResultInternal

    {
        /// <summary>An array that contains the connection strings for a mongo cluster.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString> ConnectionString { get; set; }

    }
}