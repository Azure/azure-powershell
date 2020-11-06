namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class IedmExpression :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpression,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpressionInternal
    {

        /// <summary>Backing field for <see cref="ExpressionKind" /> property.</summary>
        private string _expressionKind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ExpressionKind { get => this._expressionKind; }

        /// <summary>Internal Acessors for ExpressionKind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IIedmExpressionInternal.ExpressionKind { get => this._expressionKind; set { {_expressionKind = value;} } }

        /// <summary>Creates an new <see cref="IedmExpression" /> instance.</summary>
        public IedmExpression()
        {

        }
    }
    public partial interface IIedmExpression :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"expressionKind",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressionKind { get;  }

    }
    internal partial interface IIedmExpressionInternal

    {
        string ExpressionKind { get; set; }

    }
}