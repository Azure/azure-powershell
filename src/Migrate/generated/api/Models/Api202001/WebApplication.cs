namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>WebApplication in the guest virtual machine.</summary>
    public partial class WebApplication :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplication,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal
    {

        /// <summary>Backing field for <see cref="ApplicationPool" /> property.</summary>
        private string _applicationPool;

        /// <summary>ApplicationPool of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ApplicationPool { get => this._applicationPool; }

        /// <summary>Backing field for <see cref="GroupName" /> property.</summary>
        private string _groupName;

        /// <summary>GroupName of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string GroupName { get => this._groupName; }

        /// <summary>Internal Acessors for ApplicationPool</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.ApplicationPool { get => this._applicationPool; set { {_applicationPool = value;} } }

        /// <summary>Internal Acessors for GroupName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.GroupName { get => this._groupName; set { {_groupName = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Platform</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.Platform { get => this._platform; set { {_platform = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Internal Acessors for WebServer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IWebApplicationInternal.WebServer { get => this._webServer; set { {_webServer = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Platform" /> property.</summary>
        private string _platform;

        /// <summary>Platform of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Platform { get => this._platform; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Backing field for <see cref="WebServer" /> property.</summary>
        private string _webServer;

        /// <summary>WebServer of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string WebServer { get => this._webServer; }

        /// <summary>Creates an new <see cref="WebApplication" /> instance.</summary>
        public WebApplication()
        {

        }
    }
    /// WebApplication in the guest virtual machine.
    public partial interface IWebApplication :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>ApplicationPool of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ApplicationPool of the WebApplication.",
        SerializedName = @"applicationPool",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationPool { get;  }
        /// <summary>GroupName of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"GroupName of the WebApplication.",
        SerializedName = @"groupName",
        PossibleTypes = new [] { typeof(string) })]
        string GroupName { get;  }
        /// <summary>Name of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the WebApplication.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Platform of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Platform of the WebApplication.",
        SerializedName = @"platform",
        PossibleTypes = new [] { typeof(string) })]
        string Platform { get;  }
        /// <summary>Status of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the WebApplication.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }
        /// <summary>WebServer of the WebApplication.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"WebServer of the WebApplication.",
        SerializedName = @"webServer",
        PossibleTypes = new [] { typeof(string) })]
        string WebServer { get;  }

    }
    /// WebApplication in the guest virtual machine.
    internal partial interface IWebApplicationInternal

    {
        /// <summary>ApplicationPool of the WebApplication.</summary>
        string ApplicationPool { get; set; }
        /// <summary>GroupName of the WebApplication.</summary>
        string GroupName { get; set; }
        /// <summary>Name of the WebApplication.</summary>
        string Name { get; set; }
        /// <summary>Platform of the WebApplication.</summary>
        string Platform { get; set; }
        /// <summary>Status of the WebApplication.</summary>
        string Status { get; set; }
        /// <summary>WebServer of the WebApplication.</summary>
        string WebServer { get; set; }

    }
}