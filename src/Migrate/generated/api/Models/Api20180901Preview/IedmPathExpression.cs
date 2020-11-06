namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmPathExpression :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpression,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal
    {

        /// <summary>Backing field for <see cref="ExpressionKind" /> property.</summary>
        private string _expressionKind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ExpressionKind { get => this._expressionKind; }

        /// <summary>Internal Acessors for ExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal.ExpressionKind { get => this._expressionKind; set { {_expressionKind = value;} } }

        /// <summary>Internal Acessors for Path</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal.Path { get => this._path; set { {_path = value;} } }

        /// <summary>Internal Acessors for PathSegment</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmPathExpressionInternal.PathSegment { get => this._pathSegment; set { {_pathSegment = value;} } }

        /// <summary>Backing field for <see cref="Path" /> property.</summary>
        private string _path;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Path { get => this._path; }

        /// <summary>Backing field for <see cref="PathSegment" /> property.</summary>
        private string[] _pathSegment;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] PathSegment { get => this._pathSegment; }

        /// <summary>Creates an new <see cref="IedmPathExpression" /> instance.</summary>
        public IedmPathExpression()
        {

        }
    }
    public partial interface IIedmPathExpression :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"expressionKind",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressionKind { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"pathSegments",
        PossibleTypes = new [] { typeof(string) })]
        string[] PathSegment { get;  }

    }
    internal partial interface IIedmPathExpressionInternal

    {
        string ExpressionKind { get; set; }

        string Path { get; set; }

        string[] PathSegment { get; set; }

    }
}