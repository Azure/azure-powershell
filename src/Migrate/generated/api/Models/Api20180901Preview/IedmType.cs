namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmType :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal
    {

        /// <summary>Internal Acessors for TypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal.TypeKind { get => this._typeKind; set { {_typeKind = value;} } }

        /// <summary>Backing field for <see cref="TypeKind" /> property.</summary>
        private string _typeKind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TypeKind { get => this._typeKind; }

        /// <summary>Creates an new <see cref="IedmType" /> instance.</summary>
        public IedmType()
        {

        }
    }
    public partial interface IIedmType :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string TypeKind { get;  }

    }
    internal partial interface IIedmTypeInternal

    {
        string TypeKind { get; set; }

    }
}