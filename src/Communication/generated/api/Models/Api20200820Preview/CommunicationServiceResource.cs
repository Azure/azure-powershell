namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>A class representing a CommunicationService resource.</summary>
    public partial class CommunicationServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResource,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IValidates,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IHeaderSerializable
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResource __locationResource = new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.LocationResource();

        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.Resource();

        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResource __taggedResource = new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.TaggedResource();

        /// <summary>Backing field for <see cref="AzureAsyncOperation" /> property.</summary>
        private string _azureAsyncOperation;

        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string AzureAsyncOperation { get => this._azureAsyncOperation; set => this._azureAsyncOperation = value; }

        /// <summary>The location where the communication service stores its data at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string DataLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).DataLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).DataLocation = value; }

        /// <summary>FQDN of the CommunicationService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).HostName; }

        /// <summary>Fully qualified resource ID for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Id; }

        /// <summary>The immutable resource Id of the communication service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string ImmutableResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ImmutableResourceId; }

        /// <summary>The Azure location where the CommunicationService is running.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResourceInternal)__locationResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResourceInternal)__locationResource).Location = value; }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).HostName = value; }

        /// <summary>Internal Acessors for ImmutableResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.ImmutableResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ImmutableResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ImmutableResourceId = value; }

        /// <summary>Internal Acessors for NotificationHubId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.NotificationHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).NotificationHubId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).NotificationHubId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.CommunicationServiceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal.Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).Version = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Name; }

        /// <summary>Resource ID of an Azure Notification Hub linked to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string NotificationHubId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).NotificationHubId; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties _property;

        /// <summary>The properties of the service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.CommunicationServiceProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Tags of the service which is a list of key value pairs that describe the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceInternal)__taggedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceInternal)__taggedResource).Tag = value; }

        /// <summary>The type of the service - e.g. "Microsoft.Communication/CommunicationServices"</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal)__resource).Type; }

        /// <summary>
        /// Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Inlined)]
        public string Version { get => ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal)Property).Version; }

        /// <summary>Creates an new <see cref="CommunicationServiceResource" /> instance.</summary>
        public CommunicationServiceResource()
        {

        }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("Azure-AsyncOperation", out var __azureAsyncOperationHeader))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceResourceInternal)this).AzureAsyncOperation = System.Linq.Enumerable.FirstOrDefault(__azureAsyncOperationHeader) is string __headerAzureAsyncOperationHeader ? __headerAzureAsyncOperationHeader : (string)null;
            }
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
            await eventListener.AssertNotNull(nameof(__locationResource), __locationResource);
            await eventListener.AssertObjectIsValid(nameof(__locationResource), __locationResource);
            await eventListener.AssertNotNull(nameof(__taggedResource), __taggedResource);
            await eventListener.AssertObjectIsValid(nameof(__taggedResource), __taggedResource);
        }
    }
    /// A class representing a CommunicationService resource.
    public partial interface ICommunicationServiceResource :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResource,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResource
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"Azure-AsyncOperation",
        PossibleTypes = new [] { typeof(string) })]
        string AzureAsyncOperation { get; set; }
        /// <summary>The location where the communication service stores its data at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The location where the communication service stores its data at rest.",
        SerializedName = @"dataLocation",
        PossibleTypes = new [] { typeof(string) })]
        string DataLocation { get; set; }
        /// <summary>FQDN of the CommunicationService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"FQDN of the CommunicationService instance.",
        SerializedName = @"hostName",
        PossibleTypes = new [] { typeof(string) })]
        string HostName { get;  }
        /// <summary>The immutable resource Id of the communication service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The immutable resource Id of the communication service.",
        SerializedName = @"immutableResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ImmutableResourceId { get;  }
        /// <summary>Resource ID of an Azure Notification Hub linked to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource ID of an Azure Notification Hub linked to this resource.",
        SerializedName = @"notificationHubId",
        PossibleTypes = new [] { typeof(string) })]
        string NotificationHubId { get;  }
        /// <summary>Provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        string Version { get;  }

    }
    /// A class representing a CommunicationService resource.
    internal partial interface ICommunicationServiceResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ILocationResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ITaggedResourceInternal
    {
        string AzureAsyncOperation { get; set; }
        /// <summary>The location where the communication service stores its data at rest.</summary>
        string DataLocation { get; set; }
        /// <summary>FQDN of the CommunicationService instance.</summary>
        string HostName { get; set; }
        /// <summary>The immutable resource Id of the communication service.</summary>
        string ImmutableResourceId { get; set; }
        /// <summary>Resource ID of an Azure Notification Hub linked to this resource.</summary>
        string NotificationHubId { get; set; }
        /// <summary>The properties of the service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties Property { get; set; }
        /// <summary>Provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.
        /// </summary>
        string Version { get; set; }

    }
}