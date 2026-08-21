// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Configuration (also known as server parameter).</summary>
    public partial class ConfigurationForUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal
    {

        /// <summary>Allowed values of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue; }

        /// <summary>Data type of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType; }

        /// <summary>
        /// Value assigned by default to the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue; }

        /// <summary>Description of the configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description; }

        /// <summary>
        /// Link pointing to the documentation of the configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string DocumentationLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink; }

        /// <summary>
        /// Indicates if the value assigned to the configuration (also known as server parameter) is pending a server restart for
        /// it to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public bool? IsConfigPendingRestart { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart; }

        /// <summary>
        /// Indicates if it's a dynamic (true) or static (false) configuration (also known as server parameter). Static server parameters
        /// require a server restart after changing the value assigned to them, for the change to take effect. Dynamic server parameters
        /// do not require a server restart after changing the value assigned to them, for the change to take effect.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public bool? IsDynamicConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig; }

        /// <summary>
        /// Indicates if it's a read-only (true) or modifiable (false) configuration (also known as server parameter).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public bool? IsReadOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly; }

        /// <summary>Internal Acessors for AllowedValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.AllowedValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).AllowedValue = value ?? null; }

        /// <summary>Internal Acessors for DataType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.DataType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DataType = value ?? null; }

        /// <summary>Internal Acessors for DefaultValue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.DefaultValue { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DefaultValue = value ?? null; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Description = value ?? null; }

        /// <summary>Internal Acessors for DocumentationLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.DocumentationLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).DocumentationLink = value ?? null; }

        /// <summary>Internal Acessors for IsConfigPendingRestart</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.IsConfigPendingRestart { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsConfigPendingRestart = value ?? default(bool); }

        /// <summary>Internal Acessors for IsDynamicConfig</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.IsDynamicConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsDynamicConfig = value ?? default(bool); }

        /// <summary>Internal Acessors for IsReadOnly</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.IsReadOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).IsReadOnly = value ?? default(bool); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Unit</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationForUpdateInternal.Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties _property;

        /// <summary>Properties of a configuration (also known as server parameter).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ConfigurationProperties()); set => this._property = value; }

        /// <summary>
        /// Source of the value assigned to the configuration (also known as server parameter). Required to update the value assigned
        /// to a specific modifiable configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Source { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Source; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Source = value ?? null; }

        /// <summary>
        /// Units in which the configuration (also known as server parameter) value is expressed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Unit { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Unit; }

        /// <summary>
        /// Value of the configuration (also known as server parameter). Required to update the value assigned to a specific modifiable
        /// configuration.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string Value { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Value; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationPropertiesInternal)Property).Value = value ?? null; }

        /// <summary>Creates an new <see cref="ConfigurationForUpdate" /> instance.</summary>
        public ConfigurationForUpdate()
        {

        }
    }
    /// Configuration (also known as server parameter).
    public partial interface IConfigurationForUpdate :
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
    /// Configuration (also known as server parameter).
    internal partial interface IConfigurationForUpdateInternal

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
        /// <summary>Properties of a configuration (also known as server parameter).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IConfigurationProperties Property { get; set; }
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