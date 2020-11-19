namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmNavigationSource :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSource,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal
    {

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string IedmPathExpressionPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).Path; }

        /// <summary>Internal Acessors for IedmPathExpressionPath</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.IedmPathExpressionPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).Path = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for NavigationPropertyBinding</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.NavigationPropertyBinding { get => this._navigationPropertyBinding; set { {_navigationPropertyBinding = value;} } }

        /// <summary>Internal Acessors for Path</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.Path { get => (this._path = this._path ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpression()); set { {_path = value;} } }

        /// <summary>Internal Acessors for PathExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.PathExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).ExpressionKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).ExpressionKind = value; }

        /// <summary>Internal Acessors for PathSegment</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.PathSegment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).PathSegment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).PathSegment = value; }

        /// <summary>Internal Acessors for Type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.Type { get => (this._type = this._type ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmType()); set { {_type = value;} } }

        /// <summary>Internal Acessors for TypeKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationSourceInternal.TypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Type).TypeKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Type).TypeKind = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="NavigationPropertyBinding" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[] _navigationPropertyBinding;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[] NavigationPropertyBinding { get => this._navigationPropertyBinding; }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression _path;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression Path { get => (this._path = this._path ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmPathExpression()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string PathExpressionKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).ExpressionKind; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] PathSegment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal)Path).PathSegment; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType _type;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Type { get => (this._type = this._type ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IedmType()); }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string TypeKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmTypeInternal)Type).TypeKind; }

        /// <summary>Creates an new <see cref="IedmNavigationSource" /> instance.</summary>
        public IedmNavigationSource()
        {

        }
    }
    public partial interface IIedmNavigationSource :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string IedmPathExpressionPath { get;  }

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
        SerializedName = @"navigationPropertyBindings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[] NavigationPropertyBinding { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"expressionKind",
        PossibleTypes = new [] { typeof(string) })]
        string PathExpressionKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"pathSegments",
        PossibleTypes = new [] { typeof(string) })]
        string[] PathSegment { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"typeKind",
        PossibleTypes = new [] { typeof(string) })]
        string TypeKind { get;  }

    }
    internal partial interface IIedmNavigationSourceInternal

    {
        string IedmPathExpressionPath { get; set; }

        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmNavigationPropertyBinding[] NavigationPropertyBinding { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression Path { get; set; }

        string PathExpressionKind { get; set; }

        string[] PathSegment { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmType Type { get; set; }

        string TypeKind { get; set; }

    }
}