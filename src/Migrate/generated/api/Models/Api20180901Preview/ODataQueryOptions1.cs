namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class ODataQueryOptions1 :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal
    {

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ExpressionTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ExpressionTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceIsNullable; }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption _filter;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext FilterContext { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).Context; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FilterRawValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RawValue; }

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny FilterValidator { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).Validator; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).Validator = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ItemTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? ItemTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeIsNullable; }

        /// <summary>Internal Acessors for ExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionKind = value; }

        /// <summary>Internal Acessors for ExpressionTypeReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ExpressionTypeReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReference = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ExpressionTypeReferenceDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceDefinition = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ExpressionTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for ExpressionTypeReferenceIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ExpressionTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ExpressionTypeReferenceIsNullable = value; }

        /// <summary>Internal Acessors for Filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.FilterQueryOption()); set { {_filter = value;} } }

        /// <summary>Internal Acessors for FilterClause</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterClause { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClause; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClause = value; }

        /// <summary>Internal Acessors for FilterClauseExpression</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterClauseExpression { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseExpression; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseExpression = value; }

        /// <summary>Internal Acessors for FilterClauseItemType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterClauseItemType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseItemType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseItemType = value; }

        /// <summary>Internal Acessors for FilterClauseRangeVariable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterClauseRangeVariable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseRangeVariable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).FilterClauseRangeVariable = value; }

        /// <summary>Internal Acessors for FilterContext</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterContext { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).Context; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).Context = value; }

        /// <summary>Internal Acessors for FilterRawValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.FilterRawValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RawValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RawValue = value; }

        /// <summary>Internal Acessors for ItemTypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ItemTypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeDefinition = value; }

        /// <summary>Internal Acessors for ItemTypeDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ItemTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for ItemTypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.ItemTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).ItemTypeIsNullable = value; }

        /// <summary>Internal Acessors for RangeVariableKind</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableKind = value; }

        /// <summary>Internal Acessors for RangeVariableName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableName = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReference</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableTypeReference { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReference; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReference = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableTypeReferenceDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceDefinition = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceDefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceDefinitionTypeKind = value; }

        /// <summary>Internal Acessors for RangeVariableTypeReferenceIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryOptions1Internal.RangeVariableTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceIsNullable = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public int? RangeVariableKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RangeVariableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableName; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RangeVariableTypeReferenceDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceDefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? RangeVariableTypeReferenceIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOptionInternal)Filter).RangeVariableTypeReferenceIsNullable; }

        /// <summary>Creates an new <see cref="ODataQueryOptions1" /> instance.</summary>
        public ODataQueryOptions1()
        {

        }
    }
    public partial interface IODataQueryOptions1 :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
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
        SerializedName = @"context",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext FilterContext { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"rawValue",
        PossibleTypes = new [] { typeof(string) })]
        string FilterRawValue { get;  }
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Any object",
        SerializedName = @"validator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny FilterValidator { get; set; }

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

    }
    internal partial interface IODataQueryOptions1Internal

    {
        string ExpressionKind { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference ExpressionTypeReference { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType ExpressionTypeReferenceDefinition { get; set; }

        string ExpressionTypeReferenceDefinitionTypeKind { get; set; }

        bool? ExpressionTypeReferenceIsNullable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterQueryOption Filter { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IFilterClause FilterClause { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISingleValueNode FilterClauseExpression { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference FilterClauseItemType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRangeVariable FilterClauseRangeVariable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataQueryContext FilterContext { get; set; }

        string FilterRawValue { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny FilterValidator { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType ItemTypeDefinition { get; set; }

        string ItemTypeDefinitionTypeKind { get; set; }

        bool? ItemTypeIsNullable { get; set; }

        int? RangeVariableKind { get; set; }

        string RangeVariableName { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference RangeVariableTypeReference { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType RangeVariableTypeReferenceDefinition { get; set; }

        string RangeVariableTypeReferenceDefinitionTypeKind { get; set; }

        bool? RangeVariableTypeReferenceIsNullable { get; set; }

    }
}