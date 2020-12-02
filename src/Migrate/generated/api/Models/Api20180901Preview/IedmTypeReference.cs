namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmTypeReference :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReference,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal
    {

        /// <summary>Backing field for <see cref="Definition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType _definition;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmType()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Definition).TypeKind; }

        /// <summary>Backing field for <see cref="IsNullable" /> property.</summary>
        private bool? _isNullable;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsNullable { get => this._isNullable; }

        /// <summary>Internal Acessors for Definition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal.Definition { get => (this._definition = this._definition ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmType()); set { {_definition = value;} } }

        /// <summary>Internal Acessors for DefinitionTypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal.DefinitionTypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Definition).TypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Definition).TypeKind = value; }

        /// <summary>Internal Acessors for IsNullable</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeReferenceInternal.IsNullable { get => this._isNullable; set { {_isNullable = value;} } }

        /// <summary>Creates an new <see cref="IedmTypeReference" /> instance.</summary>
        public IedmTypeReference()
        {

        }
    }
    public partial interface IIedmTypeReference :
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
        SerializedName = @"isNullable",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsNullable { get;  }

    }
    internal partial interface IIedmTypeReferenceInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Definition { get; set; }

        string DefinitionTypeKind { get; set; }

        bool? IsNullable { get; set; }

    }
}