namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>The properties of a configuration.</summary>
    public partial class ConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedValue" /> property.</summary>
        private string _allowedValue;

        /// <summary>Allowed values of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string AllowedValue { get => this._allowedValue; }

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>Data type of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; }

        /// <summary>Backing field for <see cref="DefaultValue" /> property.</summary>
        private string _defaultValue;

        /// <summary>Default value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string DefaultValue { get => this._defaultValue; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for AllowedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationPropertiesInternal.AllowedValue { get => this._allowedValue; set { {_allowedValue = value;} } }

        /// <summary>Internal Acessors for DataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationPropertiesInternal.DataType { get => this._dataType; set { {_dataType = value;} } }

        /// <summary>Internal Acessors for DefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationPropertiesInternal.DefaultValue { get => this._defaultValue; set { {_defaultValue = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>Source of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>Value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConfigurationProperties" /> instance.</summary>
        public ConfigurationProperties()
        {

        }
    }
    /// The properties of a configuration.
    public partial interface IConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>Allowed values of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Allowed values of the configuration.",
        SerializedName = @"allowedValues",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedValue { get;  }
        /// <summary>Data type of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Data type of the configuration.",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        string DataType { get;  }
        /// <summary>Default value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Default value of the configuration.",
        SerializedName = @"defaultValue",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultValue { get;  }
        /// <summary>Description of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Description of the configuration.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Source of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source of the configuration.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>Value of the configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value of the configuration.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// The properties of a configuration.
    internal partial interface IConfigurationPropertiesInternal

    {
        /// <summary>Allowed values of the configuration.</summary>
        string AllowedValue { get; set; }
        /// <summary>Data type of the configuration.</summary>
        string DataType { get; set; }
        /// <summary>Default value of the configuration.</summary>
        string DefaultValue { get; set; }
        /// <summary>Description of the configuration.</summary>
        string Description { get; set; }
        /// <summary>Source of the configuration.</summary>
        string Source { get; set; }
        /// <summary>Value of the configuration.</summary>
        string Value { get; set; }

    }
}