namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Status of packet capture session.</summary>
    [System.ComponentModel.TypeConverter(typeof(PacketCaptureQueryStatusResultTypeConverter))]
    public partial class PacketCaptureQueryStatusResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureQueryStatusResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PacketCaptureQueryStatusResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureQueryStatusResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PacketCaptureQueryStatusResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PacketCaptureQueryStatusResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureQueryStatusResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PacketCaptureQueryStatusResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).CaptureStartTime = (global::System.DateTime?) content.GetValueForProperty("CaptureStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).CaptureStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureError = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[]) content.GetValueForProperty("PacketCaptureError",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus?) content.GetValueForProperty("PacketCaptureStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).StopReason = (string) content.GetValueForProperty("StopReason",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).StopReason, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PacketCaptureQueryStatusResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PacketCaptureQueryStatusResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).CaptureStartTime = (global::System.DateTime?) content.GetValueForProperty("CaptureStartTime",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).CaptureStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureError = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[]) content.GetValueForProperty("PacketCaptureError",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureError, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError.CreateFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureStatus = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus?) content.GetValueForProperty("PacketCaptureStatus",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).PacketCaptureStatus, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).StopReason = (string) content.GetValueForProperty("StopReason",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal)this).StopReason, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Status of packet capture session.
    [System.ComponentModel.TypeConverter(typeof(PacketCaptureQueryStatusResultTypeConverter))]
    public partial interface IPacketCaptureQueryStatusResult

    {

    }
}