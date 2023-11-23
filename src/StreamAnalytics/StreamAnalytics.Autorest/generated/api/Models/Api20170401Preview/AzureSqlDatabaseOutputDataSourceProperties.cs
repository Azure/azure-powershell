namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an Azure SQL database output.</summary>
    public partial class AzureSqlDatabaseOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseOutputDataSourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties __azureSqlDatabaseDataSourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSqlDatabaseDataSourceProperties();

        /// <summary>Authentication Mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode? AuthenticationMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).AuthenticationMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).AuthenticationMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.AuthenticationMode)""); }

        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Database = value ?? null; }

        /// <summary>
        /// Max Batch count for write to Sql database, the default value is 10,000. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public float? MaxBatchCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).MaxBatchCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).MaxBatchCount = value ?? default(float); }

        /// <summary>
        /// Max Write r count, currently only 1(single writer) and 0(based on query partition) are available. Optional on PUT requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public float? MaxWriterCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).MaxWriterCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).MaxWriterCount = value ?? default(float); }

        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Password = value ?? null; }

        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Server { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Server; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Server = value ?? null; }

        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Table { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).Table = value ?? null; }

        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string User { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).User; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal)__azureSqlDatabaseDataSourceProperties).User = value ?? null; }

        /// <summary>
        /// Creates an new <see cref="AzureSqlDatabaseOutputDataSourceProperties" /> instance.
        /// </summary>
        public AzureSqlDatabaseOutputDataSourceProperties()
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
            await eventListener.AssertNotNull(nameof(__azureSqlDatabaseDataSourceProperties), __azureSqlDatabaseDataSourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__azureSqlDatabaseDataSourceProperties), __azureSqlDatabaseDataSourceProperties);
        }
    }
    /// The properties that are associated with an Azure SQL database output.
    public partial interface IAzureSqlDatabaseOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourceProperties
    {

    }
    /// The properties that are associated with an Azure SQL database output.
    internal partial interface IAzureSqlDatabaseOutputDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSqlDatabaseDataSourcePropertiesInternal
    {

    }
}