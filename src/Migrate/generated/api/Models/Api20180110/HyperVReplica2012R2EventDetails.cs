namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Model class for event details of a HyperVReplica blue E2E event.</summary>
    public partial class HyperVReplica2012R2EventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012R2EventDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHyperVReplica2012R2EventDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails __eventProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetails();

        /// <summary>Backing field for <see cref="ContainerName" /> property.</summary>
        private string _containerName;

        /// <summary>The container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ContainerName { get => this._containerName; set => this._containerName = value; }

        /// <summary>Backing field for <see cref="FabricName" /> property.</summary>
        private string _fabricName;

        /// <summary>The fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricName { get => this._fabricName; set => this._fabricName = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="RemoteContainerName" /> property.</summary>
        private string _remoteContainerName;

        /// <summary>The remote container name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RemoteContainerName { get => this._remoteContainerName; set => this._remoteContainerName = value; }

        /// <summary>Backing field for <see cref="RemoteFabricName" /> property.</summary>
        private string _remoteFabricName;

        /// <summary>The remote fabric name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RemoteFabricName { get => this._remoteFabricName; set => this._remoteFabricName = value; }

        /// <summary>Creates an new <see cref="HyperVReplica2012R2EventDetails" /> instance.</summary>
        public HyperVReplica2012R2EventDetails()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__eventProviderSpecificDetails), __eventProviderSpecificDetails);
            await eventListener.AssertObjectIsValid(nameof(__eventProviderSpecificDetails), __eventProviderSpecificDetails);
        }
    }
    /// Model class for event details of a HyperVReplica blue E2E event.
    public partial interface IHyperVReplica2012R2EventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails
    {
        /// <summary>The container friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The container friendly name.",
        SerializedName = @"containerName",
        PossibleTypes = new [] { typeof(string) })]
        string ContainerName { get; set; }
        /// <summary>The fabric friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fabric friendly name.",
        SerializedName = @"fabricName",
        PossibleTypes = new [] { typeof(string) })]
        string FabricName { get; set; }
        /// <summary>The remote container name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The remote container name.",
        SerializedName = @"remoteContainerName",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteContainerName { get; set; }
        /// <summary>The remote fabric name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The remote fabric name.",
        SerializedName = @"remoteFabricName",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteFabricName { get; set; }

    }
    /// Model class for event details of a HyperVReplica blue E2E event.
    internal partial interface IHyperVReplica2012R2EventDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal
    {
        /// <summary>The container friendly name.</summary>
        string ContainerName { get; set; }
        /// <summary>The fabric friendly name.</summary>
        string FabricName { get; set; }
        /// <summary>The remote container name.</summary>
        string RemoteContainerName { get; set; }
        /// <summary>The remote fabric name.</summary>
        string RemoteFabricName { get; set; }

    }
}