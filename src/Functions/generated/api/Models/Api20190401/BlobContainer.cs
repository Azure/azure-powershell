namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Properties of the blob container, including Id, resource name, resource type, Etag.
    /// </summary>
    public partial class BlobContainer :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainer,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResource __azureEntityResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.AzureEntityResource();

        /// <summary>Backing field for <see cref="ContainerProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties _containerProperty;

        /// <summary>Properties of the blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties ContainerProperty { get => (this._containerProperty = this._containerProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties()); set => this._containerProperty = value; }

        /// <summary>
        /// The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container.
        /// The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ContainerPropertyHasImmutabilityPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasImmutabilityPolicy; }

        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ContainerPropertyHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasLegalHold; }

        /// <summary>Returns the date and time the container was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ContainerPropertyLastModifiedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LastModifiedTime; }

        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? ContainerPropertyLeaseDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseDuration; }

        /// <summary>Lease state of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? ContainerPropertyLeaseState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseState; }

        /// <summary>The lease status of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? ContainerPropertyLeaseStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseStatus; }

        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata ContainerPropertyMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).Metadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).Metadata = value; }

        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? ContainerPropertyPublicAccess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).PublicAccess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).PublicAccess = value; }

        /// <summary>Resource Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResourceInternal)__azureEntityResource).Etag; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Id; }

        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int ImmutabilityPeriodSinceCreationInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPeriodSinceCreationInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPeriodSinceCreationInDay = value; }

        /// <summary>ImmutabilityPolicy Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ImmutabilityPolicyEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyEtag; }

        /// <summary>The ImmutabilityPolicy update history of the blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] ImmutabilityPolicyUpdateHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyUpdateHistory; }

        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? LegalHoldHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHoldHasLegalHold; }

        /// <summary>The list of LegalHold tags of a blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] LegalHoldTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHoldTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHoldTag = value; }

        /// <summary>Internal Acessors for Etag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResourceInternal.Etag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResourceInternal)__azureEntityResource).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResourceInternal)__azureEntityResource).Etag = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Type = value; }

        /// <summary>Internal Acessors for ContainerProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerProperty { get => (this._containerProperty = this._containerProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerProperties()); set { {_containerProperty = value;} } }

        /// <summary>Internal Acessors for ContainerPropertyHasImmutabilityPolicy</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyHasImmutabilityPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasImmutabilityPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasImmutabilityPolicy = value; }

        /// <summary>Internal Acessors for ContainerPropertyHasLegalHold</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasLegalHold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).HasLegalHold = value; }

        /// <summary>Internal Acessors for ContainerPropertyImmutabilityPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyImmutabilityPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicy = value; }

        /// <summary>Internal Acessors for ContainerPropertyLastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyLastModifiedTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LastModifiedTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LastModifiedTime = value; }

        /// <summary>Internal Acessors for ContainerPropertyLeaseDuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyLeaseDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseDuration = value; }

        /// <summary>Internal Acessors for ContainerPropertyLeaseState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyLeaseState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseState = value; }

        /// <summary>Internal Acessors for ContainerPropertyLeaseStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyLeaseStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LeaseStatus = value; }

        /// <summary>Internal Acessors for ContainerPropertyLegalHold</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ContainerPropertyLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHold = value; }

        /// <summary>Internal Acessors for ImmutabilityPolicyEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ImmutabilityPolicyEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyEtag = value; }

        /// <summary>Internal Acessors for ImmutabilityPolicyProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ImmutabilityPolicyProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyProperty = value; }

        /// <summary>Internal Acessors for ImmutabilityPolicyUpdateHistory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.ImmutabilityPolicyUpdateHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyUpdateHistory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).ImmutabilityPolicyUpdateHistory = value; }

        /// <summary>Internal Acessors for LegalHoldHasLegalHold</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.LegalHoldHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHoldHasLegalHold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).LegalHoldHasLegalHold = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IBlobContainerInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).State = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Name; }

        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal)ContainerProperty).State; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceAutoGeneratedInternal)__azureEntityResource).Type; }

        /// <summary>Creates an new <see cref="BlobContainer" /> instance.</summary>
        public BlobContainer()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__azureEntityResource), __azureEntityResource);
            await eventListener.AssertObjectIsValid(nameof(__azureEntityResource), __azureEntityResource);
        }
    }
    /// Properties of the blob container, including Id, resource name, resource type, Etag.
    public partial interface IBlobContainer :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResource
    {
        /// <summary>
        /// The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container.
        /// The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container. The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.",
        SerializedName = @"hasImmutabilityPolicy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ContainerPropertyHasImmutabilityPolicy { get;  }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account.",
        SerializedName = @"hasLegalHold",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ContainerPropertyHasLegalHold { get;  }
        /// <summary>Returns the date and time the container was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the date and time the container was last modified.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ContainerPropertyLastModifiedTime { get;  }
        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.",
        SerializedName = @"leaseDuration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? ContainerPropertyLeaseDuration { get;  }
        /// <summary>Lease state of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Lease state of the container.",
        SerializedName = @"leaseState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? ContainerPropertyLeaseState { get;  }
        /// <summary>The lease status of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The lease status of the container.",
        SerializedName = @"leaseStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? ContainerPropertyLeaseStatus { get;  }
        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A name-value pair to associate with the container as metadata.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata ContainerPropertyMetadata { get; set; }
        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether data in the container may be accessed publicly and the level of access.",
        SerializedName = @"publicAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? ContainerPropertyPublicAccess { get; set; }
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The immutability period for the blobs in the container since the policy creation, in days.",
        SerializedName = @"immutabilityPeriodSinceCreationInDays",
        PossibleTypes = new [] { typeof(int) })]
        int ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>ImmutabilityPolicy Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ImmutabilityPolicy Etag.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string ImmutabilityPolicyEtag { get;  }
        /// <summary>The ImmutabilityPolicy update history of the blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ImmutabilityPolicy update history of the blob container.",
        SerializedName = @"updateHistory",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] ImmutabilityPolicyUpdateHistory { get;  }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers with hasLegalHold=true for a given account.",
        SerializedName = @"hasLegalHold",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LegalHoldHasLegalHold { get;  }
        /// <summary>The list of LegalHold tags of a blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of LegalHold tags of a blob container.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] LegalHoldTag { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get;  }

    }
    /// Properties of the blob container, including Id, resource name, resource type, Etag.
    internal partial interface IBlobContainerInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IAzureEntityResourceInternal
    {
        /// <summary>Properties of the blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties ContainerProperty { get; set; }
        /// <summary>
        /// The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container.
        /// The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.
        /// </summary>
        bool? ContainerPropertyHasImmutabilityPolicy { get; set; }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? ContainerPropertyHasLegalHold { get; set; }
        /// <summary>The ImmutabilityPolicy property of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties ContainerPropertyImmutabilityPolicy { get; set; }
        /// <summary>Returns the date and time the container was last modified.</summary>
        global::System.DateTime? ContainerPropertyLastModifiedTime { get; set; }
        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? ContainerPropertyLeaseDuration { get; set; }
        /// <summary>Lease state of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? ContainerPropertyLeaseState { get; set; }
        /// <summary>The lease status of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? ContainerPropertyLeaseStatus { get; set; }
        /// <summary>The LegalHold property of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties ContainerPropertyLegalHold { get; set; }
        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata ContainerPropertyMetadata { get; set; }
        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? ContainerPropertyPublicAccess { get; set; }
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        int ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>ImmutabilityPolicy Etag.</summary>
        string ImmutabilityPolicyEtag { get; set; }
        /// <summary>The properties of an ImmutabilityPolicy of a blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty ImmutabilityPolicyProperty { get; set; }
        /// <summary>The ImmutabilityPolicy update history of the blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] ImmutabilityPolicyUpdateHistory { get; set; }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? LegalHoldHasLegalHold { get; set; }
        /// <summary>The list of LegalHold tags of a blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] LegalHoldTag { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get; set; }

    }
}