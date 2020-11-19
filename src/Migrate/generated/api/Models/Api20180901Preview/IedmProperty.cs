namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmProperty,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal
    {

        /// <summary>Backing field for <see cref="DeclaringType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType _declaringType;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DeclaringType { get => (this._declaringType = this._declaringType ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredType()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).DefinitionTypeKind; }

        /// <summary>Internal Acessors for DeclaringType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.DeclaringType { get => (this._declaringType = this._declaringType ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmStructuredType()); set { {_declaringType = value;} } }

        /// <summary>Internal Acessors for DefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).DefinitionTypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).DefinitionTypeKind = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for PropertyKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.PropertyKind { get => this._propertyKind; set { {_propertyKind = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.Type { get => (this._type = this._type ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReference()); set { {_type = value;} } }

        /// <summary>Internal Acessors for TypeDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.TypeDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).Definition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).Definition = value; }

        /// <summary>Internal Acessors for TypeIsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPropertyInternal.TypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).IsNullable; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).IsNullable = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="PropertyKind" /> property.</summary>
        private string _propertyKind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string PropertyKind { get => this._propertyKind; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference _type;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Type { get => (this._type = this._type ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmTypeReference()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public bool? TypeIsNullable { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal)Type).IsNullable; }

        /// <summary>Creates an new <see cref="IedmProperty" /> instance.</summary>
        public IedmProperty()
        {

        }
    }
    public partial interface IIedmProperty :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"declaringType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DeclaringType { get;  }

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
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"propertyKind",
        PossibleTypes = new [] { typeof(string) })]
        string PropertyKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TypeIsNullable { get;  }

    }
    internal partial interface IIedmPropertyInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmStructuredType DeclaringType { get; set; }

        string DefinitionTypeKind { get; set; }

        string Name { get; set; }

        string PropertyKind { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference Type { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType TypeDefinition { get; set; }

        bool? TypeIsNullable { get; set; }

    }
}