namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>
    /// The configuration store along with all resource properties. The Configuration Store will have all information to begin
    /// utilizing it.
    /// </summary>
    public partial class ConfigurationStore :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStore,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.Resource();

        /// <summary>The creation date of configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).CreationDate; }

        /// <summary>The DNS endpoint where the configuration store API will be available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).Endpoint; }

        /// <summary>The resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Id; }

        /// <summary>
        /// The location of the resource. This cannot be changed after the resource is created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for CreationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreInternal.CreationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).CreationDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).CreationDate = value; }

        /// <summary>Internal Acessors for Endpoint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreInternal.Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).Endpoint = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreProperties Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ConfigurationStoreProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreProperties _property;

        /// <summary>The properties of a configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.ConfigurationStoreProperties()); set => this._property = value; }

        /// <summary>The provisioning state of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStorePropertiesInternal)Property).ProvisioningState; }

        /// <summary>The tags of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Tag = value; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ConfigurationStore" /> instance.</summary>
        public ConfigurationStore()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The configuration store along with all resource properties. The Configuration Store will have all information to begin
    /// utilizing it.
    public partial interface IConfigurationStore :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResource
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
    /// The configuration store along with all resource properties. The Configuration Store will have all information to begin
    /// utilizing it.
    internal partial interface IConfigurationStoreInternal :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IResourceInternal
    {
        /// <summary>The creation date of configuration store.</summary>
        global::System.DateTime? CreationDate { get; set; }
        /// <summary>The DNS endpoint where the configuration store API will be available.</summary>
        string Endpoint { get; set; }
        /// <summary>The properties of a configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.IConfigurationStoreProperties Property { get; set; }
        /// <summary>The provisioning state of the configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}