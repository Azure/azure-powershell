// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a configuration (also known as server parameter).</summary>
    public partial class ConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedValue" /> property.</summary>
        private string _allowedValue;

        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string AllowedValue { get => this._allowedValue; }

        /// <summary>Backing field for <see cref="DataType" /> property.</summary>
        private string _dataType;

        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DataType { get => this._dataType; }

        /// <summary>Backing field for <see cref="DefaultValue" /> property.</summary>
        private string _defaultValue;

        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DefaultValue { get => this._defaultValue; }

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Backing field for <see cref="DocumentationLink" /> property.</summary>
        private string _documentationLink;

        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DocumentationLink { get => this._documentationLink; }

        /// <summary>Backing field for <see cref="IsConfigPendingRestart" /> property.</summary>
        private bool? _isConfigPendingRestart;

        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public bool? IsConfigPendingRestart { get => this._isConfigPendingRestart; }

        /// <summary>Backing field for <see cref="IsDynamicConfig" /> property.</summary>
        private bool? _isDynamicConfig;

        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public bool? IsDynamicConfig { get => this._isDynamicConfig; }

        /// <summary>Backing field for <see cref="IsReadOnly" /> property.</summary>
        private bool? _isReadOnly;

        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public bool? IsReadOnly { get => this._isReadOnly; }

        /// <summary>Internal Acessors for AllowedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.AllowedValue { get => this._allowedValue; set { {_allowedValue = value;} } }

        /// <summary>Internal Acessors for DataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.DataType { get => this._dataType; set { {_dataType = value;} } }

        /// <summary>Internal Acessors for DefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.DefaultValue { get => this._defaultValue; set { {_defaultValue = value;} } }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for DocumentationLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.DocumentationLink { get => this._documentationLink; set { {_documentationLink = value;} } }

        /// <summary>Internal Acessors for IsConfigPendingRestart</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.IsConfigPendingRestart { get => this._isConfigPendingRestart; set { {_isConfigPendingRestart = value;} } }

        /// <summary>Internal Acessors for IsDynamicConfig</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.IsDynamicConfig { get => this._isDynamicConfig; set { {_isDynamicConfig = value;} } }

        /// <summary>Internal Acessors for IsReadOnly</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.IsReadOnly { get => this._isReadOnly; set { {_isReadOnly = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal.Unit { get => this._unit; set { {_unit = value;} } }

        /// <summary>Backing field for <see cref="Source" /> property.</summary>
        private string _source;

        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Source { get => this._source; set => this._source = value; }

        /// <summary>Backing field for <see cref="Unit" /> property.</summary>
        private string _unit;

        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Unit { get => this._unit; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConfigurationProperties" /> instance.</summary>
        public ConfigurationProperties()
        {

        }
    }
    /// Properties of a configuration (also known as server parameter).
    public partial interface IConfigurationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Allowed values of the configuration (also known as server parameter).",
        SerializedName = @"allowedValues",
        PossibleTypes = new [] { typeof(string) })]
        string AllowedValue { get;  }
        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Data type of the configuration (also known as server parameter).",
        SerializedName = @"dataType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Boolean", "Numeric", "Integer", "Enumeration", "String", "Set")]
        string DataType { get;  }
        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Value assigned by default to the configuration (also known as server parameter).",
        SerializedName = @"defaultValue",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultValue { get;  }
        /// <summary>Description of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Description of the configuration (also known as server parameter).",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Link pointing to the documentation of the configuration (also known as server parameter).",
        SerializedName = @"documentationLink",
        PossibleTypes = new [] { typeof(string) })]
        string DocumentationLink { get;  }
        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for it to take effect.",
        SerializedName = @"isConfigPendingRestart",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsConfigPendingRestart { get;  }
        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters do not require a server restart after changing the value assigned to them, for the change to take effect.",
        SerializedName = @"isDynamicConfig",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDynamicConfig { get;  }
        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).",
        SerializedName = @"isReadOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsReadOnly { get;  }
        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable configuration.",
        SerializedName = @"source",
        PossibleTypes = new [] { typeof(string) })]
        string Source { get; set; }
        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Units in which the configuration (also known as server parameter) value is expressed.",
        SerializedName = @"unit",
        PossibleTypes = new [] { typeof(string) })]
        string Unit { get;  }
        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable configuration.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Properties of a configuration (also known as server parameter).
    internal partial interface IConfigurationPropertiesInternal

    {
        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        string AllowedValue { get; set; }
        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Boolean", "Numeric", "Integer", "Enumeration", "String", "Set")]
        string DataType { get; set; }
        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        string DefaultValue { get; set; }
        /// <summary>Description of the configuration (also known as server parameter).</summary>
        string Description { get; set; }
        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        string DocumentationLink { get; set; }
        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        bool? IsConfigPendingRestart { get; set; }
        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        bool? IsDynamicConfig { get; set; }
        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        bool? IsReadOnly { get; set; }
        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        string Source { get; set; }
        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        string Unit { get; set; }
        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        string Value { get; set; }

    }
}