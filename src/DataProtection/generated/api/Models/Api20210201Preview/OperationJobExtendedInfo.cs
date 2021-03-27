namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Operation Job Extended Info</summary>
    public partial class OperationJobExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationJobExtendedInfo,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationJobExtendedInfoInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfo"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfo __operationExtendedInfo = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.OperationExtendedInfo();

        /// <summary>Backing field for <see cref="JobId" /> property.</summary>
        private string _jobId;

        /// <summary>Arm Id of the job created for this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string JobId { get => this._jobId; set => this._jobId = value; }

        /// <summary>
        /// This property will be used as the discriminator for deciding the specific types in the polymorphic chain of types.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfoInternal)__operationExtendedInfo).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfoInternal)__operationExtendedInfo).ObjectType = value ?? null; }

        /// <summary>Creates an new <see cref="OperationJobExtendedInfo" /> instance.</summary>
        public OperationJobExtendedInfo()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__operationExtendedInfo), __operationExtendedInfo);
            await eventListener.AssertObjectIsValid(nameof(__operationExtendedInfo), __operationExtendedInfo);
        }
    }
    /// Operation Job Extended Info
    public partial interface IOperationJobExtendedInfo :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfo
    {
        /// <summary>Arm Id of the job created for this operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Arm Id of the job created for this operation.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get; set; }

    }
    /// Operation Job Extended Info
    internal partial interface IOperationJobExtendedInfoInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IOperationExtendedInfoInternal
    {
        /// <summary>Arm Id of the job created for this operation.</summary>
        string JobId { get; set; }

    }
}