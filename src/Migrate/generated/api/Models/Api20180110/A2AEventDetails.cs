namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Model class for event details of a A2A event.</summary>
    public partial class A2AEventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AEventDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IA2AEventDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails __eventProviderSpecificDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EventProviderSpecificDetails();

        /// <summary>Backing field for <see cref="FabricLocation" /> property.</summary>
        private string _fabricLocation;

        /// <summary>The fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricLocation { get => this._fabricLocation; set => this._fabricLocation = value; }

        /// <summary>Backing field for <see cref="FabricName" /> property.</summary>
        private string _fabricName;

        /// <summary>Fabric arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricName { get => this._fabricName; set => this._fabricName = value; }

        /// <summary>Backing field for <see cref="FabricObjectId" /> property.</summary>
        private string _fabricObjectId;

        /// <summary>The azure vm arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricObjectId { get => this._fabricObjectId; set => this._fabricObjectId = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal)__eventProviderSpecificDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="ProtectedItemName" /> property.</summary>
        private string _protectedItemName;

        /// <summary>The protected item arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string ProtectedItemName { get => this._protectedItemName; set => this._protectedItemName = value; }

        /// <summary>Backing field for <see cref="RemoteFabricLocation" /> property.</summary>
        private string _remoteFabricLocation;

        /// <summary>Remote fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RemoteFabricLocation { get => this._remoteFabricLocation; set => this._remoteFabricLocation = value; }

        /// <summary>Backing field for <see cref="RemoteFabricName" /> property.</summary>
        private string _remoteFabricName;

        /// <summary>Remote fabric arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RemoteFabricName { get => this._remoteFabricName; set => this._remoteFabricName = value; }

        /// <summary>Creates an new <see cref="A2AEventDetails" /> instance.</summary>
        public A2AEventDetails()
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
    /// Model class for event details of a A2A event.
    public partial interface IA2AEventDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetails
    {
        /// <summary>The fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The fabric location.",
        SerializedName = @"fabricLocation",
        PossibleTypes = new [] { typeof(string) })]
        string FabricLocation { get; set; }
        /// <summary>Fabric arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fabric arm name.",
        SerializedName = @"fabricName",
        PossibleTypes = new [] { typeof(string) })]
        string FabricName { get; set; }
        /// <summary>The azure vm arm id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The azure vm arm id.",
        SerializedName = @"fabricObjectId",
        PossibleTypes = new [] { typeof(string) })]
        string FabricObjectId { get; set; }
        /// <summary>The protected item arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protected item arm name.",
        SerializedName = @"protectedItemName",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectedItemName { get; set; }
        /// <summary>Remote fabric location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote fabric location.",
        SerializedName = @"remoteFabricLocation",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteFabricLocation { get; set; }
        /// <summary>Remote fabric arm name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote fabric arm name.",
        SerializedName = @"remoteFabricName",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteFabricName { get; set; }

    }
    /// Model class for event details of a A2A event.
    internal partial interface IA2AEventDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEventProviderSpecificDetailsInternal
    {
        /// <summary>The fabric location.</summary>
        string FabricLocation { get; set; }
        /// <summary>Fabric arm name.</summary>
        string FabricName { get; set; }
        /// <summary>The azure vm arm id.</summary>
        string FabricObjectId { get; set; }
        /// <summary>The protected item arm name.</summary>
        string ProtectedItemName { get; set; }
        /// <summary>Remote fabric location.</summary>
        string RemoteFabricLocation { get; set; }
        /// <summary>Remote fabric arm name.</summary>
        string RemoteFabricName { get; set; }

    }
}