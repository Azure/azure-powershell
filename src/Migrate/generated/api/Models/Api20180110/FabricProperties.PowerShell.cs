namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Fabric properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(FabricPropertiesTypeConverter))]
    public partial class FabricProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FabricProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FabricProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FabricProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).EncryptionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) content.GetValueForProperty("EncryptionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).EncryptionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).RolloverEncryptionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) content.GetValueForProperty("RolloverEncryptionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).RolloverEncryptionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).InternalIdentifier = (string) content.GetValueForProperty("InternalIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).InternalIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).BcdrState = (string) content.GetValueForProperty("BcdrState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).BcdrState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).HealthErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).HealthErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).Health = (string) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).Health, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FabricProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).EncryptionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) content.GetValueForProperty("EncryptionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).EncryptionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).RolloverEncryptionDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IEncryptionDetails) content.GetValueForProperty("RolloverEncryptionDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).RolloverEncryptionDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.EncryptionDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).InternalIdentifier = (string) content.GetValueForProperty("InternalIdentifier",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).InternalIdentifier, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).BcdrState = (string) content.GetValueForProperty("BcdrState",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).BcdrState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).CustomDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetails) content.GetValueForProperty("CustomDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).CustomDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.FabricSpecificDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).HealthErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError[]) content.GetValueForProperty("HealthErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).HealthErrorDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IHealthError>(__y, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.HealthErrorTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).Health = (string) content.GetValueForProperty("Health",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricPropertiesInternal)this).Health, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FabricProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Fabric properties.
    [System.ComponentModel.TypeConverter(typeof(FabricPropertiesTypeConverter))]
    public partial interface IFabricProperties

    {

    }
}