namespace Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Extensions;

    /// <summary>Result of GET request to list Confluent operations.</summary>
    public partial class OperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult[] _value;

        /// <summary>List of Confluent operations supported by the Microsoft.Confluent provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Origin(Microsoft.Azure.PowerShell.Cmdlets.Confluent.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="OperationListResult" /> instance.</summary>
        public OperationListResult()
        {

        }
    }
    /// Result of GET request to list Confluent operations.
    public partial interface IOperationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"URL to get the next set of operation list results if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>List of Confluent operations supported by the Microsoft.Confluent provider.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Confluent.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of Confluent operations supported by the Microsoft.Confluent provider.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult[] Value { get; set; }

    }
    /// Result of GET request to list Confluent operations.
    internal partial interface IOperationListResultInternal

    {
        /// <summary>URL to get the next set of operation list results if there are any.</summary>
        string NextLink { get; set; }
        /// <summary>List of Confluent operations supported by the Microsoft.Confluent provider.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.Api20200301.IOperationResult[] Value { get; set; }

    }
}