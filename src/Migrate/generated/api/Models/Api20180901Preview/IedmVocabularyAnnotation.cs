namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmVocabularyAnnotation :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotation,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal
    {

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefinitionTypeKind; }

        /// <summary>Internal Acessors for DefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefinitionTypeKind = value; }

        /// <summary>Internal Acessors for Qualifier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.Qualifier { get => this._qualifier; set { {_qualifier = value;} } }

        /// <summary>Internal Acessors for Target</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.Target { get => (this._target = this._target ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Any()); set { {_target = value;} } }

        /// <summary>Internal Acessors for Term</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTerm Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.Term { get => (this._term = this._term ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTerm()); set { {_term = value;} } }

        /// <summary>Internal Acessors for TermAppliesTo</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermAppliesTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).AppliesTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).AppliesTo = value; }

        /// <summary>Internal Acessors for TermDefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermDefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefaultValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefaultValue = value; }

        /// <summary>Internal Acessors for TermName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Name = value; }

        /// <summary>Internal Acessors for TermNamespace</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Namespace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Namespace = value; }

        /// <summary>Internal Acessors for TermSchemaElementKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermSchemaElementKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).SchemaElementKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).SchemaElementKind = value; }

        /// <summary>Internal Acessors for TermType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TermType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Type = value; }

        /// <summary>Internal Acessors for TypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).TypeDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).TypeDefinition = value; }

        /// <summary>Internal Acessors for TypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.TypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).TypeIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).TypeIsNullable = value; }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpression Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmExpression()); set { {_value = value;} } }

        /// <summary>Internal Acessors for ValueExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmVocabularyAnnotationInternal.ValueExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpressionInternal)Value).ExpressionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpressionInternal)Value).ExpressionKind = value; }

        /// <summary>Backing field for <see cref="Qualifier" /> property.</summary>
        private string _qualifier;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Qualifier { get => this._qualifier; }

        /// <summary>Backing field for <see cref="Target" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny _target;

        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Target { get => (this._target = this._target ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Any()); }

        /// <summary>Backing field for <see cref="Term" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTerm _term;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTerm Term { get => (this._term = this._term ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTerm()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TermAppliesTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).AppliesTo; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TermDefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).DefaultValue; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TermName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TermNamespace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).Namespace; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TermSchemaElementKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).SchemaElementKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? TypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTermInternal)Term).TypeIsNullable; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpression _value;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpression Value { get => (this._value = this._value ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmExpression()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ValueExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpressionInternal)Value).ExpressionKind; }

        /// <summary>Creates an new <see cref="IedmVocabularyAnnotation" /> instance.</summary>
        public IedmVocabularyAnnotation()
        {

        }
    }
    public partial interface IIedmVocabularyAnnotation :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string DefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"qualifier",
        PossibleTypes = new [] { typeof(string) })]
        string Qualifier { get;  }
        /// <summary>Any object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Any object",
        SerializedName = @"target",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Target { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"appliesTo",
        PossibleTypes = new [] { typeof(string) })]
        string TermAppliesTo { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"defaultValue",
        PossibleTypes = new [] { typeof(string) })]
        string TermDefaultValue { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string TermName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"namespace",
        PossibleTypes = new [] { typeof(string) })]
        string TermNamespace { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"schemaElementKind",
        PossibleTypes = new [] { typeof(string) })]
        string TermSchemaElementKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TypeIsNullable { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"expressionKind",
        PossibleTypes = new [] { typeof(string) })]
        string ValueExpressionKind { get;  }

    }
    internal partial interface IIedmVocabularyAnnotationInternal

    {
        string DefinitionTypeKind { get; set; }

        string Qualifier { get; set; }
        /// <summary>Any object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny Target { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTerm Term { get; set; }

        string TermAppliesTo { get; set; }

        string TermDefaultValue { get; set; }

        string TermName { get; set; }

        string TermNamespace { get; set; }

        string TermSchemaElementKind { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference TermType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType TypeDefinition { get; set; }

        bool? TypeIsNullable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpression Value { get; set; }

        string ValueExpressionKind { get; set; }

    }
}