namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a blob input containing reference data.</summary>
    public partial class BlobReferenceInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobReferenceInputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobReferenceInputDataSourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties __blobDataSourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.BlobDataSourceProperties();

        /// <summary>
        /// The name of a container within the associated Storage account. This container contains either the blob(s) to be read from
        /// or written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Container { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).Container; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).Container = value ?? null; }

        /// <summary>
        /// The date format. Wherever {date} appears in pathPattern, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string DateFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).DateFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).DateFormat = value ?? null; }

        /// <summary>
        /// The blob path pattern. Not a regular expression. It represents a pattern against which blob names will be matched to determine
        /// whether or not they should be included as input or output to the job. See https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-input
        /// or https://docs.microsoft.com/en-us/rest/api/streamanalytics/stream-analytics-output for a more detailed explanation and
        /// example.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string PathPattern { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).PathPattern; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).PathPattern = value ?? null; }

        /// <summary>
        /// A list of one or more Azure Storage accounts. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IStorageAccount[] StorageAccount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).StorageAccount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).StorageAccount = value ?? null /* arrayOf */; }

        /// <summary>
        /// The time format. Wherever {time} appears in pathPattern, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string TimeFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).TimeFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal)__blobDataSourceProperties).TimeFormat = value ?? null; }

        /// <summary>Creates an new <see cref="BlobReferenceInputDataSourceProperties" /> instance.</summary>
        public BlobReferenceInputDataSourceProperties()
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
            await eventListener.AssertNotNull(nameof(__blobDataSourceProperties), __blobDataSourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__blobDataSourceProperties), __blobDataSourceProperties);
        }
    }
    /// The properties that are associated with a blob input containing reference data.
    public partial interface IBlobReferenceInputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourceProperties
    {

    }
    /// The properties that are associated with a blob input containing reference data.
    internal partial interface IBlobReferenceInputDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IBlobDataSourcePropertiesInternal
    {

    }
}