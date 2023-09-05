namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The observed state of virtual networks</summary>
    public partial class VirtualNetworkStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatus,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusInternal
    {

        /// <summary>Backing field for <see cref="ErrorCode" /> property.</summary>
        private string _errorCode;

        /// <summary>VirtualNetwork provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ErrorCode { get => this._errorCode; set => this._errorCode = value; }

        /// <summary>Backing field for <see cref="ErrorMessage" /> property.</summary>
        private string _errorMessage;

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ErrorMessage { get => this._errorMessage; set => this._errorMessage = value; }

        /// <summary>Internal Acessors for ProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusInternal.ProvisioningStatus { get => (this._provisioningStatus = this._provisioningStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualNetworkStatusProvisioningStatus()); set { {_provisioningStatus = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatus _provisioningStatus;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatus ProvisioningStatus { get => (this._provisioningStatus = this._provisioningStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.VirtualNetworkStatusProvisioningStatus()); set => this._provisioningStatus = value; }

        /// <summary>The ID of the operation performed on the virtual network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatusInternal)ProvisioningStatus).OperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatusInternal)ProvisioningStatus).OperationId = value ?? null; }

        /// <summary>
        /// The status of the operation performed on the virtual network [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatusInternal)ProvisioningStatus).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatusInternal)ProvisioningStatus).Status = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>Creates an new <see cref="VirtualNetworkStatus" /> instance.</summary>
        public VirtualNetworkStatus()
        {

        }
    }
    /// The observed state of virtual networks
    public partial interface IVirtualNetworkStatus :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>VirtualNetwork provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VirtualNetwork provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string ErrorMessage { get; set; }
        /// <summary>The ID of the operation performed on the virtual network</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the virtual network",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>
        /// The status of the operation performed on the virtual network [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the virtual network [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get; set; }

    }
    /// The observed state of virtual networks
    internal partial interface IVirtualNetworkStatusInternal

    {
        /// <summary>VirtualNetwork provisioning error code</summary>
        string ErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string ErrorMessage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualNetworkStatusProvisioningStatus ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the virtual network</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>
        /// The status of the operation performed on the virtual network [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatusStatus { get; set; }

    }
}