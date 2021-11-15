namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The parameters to provide for the Enterprise Channel.</summary>
    public partial class EnterpriseChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Node" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] _node;

        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get => this._node; set => this._node = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? _state;

        /// <summary>The current state of the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="EnterpriseChannelProperties" /> instance.</summary>
        public EnterpriseChannelProperties()
        {

        }
    }
    /// The parameters to provide for the Enterprise Channel.
    public partial interface IEnterpriseChannelProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The nodes associated with the Enterprise Channel.",
        SerializedName = @"nodes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get; set; }
        /// <summary>The current state of the Enterprise Channel.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The current state of the Enterprise Channel.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get; set; }

    }
    /// The parameters to provide for the Enterprise Channel.
    internal partial interface IEnterpriseChannelPropertiesInternal

    {
        /// <summary>The nodes associated with the Enterprise Channel.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelNode[] Node { get; set; }
        /// <summary>The current state of the Enterprise Channel.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Support.EnterpriseChannelState? State { get; set; }

    }
}