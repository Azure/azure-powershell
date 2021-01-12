namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>
    /// The request body for a request to Bot Service Management to check availability of a bot name.
    /// </summary>
    public partial class CheckNameAvailabilityRequestBody :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ICheckNameAvailabilityRequestBody,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ICheckNameAvailabilityRequestBodyInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>the name of the bot for which availability needs to be checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>the type of the bot for which availability needs to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityRequestBody" /> instance.</summary>
        public CheckNameAvailabilityRequestBody()
        {

        }
    }
    /// The request body for a request to Bot Service Management to check availability of a bot name.
    public partial interface ICheckNameAvailabilityRequestBody :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>the name of the bot for which availability needs to be checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the name of the bot for which availability needs to be checked.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>the type of the bot for which availability needs to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the type of the bot for which availability needs to be checked",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// The request body for a request to Bot Service Management to check availability of a bot name.
    internal partial interface ICheckNameAvailabilityRequestBodyInternal

    {
        /// <summary>the name of the bot for which availability needs to be checked.</summary>
        string Name { get; set; }
        /// <summary>the type of the bot for which availability needs to be checked</summary>
        string Type { get; set; }

    }
}