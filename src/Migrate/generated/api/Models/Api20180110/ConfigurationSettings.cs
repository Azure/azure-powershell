namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication provider specific settings.</summary>
    public partial class ConfigurationSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettingsInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Creates an new <see cref="ConfigurationSettings" /> instance.</summary>
        public ConfigurationSettings()
        {

        }
    }
    /// Replication provider specific settings.
    public partial interface IConfigurationSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// Replication provider specific settings.
    internal partial interface IConfigurationSettingsInternal

    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string InstanceType { get; set; }

    }
}