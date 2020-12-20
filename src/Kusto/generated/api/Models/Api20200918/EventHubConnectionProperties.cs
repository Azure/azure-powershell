namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto event hub connection properties.</summary>
    public partial class EventHubConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Compression" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression? _compression;

        /// <summary>The event hub messages compression type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression? Compression { get => this._compression; set => this._compression = value; }

        /// <summary>Backing field for <see cref="ConsumerGroup" /> property.</summary>
        private string _consumerGroup;

        /// <summary>The event hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ConsumerGroup { get => this._consumerGroup; set => this._consumerGroup = value; }

        /// <summary>Backing field for <see cref="DataFormat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat? _dataFormat;

        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat? DataFormat { get => this._dataFormat; set => this._dataFormat = value; }

        /// <summary>Backing field for <see cref="EventHubResourceId" /> property.</summary>
        private string _eventHubResourceId;

        /// <summary>The resource ID of the event hub to be used to create a data connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string EventHubResourceId { get => this._eventHubResourceId; set => this._eventHubResourceId = value; }

        /// <summary>Backing field for <see cref="EventSystemProperty" /> property.</summary>
        private string[] _eventSystemProperty;

        /// <summary>System properties of the event hub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] EventSystemProperty { get => this._eventSystemProperty; set => this._eventSystemProperty = value; }

        /// <summary>Backing field for <see cref="MappingRuleName" /> property.</summary>
        private string _mappingRuleName;

        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string MappingRuleName { get => this._mappingRuleName; set => this._mappingRuleName = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IEventHubConnectionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="TableName" /> property.</summary>
        private string _tableName;

        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string TableName { get => this._tableName; set => this._tableName = value; }

        /// <summary>Creates an new <see cref="EventHubConnectionProperties" /> instance.</summary>
        public EventHubConnectionProperties()
        {

        }
    }
    /// Class representing the Kusto event hub connection properties.
    public partial interface IEventHubConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The event hub messages compression type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The event hub messages compression type",
        SerializedName = @"compression",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression? Compression { get; set; }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat? DataFormat { get; set; }
        /// <summary>The resource ID of the event hub to be used to create a data connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource ID of the event hub to be used to create a data connection.",
        SerializedName = @"eventHubResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string EventHubResourceId { get; set; }
        /// <summary>System properties of the event hub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"System properties of the event hub",
        SerializedName = @"eventSystemProperties",
        PossibleTypes = new [] { typeof(string) })]
        string[] EventSystemProperty { get; set; }
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
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
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
    /// Class representing the Kusto event hub connection properties.
    internal partial interface IEventHubConnectionPropertiesInternal

    {
        /// <summary>The event hub messages compression type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.Compression? Compression { get; set; }
        /// <summary>The event hub consumer group.</summary>
        string ConsumerGroup { get; set; }
        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EventHubDataFormat? DataFormat { get; set; }
        /// <summary>The resource ID of the event hub to be used to create a data connection.</summary>
        string EventHubResourceId { get; set; }
        /// <summary>System properties of the event hub</summary>
        string[] EventSystemProperty { get; set; }
        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        string MappingRuleName { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        string TableName { get; set; }

    }
}