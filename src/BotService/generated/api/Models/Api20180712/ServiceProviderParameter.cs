namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>Extra Parameters specific to each Service Provider</summary>
    public partial class ServiceProviderParameter :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameter,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal
    {

        /// <summary>Backing field for <see cref="Default" /> property.</summary>
        private string _default;

        /// <summary>Default Name for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Default { get => this._default; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; }

        /// <summary>Backing field for <see cref="HelpUrl" /> property.</summary>
        private string _helpUrl;

        /// <summary>Help Url for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string HelpUrl { get => this._helpUrl; }

        /// <summary>Internal Acessors for Default</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.Default { get => this._default; set { {_default = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DisplayName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.DisplayName { get => this._displayName; set { {_displayName = value;} } }

        /// <summary>Internal Acessors for HelpUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.HelpUrl { get => this._helpUrl; set { {_helpUrl = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IServiceProviderParameterInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="ServiceProviderParameter" /> instance.</summary>
        public ServiceProviderParameter()
        {

        }
    }
    /// Extra Parameters specific to each Service Provider
    public partial interface IServiceProviderParameter :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>Default Name for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Default Name for the Service Provider",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(string) })]
        string Default { get;  }
        /// <summary>Description of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the Service Provider",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Display Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Display Name of the Service Provider",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get;  }
        /// <summary>Help Url for the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Help Url for the  Service Provider",
        SerializedName = @"helpUrl",
        PossibleTypes = new [] { typeof(string) })]
        string HelpUrl { get;  }
        /// <summary>Name of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the Service Provider",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Type of the Service Provider</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Type of the Service Provider",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// Extra Parameters specific to each Service Provider
    internal partial interface IServiceProviderParameterInternal

    {
        /// <summary>Default Name for the Service Provider</summary>
        string Default { get; set; }
        /// <summary>Description of the Service Provider</summary>
        string Description { get; set; }
        /// <summary>Display Name of the Service Provider</summary>
        string DisplayName { get; set; }
        /// <summary>Help Url for the Service Provider</summary>
        string HelpUrl { get; set; }
        /// <summary>Name of the Service Provider</summary>
        string Name { get; set; }
        /// <summary>Type of the Service Provider</summary>
        string Type { get; set; }

    }
}