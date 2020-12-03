namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Server edition capabilities.</summary>
    public partial class ServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for SupportedServerVersion</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapabilityInternal.SupportedServerVersion { get => this._supportedServerVersion; set { {_supportedServerVersion = value;} } }

        /// <summary>Internal Acessors for SupportedStorageEdition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability[] Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerEditionCapabilityInternal.SupportedStorageEdition { get => this._supportedStorageEdition; set { {_supportedStorageEdition = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Server edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="SupportedServerVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability[] _supportedServerVersion;

        /// <summary>A list of supported server versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability[] SupportedServerVersion { get => this._supportedServerVersion; }

        /// <summary>Backing field for <see cref="SupportedStorageEdition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability[] _supportedStorageEdition;

        /// <summary>A list of supported storage editions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability[] SupportedStorageEdition { get => this._supportedStorageEdition; }

        /// <summary>Creates an new <see cref="ServerEditionCapability" /> instance.</summary>
        public ServerEditionCapability()
        {

        }
    }
    /// Server edition capabilities.
    public partial interface IServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>Server edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Server edition name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>A list of supported server versions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of supported server versions.",
        SerializedName = @"supportedServerVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability[] SupportedServerVersion { get;  }
        /// <summary>A list of supported storage editions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of supported storage editions",
        SerializedName = @"supportedStorageEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability[] SupportedStorageEdition { get;  }

    }
    /// Server edition capabilities.
    internal partial interface IServerEditionCapabilityInternal

    {
        /// <summary>Server edition name</summary>
        string Name { get; set; }
        /// <summary>A list of supported server versions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IServerVersionCapability[] SupportedServerVersion { get; set; }
        /// <summary>A list of supported storage editions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IStorageEditionCapability[] SupportedStorageEdition { get; set; }

    }
}