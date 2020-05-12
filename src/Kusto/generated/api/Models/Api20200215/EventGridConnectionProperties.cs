namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto event grid connection properties.</summary>
    public partial class EventGridConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IEventGridConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IEventGridConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConsumerGroup" /> property.</summary>
        private string _consumerGroup;

        /// <summary>The event hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ConsumerGroup { get => this._consumerGroup; set => this._consumerGroup = value; }

        /// <summary>Backing field for <see cref="DataFormat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat _dataFormat;

        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat DataFormat { get => this._dataFormat; set => this._dataFormat = value; }

        /// <summary>Backing field for <see cref="EventHubResourceId" /> property.</summary>
        private string _eventHubResourceId;

        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string EventHubResourceId { get => this._eventHubResourceId; set => this._eventHubResourceId = value; }

        /// <summary>Backing field for <see cref="MappingRuleName" /> property.</summary>
        private string _mappingRuleName;

        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string MappingRuleName { get => this._mappingRuleName; set => this._mappingRuleName = value; }

        /// <summary>Backing field for <see cref="StorageAccountResourceId" /> property.</summary>
        private string _storageAccountResourceId;

        /// <summary>The resource ID of the storage account where the data resides.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string StorageAccountResourceId { get => this._storageAccountResourceId; set => this._storageAccountResourceId = value; }

        /// <summary>Backing field for <see cref="TableName" /> property.</summary>
        private string _tableName;

        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string TableName { get => this._tableName; set => this._tableName = value; }

        /// <summary>Creates an new <see cref="EventGridConnectionProperties" /> instance.</summary>
        public EventGridConnectionProperties()
        {

        }
    }
    /// Class representing the Kusto event grid connection properties.
    public partial interface IEventGridConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
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
        Required = true,
        ReadOnly = false,
        Description = @"The data format of the message. Optionally the data format can be added to each message.",
        SerializedName = @"dataFormat",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat DataFormat { get; set; }
        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource ID where the event grid is configured to send events.",
        SerializedName = @"eventHubResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EventHubResourceId { get; set; }
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
        Required = true,
        ReadOnly = false,
        Description = @"The table where the data should be ingested. Optionally the table information can be added to each message.",
        SerializedName = @"tableName",
        PossibleTypes = new [] { typeof(string) })]
        string TableName { get; set; }

    }
    /// Class representing the Kusto event grid connection properties.
    internal partial interface IEventGridConnectionPropertiesInternal

    {
        /// <summary>The event hub consumer group.</summary>
        string ConsumerGroup { get; set; }
        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventGridDataFormat DataFormat { get; set; }
        /// <summary>The resource ID where the event grid is configured to send events.</summary>
        string EventHubResourceId { get; set; }
        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        string MappingRuleName { get; set; }
        /// <summary>The resource ID of the storage account where the data resides.</summary>
        string StorageAccountResourceId { get; set; }
        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        string TableName { get; set; }

    }
}