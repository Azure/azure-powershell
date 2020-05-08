namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class representing database principal entity.</summary>
    public partial class DatabasePrincipal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalInternal
    {

        /// <summary>Backing field for <see cref="AppId" /> property.</summary>
        private string _appId;

        /// <summary>Application id - relevant only for application principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string AppId { get => this._appId; set => this._appId = value; }

        /// <summary>Backing field for <see cref="Email" /> property.</summary>
        private string _email;

        /// <summary>Database principal email if exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Email { get => this._email; set => this._email = value; }

        /// <summary>Backing field for <see cref="Fqn" /> property.</summary>
        private string _fqn;

        /// <summary>Database principal fully qualified name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Fqn { get => this._fqn; set => this._fqn = value; }

        /// <summary>Internal Acessors for TenantName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabasePrincipalInternal.TenantName { get => this._tenantName; set { {_tenantName = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Database principal name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Role" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole _role;

        /// <summary>Database principal role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get => this._role; set => this._role = value; }

        /// <summary>Backing field for <see cref="TenantName" /> property.</summary>
        private string _tenantName;

        /// <summary>The tenant name of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string TenantName { get => this._tenantName; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalType _type;

        /// <summary>Database principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalType Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="DatabasePrincipal" /> instance.</summary>
        public DatabasePrincipal()
        {

        }
    }
    /// A class representing database principal entity.
    public partial interface IDatabasePrincipal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>Application id - relevant only for application principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application id - relevant only for application principal type.",
        SerializedName = @"appId",
        PossibleTypes = new [] { typeof(string) })]
        string AppId { get; set; }
        /// <summary>Database principal email if exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Database principal email if exists.",
        SerializedName = @"email",
        PossibleTypes = new [] { typeof(string) })]
        string Email { get; set; }
        /// <summary>Database principal fully qualified name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Database principal fully qualified name.",
        SerializedName = @"fqn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqn { get; set; }
        /// <summary>Database principal name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Database principal name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Database principal role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Database principal role.",
        SerializedName = @"role",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get; set; }
        /// <summary>The tenant name of the principal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant name of the principal",
        SerializedName = @"tenantName",
        PossibleTypes = new [] { typeof(string) })]
        string TenantName { get;  }
        /// <summary>Database principal type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Database principal type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalType Type { get; set; }

    }
    /// A class representing database principal entity.
    internal partial interface IDatabasePrincipalInternal

    {
        /// <summary>Application id - relevant only for application principal type.</summary>
        string AppId { get; set; }
        /// <summary>Database principal email if exists.</summary>
        string Email { get; set; }
        /// <summary>Database principal fully qualified name.</summary>
        string Fqn { get; set; }
        /// <summary>Database principal name.</summary>
        string Name { get; set; }
        /// <summary>Database principal role.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalRole Role { get; set; }
        /// <summary>The tenant name of the principal</summary>
        string TenantName { get; set; }
        /// <summary>Database principal type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.DatabasePrincipalType Type { get; set; }

    }
}