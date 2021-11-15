namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Direct Line channel definition</summary>
    public partial class DirectLineChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelInternal,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel __channel = new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.Channel();

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineChannelProperties()); set { {_property = value;} } }

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal)__channel).Name = value ; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelProperties _property;

        /// <summary>The set of properties specific to Direct Line channel resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.DirectLineChannelProperties()); set => this._property = value; }

        /// <summary>The list of Direct Line sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] Site { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelPropertiesInternal)Property).Site; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelPropertiesInternal)Property).Site = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="DirectLineChannel" /> instance.</summary>
        public DirectLineChannel()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__channel), __channel);
            await eventListener.AssertObjectIsValid(nameof(__channel), __channel);
        }
    }
    /// Direct Line channel definition
    public partial interface IDirectLineChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel
    {
        /// <summary>The list of Direct Line sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of Direct Line sites",
        SerializedName = @"sites",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] Site { get; set; }

    }
    /// Direct Line channel definition
    internal partial interface IDirectLineChannelInternal :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {
        /// <summary>The set of properties specific to Direct Line channel resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelProperties Property { get; set; }
        /// <summary>The list of Direct Line sites</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] Site { get; set; }

    }
}