namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Azure Firewall FQDN Tag Properties</summary>
    public partial class AzureFirewallFqdnTagPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallFqdnTagPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallFqdnTagPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="FqdnTagName" /> property.</summary>
        private string _fqdnTagName;

        /// <summary>The name of this FQDN Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string FqdnTagName { get => this._fqdnTagName; }

        /// <summary>Internal Acessors for FqdnTagName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallFqdnTagPropertiesFormatInternal.FqdnTagName { get => this._fqdnTagName; set { {_fqdnTagName = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallFqdnTagPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="AzureFirewallFqdnTagPropertiesFormat" /> instance.</summary>
        public AzureFirewallFqdnTagPropertiesFormat()
        {

        }
    }
    /// Azure Firewall FQDN Tag Properties
    public partial interface IAzureFirewallFqdnTagPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The name of this FQDN Tag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of this FQDN Tag.",
        SerializedName = @"fqdnTagName",
        PossibleTypes = new [] { typeof(string) })]
        string FqdnTagName { get;  }
        /// <summary>The provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }

    }
    /// Azure Firewall FQDN Tag Properties
    internal partial interface IAzureFirewallFqdnTagPropertiesFormatInternal

    {
        /// <summary>The name of this FQDN Tag.</summary>
        string FqdnTagName { get; set; }
        /// <summary>The provisioning state of the resource.</summary>
        string ProvisioningState { get; set; }

    }
}