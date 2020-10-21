namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmSchemaElement :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmSchemaElement,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmSchemaElementInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmSchemaElementInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Namespace</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmSchemaElementInternal.Namespace { get => this._namespace; set { {_namespace = value;} } }

        /// <summary>Internal Acessors for SchemaElementKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmSchemaElementInternal.SchemaElementKind { get => this._schemaElementKind; set { {_schemaElementKind = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Namespace" /> property.</summary>
        private string _namespace;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Namespace { get => this._namespace; }

        /// <summary>Backing field for <see cref="SchemaElementKind" /> property.</summary>
        private string _schemaElementKind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SchemaElementKind { get => this._schemaElementKind; }

        /// <summary>Creates an new <see cref="IedmSchemaElement" /> instance.</summary>
        public IedmSchemaElement()
        {

        }
    }
    public partial interface IIedmSchemaElement :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
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
        SerializedName = @"namespace",
        PossibleTypes = new [] { typeof(string) })]
        string Namespace { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"schemaElementKind",
        PossibleTypes = new [] { typeof(string) })]
        string SchemaElementKind { get;  }

    }
    internal partial interface IIedmSchemaElementInternal

    {
        string Name { get; set; }

        string Namespace { get; set; }

        string SchemaElementKind { get; set; }

    }
}