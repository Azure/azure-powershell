namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing an Event Grid data connection.</summary>
    public partial class EventGridDataConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridDataConnection,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridDataConnectionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection __dataConnection = new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DataConnection();

        /// <summary>The name of blob storage event type to process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType? BlobStorageEventType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).BlobStorageEventType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).BlobStorageEventType = value; }

        /// <summary>The event hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string ConsumerGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).ConsumerGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).ConsumerGroup = value; }

        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat? DataFormat { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).DataFormat; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).DataFormat = value; }

        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string EventHubResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).EventHubResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).EventHubResourceId = value; }

        /// <summary>
        /// Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Id; }

        /// <summary>
        /// A Boolean value that, if set to true, indicates that ingestion should ignore the first record of every file
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public bool? IgnoreFirstRecord { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).IgnoreFirstRecord; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).IgnoreFirstRecord = value; }

        /// <summary>Kind of the endpoint for the data connection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Kind Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)__dataConnection).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)__dataConnection).Kind = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)__dataConnection).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal)__dataConnection).Location = value; }

        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string MappingRuleName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).MappingRuleName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).MappingRuleName = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionProperties Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridDataConnectionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventGridConnectionProperties()); set { {_property = value;} } }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionProperties _property;

        /// <summary>The properties of the Event Grid data connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.EventGridConnectionProperties()); set => this._property = value; }

        /// <summary>The resource ID of the storage account where the data resides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string StorageAccountResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).StorageAccountResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).StorageAccountResourceId = value; }

        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public string TableName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).TableName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionPropertiesInternal)Property).TableName = value; }

        /// <summary>
        /// The type of the resource. Ex- Microsoft.Compute/virtualMachines or Microsoft.Storage/storageAccounts.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api10.IResourceInternal)__dataConnection).Type; }

        /// <summary>Creates an new <see cref="EventGridDataConnection" /> instance.</summary>
        public EventGridDataConnection()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dataConnection), __dataConnection);
            await eventListener.AssertObjectIsValid(nameof(__dataConnection), __dataConnection);
        }
    }
    /// Class representing an Event Grid data connection.
    public partial interface IEventGridDataConnection :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnection
    {
        /// <summary>The name of blob storage event type to process.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of blob storage event type to process.",
        SerializedName = @"blobStorageEventType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType? BlobStorageEventType { get; set; }
        /// <summary>The event hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The event hub consumer group.",
        SerializedName = @"consumerGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ConsumerGroup { get; set; }
        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The data format of the message. Optionally the data format can be added to each message.",
        SerializedName = @"dataFormat",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat? DataFormat { get; set; }
        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource ID where the event grid is configured to send events.",
        SerializedName = @"eventHubResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EventHubResourceId { get; set; }
        /// <summary>
        /// A Boolean value that, if set to true, indicates that ingestion should ignore the first record of every file
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A Boolean value that, if set to true, indicates that ingestion should ignore the first record of every file",
        SerializedName = @"ignoreFirstRecord",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IgnoreFirstRecord { get; set; }
        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.",
        SerializedName = @"mappingRuleName",
        PossibleTypes = new [] { typeof(string) })]
        string MappingRuleName { get; set; }
        /// <summary>The resource ID of the storage account where the data resides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource ID of the storage account where the data resides.",
        SerializedName = @"storageAccountResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageAccountResourceId { get; set; }
        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The table where the data should be ingested. Optionally the table information can be added to each message.",
        SerializedName = @"tableName",
        PossibleTypes = new [] { typeof(string) })]
        string TableName { get; set; }

    }
    /// Class representing an Event Grid data connection.
    internal partial interface IEventGridDataConnectionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDataConnectionInternal
    {
        /// <summary>The name of blob storage event type to process.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.BlobStorageEventType? BlobStorageEventType { get; set; }
        /// <summary>The event hub consumer group.</summary>
        string ConsumerGroup { get; set; }
        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat? DataFormat { get; set; }
        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        string EventHubResourceId { get; set; }
        /// <summary>
        /// A Boolean value that, if set to true, indicates that ingestion should ignore the first record of every file
        /// </summary>
        bool? IgnoreFirstRecord { get; set; }
        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        string MappingRuleName { get; set; }
        /// <summary>The properties of the Event Grid data connection.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IEventGridConnectionProperties Property { get; set; }
        /// <summary>The resource ID of the storage account where the data resides.</summary>
        string StorageAccountResourceId { get; set; }
        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        string TableName { get; set; }

    }
}