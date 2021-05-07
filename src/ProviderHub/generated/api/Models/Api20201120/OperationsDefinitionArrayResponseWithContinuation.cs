namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class OperationsDefinitionArrayResponseWithContinuation :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinitionArrayResponseWithContinuation,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinitionArrayResponseWithContinuationInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get to the next set of results, if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Value { get => this._value; set => this._value = value; }

        /// <summary>
        /// Creates an new <see cref="OperationsDefinitionArrayResponseWithContinuation" /> instance.
        /// </summary>
        public OperationsDefinitionArrayResponseWithContinuation()
        {

        }
    }
    public partial interface IOperationsDefinitionArrayResponseWithContinuation :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get to the next set of results, if there are any.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get to the next set of results, if there are any.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Value { get; set; }

    }
    internal partial interface IOperationsDefinitionArrayResponseWithContinuationInternal

    {
        /// <summary>The URL to get to the next set of results, if there are any.</summary>
        string NextLink { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IOperationsDefinition[] Value { get; set; }

    }
}