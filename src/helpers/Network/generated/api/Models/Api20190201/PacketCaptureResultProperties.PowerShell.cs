namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Describes the properties of a packet capture session.</summary>
    [System.ComponentModel.TypeConverter(typeof(PacketCaptureResultPropertiesTypeConverter))]
    public partial class PacketCaptureResultProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PacketCaptureResultProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PacketCaptureResultProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PacketCaptureResultProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PacketCaptureResultProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationFilePath = (string) content.GetValueForProperty("StorageLocationFilePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationFilePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStorageId = (string) content.GetValueForProperty("StorageLocationStorageId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStorageId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStoragePath = (string) content.GetValueForProperty("StorageLocationStoragePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStoragePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation) content.GetValueForProperty("StorageLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureStorageLocationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).BytesToCapturePerPacket = (int?) content.GetValueForProperty("BytesToCapturePerPacket",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).BytesToCapturePerPacket, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Filter = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[]) content.GetValueForProperty("Filter",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Filter, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureFilterTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TimeLimitInSeconds = (int?) content.GetValueForProperty("TimeLimitInSeconds",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TimeLimitInSeconds, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TotalBytesPerSession = (int?) content.GetValueForProperty("TotalBytesPerSession",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TotalBytesPerSession, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureResultProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PacketCaptureResultProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResultPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationFilePath = (string) content.GetValueForProperty("StorageLocationFilePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationFilePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStorageId = (string) content.GetValueForProperty("StorageLocationStorageId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStorageId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStoragePath = (string) content.GetValueForProperty("StorageLocationStoragePath",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocationStoragePath, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureStorageLocation) content.GetValueForProperty("StorageLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).StorageLocation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureStorageLocationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).BytesToCapturePerPacket = (int?) content.GetValueForProperty("BytesToCapturePerPacket",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).BytesToCapturePerPacket, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Filter = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter[]) content.GetValueForProperty("Filter",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Filter, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureFilter>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureFilterTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TimeLimitInSeconds = (int?) content.GetValueForProperty("TimeLimitInSeconds",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TimeLimitInSeconds, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TotalBytesPerSession = (int?) content.GetValueForProperty("TotalBytesPerSession",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureParametersInternal)this).TotalBytesPerSession, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of a packet capture session.
    [System.ComponentModel.TypeConverter(typeof(PacketCaptureResultPropertiesTypeConverter))]
    public partial interface IPacketCaptureResultProperties

    {

    }
}