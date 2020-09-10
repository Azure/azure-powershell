namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(ContainerNetworkInterfaceStatisticsTypeConverter))]
    public partial class ContainerNetworkInterfaceStatistics
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerNetworkInterfaceStatistics(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxByte = (long?) content.GetValueForProperty("RxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxDropped = (long?) content.GetValueForProperty("RxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxError = (long?) content.GetValueForProperty("RxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxPacket = (long?) content.GetValueForProperty("RxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxByte = (long?) content.GetValueForProperty("TxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxDropped = (long?) content.GetValueForProperty("TxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxError = (long?) content.GetValueForProperty("TxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxPacket = (long?) content.GetValueForProperty("TxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerNetworkInterfaceStatistics(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxByte = (long?) content.GetValueForProperty("RxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxDropped = (long?) content.GetValueForProperty("RxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxError = (long?) content.GetValueForProperty("RxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxPacket = (long?) content.GetValueForProperty("RxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).RxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxByte = (long?) content.GetValueForProperty("TxByte",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxDropped = (long?) content.GetValueForProperty("TxDropped",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxDropped, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxError = (long?) content.GetValueForProperty("TxError",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxError, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxPacket = (long?) content.GetValueForProperty("TxPacket",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal)this).TxPacket, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerNetworkInterfaceStatistics(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ContainerNetworkInterfaceStatistics"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerNetworkInterfaceStatistics(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerNetworkInterfaceStatistics" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(ContainerNetworkInterfaceStatisticsTypeConverter))]
    public partial interface IContainerNetworkInterfaceStatistics

    {

    }
}