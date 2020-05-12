namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Response containing operationId for a specific purge action.</summary>
    public partial class ComponentPurgeResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeResponse,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20150501.IComponentPurgeResponseInternal
    {

        /// <summary>Backing field for <see cref="OperationId" /> property.</summary>
        private string _operationId;

        /// <summary>Id to use when querying for status for a particular purge operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OperationId { get => this._operationId; set => this._operationId = value; }

        /// <summary>Creates an new <see cref="ComponentPurgeResponse" /> instance.</summary>
        public ComponentPurgeResponse()
        {

        }
    }
    /// Response containing operationId for a specific purge action.
    public partial interface IComponentPurgeResponse :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Id to use when querying for status for a particular purge operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Id to use when querying for status for a particular purge operation.",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string OperationId { get; set; }

    }
    /// Response containing operationId for a specific purge action.
    internal partial interface IComponentPurgeResponseInternal

    {
        /// <summary>Id to use when querying for status for a particular purge operation.</summary>
        string OperationId { get; set; }

    }
}