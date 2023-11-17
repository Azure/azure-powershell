namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class DefaultRolloutProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal
    {

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] CanaryRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).CanaryRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).CanaryRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] CanarySkipRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).CanarySkipRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).CanarySkipRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] HighTrafficRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTrafficRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTrafficRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? HighTrafficWaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTrafficWaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTrafficWaitDuration = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] LowTrafficRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTrafficRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTrafficRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? LowTrafficWaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTrafficWaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTrafficWaitDuration = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] MediumTrafficRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTrafficRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTrafficRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? MediumTrafficWaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTrafficWaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTrafficWaitDuration = value ?? default(global::System.TimeSpan); }

        /// <summary>Internal Acessors for Specification</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.Specification { get => (this._specification = this._specification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutSpecification()); set { {_specification = value;} } }

        /// <summary>Internal Acessors for SpecificationCanary</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationCanary { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).Canary; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).Canary = value; }

        /// <summary>Internal Acessors for SpecificationHighTraffic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationHighTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).HighTraffic = value; }

        /// <summary>Internal Acessors for SpecificationLowTraffic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationLowTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).LowTraffic = value; }

        /// <summary>Internal Acessors for SpecificationMediumTraffic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationMediumTraffic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTraffic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).MediumTraffic = value; }

        /// <summary>Internal Acessors for SpecificationRestOfTheWorldGroupOne</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationRestOfTheWorldGroupOne { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOne; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOne = value; }

        /// <summary>Internal Acessors for SpecificationRestOfTheWorldGroupTwo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.SpecificationRestOfTheWorldGroupTwo { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwo; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwo = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutPropertiesInternal.Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutStatus()); set { {_status = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] RestOfTheWorldGroupOneRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOneRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOneRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? RestOfTheWorldGroupOneWaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOneWaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupOneWaitDuration = value ?? default(global::System.TimeSpan); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] RestOfTheWorldGroupTwoRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwoRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwoRegion = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.TimeSpan? RestOfTheWorldGroupTwoWaitDuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwoWaitDuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).RestOfTheWorldGroupTwoWaitDuration = value ?? default(global::System.TimeSpan); }

        /// <summary>Backing field for <see cref="Specification" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification _specification;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification Specification { get => (this._specification = this._specification ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutSpecification()); set => this._specification = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration SpecificationProviderRegistration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).ProviderRegistration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).ProviderRegistration = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] SpecificationResourceTypeRegistration { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).ResourceTypeRegistration; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecificationInternal)Specification).ResourceTypeRegistration = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus _status;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus Status { get => (this._status = this._status ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.DefaultRolloutStatus()); set => this._status = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string[] StatusCompletedRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseInternal)Status).CompletedRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseInternal)Status).CompletedRegion = value ?? null /* arrayOf */; }

        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions StatusFailedOrSkippedRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseInternal)Status).FailedOrSkippedRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseInternal)Status).FailedOrSkippedRegion = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory? StatusNextTrafficRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).NextTrafficRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).NextTrafficRegion = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public global::System.DateTime? StatusNextTrafficRegionScheduledTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).NextTrafficRegionScheduledTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).NextTrafficRegionScheduledTime = value ?? default(global::System.DateTime); }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult? StatusSubscriptionReregistrationResult { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).SubscriptionReregistrationResult; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatusInternal)Status).SubscriptionReregistrationResult = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult)""); }

        /// <summary>Creates an new <see cref="DefaultRolloutProperties" /> instance.</summary>
        public DefaultRolloutProperties()
        {

        }
    }
    public partial interface IDefaultRolloutProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] CanaryRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"skipRegions",
        PossibleTypes = new [] { typeof(string) })]
        string[] CanarySkipRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] HighTrafficRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? HighTrafficWaitDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] LowTrafficRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? LowTrafficWaitDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] MediumTrafficRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? MediumTrafficWaitDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] RestOfTheWorldGroupOneRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? RestOfTheWorldGroupOneWaitDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"regions",
        PossibleTypes = new [] { typeof(string) })]
        string[] RestOfTheWorldGroupTwoRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"waitDuration",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? RestOfTheWorldGroupTwoWaitDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"providerRegistration",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration SpecificationProviderRegistration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceTypeRegistrations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] SpecificationResourceTypeRegistration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"completedRegions",
        PossibleTypes = new [] { typeof(string) })]
        string[] StatusCompletedRegion { get; set; }
        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <ExtendedErrorInfo>",
        SerializedName = @"failedOrSkippedRegions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions StatusFailedOrSkippedRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nextTrafficRegion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory? StatusNextTrafficRegion { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"nextTrafficRegionScheduledTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StatusNextTrafficRegionScheduledTime { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"subscriptionReregistrationResult",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult? StatusSubscriptionReregistrationResult { get; set; }

    }
    internal partial interface IDefaultRolloutPropertiesInternal

    {
        string[] CanaryRegion { get; set; }

        string[] CanarySkipRegion { get; set; }

        string[] HighTrafficRegion { get; set; }

        global::System.TimeSpan? HighTrafficWaitDuration { get; set; }

        string[] LowTrafficRegion { get; set; }

        global::System.TimeSpan? LowTrafficWaitDuration { get; set; }

        string[] MediumTrafficRegion { get; set; }

        global::System.TimeSpan? MediumTrafficWaitDuration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.ProvisioningState? ProvisioningState { get; set; }

        string[] RestOfTheWorldGroupOneRegion { get; set; }

        global::System.TimeSpan? RestOfTheWorldGroupOneWaitDuration { get; set; }

        string[] RestOfTheWorldGroupTwoRegion { get; set; }

        global::System.TimeSpan? RestOfTheWorldGroupTwoWaitDuration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutSpecification Specification { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ICanaryTrafficRegionRolloutConfiguration SpecificationCanary { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration SpecificationHighTraffic { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration SpecificationLowTraffic { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration SpecificationMediumTraffic { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IProviderRegistration SpecificationProviderRegistration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceTypeRegistration[] SpecificationResourceTypeRegistration { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration SpecificationRestOfTheWorldGroupOne { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ITrafficRegionRolloutConfiguration SpecificationRestOfTheWorldGroupTwo { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IDefaultRolloutStatus Status { get; set; }

        string[] StatusCompletedRegion { get; set; }
        /// <summary>Dictionary of <ExtendedErrorInfo></summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IRolloutStatusBaseFailedOrSkippedRegions StatusFailedOrSkippedRegion { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.TrafficRegionCategory? StatusNextTrafficRegion { get; set; }

        global::System.DateTime? StatusNextTrafficRegionScheduledTime { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionReregistrationResult? StatusSubscriptionReregistrationResult { get; set; }

    }
}