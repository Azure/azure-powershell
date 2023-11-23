namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a DocumentDB output.</summary>
    public partial class AzureFunctionOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureFunctionOutputDataSourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ApiKey" /> property.</summary>
        private string _apiKey;

        /// <summary>
        /// If you want to use an Azure Function from another subscription, you can do so by providing the key to access your function.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string ApiKey { get => this._apiKey; set => this._apiKey = value; }

        /// <summary>Backing field for <see cref="FunctionAppName" /> property.</summary>
        private string _functionAppName;

        /// <summary>The name of your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string FunctionAppName { get => this._functionAppName; set => this._functionAppName = value; }

        /// <summary>Backing field for <see cref="FunctionName" /> property.</summary>
        private string _functionName;

        /// <summary>The name of the function in your Azure Functions app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string FunctionName { get => this._functionName; set => this._functionName = value; }

        /// <summary>Backing field for <see cref="MaxBatchCount" /> property.</summary>
        private float? _maxBatchCount;

        /// <summary>
        /// A property that lets you specify the maximum number of events in each batch that's sent to Azure Functions. The default
        /// value is 100.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public float? MaxBatchCount { get => this._maxBatchCount; set => this._maxBatchCount = value; }

        /// <summary>Backing field for <see cref="MaxBatchSize" /> property.</summary>
        private float? _maxBatchSize;

        /// <summary>
        /// A property that lets you set the maximum size for each output batch that's sent to your Azure function. The input unit
        /// is in bytes. By default, this value is 262,144 bytes (256 KB).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public float? MaxBatchSize { get => this._maxBatchSize; set => this._maxBatchSize = value; }

        /// <summary>Creates an new <see cref="AzureFunctionOutputDataSourceProperties" /> instance.</summary>
        public AzureFunctionOutputDataSourceProperties()
        {

        }
    }
    /// The properties that are associated with a DocumentDB output.
    public partial interface IAzureFunctionOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
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
    /// The properties that are associated with a DocumentDB output.
    internal partial interface IAzureFunctionOutputDataSourcePropertiesInternal

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

    }
}