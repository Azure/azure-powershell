namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Immediate copy Option</summary>
    public partial class ImmediateCopyOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IImmediateCopyOption,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IImmediateCopyOptionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption __copyOption = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.CopyOption();

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOptionInternal)__copyOption).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOptionInternal)__copyOption).ObjectType = value ; }

        /// <summary>Creates an new <see cref="ImmediateCopyOption" /> instance.</summary>
        public ImmediateCopyOption()
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
            await eventListener.AssertNotNull(nameof(__copyOption), __copyOption);
            await eventListener.AssertObjectIsValid(nameof(__copyOption), __copyOption);
        }
    }
    /// Immediate copy Option
    public partial interface IImmediateCopyOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOption
    {

    }
    /// Immediate copy Option
    internal partial interface IImmediateCopyOptionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ICopyOptionInternal
    {

    }
}