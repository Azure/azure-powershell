namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmReferentialConstraint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmReferentialConstraint,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmReferentialConstraintInternal
    {

        /// <summary>Internal Acessors for PropertyPair</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmReferentialConstraintInternal.PropertyPair { get => this._propertyPair; set { {_propertyPair = value;} } }

        /// <summary>Backing field for <see cref="PropertyPair" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair[] _propertyPair;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair[] PropertyPair { get => this._propertyPair; }

        /// <summary>Creates an new <see cref="IedmReferentialConstraint" /> instance.</summary>
        public IedmReferentialConstraint()
        {

        }
    }
    public partial interface IIedmReferentialConstraint :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"propertyPairs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair[] PropertyPair { get;  }

    }
    internal partial interface IIedmReferentialConstraintInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IEdmReferentialConstraintPropertyPair[] PropertyPair { get; set; }

    }
}