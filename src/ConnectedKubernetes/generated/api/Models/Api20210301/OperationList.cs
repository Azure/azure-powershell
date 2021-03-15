namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Extensions;

    /// <summary>The paginated list of connected cluster API operations.</summary>
    public partial class OperationList :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperationList,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperationListInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation[] Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperationListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link to fetch the next page of connected cluster API operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation[] _value;

        /// <summary>The list of connected cluster API operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="OperationList" /> instance.</summary>
        public OperationList()
        {

        }
    }
    /// The paginated list of connected cluster API operations.
    public partial interface IOperationList :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.IJsonSerializable
    {
        /// <summary>The link to fetch the next page of connected cluster API operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link to fetch the next page of connected cluster API operations.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of connected cluster API operations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of connected cluster API operations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation) })]
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation[] Value { get;  }

    }
    /// The paginated list of connected cluster API operations.
    internal partial interface IOperationListInternal

    {
        /// <summary>The link to fetch the next page of connected cluster API operations.</summary>
        string NextLink { get; set; }
        /// <summary>The list of connected cluster API operations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20210301.IOperation[] Value { get; set; }

    }
}