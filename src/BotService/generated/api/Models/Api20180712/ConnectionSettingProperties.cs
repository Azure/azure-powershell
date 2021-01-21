namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Properties for a Connection Setting Item</summary>
    public partial class ConnectionSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>Client Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; set => this._clientId = value; }

        /// <summary>Backing field for <see cref="ClientSecret" /> property.</summary>
        private string _clientSecret;

        /// <summary>Client Secret associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ClientSecret { get => this._clientSecret; set => this._clientSecret = value; }

        /// <summary>Internal Acessors for SettingId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingPropertiesInternal.SettingId { get => this._settingId; set { {_settingId = value;} } }

        /// <summary>Backing field for <see cref="Parameter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter[] _parameter;

        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter[] Parameter { get => this._parameter; set => this._parameter = value; }

        /// <summary>Backing field for <see cref="Scope" /> property.</summary>
        private string _scope;

        /// <summary>Scopes associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Scope { get => this._scope; set => this._scope = value; }

        /// <summary>Backing field for <see cref="ServiceProviderDisplayName" /> property.</summary>
        private string _serviceProviderDisplayName;

        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ServiceProviderDisplayName { get => this._serviceProviderDisplayName; set => this._serviceProviderDisplayName = value; }

        /// <summary>Backing field for <see cref="ServiceProviderId" /> property.</summary>
        private string _serviceProviderId;

        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string ServiceProviderId { get => this._serviceProviderId; set => this._serviceProviderId = value; }

        /// <summary>Backing field for <see cref="SettingId" /> property.</summary>
        private string _settingId;

        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string SettingId { get => this._settingId; }

        /// <summary>Creates an new <see cref="ConnectionSettingProperties" /> instance.</summary>
        public ConnectionSettingProperties()
        {

        }
    }
    /// Properties for a Connection Setting Item
    public partial interface IConnectionSettingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Client Id associated with the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Client Id associated with the Connection Setting.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get; set; }
        /// <summary>Client Secret associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Client Secret associated with the Connection Setting",
        SerializedName = @"clientSecret",
        PossibleTypes = new [] { typeof(string) })]
        string ClientSecret { get; set; }
        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service Provider Parameters associated with the Connection Setting",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter[] Parameter { get; set; }
        /// <summary>Scopes associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Scopes associated with the Connection Setting",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(string) })]
        string Scope { get; set; }
        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service Provider Display Name associated with the Connection Setting",
        SerializedName = @"serviceProviderDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderDisplayName { get; set; }
        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service Provider Id associated with the Connection Setting",
        SerializedName = @"serviceProviderId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderId { get; set; }
        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Setting Id set by the service for the Connection Setting.",
        SerializedName = @"settingId",
        PossibleTypes = new [] { typeof(string) })]
        string SettingId { get;  }

    }
    /// Properties for a Connection Setting Item
    internal partial interface IConnectionSettingPropertiesInternal

    {
        /// <summary>Client Id associated with the Connection Setting.</summary>
        string ClientId { get; set; }
        /// <summary>Client Secret associated with the Connection Setting</summary>
        string ClientSecret { get; set; }
        /// <summary>Service Provider Parameters associated with the Connection Setting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IConnectionSettingParameter[] Parameter { get; set; }
        /// <summary>Scopes associated with the Connection Setting</summary>
        string Scope { get; set; }
        /// <summary>Service Provider Display Name associated with the Connection Setting</summary>
        string ServiceProviderDisplayName { get; set; }
        /// <summary>Service Provider Id associated with the Connection Setting</summary>
        string ServiceProviderId { get; set; }
        /// <summary>Setting Id set by the service for the Connection Setting.</summary>
        string SettingId { get; set; }

    }
}