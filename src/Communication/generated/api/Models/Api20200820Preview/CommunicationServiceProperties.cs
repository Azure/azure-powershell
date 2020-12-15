namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>A class that describes the properties of the CommunicationService.</summary>
    public partial class CommunicationServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServiceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal
    {

        /// <summary>Backing field for <see cref="DataLocation" /> property.</summary>
        private string _dataLocation;

        /// <summary>The location where the communication service stores its data at rest.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string DataLocation { get => this._dataLocation; set => this._dataLocation = value; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string _hostName;

        /// <summary>FQDN of the CommunicationService instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string HostName { get => this._hostName; }

        /// <summary>Backing field for <see cref="ImmutableResourceId" /> property.</summary>
        private string _immutableResourceId;

        /// <summary>The immutable resource Id of the communication service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string ImmutableResourceId { get => this._immutableResourceId; }

        /// <summary>Internal Acessors for HostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal.HostName { get => this._hostName; set { {_hostName = value;} } }

        /// <summary>Internal Acessors for ImmutableResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal.ImmutableResourceId { get => this._immutableResourceId; set { {_immutableResourceId = value;} } }

        /// <summary>Internal Acessors for NotificationHubId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal.NotificationHubId { get => this._notificationHubId; set { {_notificationHubId = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Version</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.ICommunicationServicePropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="NotificationHubId" /> property.</summary>
        private string _notificationHubId;

        /// <summary>Resource ID of an Azure Notification Hub linked to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string NotificationHubId { get => this._notificationHubId; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private string _version;

        /// <summary>
        /// Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Version { get => this._version; }

        /// <summary>Creates an new <see cref="CommunicationServiceProperties" /> instance.</summary>
        public CommunicationServiceProperties()
        {

        }
    }
    /// A class that describes the properties of the CommunicationService.
    public partial interface ICommunicationServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
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
    /// A class that describes the properties of the CommunicationService.
    internal partial interface ICommunicationServicePropertiesInternal

    {
        /// <summary>The location where the communication service stores its data at rest.</summary>
        string DataLocation { get; set; }
        /// <summary>FQDN of the CommunicationService instance.</summary>
        string HostName { get; set; }
        /// <summary>The immutable resource Id of the communication service.</summary>
        string ImmutableResourceId { get; set; }
        /// <summary>Resource ID of an Azure Notification Hub linked to this resource.</summary>
        string NotificationHubId { get; set; }
        /// <summary>Provisioning state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// Version of the CommunicationService resource. Probably you need the same or higher version of client SDKs.
        /// </summary>
        string Version { get; set; }

    }
}