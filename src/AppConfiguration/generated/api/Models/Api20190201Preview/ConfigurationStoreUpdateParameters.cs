namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The parameters for updating a configuration store.</summary>
    public partial class ConfigurationStoreUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters _property;

        /// <summary>The properties for updating a configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ConfigurationStorePropertiesUpdateParameters()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags _tag;

        /// <summary>The ARM resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ConfigurationStoreUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ConfigurationStoreUpdateParameters" /> instance.</summary>
        public ConfigurationStoreUpdateParameters()
        {

        }
    }
    /// The parameters for updating a configuration store.
    public partial interface IConfigurationStoreUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The properties for updating a configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The properties for updating a configuration store.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters Property { get; set; }
        /// <summary>The ARM resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags Tag { get; set; }

    }
    /// The parameters for updating a configuration store.
    internal partial interface IConfigurationStoreUpdateParametersInternal

    {
        /// <summary>The properties for updating a configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesUpdateParameters Property { get; set; }
        /// <summary>The ARM resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreUpdateParametersTags Tag { get; set; }

    }
}