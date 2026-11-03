// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>Database role definition that is assigned to a user.</summary>
    public partial class DatabaseRole :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRole,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRoleInternal
    {

        /// <summary>Backing field for <see cref="Db" /> property.</summary>
        private string _db;

        /// <summary>Database scope that the role is assigned to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Db { get => this._db; set => this._db = value; }

        /// <summary>Internal Acessors for Role</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDatabaseRoleInternal.Role { get => this._role; set { {_role = value;} } }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private string _role= @"root";

        /// <summary>The role that is assigned to the user on the database scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Role { get => this._role; }

        /// <summary>Creates an new <see cref="DatabaseRole" /> instance.</summary>
        public DatabaseRole()
        {

        }
    }
    /// Database role definition that is assigned to a user.
    public partial interface IDatabaseRole :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>Database scope that the role is assigned to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Database scope that the role is assigned to.",
        SerializedName = @"db",
        PossibleTypes = new [] { typeof(string) })]
        string Db { get; set; }
        /// <summary>The role that is assigned to the user on the database scope.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The role that is assigned to the user on the database scope.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(string) })]
        string Role { get;  }

    }
    /// Database role definition that is assigned to a user.
    internal partial interface IDatabaseRoleInternal

    {
        /// <summary>Database scope that the role is assigned to.</summary>
        string Db { get; set; }
        /// <summary>The role that is assigned to the user on the database scope.</summary>
        string Role { get; set; }

    }
}