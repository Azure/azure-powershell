namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The list of bot service operation response.</summary>
    public partial class EnterpriseChannelResponseList :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelResponseList,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelResponseListInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel[] Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelResponseListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The link used to get the next page of bot service resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel[] _value;

        /// <summary>The list of Enterprise Channels and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="EnterpriseChannelResponseList" /> instance.</summary>
        public EnterpriseChannelResponseList()
        {

        }
    }
    /// The list of bot service operation response.
    public partial interface IEnterpriseChannelResponseList :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The link used to get the next page of bot service resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The link used to get the next page of bot service resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of Enterprise Channels and their properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The list of Enterprise Channels and their properties.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel[] Value { get;  }

    }
    /// The list of bot service operation response.
    internal partial interface IEnterpriseChannelResponseListInternal

    {
        /// <summary>The link used to get the next page of bot service resources.</summary>
        string NextLink { get; set; }
        /// <summary>The list of Enterprise Channels and their properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannel[] Value { get; set; }

    }
}