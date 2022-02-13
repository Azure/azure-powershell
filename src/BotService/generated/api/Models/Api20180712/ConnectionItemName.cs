namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The display name of a connection Item Setting registered with the Bot</summary>
    public partial class ConnectionItemName :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionItemName,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionItemNameInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionItemNameInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Connection Item name that has been added in the API</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="ConnectionItemName" /> instance.</summary>
        public ConnectionItemName()
        {

        }
    }
    /// The display name of a connection Item Setting registered with the Bot
    public partial interface IConnectionItemName :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Connection Item name that has been added in the API</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Connection Item name that has been added in the API",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    /// The display name of a connection Item Setting registered with the Bot
    internal partial interface IConnectionItemNameInternal

    {
        /// <summary>Connection Item name that has been added in the API</summary>
        string Name { get; set; }

    }
}