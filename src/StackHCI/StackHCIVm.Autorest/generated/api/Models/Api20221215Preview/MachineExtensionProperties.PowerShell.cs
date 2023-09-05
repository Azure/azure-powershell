namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.PowerShell;

    /// <summary>Describes the properties of a Machine Extension.</summary>
    [System.ComponentModel.TypeConverter(typeof(MachineExtensionPropertiesTypeConverter))]
    public partial class MachineExtensionProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineExtensionProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineExtensionProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineExtensionProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineExtensionProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ForceUpdateTag = (string) content.GetValueForProperty("ForceUpdateTag",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ForceUpdateTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).TypeHandlerVersion = (string) content.GetValueForProperty("TypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).TypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).AutoUpgradeMinorVersion = (bool?) content.GetValueForProperty("AutoUpgradeMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).AutoUpgradeMinorVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IAny) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IAny) content.GetValueForProperty("ProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionInstanceViewStatus) content.GetValueForProperty("InstanceViewStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionInstanceViewStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewName = (string) content.GetValueForProperty("InstanceViewName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewType = (string) content.GetValueForProperty("InstanceViewType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewTypeHandlerVersion = (string) content.GetValueForProperty("InstanceViewTypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewTypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusCode = (string) content.GetValueForProperty("StatusCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusLevel = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusLevelTypes?) content.GetValueForProperty("StatusLevel",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusLevel, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusLevelTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusDisplayStatus = (string) content.GetValueForProperty("StatusDisplayStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusDisplayStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusMessage = (string) content.GetValueForProperty("StatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusTime = (global::System.DateTime?) content.GetValueForProperty("StatusTime",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineExtensionProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceView = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionInstanceView) content.GetValueForProperty("InstanceView",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceView, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionInstanceViewTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ForceUpdateTag = (string) content.GetValueForProperty("ForceUpdateTag",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ForceUpdateTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Publisher = (string) content.GetValueForProperty("Publisher",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Publisher, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).TypeHandlerVersion = (string) content.GetValueForProperty("TypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).TypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).AutoUpgradeMinorVersion = (bool?) content.GetValueForProperty("AutoUpgradeMinorVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).AutoUpgradeMinorVersion, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Setting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IAny) content.GetValueForProperty("Setting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).Setting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProtectedSetting = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IAny) content.GetValueForProperty("ProtectedSetting",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProtectedSetting, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewStatus = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionInstanceViewStatus) content.GetValueForProperty("InstanceViewStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewStatus, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.MachineExtensionInstanceViewStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewName = (string) content.GetValueForProperty("InstanceViewName",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewType = (string) content.GetValueForProperty("InstanceViewType",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewTypeHandlerVersion = (string) content.GetValueForProperty("InstanceViewTypeHandlerVersion",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).InstanceViewTypeHandlerVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusCode = (string) content.GetValueForProperty("StatusCode",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusLevel = (Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusLevelTypes?) content.GetValueForProperty("StatusLevel",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusLevel, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.StatusLevelTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusDisplayStatus = (string) content.GetValueForProperty("StatusDisplayStatus",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusDisplayStatus, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusMessage = (string) content.GetValueForProperty("StatusMessage",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusTime = (global::System.DateTime?) content.GetValueForProperty("StatusTime",((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMachineExtensionPropertiesInternal)this).StatusTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of a Machine Extension.
    [System.ComponentModel.TypeConverter(typeof(MachineExtensionPropertiesTypeConverter))]
    public partial interface IMachineExtensionProperties

    {

    }
}