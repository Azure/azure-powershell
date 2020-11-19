namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>AppsAndRoles in the guest virtual machine.</summary>
    public partial class AppsAndRoles :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRoles,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal
    {

        /// <summary>Backing field for <see cref="Application" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] _application;

        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Application { get => this._application; }

        /// <summary>Backing field for <see cref="BizTalkServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] _bizTalkServer;

        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] BizTalkServer { get => this._bizTalkServer; }

        /// <summary>Backing field for <see cref="ExchangeServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] _exchangeServer;

        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] ExchangeServer { get => this._exchangeServer; }

        /// <summary>Backing field for <see cref="Feature" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] _feature;

        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Feature { get => this._feature; }

        /// <summary>Internal Acessors for Application</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.Application { get => this._application; set { {_application = value;} } }

        /// <summary>Internal Acessors for BizTalkServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.BizTalkServer { get => this._bizTalkServer; set { {_bizTalkServer = value;} } }

        /// <summary>Internal Acessors for ExchangeServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.ExchangeServer { get => this._exchangeServer; set { {_exchangeServer = value;} } }

        /// <summary>Internal Acessors for Feature</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.Feature { get => this._feature; set { {_feature = value;} } }

        /// <summary>Internal Acessors for OtherDatabase</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.OtherDatabase { get => this._otherDatabase; set { {_otherDatabase = value;} } }

        /// <summary>Internal Acessors for SharePointServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.SharePointServer { get => this._sharePointServer; set { {_sharePointServer = value;} } }

        /// <summary>Internal Acessors for SqlServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.SqlServer { get => this._sqlServer; set { {_sqlServer = value;} } }

        /// <summary>Internal Acessors for SystemCenter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.SystemCenter { get => this._systemCenter; set { {_systemCenter = value;} } }

        /// <summary>Internal Acessors for WebApplication</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IAppsAndRolesInternal.WebApplication { get => this._webApplication; set { {_webApplication = value;} } }

        /// <summary>Backing field for <see cref="OtherDatabase" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] _otherDatabase;

        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] OtherDatabase { get => this._otherDatabase; }

        /// <summary>Backing field for <see cref="SharePointServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] _sharePointServer;

        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] SharePointServer { get => this._sharePointServer; }

        /// <summary>Backing field for <see cref="SqlServer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] _sqlServer;

        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] SqlServer { get => this._sqlServer; }

        /// <summary>Backing field for <see cref="SystemCenter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] _systemCenter;

        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] SystemCenter { get => this._systemCenter; }

        /// <summary>Backing field for <see cref="WebApplication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] _webApplication;

        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] WebApplication { get => this._webApplication; }

        /// <summary>Creates an new <see cref="AppsAndRoles" /> instance.</summary>
        public AppsAndRoles()
        {

        }
    }
    /// AppsAndRoles in the guest virtual machine.
    public partial interface IAppsAndRoles :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Applications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Applications of the AppsAndRoles.",
        SerializedName = @"applications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Application { get;  }
        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"BizTalkServers of the AppsAndRoles.",
        SerializedName = @"bizTalkServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] BizTalkServer { get;  }
        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ExchangeServers of the AppsAndRoles.",
        SerializedName = @"exchangeServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] ExchangeServer { get;  }
        /// <summary>Features of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Features of the AppsAndRoles.",
        SerializedName = @"features",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Feature { get;  }
        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"OtherDatabaseServers of the AppsAndRoles.",
        SerializedName = @"otherDatabases",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] OtherDatabase { get;  }
        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SharePointServers of the AppsAndRoles.",
        SerializedName = @"sharePointServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] SharePointServer { get;  }
        /// <summary>SQLServers of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SQLServers of the AppsAndRoles.",
        SerializedName = @"sqlServers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] SqlServer { get;  }
        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SystemCenters of the AppsAndRoles.",
        SerializedName = @"systemCenters",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] SystemCenter { get;  }
        /// <summary>WebApplications of the AppsAndRoles.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"WebApplications of the AppsAndRoles.",
        SerializedName = @"webApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] WebApplication { get;  }

    }
    /// AppsAndRoles in the guest virtual machine.
    internal partial interface IAppsAndRolesInternal

    {
        /// <summary>Applications of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IApplication[] Application { get; set; }
        /// <summary>BizTalkServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IBizTalkServer[] BizTalkServer { get; set; }
        /// <summary>ExchangeServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IExchangeServer[] ExchangeServer { get; set; }
        /// <summary>Features of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IFeature[] Feature { get; set; }
        /// <summary>OtherDatabaseServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOtherDatabase[] OtherDatabase { get; set; }
        /// <summary>SharePointServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISharePointServer[] SharePointServer { get; set; }
        /// <summary>SQLServers of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISqlServer[] SqlServer { get; set; }
        /// <summary>SystemCenters of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ISystemCenter[] SystemCenter { get; set; }
        /// <summary>WebApplications of the AppsAndRoles.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication[] WebApplication { get; set; }

    }
}