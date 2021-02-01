namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class FilterQueryOption :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal
    {

        /// <summary>Backing field for <see cref="Context" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext _context;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext Context { get => (this._context = this._context ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContext()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ExpressionTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ExpressionTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceIsNullable; }

        /// <summary>Backing field for <see cref="FilterClause" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause _filterClause;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause FilterClause { get => (this._filterClause = this._filterClause ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ItemTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ItemTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeIsNullable; }

        /// <summary>Internal Acessors for Context</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.Context { get => (this._context = this._context ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ODataQueryContext()); set { {_context = value;} } }

        /// <summary>Internal Acessors for ExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionKind = value; }

        /// <summary>Internal Acessors for ExpressionTypeReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ExpressionTypeReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReference = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ExpressionTypeReferenceDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceDefinition = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ExpressionTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ExpressionTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ExpressionTypeReferenceIsNullable = value; }

        /// <summary>Internal Acessors for FilterClause</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.FilterClause { get => (this._filterClause = this._filterClause ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterClause()); set { {_filterClause = value;} } }

        /// <summary>Internal Acessors for FilterClauseExpression</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.FilterClauseExpression { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).Expression; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).Expression = value; }

        /// <summary>Internal Acessors for FilterClauseItemType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.FilterClauseItemType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemType = value; }

        /// <summary>Internal Acessors for FilterClauseRangeVariable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.FilterClauseRangeVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariable = value; }

        /// <summary>Internal Acessors for ItemTypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ItemTypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeDefinition = value; }

        /// <summary>Internal Acessors for ItemTypeDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ItemTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for ItemTypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.ItemTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).ItemTypeIsNullable = value; }

        /// <summary>Internal Acessors for RangeVariableKind</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableKind = value; }

        /// <summary>Internal Acessors for RangeVariableName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableName = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableTypeReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReference = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableTypeReferenceDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceDefinition = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RangeVariableTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceIsNullable = value; }

        /// <summary>Internal Acessors for RawValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal.RawValue { get => this._rawValue; set { {_rawValue = value;} } }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? RangeVariableKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RangeVariableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableName; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RangeVariableTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? RangeVariableTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClauseInternal)FilterClause).RangeVariableTypeReferenceIsNullable; }

        /// <summary>Backing field for <see cref="RawValue" /> property.</summary>
        private string _rawValue;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RawValue { get => this._rawValue; }

        /// <summary>Backing field for <see cref="Validator" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny _validator;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Validator { get => (this._validator = this._validator ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Any()); set => this._validator = value; }

        /// <summary>Creates an new <see cref="FilterQueryOption" /> instance.</summary>
        public FilterQueryOption()
        {

        }
    }
    public partial interface IFilterQueryOption :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"context",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext Context { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressionKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressionTypeReferenceDefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ExpressionTypeReferenceIsNullable { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string ItemTypeDefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ItemTypeIsNullable { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(int) })]
        int? RangeVariableKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string RangeVariableName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string RangeVariableTypeReferenceDefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RangeVariableTypeReferenceIsNullable { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"rawValue",
        PossibleTypes = new [] { typeof(string) })]
        string RawValue { get;  }
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any object",
        SerializedName = @"validator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Validator { get; set; }

    }
    internal partial interface IFilterQueryOptionInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext Context { get; set; }

        string ExpressionKind { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference ExpressionTypeReference { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType ExpressionTypeReferenceDefinition { get; set; }

        string ExpressionTypeReferenceDefinitionTypeKind { get; set; }

        bool? ExpressionTypeReferenceIsNullable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause FilterClause { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode FilterClauseExpression { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference FilterClauseItemType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable FilterClauseRangeVariable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType ItemTypeDefinition { get; set; }

        string ItemTypeDefinitionTypeKind { get; set; }

        bool? ItemTypeIsNullable { get; set; }

        int? RangeVariableKind { get; set; }

        string RangeVariableName { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference RangeVariableTypeReference { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType RangeVariableTypeReferenceDefinition { get; set; }

        string RangeVariableTypeReferenceDefinitionTypeKind { get; set; }

        bool? RangeVariableTypeReferenceIsNullable { get; set; }

        string RawValue { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Validator { get; set; }

    }
}