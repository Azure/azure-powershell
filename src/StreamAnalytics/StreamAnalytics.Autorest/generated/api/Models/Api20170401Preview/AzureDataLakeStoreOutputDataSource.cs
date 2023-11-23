namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes an Azure Data Lake Store output data source.</summary>
    public partial class AzureDataLakeStoreOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>
        /// The name of the Azure Data Lake Store account. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string AccountName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).AccountName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).AccountName = value ?? null; }

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>
        /// The date format. Wherever {date} appears in filePathPrefix, the value of this property is used as the date format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string DateFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).DateFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).DateFormat = value ?? null; }

        /// <summary>
        /// The location of the file to which the output should be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string FilePathPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).FilePathPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).FilePathPrefix = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with an Azure Data Lake Store output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureDataLakeStoreOutputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string RefreshToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).RefreshToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).RefreshToken = value ?? null; }

        /// <summary>
        /// The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).TenantId = value ?? null; }

        /// <summary>
        /// The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TimeFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).TimeFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourcePropertiesInternal)Property).TimeFormat = value ?? null; }

        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TokenUserDisplayName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).TokenUserDisplayName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).TokenUserDisplayName = value ?? null; }

        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string TokenUserPrincipalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).TokenUserPrincipalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOAuthBasedDataSourcePropertiesInternal)Property).TokenUserPrincipalName = value ?? null; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="AzureDataLakeStoreOutputDataSource" /> instance.</summary>
        public AzureDataLakeStoreOutputDataSource()
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
            await eventListener.AssertNotNull(nameof(__outputDataSource), __outputDataSource);
            await eventListener.AssertObjectIsValid(nameof(__outputDataSource), __outputDataSource);
        }
    }
    /// Describes an Azure Data Lake Store output data source.
    public partial interface IAzureDataLakeStoreOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
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
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source. A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value here when creating the data source and then going to the Azure Portal to authenticate the data source which will update this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.",
        SerializedName = @"refreshToken",
        PossibleTypes = new [] { typeof(string) })]
        string RefreshToken { get; set; }
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
        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user display name of the user that was used to obtain the refresh token. Use this property to help remember which user was used to obtain the refresh token.",
        SerializedName = @"tokenUserDisplayName",
        PossibleTypes = new [] { typeof(string) })]
        string TokenUserDisplayName { get; set; }
        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember which user was used to obtain the refresh token.",
        SerializedName = @"tokenUserPrincipalName",
        PossibleTypes = new [] { typeof(string) })]
        string TokenUserPrincipalName { get; set; }

    }
    /// Describes an Azure Data Lake Store output data source.
    internal partial interface IAzureDataLakeStoreOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
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
        /// The properties that are associated with an Azure Data Lake Store output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureDataLakeStoreOutputDataSourceProperties Property { get; set; }
        /// <summary>
        /// A refresh token that can be used to obtain a valid access token that can then be used to authenticate with the data source.
        /// A valid refresh token is currently only obtainable via the Azure Portal. It is recommended to put a dummy string value
        /// here when creating the data source and then going to the Azure Portal to authenticate the data source which will update
        /// this property with a valid refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string RefreshToken { get; set; }
        /// <summary>
        /// The tenant id of the user used to obtain the refresh token. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>
        /// The time format. Wherever {time} appears in filePathPrefix, the value of this property is used as the time format instead.
        /// </summary>
        string TimeFormat { get; set; }
        /// <summary>
        /// The user display name of the user that was used to obtain the refresh token. Use this property to help remember which
        /// user was used to obtain the refresh token.
        /// </summary>
        string TokenUserDisplayName { get; set; }
        /// <summary>
        /// The user principal name (UPN) of the user that was used to obtain the refresh token. Use this property to help remember
        /// which user was used to obtain the refresh token.
        /// </summary>
        string TokenUserPrincipalName { get; set; }

    }
}