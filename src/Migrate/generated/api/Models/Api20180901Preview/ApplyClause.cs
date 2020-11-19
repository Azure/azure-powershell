namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class ApplyClause :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IApplyClause,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IApplyClauseInternal
    {

        /// <summary>Internal Acessors for Transformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IApplyClauseInternal.Transformation { get => this._transformation; set { {_transformation = value;} } }

        /// <summary>Backing field for <see cref="Transformation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode[] _transformation;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode[] Transformation { get => this._transformation; }

        /// <summary>Creates an new <see cref="ApplyClause" /> instance.</summary>
        public ApplyClause()
        {

        }
    }
    public partial interface IApplyClause :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"transformations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode[] Transformation { get;  }

    }
    internal partial interface IApplyClauseInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode[] Transformation { get; set; }

    }
}