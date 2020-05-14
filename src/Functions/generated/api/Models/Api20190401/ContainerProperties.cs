namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The properties of a container.</summary>
    public partial class ContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal
    {

        /// <summary>Backing field for <see cref="HasImmutabilityPolicy" /> property.</summary>
        private bool? _hasImmutabilityPolicy;

        /// <summary>
        /// The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container.
        /// The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasImmutabilityPolicy { get => this._hasImmutabilityPolicy; }

        /// <summary>Backing field for <see cref="HasLegalHold" /> property.</summary>
        private bool? _hasLegalHold;

        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HasLegalHold { get => this._hasLegalHold; }

        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int ImmutabilityPeriodSinceCreationInDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).ImmutabilityPeriodSinceCreationInDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).ImmutabilityPeriodSinceCreationInDay = value; }

        /// <summary>Backing field for <see cref="ImmutabilityPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties _immutabilityPolicy;

        /// <summary>The ImmutabilityPolicy property of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties ImmutabilityPolicy { get => (this._immutabilityPolicy = this._immutabilityPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyProperties()); }

        /// <summary>ImmutabilityPolicy Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ImmutabilityPolicyEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).Etag; }

        /// <summary>The ImmutabilityPolicy update history of the blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] ImmutabilityPolicyUpdateHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).UpdateHistory; }

        /// <summary>Backing field for <see cref="LastModifiedTime" /> property.</summary>
        private global::System.DateTime? _lastModifiedTime;

        /// <summary>Returns the date and time the container was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTime { get => this._lastModifiedTime; }

        /// <summary>Backing field for <see cref="LeaseDuration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? _leaseDuration;

        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? LeaseDuration { get => this._leaseDuration; }

        /// <summary>Backing field for <see cref="LeaseState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? _leaseState;

        /// <summary>Lease state of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? LeaseState { get => this._leaseState; }

        /// <summary>Backing field for <see cref="LeaseStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? _leaseStatus;

        /// <summary>The lease status of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? LeaseStatus { get => this._leaseStatus; }

        /// <summary>Backing field for <see cref="LegalHold" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties _legalHold;

        /// <summary>The LegalHold property of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties LegalHold { get => (this._legalHold = this._legalHold ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.LegalHoldProperties()); }

        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? LegalHoldHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal)LegalHold).HasLegalHold; }

        /// <summary>The list of LegalHold tags of a blob container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] LegalHoldTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal)LegalHold).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal)LegalHold).Tag = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata _metadata;

        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ContainerPropertiesMetadata()); set => this._metadata = value; }

        /// <summary>Internal Acessors for HasImmutabilityPolicy</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.HasImmutabilityPolicy { get => this._hasImmutabilityPolicy; set { {_hasImmutabilityPolicy = value;} } }

        /// <summary>Internal Acessors for HasLegalHold</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.HasLegalHold { get => this._hasLegalHold; set { {_hasLegalHold = value;} } }

        /// <summary>Internal Acessors for ImmutabilityPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.ImmutabilityPolicy { get => (this._immutabilityPolicy = this._immutabilityPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ImmutabilityPolicyProperties()); set { {_immutabilityPolicy = value;} } }

        /// <summary>Internal Acessors for ImmutabilityPolicyEtag</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.ImmutabilityPolicyEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).Etag = value; }

        /// <summary>Internal Acessors for ImmutabilityPolicyProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.ImmutabilityPolicyProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).Property = value; }

        /// <summary>Internal Acessors for ImmutabilityPolicyUpdateHistory</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.ImmutabilityPolicyUpdateHistory { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).UpdateHistory; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).UpdateHistory = value; }

        /// <summary>Internal Acessors for LastModifiedTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LastModifiedTime { get => this._lastModifiedTime; set { {_lastModifiedTime = value;} } }

        /// <summary>Internal Acessors for LeaseDuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LeaseDuration { get => this._leaseDuration; set { {_leaseDuration = value;} } }

        /// <summary>Internal Acessors for LeaseState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LeaseState { get => this._leaseState; set { {_leaseState = value;} } }

        /// <summary>Internal Acessors for LeaseStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LeaseStatus { get => this._leaseStatus; set { {_leaseStatus = value;} } }

        /// <summary>Internal Acessors for LegalHold</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LegalHold { get => (this._legalHold = this._legalHold ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.LegalHoldProperties()); set { {_legalHold = value;} } }

        /// <summary>Internal Acessors for LegalHoldHasLegalHold</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.LegalHoldHasLegalHold { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal)LegalHold).HasLegalHold; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldPropertiesInternal)LegalHold).HasLegalHold = value; }

        /// <summary>Internal Acessors for State</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).State = value; }

        /// <summary>Backing field for <see cref="PublicAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? _publicAccess;

        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? PublicAccess { get => this._publicAccess; set => this._publicAccess = value; }

        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyPropertiesInternal)ImmutabilityPolicy).State; }

        /// <summary>Creates an new <see cref="ContainerProperties" /> instance.</summary>
        public ContainerProperties()
        {

        }
    }
    /// The properties of a container.
    public partial interface IContainerProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
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
        bool? HasImmutabilityPolicy { get;  }
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
        bool? HasLegalHold { get;  }
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
        /// <summary>Returns the date and time the container was last modified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Returns the date and time the container was last modified.",
        SerializedName = @"lastModifiedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTime { get;  }
        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.",
        SerializedName = @"leaseDuration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? LeaseDuration { get;  }
        /// <summary>Lease state of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Lease state of the container.",
        SerializedName = @"leaseState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? LeaseState { get;  }
        /// <summary>The lease status of the container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The lease status of the container.",
        SerializedName = @"leaseStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? LeaseStatus { get;  }
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
        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A name-value pair to associate with the container as metadata.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata Metadata { get; set; }
        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies whether data in the container may be accessed publicly and the level of access.",
        SerializedName = @"publicAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? PublicAccess { get; set; }
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
    /// The properties of a container.
    internal partial interface IContainerPropertiesInternal

    {
        /// <summary>
        /// The hasImmutabilityPolicy public property is set to true by SRP if ImmutabilityPolicy has been created for this container.
        /// The hasImmutabilityPolicy public property is set to false by SRP if ImmutabilityPolicy has not been created for this container.
        /// </summary>
        bool? HasImmutabilityPolicy { get; set; }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? HasLegalHold { get; set; }
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        int ImmutabilityPeriodSinceCreationInDay { get; set; }
        /// <summary>The ImmutabilityPolicy property of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperties ImmutabilityPolicy { get; set; }
        /// <summary>ImmutabilityPolicy Etag.</summary>
        string ImmutabilityPolicyEtag { get; set; }
        /// <summary>The properties of an ImmutabilityPolicy of a blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IImmutabilityPolicyProperty ImmutabilityPolicyProperty { get; set; }
        /// <summary>The ImmutabilityPolicy update history of the blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IUpdateHistoryProperty[] ImmutabilityPolicyUpdateHistory { get; set; }
        /// <summary>Returns the date and time the container was last modified.</summary>
        global::System.DateTime? LastModifiedTime { get; set; }
        /// <summary>
        /// Specifies whether the lease on a container is of infinite or fixed duration, only when the container is leased.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseDuration? LeaseDuration { get; set; }
        /// <summary>Lease state of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseState? LeaseState { get; set; }
        /// <summary>The lease status of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.LeaseStatus? LeaseStatus { get; set; }
        /// <summary>The LegalHold property of the container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ILegalHoldProperties LegalHold { get; set; }
        /// <summary>
        /// The hasLegalHold public property is set to true by SRP if there are at least one existing tag. The hasLegalHold public
        /// property is set to false by SRP if all existing legal hold tags are cleared out. There can be a maximum of 1000 blob containers
        /// with hasLegalHold=true for a given account.
        /// </summary>
        bool? LegalHoldHasLegalHold { get; set; }
        /// <summary>The list of LegalHold tags of a blob container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.ITagProperty[] LegalHoldTag { get; set; }
        /// <summary>A name-value pair to associate with the container as metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IContainerPropertiesMetadata Metadata { get; set; }
        /// <summary>
        /// Specifies whether data in the container may be accessed publicly and the level of access.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.PublicAccess? PublicAccess { get; set; }
        /// <summary>
        /// The ImmutabilityPolicy state of a blob container, possible values include: Locked and Unlocked.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ImmutabilityPolicyState? State { get; set; }

    }
}