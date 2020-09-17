namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Display properties</summary>
    public partial class OperationValueDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplayInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1 __operationValueDisplay1 = new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.OperationValueDisplay1();

        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Description = value; }

        /// <summary>Internal Acessors for Operation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal.Operation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Operation = value; }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal.Provider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Provider = value; }

        /// <summary>Internal Acessors for Resource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal.Resource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Resource = value; }

        /// <summary>The display name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Operation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Operation; }

        /// <summary>The resource provider for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Provider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Provider; }

        /// <summary>The display name of the resource the operation applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inherited)]
        public string Resource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal)__operationValueDisplay1).Resource; }

        /// <summary>Creates an new <see cref="OperationValueDisplay" /> instance.</summary>
        public OperationValueDisplay()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__operationValueDisplay1), __operationValueDisplay1);
            await eventListener.AssertObjectIsValid(nameof(__operationValueDisplay1), __operationValueDisplay1);
        }
    }
    /// Display properties
    public partial interface IOperationValueDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1
    {

    }
    /// Display properties
    internal partial interface IOperationValueDisplayInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IOperationValueDisplay1Internal
    {

    }
}