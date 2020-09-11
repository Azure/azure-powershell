namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Hybrid Compute Machine properties</summary>
    [System.ComponentModel.TypeConverter(typeof(MachineUpdateProperties1TypeConverter))]
    public partial class MachineUpdateProperties1
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineUpdateProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdateProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdateProperties1 DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineUpdateProperties1(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineUpdateProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdateProperties1"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdateProperties1 DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineUpdateProperties1(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineUpdateProperties1" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdateProperties1 FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineUpdateProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineUpdateProperties1(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataName = (string) content.GetValueForProperty("LocationDataName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCity = (string) content.GetValueForProperty("LocationDataCity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataDistrict = (string) content.GetValueForProperty("LocationDataDistrict",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataDistrict, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCountryOrRegion = (string) content.GetValueForProperty("LocationDataCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData) content.GetValueForProperty("LocationData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationDataTypeConverter.ConvertFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.MachineUpdateProperties1"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineUpdateProperties1(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataName = (string) content.GetValueForProperty("LocationDataName",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCity = (string) content.GetValueForProperty("LocationDataCity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCity, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataDistrict = (string) content.GetValueForProperty("LocationDataDistrict",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataDistrict, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCountryOrRegion = (string) content.GetValueForProperty("LocationDataCountryOrRegion",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationDataCountryOrRegion, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationData = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.ILocationData) content.GetValueForProperty("LocationData",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200730Preview.IMachineUpdatePropertiesInternal)this).LocationData, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api10.LocationDataTypeConverter.ConvertFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Hybrid Compute Machine properties
    [System.ComponentModel.TypeConverter(typeof(MachineUpdateProperties1TypeConverter))]
    public partial interface IMachineUpdateProperties1

    {

    }
}