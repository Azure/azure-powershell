namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Channel definition</summary>
    public partial class Channel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannel,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IChannelInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Channel" /> instance.</summary>
        public Channel()
        {

        }
    }
    /// Channel definition
    public partial interface IChannel :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The channel name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The channel name",
        SerializedName = @"channelName",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Channel definition
    internal partial interface IChannelInternal

    {
        /// <summary>The channel name</summary>
        string Name { get; set; }

    }
}