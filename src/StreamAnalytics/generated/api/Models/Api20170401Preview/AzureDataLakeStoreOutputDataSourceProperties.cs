namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an Azure Data Lake Store.</summary>
    public partial class AzureDataLakeStoreOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourceProperties __oAuthBasedDataSourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OAuthBasedDataSourceProperties();

        /// <summary>Backing field for <see cref="AccountName" /> property.</summary>
        private string _accountName;

        /// <summary>
        /// The name of the Azure Data Lake Store account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string AccountName { get => this._accountName; set => this._accountName = value; }

        /// <summary>Backing field for <see cref="AuthenticationMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? _authenticationMode;

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => this._authenticationMode; set => this._authenticationMode = value; }

        /// <summary>Backing field for <see cref="DateFormat" /> property.</summary>
        private string _dateFormat;

        /// <summary>
        /// The date format. Wherever {date} appears in filePathPrefix, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DateFormat { get => this._dateFormat; set => this._dateFormat = value; }

        /// <summary>Backing field for <see cref="FilePathPrefix" /> property.</summary>
        private string _filePathPrefix;

        /// <summary>
        /// The location of the file to which the output should be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string FilePathPrefix { get => this._filePathPrefix; set => this._filePathPrefix = value; }

        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string RefreshToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).RefreshToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).RefreshToken = value ?? null; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Backing field for <see cref="TimeFormat" /> property.</summary>
        private string _timeFormat;

        /// <summary>
        /// The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string TimeFormat { get => this._timeFormat; set => this._timeFormat = value; }

        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string TokenUserDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).TokenUserDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).TokenUserDisplayName = value ?? null; }

        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string TokenUserPrincipalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).TokenUserPrincipalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)__oAuthBasedDataSourceProperties).TokenUserPrincipalName = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="AzureDataLakeStoreOutputDataSourceProperties" /> instance.
        /// </summary>
        public AzureDataLakeStoreOutputDataSourceProperties()
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
            await eventListener.AssertNotNull(nameof(__oAuthBasedDataSourceProperties), __oAuthBasedDataSourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__oAuthBasedDataSourceProperties), __oAuthBasedDataSourceProperties);
        }
    }
    /// The properties that are associated with an Azure Data Lake Store.
    public partial interface IAzureDataLakeStoreOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourceProperties
    {
        /// <summary>
        /// The name of the Azure Data Lake Store account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the Azure Data Lake Store account. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"accountName",
        PossibleTypes = new [] { typeof(string) })]
        string AccountName { get; set; }
        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Authentication Mode.",
        SerializedName = @"authenticationMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in filePathPrefix, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The date format. Wherever {date} appears in filePathPrefix, the value of this property is used as the date format instead.",
        SerializedName = @"dateFormat",
        PossibleTypes = new [] { typeof(string) })]
        string DateFormat { get; set; }
        /// <summary>
        /// The location of the file to which the output should be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The location of the file to which the output should be written to. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"filePathPrefix",
        PossibleTypes = new [] { typeof(string) })]
        string FilePathPrefix { get; set; }
        /// <summary>
        /// The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.",
        SerializedName = @"timeFormat",
        PossibleTypes = new [] { typeof(string) })]
        string TimeFormat { get; set; }

    }
    /// The properties that are associated with an Azure Data Lake Store.
    internal partial interface IAzureDataLakeStoreOutputDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal
    {
        /// <summary>
        /// The name of the Azure Data Lake Store account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string AccountName { get; set; }
        /// <summary>Authentication Mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get; set; }
        /// <summary>
        /// The date format. Wherever {date} appears in filePathPrefix, the value of this property is used as the date format instead.
        /// </summary>
        string DateFormat { get; set; }
        /// <summary>
        /// The location of the file to which the output should be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string FilePathPrefix { get; set; }
        /// <summary>
        /// The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.
        /// </summary>
        string TimeFormat { get; set; }

    }
}