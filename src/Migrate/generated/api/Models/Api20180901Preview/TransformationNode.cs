namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class TransformationNode :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNode,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNodeInternal
    {

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; }

        /// <summary>Internal Acessors for Kind</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ITransformationNodeInternal.Kind { get => this._kind; set { {_kind = value;} } }

        /// <summary>Creates an new <see cref="TransformationNode" /> instance.</summary>
        public TransformationNode()
        {

        }
    }
    public partial interface ITransformationNode :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get;  }

    }
    internal partial interface ITransformationNodeInternal

    {
        string Kind { get; set; }

    }
}