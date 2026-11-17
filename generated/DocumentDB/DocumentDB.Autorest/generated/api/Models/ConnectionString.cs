// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Connection string for the mongo cluster</summary>
    public partial class ConnectionString :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionString,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionStringInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString1" /> property.</summary>
        private string _connectionString1;

        /// <summary>Value of the connection string</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string ConnectionString1 { get => this._connectionString1; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the connection string</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for ConnectionString1</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionStringInternal.ConnectionString1 { get => this._connectionString1; set { {_connectionString1 = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionStringInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IConnectionStringInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="ConnectionString" /> instance.</summary>
        public ConnectionString()
        {

        }
    }
    /// Connection string for the mongo cluster
    public partial interface IConnectionString :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>Value of the connection string</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Value of the connection string",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString1 { get;  }
        /// <summary>Description of the connection string</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Description of the connection string",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Name of the connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name of the connection string.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    /// Connection string for the mongo cluster
    internal partial interface IConnectionStringInternal

    {
        /// <summary>Value of the connection string</summary>
        string ConnectionString1 { get; set; }
        /// <summary>Description of the connection string</summary>
        string Description { get; set; }
        /// <summary>Name of the connection string.</summary>
        string Name { get; set; }

    }
}