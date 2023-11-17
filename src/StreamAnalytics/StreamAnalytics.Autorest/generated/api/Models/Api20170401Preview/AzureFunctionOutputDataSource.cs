namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Defines the metadata of AzureFunctionOutputDataSource</summary>
    public partial class AzureFunctionOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSource,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource __outputDataSource = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.OutputDataSource();

        /// <summary>
        /// If you want to use an Azure Function from another subscription, you can do so by providing the key to access your function.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string ApiKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).ApiKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).ApiKey = value ?? null; }

        /// <summary>The name of your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string FunctionAppName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).FunctionAppName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).FunctionAppName = value ?? null; }

        /// <summary>The name of the function in your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public string FunctionName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).FunctionName; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).FunctionName = value ?? null; }

        /// <summary>
        /// A property that lets you specify the maximum number of events in each batch that's sent to Azure Functions. The default
        /// value is 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public float? MaxBatchCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).MaxBatchCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).MaxBatchCount = value ?? default(float); }

        /// <summary>
        /// A property that lets you set the maximum size for each output batch that's sent to your Azure function. The input unit
        /// is in bytes. By default, this value is 262,144 bytes (256 KB).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inlined)]
        public float? MaxBatchSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).MaxBatchSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal)Property).MaxBatchSize = value ?? default(float); }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceProperties Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureFunctionOutputDataSourceProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceProperties _property;

        /// <summary>
        /// The properties that are associated with a Azure Function output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureFunctionOutputDataSourceProperties()); set => this._property = value; }

        /// <summary>
        /// Indicates the type of data source output will be written to. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal)__outputDataSource).Type = value ; }

        /// <summary>Creates an new <see cref="AzureFunctionOutputDataSource" /> instance.</summary>
        public AzureFunctionOutputDataSource()
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
    /// Defines the metadata of AzureFunctionOutputDataSource
    public partial interface IAzureFunctionOutputDataSource :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSource
    {
        /// <summary>
        /// If you want to use an Azure Function from another subscription, you can do so by providing the key to access your function.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If you want to use an Azure Function from another subscription, you can do so by providing the key to access your function.",
        SerializedName = @"apiKey",
        PossibleTypes = new [] { typeof(string) })]
        string ApiKey { get; set; }
        /// <summary>The name of your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of your Azure Functions app.",
        SerializedName = @"functionAppName",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionAppName { get; set; }
        /// <summary>The name of the function in your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the function in your Azure Functions app.",
        SerializedName = @"functionName",
        PossibleTypes = new [] { typeof(string) })]
        string FunctionName { get; set; }
        /// <summary>
        /// A property that lets you specify the maximum number of events in each batch that's sent to Azure Functions. The default
        /// value is 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A property that lets you specify the maximum number of events in each batch that's sent to Azure Functions. The default value is 100.",
        SerializedName = @"maxBatchCount",
        PossibleTypes = new [] { typeof(float) })]
        float? MaxBatchCount { get; set; }
        /// <summary>
        /// A property that lets you set the maximum size for each output batch that's sent to your Azure function. The input unit
        /// is in bytes. By default, this value is 262,144 bytes (256 KB).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A property that lets you set the maximum size for each output batch that's sent to your Azure function. The input unit is in bytes. By default, this value is 262,144 bytes (256 KB).",
        SerializedName = @"maxBatchSize",
        PossibleTypes = new [] { typeof(float) })]
        float? MaxBatchSize { get; set; }

    }
    /// Defines the metadata of AzureFunctionOutputDataSource
    internal partial interface IAzureFunctionOutputDataSourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutputDataSourceInternal
    {
        /// <summary>
        /// If you want to use an Azure Function from another subscription, you can do so by providing the key to access your function.
        /// </summary>
        string ApiKey { get; set; }
        /// <summary>The name of your Azure Functions app.</summary>
        string FunctionAppName { get; set; }
        /// <summary>The name of the function in your Azure Functions app.</summary>
        string FunctionName { get; set; }
        /// <summary>
        /// A property that lets you specify the maximum number of events in each batch that's sent to Azure Functions. The default
        /// value is 100.
        /// </summary>
        float? MaxBatchCount { get; set; }
        /// <summary>
        /// A property that lets you set the maximum size for each output batch that's sent to your Azure function. The input unit
        /// is in bytes. By default, this value is 262,144 bytes (256 KB).
        /// </summary>
        float? MaxBatchSize { get; set; }
        /// <summary>
        /// The properties that are associated with a Azure Function output. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceProperties Property { get; set; }

    }
}