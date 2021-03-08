namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines reference to NSG.</summary>
    public partial class NsgReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgReference,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.INsgReferenceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference __azureResourceReference = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.AzureResourceReference();

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string SourceArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)__azureResourceReference).SourceArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)__azureResourceReference).SourceArmResourceId = value ; }

        /// <summary>Creates an new <see cref="NsgReference" /> instance.</summary>
        public NsgReference()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__azureResourceReference), __azureResourceReference);
            await eventListener.AssertObjectIsValid(nameof(__azureResourceReference), __azureResourceReference);
        }
    }
    /// Defines reference to NSG.
    public partial interface INsgReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReference
    {

    }
    /// Defines reference to NSG.
    internal partial interface INsgReferenceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal
    {

    }
}