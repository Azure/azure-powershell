namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A request to approve or reject a private endpoint connection</summary>
    public partial class PrivateLinkConnectionApprovalRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionApprovalRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionApprovalRequestInternal
    {

        /// <summary>Internal Acessors for PrivateLinkServiceConnectionState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionApprovalRequestInternal.PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkConnectionState()); set { {_privateLinkServiceConnectionState = value;} } }

        /// <summary>Backing field for <see cref="PrivateLinkServiceConnectionState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState _privateLinkServiceConnectionState;

        /// <summary>The state of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState PrivateLinkServiceConnectionState { get => (this._privateLinkServiceConnectionState = this._privateLinkServiceConnectionState ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PrivateLinkConnectionState()); set => this._privateLinkServiceConnectionState = value; }

        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateActionsRequired { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).ActionsRequired; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).ActionsRequired = value; }

        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Description = value; }

        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PrivateLinkServiceConnectionStateStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionStateInternal)PrivateLinkServiceConnectionState).Status = value; }

        /// <summary>Creates an new <see cref="PrivateLinkConnectionApprovalRequest" /> instance.</summary>
        public PrivateLinkConnectionApprovalRequest()
        {

        }
    }
    /// A request to approve or reject a private endpoint connection
    public partial interface IPrivateLinkConnectionApprovalRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>ActionsRequired for a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ActionsRequired for a private link connection",
        SerializedName = @"actionsRequired",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of a private link connection",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of a private link connection",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateLinkServiceConnectionStateStatus { get; set; }

    }
    /// A request to approve or reject a private endpoint connection
    internal partial interface IPrivateLinkConnectionApprovalRequestInternal

    {
        /// <summary>The state of a private link connection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkConnectionState PrivateLinkServiceConnectionState { get; set; }
        /// <summary>ActionsRequired for a private link connection</summary>
        string PrivateLinkServiceConnectionStateActionsRequired { get; set; }
        /// <summary>Description of a private link connection</summary>
        string PrivateLinkServiceConnectionStateDescription { get; set; }
        /// <summary>Status of a private link connection</summary>
        string PrivateLinkServiceConnectionStateStatus { get; set; }

    }
}