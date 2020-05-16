namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Database connection string information.</summary>
    public partial class ConnStringInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfoInternal
    {

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private string _connectionString;

        /// <summary>Connection string value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConnectionString { get => this._connectionString; set => this._connectionString = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType? _type;

        /// <summary>Type of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ConnStringInfo" /> instance.</summary>
        public ConnStringInfo()
        {

        }
    }
    /// Database connection string information.
    public partial interface IConnStringInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Connection string value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection string value.",
        SerializedName = @"connectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectionString { get; set; }
        /// <summary>Name of connection string.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of connection string.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Type of database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of database.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType? Type { get; set; }

    }
    /// Database connection string information.
    internal partial interface IConnStringInfoInternal

    {
        /// <summary>Connection string value.</summary>
        string ConnectionString { get; set; }
        /// <summary>Name of connection string.</summary>
        string Name { get; set; }
        /// <summary>Type of database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ConnectionStringType? Type { get; set; }

    }
}