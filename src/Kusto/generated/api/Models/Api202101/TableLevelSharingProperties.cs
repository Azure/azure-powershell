namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Tables that will be included and excluded in the follower database</summary>
    public partial class TableLevelSharingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.ITableLevelSharingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ExternalTablesToExclude" /> property.</summary>
        private string[] _externalTablesToExclude;

        /// <summary>List of external tables exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] ExternalTablesToExclude { get => this._externalTablesToExclude; set => this._externalTablesToExclude = value; }

        /// <summary>Backing field for <see cref="ExternalTablesToInclude" /> property.</summary>
        private string[] _externalTablesToInclude;

        /// <summary>List of external tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] ExternalTablesToInclude { get => this._externalTablesToInclude; set => this._externalTablesToInclude = value; }

        /// <summary>Backing field for <see cref="MaterializedViewsToExclude" /> property.</summary>
        private string[] _materializedViewsToExclude;

        /// <summary>List of materialized views exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] MaterializedViewsToExclude { get => this._materializedViewsToExclude; set => this._materializedViewsToExclude = value; }

        /// <summary>Backing field for <see cref="MaterializedViewsToInclude" /> property.</summary>
        private string[] _materializedViewsToInclude;

        /// <summary>List of materialized views to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] MaterializedViewsToInclude { get => this._materializedViewsToInclude; set => this._materializedViewsToInclude = value; }

        /// <summary>Backing field for <see cref="TablesToExclude" /> property.</summary>
        private string[] _tablesToExclude;

        /// <summary>List of tables to exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] TablesToExclude { get => this._tablesToExclude; set => this._tablesToExclude = value; }

        /// <summary>Backing field for <see cref="TablesToInclude" /> property.</summary>
        private string[] _tablesToInclude;

        /// <summary>List of tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] TablesToInclude { get => this._tablesToInclude; set => this._tablesToInclude = value; }

        /// <summary>Creates an new <see cref="TableLevelSharingProperties" /> instance.</summary>
        public TableLevelSharingProperties()
        {

        }
    }
    /// Tables that will be included and excluded in the follower database
    public partial interface ITableLevelSharingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>List of external tables exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of external tables exclude from the follower database",
        SerializedName = @"externalTablesToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExternalTablesToExclude { get; set; }
        /// <summary>List of external tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of external tables to include in the follower database",
        SerializedName = @"externalTablesToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] ExternalTablesToInclude { get; set; }
        /// <summary>List of materialized views exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of materialized views exclude from the follower database",
        SerializedName = @"materializedViewsToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] MaterializedViewsToExclude { get; set; }
        /// <summary>List of materialized views to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of materialized views to include in the follower database",
        SerializedName = @"materializedViewsToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] MaterializedViewsToInclude { get; set; }
        /// <summary>List of tables to exclude from the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of tables to exclude from the follower database",
        SerializedName = @"tablesToExclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TablesToExclude { get; set; }
        /// <summary>List of tables to include in the follower database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of tables to include in the follower database",
        SerializedName = @"tablesToInclude",
        PossibleTypes = new [] { typeof(string) })]
        string[] TablesToInclude { get; set; }

    }
    /// Tables that will be included and excluded in the follower database
    internal partial interface ITableLevelSharingPropertiesInternal

    {
        /// <summary>List of external tables exclude from the follower database</summary>
        string[] ExternalTablesToExclude { get; set; }
        /// <summary>List of external tables to include in the follower database</summary>
        string[] ExternalTablesToInclude { get; set; }
        /// <summary>List of materialized views exclude from the follower database</summary>
        string[] MaterializedViewsToExclude { get; set; }
        /// <summary>List of materialized views to include in the follower database</summary>
        string[] MaterializedViewsToInclude { get; set; }
        /// <summary>List of tables to exclude from the follower database</summary>
        string[] TablesToExclude { get; set; }
        /// <summary>List of tables to include in the follower database</summary>
        string[] TablesToInclude { get; set; }

    }
}