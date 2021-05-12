namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes a blob input data source that contains reference data.</summary>
    public partial class BlobReferenceInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobReferenceInputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobReferenceInputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource __referenceInputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ReferenceInputDataSource();

        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string Container { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).Container; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).Container = value ?? null; }

        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DateFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).DateFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).DateFormat = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobReferenceInputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.BlobDataSourceProperties()); set { {_property = value;} } }

        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string PathPattern { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).PathPattern; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).PathPattern = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with a blob input containing reference data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.BlobDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).StorageAccount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).StorageAccount = value ?? null /* arrayOf */; }

        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TimeFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).TimeFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)Property).TimeFormat = value ?? null; }

        /// <summary>
        /// Indicates the type of input data source containing reference data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal)__referenceInputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal)__referenceInputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="BlobReferenceInputDataSource" /> instance.</summary>
        public BlobReferenceInputDataSource()
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
            await eventListener.AssertNotNull(nameof(__referenceInputDataSource), __referenceInputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__referenceInputDataSource), __referenceInputDataSource);
        }
    }
    /// Describes a blob input data source that contains reference data.
    public partial interface IBlobReferenceInputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSource
    {
        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of a container within the associated Storage account. This container contains either the blob(s) to be read from or written to. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"container",
        PossibleTypes = new [] { typeof(string) })]
        string Container { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.",
        SerializedName = @"dateFormat",
        PossibleTypes = new [] { typeof(string) })]
        string DateFormat { get; set; }
        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and example.",
        SerializedName = @"pathPattern",
        PossibleTypes = new [] { typeof(string) })]
        string PathPattern { get; set; }
        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"storageAccounts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.",
        SerializedName = @"timeFormat",
        PossibleTypes = new [] { typeof(string) })]
        string TimeFormat { get; set; }

    }
    /// Describes a blob input data source that contains reference data.
    internal partial interface IBlobReferenceInputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IReferenceInputDataSourceInternal
    {
        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string Container { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        string DateFormat { get; set; }
        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        string PathPattern { get; set; }
        /// <summary>
        /// The properties that are associated with a blob input containing reference data. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties Property { get; set; }
        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        string TimeFormat { get; set; }

    }
}