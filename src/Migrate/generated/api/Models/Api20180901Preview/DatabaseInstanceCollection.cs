namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Collection of database instances.</summary>
    public partial class DatabaseInstanceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceCollection,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstanceCollectionInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>Gets or sets the value of nextLink.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstance[] _value;

        /// <summary>Gets or sets the database instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstance[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="DatabaseInstanceCollection" /> instance.</summary>
        public DatabaseInstanceCollection()
        {

        }
    }
    /// Collection of database instances.
    public partial interface IDatabaseInstanceCollection :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the value of nextLink.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the value of nextLink.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>Gets or sets the database instances.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the database instances.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstance) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstance[] Value { get; set; }

    }
    /// Collection of database instances.
    internal partial interface IDatabaseInstanceCollectionInternal

    {
        /// <summary>Gets or sets the value of nextLink.</summary>
        string NextLink { get; set; }
        /// <summary>Gets or sets the database instances.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDatabaseInstance[] Value { get; set; }

    }
}