namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Extensions;

    /// <summary>
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    /// </summary>
    public partial class HealthBotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BotManagementPortalLink" /> property.</summary>
        private string _botManagementPortalLink;

        /// <summary>The link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public string BotManagementPortalLink { get => this._botManagementPortalLink; }

        /// <summary>Internal Acessors for BotManagementPortalLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal.BotManagementPortalLink { get => this._botManagementPortalLink; set { {_botManagementPortalLink = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IHealthBotPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the Healthbot resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="HealthBotProperties" /> instance.</summary>
        public HealthBotProperties()
        {

        }
    }
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    public partial interface IHealthBotProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IJsonSerializable
    {
        /// <summary>The link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The link.",
        SerializedName = @"botManagementPortalLink",
        PossibleTypes = new [] { typeof(string) })]
        string BotManagementPortalLink { get;  }
        /// <summary>The provisioning state of the Healthbot resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the Healthbot resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// The properties of a HealthBot. The Health Bot Service is a cloud platform that empowers developers in Healthcare organizations
    /// to build and deploy their compliant, AI-powered virtual health assistants and health bots, that help them improve processes
    /// and reduce costs.
    internal partial interface IHealthBotPropertiesInternal

    {
        /// <summary>The link.</summary>
        string BotManagementPortalLink { get; set; }
        /// <summary>The provisioning state of the Healthbot resource.</summary>
        string ProvisioningState { get; set; }

    }
}