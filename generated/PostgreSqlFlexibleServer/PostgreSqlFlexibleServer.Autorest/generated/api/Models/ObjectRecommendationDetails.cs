// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Recommendation details for the recommended action.</summary>
    public partial class ObjectRecommendationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetailsInternal
    {

        /// <summary>Backing field for <see cref="DatabaseName" /> property.</summary>
        private string _databaseName;

        /// <summary>Database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DatabaseName { get => this._databaseName; set => this._databaseName = value; }

        /// <summary>Backing field for <see cref="IncludedColumn" /> property.</summary>
        private System.Collections.Generic.List<string> _includedColumn;

        /// <summary>Index included columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> IncludedColumn { get => this._includedColumn; set => this._includedColumn = value; }

        /// <summary>Backing field for <see cref="IndexColumn" /> property.</summary>
        private System.Collections.Generic.List<string> _indexColumn;

        /// <summary>Index columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> IndexColumn { get => this._indexColumn; set => this._indexColumn = value; }

        /// <summary>Backing field for <see cref="IndexName" /> property.</summary>
        private string _indexName;

        /// <summary>Index name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string IndexName { get => this._indexName; set => this._indexName = value; }

        /// <summary>Backing field for <see cref="IndexType" /> property.</summary>
        private string _indexType;

        /// <summary>Index type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string IndexType { get => this._indexType; set => this._indexType = value; }

        /// <summary>Backing field for <see cref="Schema" /> property.</summary>
        private string _schema;

        /// <summary>Schema name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Schema { get => this._schema; set => this._schema = value; }

        /// <summary>Backing field for <see cref="Table" /> property.</summary>
        private string _table;

        /// <summary>Table name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Table { get => this._table; set => this._table = value; }

        /// <summary>Creates an new <see cref="ObjectRecommendationDetails" /> instance.</summary>
        public ObjectRecommendationDetails()
        {

        }
    }
    /// Recommendation details for the recommended action.
    public partial interface IObjectRecommendationDetails :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Database name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Database name.",
        SerializedName = @"databaseName",
        PossibleTypes = new [] { typeof(string) })]
        string DatabaseName { get; set; }
        /// <summary>Index included columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Index included columns.",
        SerializedName = @"includedColumns",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> IncludedColumn { get; set; }
        /// <summary>Index columns.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Index columns.",
        SerializedName = @"indexColumns",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> IndexColumn { get; set; }
        /// <summary>Index name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Index name.",
        SerializedName = @"indexName",
        PossibleTypes = new [] { typeof(string) })]
        string IndexName { get; set; }
        /// <summary>Index type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Index type.",
        SerializedName = @"indexType",
        PossibleTypes = new [] { typeof(string) })]
        string IndexType { get; set; }
        /// <summary>Schema name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Schema name.",
        SerializedName = @"schema",
        PossibleTypes = new [] { typeof(string) })]
        string Schema { get; set; }
        /// <summary>Table name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Table name.",
        SerializedName = @"table",
        PossibleTypes = new [] { typeof(string) })]
        string Table { get; set; }

    }
    /// Recommendation details for the recommended action.
    internal partial interface IObjectRecommendationDetailsInternal

    {
        /// <summary>Database name.</summary>
        string DatabaseName { get; set; }
        /// <summary>Index included columns.</summary>
        System.Collections.Generic.List<string> IncludedColumn { get; set; }
        /// <summary>Index columns.</summary>
        System.Collections.Generic.List<string> IndexColumn { get; set; }
        /// <summary>Index name.</summary>
        string IndexName { get; set; }
        /// <summary>Index type.</summary>
        string IndexType { get; set; }
        /// <summary>Schema name.</summary>
        string Schema { get; set; }
        /// <summary>Table name.</summary>
        string Table { get; set; }

    }
}