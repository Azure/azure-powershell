namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Delete option with duration</summary>
    public partial class AbsoluteDeleteOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAbsoluteDeleteOption,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IAbsoluteDeleteOptionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOption"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOption __deleteOption = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DeleteOption();

        /// <summary>Duration of deletion after given timespan</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string Duration { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOptionInternal)__deleteOption).Duration; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOptionInternal)__deleteOption).Duration = value ; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOptionInternal)__deleteOption).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOptionInternal)__deleteOption).ObjectType = value ; }

        /// <summary>Creates an new <see cref="AbsoluteDeleteOption" /> instance.</summary>
        public AbsoluteDeleteOption()
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
            await eventListener.AssertNotNull(nameof(__deleteOption), __deleteOption);
            await eventListener.AssertObjectIsValid(nameof(__deleteOption), __deleteOption);
        }
    }
    /// Delete option with duration
    public partial interface IAbsoluteDeleteOption :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOption
    {

    }
    /// Delete option with duration
    internal partial interface IAbsoluteDeleteOptionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDeleteOptionInternal
    {

    }
}