namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.PowerShell;

    /// <summary>The instance view of the container instance. Only valid in response.</summary>
    [System.ComponentModel.TypeConverter(typeof(ContainerPropertiesInstanceViewTypeConverter))]
    public partial class ContainerPropertiesInstanceView
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
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ContainerPropertiesInstanceView(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentState = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState) content.GetValueForProperty("CurrentState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentState, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviousState = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState) content.GetValueForProperty("PreviousState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviousState, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).RestartCount = (int?) content.GetValueForProperty("RestartCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).RestartCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).Event = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[]) content.GetValueForProperty("Event",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).Event, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EventTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateState = (string) content.GetValueForProperty("CurrentStateState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentStateStartTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateExitCode = (int?) content.GetValueForProperty("CurrentStateExitCode",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateExitCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateFinishTime = (global::System.DateTime?) content.GetValueForProperty("CurrentStateFinishTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateFinishTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateDetailStatus = (string) content.GetValueForProperty("CurrentStateDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateDetailStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouState = (string) content.GetValueForProperty("PreviouState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateStartTime = (global::System.DateTime?) content.GetValueForProperty("PreviouStateStartTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateExitCode = (int?) content.GetValueForProperty("PreviouStateExitCode",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateExitCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateFinishTime = (global::System.DateTime?) content.GetValueForProperty("PreviouStateFinishTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateFinishTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateDetailStatus = (string) content.GetValueForProperty("PreviouStateDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateDetailStatus, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ContainerPropertiesInstanceView(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentState = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState) content.GetValueForProperty("CurrentState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentState, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviousState = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerState) content.GetValueForProperty("PreviousState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviousState, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerStateTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).RestartCount = (int?) content.GetValueForProperty("RestartCount",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).RestartCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).Event = (Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[]) content.GetValueForProperty("Event",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).Event, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent>(__y, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EventTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateState = (string) content.GetValueForProperty("CurrentStateState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateStartTime = (global::System.DateTime?) content.GetValueForProperty("CurrentStateStartTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateExitCode = (int?) content.GetValueForProperty("CurrentStateExitCode",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateExitCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateFinishTime = (global::System.DateTime?) content.GetValueForProperty("CurrentStateFinishTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateFinishTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateDetailStatus = (string) content.GetValueForProperty("CurrentStateDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).CurrentStateDetailStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouState = (string) content.GetValueForProperty("PreviouState",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateStartTime = (global::System.DateTime?) content.GetValueForProperty("PreviouStateStartTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateExitCode = (int?) content.GetValueForProperty("PreviouStateExitCode",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateExitCode, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateFinishTime = (global::System.DateTime?) content.GetValueForProperty("PreviouStateFinishTime",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateFinishTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateDetailStatus = (string) content.GetValueForProperty("PreviouStateDetailStatus",((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceViewInternal)this).PreviouStateDetailStatus, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ContainerPropertiesInstanceView(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerPropertiesInstanceView"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ContainerPropertiesInstanceView(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ContainerPropertiesInstanceView" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPropertiesInstanceView FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The instance view of the container instance. Only valid in response.
    [System.ComponentModel.TypeConverter(typeof(ContainerPropertiesInstanceViewTypeConverter))]
    public partial interface IContainerPropertiesInstanceView

    {

    }
}