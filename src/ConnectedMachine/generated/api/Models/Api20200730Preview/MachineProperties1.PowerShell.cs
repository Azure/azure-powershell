namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Hybrid Compute Machine properties</summary>
    [System.ComponentModel.TypeConverter(typeof(MachineProperties1TypeConverter))]
    public partial class MachineProperties1
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineProperties1(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineProperties1(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineProperties1" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineProperties1 FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineProperties1(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataName = (string) content.GetValueForProperty("LocationDataName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCity = (string) content.GetValueForProperty("LocationDataCity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataDistrict = (string) content.GetValueForProperty("LocationDataDistrict",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataDistrict, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCountryOrRegion = (string) content.GetValueForProperty("LocationDataCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfileComputerName = (string) content.GetValueForProperty("OSProfileComputerName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfileComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData) content.GetValueForProperty("LocationData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachinePropertiesOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AdFqdn = (string) content.GetValueForProperty("AdFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AdFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ClientPublicKey = (string) content.GetValueForProperty("ClientPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ClientPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DnsFqdn = (string) content.GetValueForProperty("DnsFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DnsFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[]) content.GetValueForProperty("ErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.ErrorDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LastStatusChange = (global::System.DateTime?) content.GetValueForProperty("LastStatusChange",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LastStatusChange, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).MachineFqdn = (string) content.GetValueForProperty("MachineFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).MachineFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSName = (string) content.GetValueForProperty("OSName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSSku = (string) content.GetValueForProperty("OSSku",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSSku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMId = (string) content.GetValueForProperty("VMId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMUuid = (string) content.GetValueForProperty("VMUuid",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMUuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Extension = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[]) content.GetValueForProperty("Extension",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Extension, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionInstanceViewTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineProperties1(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataName = (string) content.GetValueForProperty("LocationDataName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCity = (string) content.GetValueForProperty("LocationDataCity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataDistrict = (string) content.GetValueForProperty("LocationDataDistrict",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataDistrict, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCountryOrRegion = (string) content.GetValueForProperty("LocationDataCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationDataCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfileComputerName = (string) content.GetValueForProperty("OSProfileComputerName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfileComputerName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData) content.GetValueForProperty("LocationData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LocationData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationDataTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfile = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesOSProfile) content.GetValueForProperty("OSProfile",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSProfile, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachinePropertiesOSProfileTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AdFqdn = (string) content.GetValueForProperty("AdFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AdFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AgentVersion = (string) content.GetValueForProperty("AgentVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).AgentVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ClientPublicKey = (string) content.GetValueForProperty("ClientPublicKey",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ClientPublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DnsFqdn = (string) content.GetValueForProperty("DnsFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DnsFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).DomainName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail[]) content.GetValueForProperty("ErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.ErrorDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LastStatusChange = (global::System.DateTime?) content.GetValueForProperty("LastStatusChange",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).LastStatusChange, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).MachineFqdn = (string) content.GetValueForProperty("MachineFqdn",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).MachineFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSName = (string) content.GetValueForProperty("OSName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSSku = (string) content.GetValueForProperty("OSSku",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSSku, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSVersion = (string) content.GetValueForProperty("OSVersion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).OSVersion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.StatusTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMId = (string) content.GetValueForProperty("VMId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMUuid = (string) content.GetValueForProperty("VMUuid",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).VMUuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Extension = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView[]) content.GetValueForProperty("Extension",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachinePropertiesInternal)this).Extension, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineExtensionInstanceView>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineExtensionInstanceViewTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Hybrid Compute Machine properties
    [System.ComponentModel.TypeConverter(typeof(MachineProperties1TypeConverter))]
    public partial interface IMachineProperties1

    {

    }
}