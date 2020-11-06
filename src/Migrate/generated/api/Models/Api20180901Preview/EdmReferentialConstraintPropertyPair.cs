namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class EdmReferentialConstraintPropertyPair :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal
    {

        /// <summary>Backing field for <see cref="DependentProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty _dependentProperty;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty DependentProperty { get => (this._dependentProperty = this._dependentProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralProperty()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DependentPropertyDeclaringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DeclaringType; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DependentPropertyDefaultValueString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefaultValueString; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DependentPropertyKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).PropertyKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DependentPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DependentPropertyTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? DependentPropertyTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).TypeIsNullable; }

        /// <summary>Internal Acessors for DependentProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentProperty { get => (this._dependentProperty = this._dependentProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralProperty()); set { {_dependentProperty = value;} } }

        /// <summary>Internal Acessors for DependentPropertyDeclaringType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyDeclaringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DeclaringType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DeclaringType = value; }

        /// <summary>Internal Acessors for DependentPropertyDefaultValueString</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyDefaultValueString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefaultValueString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefaultValueString = value; }

        /// <summary>Internal Acessors for DependentPropertyKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).PropertyKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).PropertyKind = value; }

        /// <summary>Internal Acessors for DependentPropertyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).Name = value; }

        /// <summary>Internal Acessors for DependentPropertyType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).Type = value; }

        /// <summary>Internal Acessors for DependentPropertyTypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyTypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).TypeDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).TypeDefinition = value; }

        /// <summary>Internal Acessors for DependentPropertyTypeDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).DefinitionTypeKind = value; }

        /// <summary>Internal Acessors for DependentPropertyTypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.DependentPropertyTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).TypeIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)DependentProperty).TypeIsNullable = value; }

        /// <summary>Internal Acessors for PrincipalProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalProperty { get => (this._principalProperty = this._principalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralProperty()); set { {_principalProperty = value;} } }

        /// <summary>Internal Acessors for PrincipalPropertyDeclaringType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyDeclaringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DeclaringType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DeclaringType = value; }

        /// <summary>Internal Acessors for PrincipalPropertyDefaultValueString</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyDefaultValueString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefaultValueString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefaultValueString = value; }

        /// <summary>Internal Acessors for PrincipalPropertyKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).PropertyKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).PropertyKind = value; }

        /// <summary>Internal Acessors for PrincipalPropertyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).Name = value; }

        /// <summary>Internal Acessors for PrincipalPropertyType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).Type = value; }

        /// <summary>Internal Acessors for PrincipalPropertyTypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyTypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).TypeDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).TypeDefinition = value; }

        /// <summary>Internal Acessors for PrincipalPropertyTypeDefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefinitionTypeKind = value; }

        /// <summary>Internal Acessors for PrincipalPropertyTypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPairInternal.PrincipalPropertyTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).TypeIsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).TypeIsNullable = value; }

        /// <summary>Backing field for <see cref="PrincipalProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty _principalProperty;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty PrincipalProperty { get => (this._principalProperty = this._principalProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuralProperty()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType PrincipalPropertyDeclaringType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DeclaringType; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrincipalPropertyDefaultValueString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefaultValueString; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrincipalPropertyKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).PropertyKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrincipalPropertyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).Name; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PrincipalPropertyTypeDefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).DefinitionTypeKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? PrincipalPropertyTypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralPropertyInternal)PrincipalProperty).TypeIsNullable; }

        /// <summary>Creates an new <see cref="EdmReferentialConstraintPropertyPair" /> instance.</summary>
        public EdmReferentialConstraintPropertyPair()
        {

        }
    }
    public partial interface IEdmReferentialConstraintPropertyPair :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"declaringType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DependentPropertyDeclaringType { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"defaultValueString",
        PossibleTypes = new [] { typeof(string) })]
        string DependentPropertyDefaultValueString { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"propertyKind",
        PossibleTypes = new [] { typeof(string) })]
        string DependentPropertyKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string DependentPropertyName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string DependentPropertyTypeDefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DependentPropertyTypeIsNullable { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"declaringType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType PrincipalPropertyDeclaringType { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"defaultValueString",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalPropertyDefaultValueString { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"propertyKind",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalPropertyKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalPropertyName { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalPropertyTypeDefinitionTypeKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? PrincipalPropertyTypeIsNullable { get;  }

    }
    internal partial interface IEdmReferentialConstraintPropertyPairInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty DependentProperty { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DependentPropertyDeclaringType { get; set; }

        string DependentPropertyDefaultValueString { get; set; }

        string DependentPropertyKind { get; set; }

        string DependentPropertyName { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference DependentPropertyType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType DependentPropertyTypeDefinition { get; set; }

        string DependentPropertyTypeDefinitionTypeKind { get; set; }

        bool? DependentPropertyTypeIsNullable { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuralProperty PrincipalProperty { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType PrincipalPropertyDeclaringType { get; set; }

        string PrincipalPropertyDefaultValueString { get; set; }

        string PrincipalPropertyKind { get; set; }

        string PrincipalPropertyName { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference PrincipalPropertyType { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType PrincipalPropertyTypeDefinition { get; set; }

        string PrincipalPropertyTypeDefinitionTypeKind { get; set; }

        bool? PrincipalPropertyTypeIsNullable { get; set; }

    }
}