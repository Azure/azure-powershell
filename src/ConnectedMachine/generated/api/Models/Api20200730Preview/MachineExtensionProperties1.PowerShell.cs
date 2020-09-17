namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Describes the properties of a Machine Extension.</summary>
    [System.ComponentModel.TypeConverter(typeof(MachineExtensionProperties1TypeConverter))]
    public partial class MachineExtensionProperties1
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1 DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineExtensionProperties1(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1 DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineExtensionProperties1(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineExtensionProperties1" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1 FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineExtensionProperties1(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).AutoUpgradeMinorVersion = (bool?) content.GetValueForProperty("AutoUpgradeMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).AutoUpgradeMinorVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ForceUpdateTag = (string) content.GetValueForProperty("ForceUpdateTag",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ForceUpdateTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesProtectedSettings) content.GetValueForProperty("ProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesProtectedSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).TypeHandlerVersion = (string) content.GetValueForProperty("TypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).TypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceViewStatus) content.GetValueForProperty("InstanceViewStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionInstanceViewStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewName = (string) content.GetValueForProperty("InstanceViewName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewType = (string) content.GetValueForProperty("InstanceViewType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewTypeHandlerVersion = (string) content.GetValueForProperty("InstanceViewTypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewTypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusCode = (string) content.GetValueForProperty("InstanceViewStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusDisplayStatus = (string) content.GetValueForProperty("InstanceViewStatusDisplayStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusDisplayStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusLevel = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes?) content.GetValueForProperty("InstanceViewStatusLevel",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusLevel, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusMessage = (string) content.GetValueForProperty("InstanceViewStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusTime = (global::System.DateTime?) content.GetValueForProperty("InstanceViewStatusTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineExtensionProperties1(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).AutoUpgradeMinorVersion = (bool?) content.GetValueForProperty("AutoUpgradeMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).AutoUpgradeMinorVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ForceUpdateTag = (string) content.GetValueForProperty("ForceUpdateTag",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ForceUpdateTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesProtectedSettings) content.GetValueForProperty("ProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesProtectedSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionPropertiesSettings) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionPropertiesSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).TypeHandlerVersion = (string) content.GetValueForProperty("TypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).TypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatus = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceViewStatus) content.GetValueForProperty("InstanceViewStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatus, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionInstanceViewStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewName = (string) content.GetValueForProperty("InstanceViewName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewType = (string) content.GetValueForProperty("InstanceViewType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewTypeHandlerVersion = (string) content.GetValueForProperty("InstanceViewTypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewTypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusCode = (string) content.GetValueForProperty("InstanceViewStatusCode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusDisplayStatus = (string) content.GetValueForProperty("InstanceViewStatusDisplayStatus",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusDisplayStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusLevel = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes?) content.GetValueForProperty("InstanceViewStatusLevel",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusLevel, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusLevelTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusMessage = (string) content.GetValueForProperty("InstanceViewStatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusTime = (global::System.DateTime?) content.GetValueForProperty("InstanceViewStatusTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionProperties1Internal)this).InstanceViewStatusTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of a Machine Extension.
    [System.ComponentModel.TypeConverter(typeof(MachineExtensionProperties1TypeConverter))]
    public partial interface IMachineExtensionProperties1

    {

    }
}