namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Service Provider Definition</summary>
    public partial class ServiceProvider :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProvider,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal
    {

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DevPortalUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DevPortalUrl; }

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DisplayName; }

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string IconUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).IconUrl; }

        /// <summary>Id for Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).Id; }

        /// <summary>Internal Acessors for DevPortalUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.DevPortalUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DevPortalUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DevPortalUrl = value; }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.DisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).DisplayName = value; }

        /// <summary>Internal Acessors for IconUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.IconUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).IconUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).IconUrl = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).ServiceProviderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).ServiceProviderName = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderProperties Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ServiceProviderProperties()); set { {_property = value;} } }

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).ServiceProviderName; }

        /// <summary>The list of parameters for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameter[] Parameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).Parameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderPropertiesInternal)Property).Parameter = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderProperties _property;

        /// <summary>The Properties of a Service Provider Object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.ServiceProviderProperties()); set => this._property = value; }

        /// <summary>Creates an new <see cref="ServiceProvider" /> instance.</summary>
        public ServiceProvider()
        {

        }
    }
    /// Service Provider Definition
    public partial interface IServiceProvider :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"devPortalUrl",
        PossibleTypes = new [] { typeof(string) })]
        string DevPortalUrl { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"iconUrl",
        PossibleTypes = new [] { typeof(string) })]
        string IconUrl { get;  }
        /// <summary>Id for Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Id for Service Provider",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"serviceProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The list of parameters for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of parameters for the Service Provider",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameter) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameter[] Parameter { get; set; }

    }
    /// Service Provider Definition
    internal partial interface IServiceProviderInternal

    {
        /// <summary>Display Name of the Service Provider</summary>
        string DevPortalUrl { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string DisplayName { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string IconUrl { get; set; }
        /// <summary>Id for Service Provider</summary>
        string Id { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string Name { get; set; }
        /// <summary>The list of parameters for the Service Provider</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameter[] Parameter { get; set; }
        /// <summary>The Properties of a Service Provider Object</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderProperties Property { get; set; }

    }
}