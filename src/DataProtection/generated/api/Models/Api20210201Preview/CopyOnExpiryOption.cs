namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Copy on Expiry Option</summary>
    public partial class CopyOnExpiryOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOnExpiryOption,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOnExpiryOptionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOption"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOption __copyOption = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.CopyOption();

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOptionInternal)__copyOption).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOptionInternal)__copyOption).ObjectType = value ; }

        /// <summary>Creates an new <see cref="CopyOnExpiryOption" /> instance.</summary>
        public CopyOnExpiryOption()
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
    /// Copy on Expiry Option
    public partial interface ICopyOnExpiryOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOption
    {

    }
    /// Copy on Expiry Option
    internal partial interface ICopyOnExpiryOptionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICopyOptionInternal
    {

    }
}