namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The properties of a configuration store.</summary>
    public partial class ConfigurationStoreProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreProperties,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CreationDate" /> property.</summary>
        private global::System.DateTime? _creationDate;

        /// <summary>The creation date of configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? CreationDate { get => this._creationDate; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>The DNS endpoint where the configuration store API will be available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; }

        /// <summary>Internal Acessors for CreationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal.CreationDate { get => this._creationDate; set { {_creationDate = value;} } }

        /// <summary>Internal Acessors for Endpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal.Endpoint { get => this._endpoint; set { {_endpoint = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioning state of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ConfigurationStoreProperties" /> instance.</summary>
        public ConfigurationStoreProperties()
        {

        }
    }
    /// The properties of a configuration store.
    public partial interface IConfigurationStoreProperties :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The creation date of configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The creation date of configuration store.",
        SerializedName = @"creationDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreationDate { get;  }
        /// <summary>The DNS endpoint where the configuration store API will be available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The DNS endpoint where the configuration store API will be available.",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get;  }
        /// <summary>The provisioning state of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the configuration store.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? ProvisioningState { get;  }

    }
    /// The properties of a configuration store.
    internal partial interface IConfigurationStorePropertiesInternal

    {
        /// <summary>The creation date of configuration store.</summary>
        global::System.DateTime? CreationDate { get; set; }
        /// <summary>The DNS endpoint where the configuration store API will be available.</summary>
        string Endpoint { get; set; }
        /// <summary>The provisioning state of the configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}