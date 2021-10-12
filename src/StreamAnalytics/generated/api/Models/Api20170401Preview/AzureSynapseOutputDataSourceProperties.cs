namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with an Azure Synapse output.</summary>
    public partial class AzureSynapseOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseOutputDataSourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseOutputDataSourcePropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourceProperties __azureSynapseDataSourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureSynapseDataSourceProperties();

        /// <summary>The name of the Azure SQL database. Required on PUT (CreateOrReplace) requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Database { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Database; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Database = value ?? null; }

        /// <summary>
        /// The password that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Password = value ?? null; }

        /// <summary>
        /// The name of the SQL server containing the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Server { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Server; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Server = value ?? null; }

        /// <summary>
        /// The name of the table in the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Table { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Table; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).Table = value ?? null; }

        /// <summary>
        /// The user name that will be used to connect to the Azure SQL database. Required on PUT (CreateOrReplace) requests.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string User { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).User; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal)__azureSynapseDataSourceProperties).User = value ?? null; }

        /// <summary>Creates an new <see cref="AzureSynapseOutputDataSourceProperties" /> instance.</summary>
        public AzureSynapseOutputDataSourceProperties()
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
            await eventListener.AssertNotNull(nameof(__azureSynapseDataSourceProperties), __azureSynapseDataSourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__azureSynapseDataSourceProperties), __azureSynapseDataSourceProperties);
        }
    }
    /// The properties that are associated with an Azure Synapse output.
    public partial interface IAzureSynapseOutputDataSourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourceProperties
    {

    }
    /// The properties that are associated with an Azure Synapse output.
    internal partial interface IAzureSynapseOutputDataSourcePropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureSynapseDataSourcePropertiesInternal
    {

    }
}