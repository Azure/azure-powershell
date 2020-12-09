namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto Iot hub connection properties.</summary>
    public partial class IotHubConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIotHubConnectionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IIotHubConnectionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConsumerGroup" /> property.</summary>
        private string _consumerGroup;

        /// <summary>The iot hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ConsumerGroup { get => this._consumerGroup; set => this._consumerGroup = value; }

        /// <summary>Backing field for <see cref="DataFormat" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat? _dataFormat;

        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat? DataFormat { get => this._dataFormat; set => this._dataFormat = value; }

        /// <summary>Backing field for <see cref="EventSystemProperty" /> property.</summary>
        private string[] _eventSystemProperty;

        /// <summary>System properties of the iot hub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string[] EventSystemProperty { get => this._eventSystemProperty; set => this._eventSystemProperty = value; }

        /// <summary>Backing field for <see cref="IotHubResourceId" /> property.</summary>
        private string _iotHubResourceId;

        /// <summary>The resource ID of the Iot hub to be used to create a data connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string IotHubResourceId { get => this._iotHubResourceId; set => this._iotHubResourceId = value; }

        /// <summary>Backing field for <see cref="MappingRuleName" /> property.</summary>
        private string _mappingRuleName;

        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string MappingRuleName { get => this._mappingRuleName; set => this._mappingRuleName = value; }

        /// <summary>Backing field for <see cref="SharedAccessPolicyName" /> property.</summary>
        private string _sharedAccessPolicyName;

        /// <summary>The name of the share access policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string SharedAccessPolicyName { get => this._sharedAccessPolicyName; set => this._sharedAccessPolicyName = value; }

        /// <summary>Backing field for <see cref="TableName" /> property.</summary>
        private string _tableName;

        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string TableName { get => this._tableName; set => this._tableName = value; }

        /// <summary>Creates an new <see cref="IotHubConnectionProperties" /> instance.</summary>
        public IotHubConnectionProperties()
        {

        }
    }
    /// Class representing the Kusto Iot hub connection properties.
    public partial interface IIotHubConnectionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The iot hub consumer group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The iot hub consumer group.",
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat? DataFormat { get; set; }
        /// <summary>System properties of the iot hub</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"System properties of the iot hub",
        SerializedName = @"eventSystemProperties",
        PossibleTypes = new [] { typeof(string) })]
        string[] EventSystemProperty { get; set; }
        /// <summary>The resource ID of the Iot hub to be used to create a data connection.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource ID of the Iot hub to be used to create a data connection.",
        SerializedName = @"iotHubResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string IotHubResourceId { get; set; }
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
        /// <summary>The name of the share access policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the share access policy",
        SerializedName = @"sharedAccessPolicyName",
        PossibleTypes = new [] { typeof(string) })]
        string SharedAccessPolicyName { get; set; }
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
    /// Class representing the Kusto Iot hub connection properties.
    internal partial interface IIotHubConnectionPropertiesInternal

    {
        /// <summary>The iot hub consumer group.</summary>
        string ConsumerGroup { get; set; }
        /// <summary>
        /// The data format of the message. Optionally the data format can be added to each message.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IotHubDataFormat? DataFormat { get; set; }
        /// <summary>System properties of the iot hub</summary>
        string[] EventSystemProperty { get; set; }
        /// <summary>The resource ID of the Iot hub to be used to create a data connection.</summary>
        string IotHubResourceId { get; set; }
        /// <summary>
        /// The mapping rule to be used to ingest the data. Optionally the mapping information can be added to each message.
        /// </summary>
        string MappingRuleName { get; set; }
        /// <summary>The name of the share access policy</summary>
        string SharedAccessPolicyName { get; set; }
        /// <summary>
        /// The table where the data should be ingested. Optionally the table information can be added to each message.
        /// </summary>
        string TableName { get; set; }

    }
}