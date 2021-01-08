namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    /// </summary>
    public partial class EnterpriseChannelCheckNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelCheckNameAvailabilityRequest,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IEnterpriseChannelCheckNameAvailabilityRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the Enterprise Channel for which availability needs to be checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// Creates an new <see cref="EnterpriseChannelCheckNameAvailabilityRequest" /> instance.
        /// </summary>
        public EnterpriseChannelCheckNameAvailabilityRequest()
        {

        }
    }
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    public partial interface IEnterpriseChannelCheckNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The name of the Enterprise Channel for which availability needs to be checked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Enterprise Channel for which availability needs to be checked.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// A request to Bot Service Management to check availability of an Enterprise Channel name.
    internal partial interface IEnterpriseChannelCheckNameAvailabilityRequestInternal

    {
        /// <summary>The name of the Enterprise Channel for which availability needs to be checked.</summary>
        string Name { get; set; }

    }
}