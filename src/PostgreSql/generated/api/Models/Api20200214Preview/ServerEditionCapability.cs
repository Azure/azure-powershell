namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Server edition capabilities.</summary>
    public partial class ServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for SupportedServerVersion</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapabilityInternal.SupportedServerVersion { get => this._supportedServerVersion; set { {_supportedServerVersion = value;} } }

        /// <summary>Internal Acessors for SupportedStorageEdition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability[] Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerEditionCapabilityInternal.SupportedStorageEdition { get => this._supportedStorageEdition; set { {_supportedStorageEdition = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Server edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="SupportedServerVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability[] _supportedServerVersion;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability[] SupportedServerVersion { get => this._supportedServerVersion; }

        /// <summary>Backing field for <see cref="SupportedStorageEdition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability[] _supportedStorageEdition;

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability[] SupportedStorageEdition { get => this._supportedStorageEdition; }

        /// <summary>Creates an new <see cref="ServerEditionCapability" /> instance.</summary>
        public ServerEditionCapability()
        {

        }
    }
    /// Server edition capabilities.
    public partial interface IServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>Server edition name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Server edition name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"supportedServerVersions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability[] SupportedServerVersion { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"supportedStorageEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability) })]
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability[] SupportedStorageEdition { get;  }

    }
    /// Server edition capabilities.
    internal partial interface IServerEditionCapabilityInternal

    {
        /// <summary>Server edition name</summary>
        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerVersionCapability[] SupportedServerVersion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IStorageEditionCapability[] SupportedStorageEdition { get; set; }

    }
}