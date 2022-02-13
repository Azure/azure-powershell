namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Direct Line channel.</summary>
    public partial class DirectLineChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Site" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] _site;

        /// <summary>The list of Direct Line sites</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] Site { get => this._site; set => this._site = value; }

        /// <summary>Creates an new <see cref="DirectLineChannelProperties" /> instance.</summary>
        public DirectLineChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Direct Line channel.
    public partial interface IDirectLineChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
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
    /// The parameters to provide for the Direct Line channel.
    internal partial interface IDirectLineChannelPropertiesInternal

    {
        /// <summary>The list of Direct Line sites</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IDirectLineSite[] Site { get; set; }

    }
}