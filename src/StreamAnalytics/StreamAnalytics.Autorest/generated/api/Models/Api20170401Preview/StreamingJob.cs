namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// A streaming job object, containing all information associated with the named streaming job.
    /// </summary>
    public partial class StreamingJob :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJob,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IHeaderSerializable
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.TrackedResource();

        /// <summary>The resource id of cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ClusterId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ClusterId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ClusterId = value ?? null; }

        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).CompatibilityLevel; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).CompatibilityLevel = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel)""); }

        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ContentStoragePolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ContentStoragePolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy)""); }

        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public global::System.DateTime? CreatedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).CreatedDate; }

        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DataLocale { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).DataLocale; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).DataLocale = value ?? null; }

        /// <summary>Backing field for <see cref="ETag" /> property.</summary>
        private string _eTag;

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ETag { get => this._eTag; set => this._eTag = value; }

        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? EventsLateArrivalMaxDelayInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsLateArrivalMaxDelayInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsLateArrivalMaxDelayInSecond = value ?? default(int); }

        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? EventsOutOfOrderMaxDelayInSecond { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsOutOfOrderMaxDelayInSecond; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsOutOfOrderMaxDelayInSecond = value ?? default(int); }

        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsOutOfOrderPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).EventsOutOfOrderPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy)""); }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ExternalContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalContainer = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ExternalPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalPath = value ?? null; }

        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Function; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Function = value ?? null /* arrayOf */; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentity _identity;

        /// <summary>
        /// Describes the system-assigned managed identity assigned to this job that can be used to authenticate with inputs and outputs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Identity()); set => this._identity = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).PrincipalId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).TenantId = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentityInternal)Identity).Type = value ?? null; }

        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Input; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Input = value ?? null /* arrayOf */; }

        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobId; }

        /// <summary>Describes the state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobState; }

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountAuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountAuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobStorageAccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountKey = value ?? null; }

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string JobStorageAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccountName = value ?? null; }

        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType)""); }

        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastOutputEventTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).LastOutputEventTime; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for Cluster</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.Cluster { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Cluster; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Cluster = value; }

        /// <summary>Internal Acessors for CreatedDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.CreatedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).CreatedDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).CreatedDate = value; }

        /// <summary>Internal Acessors for External</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.External { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).External; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).External = value; }

        /// <summary>Internal Acessors for ExternalStorageAccount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.ExternalStorageAccount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalStorageAccount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ExternalStorageAccount = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentity Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.Identity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for JobId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.JobId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobId = value; }

        /// <summary>Internal Acessors for JobState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.JobState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobState = value; }

        /// <summary>Internal Acessors for JobStorageAccount</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.JobStorageAccount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).JobStorageAccount = value; }

        /// <summary>Internal Acessors for LastOutputEventTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.LastOutputEventTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).LastOutputEventTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).LastOutputEventTime = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamingJobProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Sku = value; }

        /// <summary>Internal Acessors for Transformation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.Transformation { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Transformation; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Transformation = value; }

        /// <summary>Internal Acessors for TransformationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.TransformationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationId = value; }

        /// <summary>Internal Acessors for TransformationName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.TransformationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationName = value; }

        /// <summary>Internal Acessors for TransformationProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.TransformationProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationProperty = value; }

        /// <summary>Internal Acessors for TransformationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal.TransformationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationType = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Name; }

        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Output; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Output = value ?? null /* arrayOf */; }

        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputErrorPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputErrorPolicy = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy)""); }

        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputStartMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputStartMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode)""); }

        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public global::System.DateTime? OutputStartTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputStartTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).OutputStartTime = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties _property;

        /// <summary>
        /// The properties that are associated with a streaming job. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.StreamingJobProperties()); set => this._property = value; }

        /// <summary>Describes the provisioning status of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Query { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Query; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).Query = value ?? null; }

        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).SkuName = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName)""); }

        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string StorageAccountKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StorageAccountKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StorageAccountKey = value ?? null; }

        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string StorageAccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StorageAccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StorageAccountName = value ?? null; }

        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public int? StreamingUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StreamingUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).StreamingUnit = value ?? default(int); }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationETag = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationId; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationName; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TransformationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobPropertiesInternal)Property).TransformationType; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.IResourceInternal)__trackedResource).Type; }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("ETag", out var __eTagHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal)this).ETag = System.Linq.Enumerable.FirstOrDefault(__eTagHeader0) is string __headerETagHeader0 ? __headerETagHeader0 : (string)null;
            }
            if (headers.TryGetValues("ETag", out var __eTagHeader1))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobInternal)this).TransformationETag = System.Linq.Enumerable.FirstOrDefault(__eTagHeader1) is string __headerETagHeader1 ? __headerETagHeader1 : (string)null;
            }
        }

        /// <summary>Creates an new <see cref="StreamingJob" /> instance.</summary>
        public StreamingJob()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// A streaming job object, containing all information associated with the named streaming job.
    public partial interface IStreamingJob :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResource
    {
        /// <summary>The resource id of cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of cluster.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterId { get; set; }
        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Controls certain runtime behaviors of the streaming job.",
        SerializedName = @"compatibilityLevel",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get; set; }
        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify jobStorageAccount property. .",
        SerializedName = @"contentStoragePolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get; set; }
        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.",
        SerializedName = @"createdDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CreatedDate { get;  }
        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx. Defaults to 'en-US' if none specified.",
        SerializedName = @"dataLocale",
        PossibleTypes = new [] { typeof(string) })]
        string DataLocale { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ETag",
        PossibleTypes = new [] { typeof(string) })]
        string ETag { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum tolerable delay in seconds where events arriving late could be included.  Supported range is -1 to 1814399 (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a value of -1.",
        SerializedName = @"eventsLateArrivalMaxDelayInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? EventsLateArrivalMaxDelayInSecond { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.",
        SerializedName = @"eventsOutOfOrderMaxDelayInSeconds",
        PossibleTypes = new [] { typeof(int) })]
        int? EventsOutOfOrderMaxDelayInSecond { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the policy to apply to events that arrive out of order in the input event stream.",
        SerializedName = @"eventsOutOfOrderPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalContainer { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalPath { get; set; }
        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more functions for the streaming job. The name property for each function is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual transformation.",
        SerializedName = @"functions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityType { get; set; }
        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual input.",
        SerializedName = @"inputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get; set; }
        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.",
        SerializedName = @"jobId",
        PossibleTypes = new [] { typeof(string) })]
        string JobId { get;  }
        /// <summary>Describes the state of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Describes the state of the streaming job.",
        SerializedName = @"jobState",
        PossibleTypes = new [] { typeof(string) })]
        string JobState { get;  }
        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication Mode.",
        SerializedName = @"authenticationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string JobStorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string JobStorageAccountName { get; set; }
        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the type of the job. Valid modes are `Cloud` and 'Edge'.",
        SerializedName = @"jobType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in that set.",
        SerializedName = @"lastOutputEventTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastOutputEventTime { get;  }
        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more outputs for the streaming job. The name property for each output is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual output.",
        SerializedName = @"outputs",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to being malformed (missing column values, column values of wrong type or size).",
        SerializedName = @"outputErrorPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get; set; }
        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"This property should only be utilized when it is desired that the job be started immediately upon creation. Value may be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property, or start from the last event output time.",
        SerializedName = @"outputStartMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null to indicate that the output event stream will start whenever the streaming job is started. This property must have a value if outputStartMode is set to CustomTime.",
        SerializedName = @"outputStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? OutputStartTime { get; set; }
        /// <summary>Describes the provisioning status of the streaming job.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Describes the provisioning status of the streaming job.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"query",
        PossibleTypes = new [] { typeof(string) })]
        string Query { get; set; }
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the SKU. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountKey",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountName { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of streaming units that the streaming job uses.",
        SerializedName = @"streamingUnits",
        PossibleTypes = new [] { typeof(int) })]
        int? StreamingUnit { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ETag",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationETag { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationId { get;  }
        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationName { get;  }
        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string TransformationType { get;  }

    }
    /// A streaming job object, containing all information associated with the named streaming job.
    internal partial interface IStreamingJobInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.ApiV1.ITrackedResourceInternal
    {
        /// <summary>The cluster which streaming jobs will run on.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IClusterInfo Cluster { get; set; }
        /// <summary>The resource id of cluster.</summary>
        string ClusterId { get; set; }
        /// <summary>Controls certain runtime behaviors of the streaming job.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.CompatibilityLevel? CompatibilityLevel { get; set; }
        /// <summary>
        /// Valid values are JobStorageAccount and SystemAccount. If set to JobStorageAccount, this requires the user to also specify
        /// jobStorageAccount property. .
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.ContentStoragePolicy? ContentStoragePolicy { get; set; }
        /// <summary>
        /// Value is an ISO-8601 formatted UTC timestamp indicating when the streaming job was created.
        /// </summary>
        global::System.DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The data locale of the stream analytics job. Value should be the name of a supported .NET Culture from the set https://msdn.microsoft.com/en-us/library/system.globalization.culturetypes(v=vs.110).aspx.
        /// Defaults to 'en-US' if none specified.
        /// </summary>
        string DataLocale { get; set; }

        string ETag { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where events arriving late could be included. Supported range is -1 to 1814399
        /// (20.23:59:59 days) and -1 is used to specify wait indefinitely. If the property is absent, it is interpreted to have a
        /// value of -1.
        /// </summary>
        int? EventsLateArrivalMaxDelayInSecond { get; set; }
        /// <summary>
        /// The maximum tolerable delay in seconds where out-of-order events can be adjusted to be back in order.
        /// </summary>
        int? EventsOutOfOrderMaxDelayInSecond { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive out of order in the input event stream.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.EventsOutOfOrderPolicy? EventsOutOfOrderPolicy { get; set; }
        /// <summary>The storage account where the custom code artifacts are located.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IExternal External { get; set; }

        string ExternalContainer { get; set; }

        string ExternalPath { get; set; }
        /// <summary>The properties that are associated with an Azure Storage account</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount ExternalStorageAccount { get; set; }
        /// <summary>
        /// A list of one or more functions for the streaming job. The name property for each function is required when specifying
        /// this property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual transformation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunction[] Function { get; set; }
        /// <summary>
        /// Describes the system-assigned managed identity assigned to this job that can be used to authenticate with inputs and outputs.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IIdentity Identity { get; set; }

        string IdentityPrincipalId { get; set; }

        string IdentityTenantId { get; set; }

        string IdentityType { get; set; }
        /// <summary>
        /// A list of one or more inputs to the streaming job. The name property for each input is required when specifying this property
        /// in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available for the individual
        /// input.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput[] Input { get; set; }
        /// <summary>
        /// A GUID uniquely identifying the streaming job. This GUID is generated upon creation of the streaming job.
        /// </summary>
        string JobId { get; set; }
        /// <summary>Describes the state of the streaming job.</summary>
        string JobState { get; set; }
        /// <summary>The properties that are associated with an Azure Storage account with MSI</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IJobStorageAccount JobStorageAccount { get; set; }
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? JobStorageAccountAuthenticationMode { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string JobStorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string JobStorageAccountName { get; set; }
        /// <summary>Describes the type of the job. Valid modes are `Cloud` and 'Edge'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.JobType? JobType { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted timestamp indicating the last output event time of the streaming job or null indicating
        /// that output has not yet been produced. In case of multiple outputs or multiple streams, this shows the latest value in
        /// that set.
        /// </summary>
        global::System.DateTime? LastOutputEventTime { get; set; }
        /// <summary>
        /// A list of one or more outputs for the streaming job. The name property for each output is required when specifying this
        /// property in a PUT request. This property cannot be modify via a PATCH operation. You must use the PATCH API available
        /// for the individual output.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput[] Output { get; set; }
        /// <summary>
        /// Indicates the policy to apply to events that arrive at the output and cannot be written to the external storage due to
        /// being malformed (missing column values, column values of wrong type or size).
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputErrorPolicy? OutputErrorPolicy { get; set; }
        /// <summary>
        /// This property should only be utilized when it is desired that the job be started immediately upon creation. Value may
        /// be JobStartTime, CustomTime, or LastOutputEventTime to indicate whether the starting point of the output event stream
        /// should start whenever the job is started, start at a custom user time stamp specified via the outputStartTime property,
        /// or start from the last event output time.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.OutputStartMode? OutputStartMode { get; set; }
        /// <summary>
        /// Value is either an ISO-8601 formatted time stamp that indicates the starting point of the output event stream, or null
        /// to indicate that the output event stream will start whenever the streaming job is started. This property must have a value
        /// if outputStartMode is set to CustomTime.
        /// </summary>
        global::System.DateTime? OutputStartTime { get; set; }
        /// <summary>
        /// The properties that are associated with a streaming job. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobProperties Property { get; set; }
        /// <summary>Describes the provisioning status of the streaming job.</summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Specifies the query that will be run in the streaming job. You can learn more about the Stream Analytics Query Language
        /// (SAQL) here: https://msdn.microsoft.com/library/azure/dn834998 . Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Query { get; set; }
        /// <summary>
        /// Describes the SKU of the streaming job. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStreamingJobSku Sku { get; set; }
        /// <summary>The name of the SKU. Required on PUT (CreateOrReplace) requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.StreamingJobSkuName? SkuName { get; set; }
        /// <summary>
        /// The account key for the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string StorageAccountKey { get; set; }
        /// <summary>
        /// The name of the Azure Storage account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string StorageAccountName { get; set; }
        /// <summary>Specifies the number of streaming units that the streaming job uses.</summary>
        int? StreamingUnit { get; set; }
        /// <summary>
        /// Indicates the query and the number of streaming units to use for the streaming job. The name property of the transformation
        /// is required when specifying this property in a PUT request. This property cannot be modify via a PATCH operation. You
        /// must use the PATCH API available for the individual transformation.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformation Transformation { get; set; }

        string TransformationETag { get; set; }
        /// <summary>Resource Id</summary>
        string TransformationId { get; set; }
        /// <summary>Resource name</summary>
        string TransformationName { get; set; }
        /// <summary>
        /// The properties that are associated with a transformation. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ITransformationProperties TransformationProperty { get; set; }
        /// <summary>Resource type</summary>
        string TransformationType { get; set; }

    }
}