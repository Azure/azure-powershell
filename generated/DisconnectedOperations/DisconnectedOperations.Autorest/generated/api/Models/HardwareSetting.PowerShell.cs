// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell;

    /// <summary>Hardware settings resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(HardwareSettingTypeConverter))]
    public partial class HardwareSetting
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new HardwareSetting(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new HardwareSetting(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="HardwareSetting" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="HardwareSetting" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSetting FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal HardwareSetting(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSettingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Node"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Node = (int?) content.GetValueForProperty("Node",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Node, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("TotalCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).TotalCore = (int?) content.GetValueForProperty("TotalCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).TotalCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DiskSpaceInGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DiskSpaceInGb = (int?) content.GetValueForProperty("DiskSpaceInGb",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DiskSpaceInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MemoryInGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).MemoryInGb = (int?) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).MemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Oem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Oem = (string) content.GetValueForProperty("Oem",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Oem, global::System.Convert.ToString);
            }
            if (content.Contains("HardwareSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).HardwareSku = (string) content.GetValueForProperty("HardwareSku",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).HardwareSku, global::System.Convert.ToString);
            }
            if (content.Contains("VersionAtRegistration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).VersionAtRegistration = (string) content.GetValueForProperty("VersionAtRegistration",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).VersionAtRegistration, global::System.Convert.ToString);
            }
            if (content.Contains("SolutionBuilderExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).SolutionBuilderExtension = (string) content.GetValueForProperty("SolutionBuilderExtension",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).SolutionBuilderExtension, global::System.Convert.ToString);
            }
            if (content.Contains("DeviceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DeviceId = (string) content.GetValueForProperty("DeviceId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DeviceId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSetting"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal HardwareSetting(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Property"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.HardwareSettingPropertiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("SystemDataCreatedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedBy = (string) content.GetValueForProperty("SystemDataCreatedBy",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedByType = (string) content.GetValueForProperty("SystemDataCreatedByType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataCreatedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataCreatedAt",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataCreatedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemDataLastModifiedBy"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedBy = (string) content.GetValueForProperty("SystemDataLastModifiedBy",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedBy, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedByType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedByType = (string) content.GetValueForProperty("SystemDataLastModifiedByType",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedByType, global::System.Convert.ToString);
            }
            if (content.Contains("SystemDataLastModifiedAt"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedAt = (global::System.DateTime?) content.GetValueForProperty("SystemDataLastModifiedAt",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemDataLastModifiedAt, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("SystemData"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemData = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.ISystemData) content.GetValueForProperty("SystemData",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).SystemData, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.SystemDataTypeConverter.ConvertFrom);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Id, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Type"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IResourceInternal)this).Type, global::System.Convert.ToString);
            }
            if (content.Contains("Node"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Node = (int?) content.GetValueForProperty("Node",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Node, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("TotalCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).TotalCore = (int?) content.GetValueForProperty("TotalCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).TotalCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("DiskSpaceInGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DiskSpaceInGb = (int?) content.GetValueForProperty("DiskSpaceInGb",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DiskSpaceInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("MemoryInGb"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).MemoryInGb = (int?) content.GetValueForProperty("MemoryInGb",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).MemoryInGb, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Oem"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Oem = (string) content.GetValueForProperty("Oem",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).Oem, global::System.Convert.ToString);
            }
            if (content.Contains("HardwareSku"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).HardwareSku = (string) content.GetValueForProperty("HardwareSku",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).HardwareSku, global::System.Convert.ToString);
            }
            if (content.Contains("VersionAtRegistration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).VersionAtRegistration = (string) content.GetValueForProperty("VersionAtRegistration",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).VersionAtRegistration, global::System.Convert.ToString);
            }
            if (content.Contains("SolutionBuilderExtension"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).SolutionBuilderExtension = (string) content.GetValueForProperty("SolutionBuilderExtension",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).SolutionBuilderExtension, global::System.Convert.ToString);
            }
            if (content.Contains("DeviceId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DeviceId = (string) content.GetValueForProperty("DeviceId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IHardwareSettingInternal)this).DeviceId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Hardware settings resource.
    [System.ComponentModel.TypeConverter(typeof(HardwareSettingTypeConverter))]
    public partial interface IHardwareSetting

    {

    }
}