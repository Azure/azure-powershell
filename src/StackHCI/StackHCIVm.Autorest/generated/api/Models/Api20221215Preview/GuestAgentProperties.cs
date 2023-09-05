namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>Defines the resource properties.</summary>
    public partial class GuestAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Credentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredential _credentials;

        /// <summary>Username / Password Credentials to provision guest agent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredential Credentials { get => (this._credentials = this._credentials ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GuestCredential()); set => this._credentials = value; }

        /// <summary>The password to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string CredentialsPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredentialInternal)Credentials).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredentialInternal)Credentials).Password = value ?? null; }

        /// <summary>The username to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string CredentialsUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredentialInternal)Credentials).Username; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredentialInternal)Credentials).Username = value ?? null; }

        /// <summary>Backing field for <see cref="HttpProxyConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfiguration _httpProxyConfig;

        /// <summary>HTTP Proxy configuration for the VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfiguration HttpProxyConfig { get => (this._httpProxyConfig = this._httpProxyConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HttpProxyConfiguration()); set => this._httpProxyConfig = value; }

        /// <summary>The httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string HttpProxyConfigHttpsProxy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfigurationInternal)HttpProxyConfig).HttpsProxy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfigurationInternal)HttpProxyConfig).HttpsProxy = value ?? null; }

        /// <summary>Internal Acessors for Credentials</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredential Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentPropertiesInternal.Credentials { get => (this._credentials = this._credentials ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.GuestCredential()); set { {_credentials = value;} } }

        /// <summary>Internal Acessors for HttpProxyConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfiguration Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentPropertiesInternal.HttpProxyConfig { get => (this._httpProxyConfig = this._httpProxyConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.HttpProxyConfiguration()); set { {_httpProxyConfig = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestAgentPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningAction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningAction? _provisioningAction;

        /// <summary>The guest agent provisioning action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningAction? ProvisioningAction { get => this._provisioningAction; set => this._provisioningAction = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>The guest agent status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="GuestAgentProperties" /> instance.</summary>
        public GuestAgentProperties()
        {

        }
    }
    /// Defines the resource properties.
    public partial interface IGuestAgentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>The password to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password to connect with the guest.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string CredentialsPassword { get; set; }
        /// <summary>The username to connect with the guest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The username to connect with the guest.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string CredentialsUsername { get; set; }
        /// <summary>The httpsProxy url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The httpsProxy url.",
        SerializedName = @"httpsProxy",
        PossibleTypes = new [] { typeof(string) })]
        string HttpProxyConfigHttpsProxy { get; set; }
        /// <summary>The guest agent provisioning action.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The guest agent provisioning action.",
        SerializedName = @"provisioningAction",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningAction) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningAction? ProvisioningAction { get; set; }
        /// <summary>The provisioning state.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The guest agent status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The guest agent status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }

    }
    /// Defines the resource properties.
    internal partial interface IGuestAgentPropertiesInternal

    {
        /// <summary>Username / Password Credentials to provision guest agent.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGuestCredential Credentials { get; set; }
        /// <summary>The password to connect with the guest.</summary>
        string CredentialsPassword { get; set; }
        /// <summary>The username to connect with the guest.</summary>
        string CredentialsUsername { get; set; }
        /// <summary>HTTP Proxy configuration for the VM.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IHttpProxyConfiguration HttpProxyConfig { get; set; }
        /// <summary>The httpsProxy url.</summary>
        string HttpProxyConfigHttpsProxy { get; set; }
        /// <summary>The guest agent provisioning action.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningAction? ProvisioningAction { get; set; }
        /// <summary>The provisioning state.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The guest agent status.</summary>
        string Status { get; set; }

    }
}