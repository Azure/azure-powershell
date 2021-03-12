namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Specifies configuration of a redis module</summary>
    public partial class Module :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModule,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModuleInternal
    {

        /// <summary>Backing field for <see cref="Arg" /> property.</summary>
        private string _arg;

        /// <summary>Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Arg { get => this._arg; set => this._arg = value; }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20210301.IModuleInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>The version of the module, e.g. '1.0'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="Module" /> instance.</summary>
        public Module()
        {

        }
    }
    /// Specifies configuration of a redis module
    public partial interface IModule :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.",
        SerializedName = @"args",
        PossibleTypes = new [] { typeof(string) })]
        string Arg { get; set; }
        /// <summary>The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The version of the module, e.g. '1.0'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The version of the module, e.g. '1.0'.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// Specifies configuration of a redis module
    internal partial interface IModuleInternal

    {
        /// <summary>Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.</summary>
        string Arg { get; set; }
        /// <summary>The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'</summary>
        string Name { get; set; }
        /// <summary>The version of the module, e.g. '1.0'.</summary>
        string Version { get; set; }

    }
}