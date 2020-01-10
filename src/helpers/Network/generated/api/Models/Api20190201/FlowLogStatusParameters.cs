namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// Parameters that define a resource to query flow log and traffic analytics (optional) status.
    /// </summary>
    public partial class FlowLogStatusParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogStatusParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogStatusParametersInternal
    {

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>
        /// The target resource where getting the flow log and traffic analytics (optional) status.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="FlowLogStatusParameters" /> instance.</summary>
        public FlowLogStatusParameters()
        {

        }
    }
    /// Parameters that define a resource to query flow log and traffic analytics (optional) status.
    public partial interface IFlowLogStatusParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The target resource where getting the flow log and traffic analytics (optional) status.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The target resource where getting the flow log and traffic analytics (optional) status.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define a resource to query flow log and traffic analytics (optional) status.
    internal partial interface IFlowLogStatusParametersInternal

    {
        /// <summary>
        /// The target resource where getting the flow log and traffic analytics (optional) status.
        /// </summary>
        string TargetResourceId { get; set; }

    }
}