namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Properties of the machine resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(MachinePropertiesTypeConverter))]
    public partial class MachineProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MachineProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MachineProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachineProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MachineProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).DiscoveryData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[]) content.GetValueForProperty("DiscoveryData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).DiscoveryData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DiscoveryDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).AssessmentData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[]) content.GetValueForProperty("AssessmentData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).AssessmentData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.AssessmentDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).MigrationData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[]) content.GetValueForProperty("MigrationData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).MigrationData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MachineProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).DiscoveryData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails[]) content.GetValueForProperty("DiscoveryData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).DiscoveryData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDiscoveryDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.DiscoveryDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).AssessmentData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails[]) content.GetValueForProperty("AssessmentData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).AssessmentData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.AssessmentDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).MigrationData = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails[]) content.GetValueForProperty("MigrationData",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).MigrationData, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMigrationDetails>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.MigrationDetailsTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).LastUpdatedTime = (global::System.DateTime?) content.GetValueForProperty("LastUpdatedTime",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IMachinePropertiesInternal)this).LastUpdatedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Properties of the machine resource.
    [System.ComponentModel.TypeConverter(typeof(MachinePropertiesTypeConverter))]
    public partial interface IMachineProperties

    {

    }
}