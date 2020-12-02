namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>App properties used for validation.</summary>
    [System.ComponentModel.TypeConverter(typeof(ValidatePropertiesTypeConverter))]
    public partial class ValidateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ValidateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ValidateProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ValidateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ValidateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ServerFarmId = (string) content.GetValueForProperty("ServerFarmId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ServerFarmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).NeedLinuxWorker = (bool?) content.GetValueForProperty("NeedLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).NeedLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryBaseUrl = (string) content.GetValueForProperty("ContainerRegistryBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryUsername = (string) content.GetValueForProperty("ContainerRegistryUsername",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryPassword = (string) content.GetValueForProperty("ContainerRegistryPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageRepository = (string) content.GetValueForProperty("ContainerImageRepository",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageRepository, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageTag = (string) content.GetValueForProperty("ContainerImageTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImagePlatform = (string) content.GetValueForProperty("ContainerImagePlatform",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImagePlatform, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ValidateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ServerFarmId = (string) content.GetValueForProperty("ServerFarmId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ServerFarmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).NeedLinuxWorker = (bool?) content.GetValueForProperty("NeedLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).NeedLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryBaseUrl = (string) content.GetValueForProperty("ContainerRegistryBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryUsername = (string) content.GetValueForProperty("ContainerRegistryUsername",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryPassword = (string) content.GetValueForProperty("ContainerRegistryPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerRegistryPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageRepository = (string) content.GetValueForProperty("ContainerImageRepository",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageRepository, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageTag = (string) content.GetValueForProperty("ContainerImageTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImageTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImagePlatform = (string) content.GetValueForProperty("ContainerImagePlatform",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidatePropertiesInternal)this).ContainerImagePlatform, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// App properties used for validation.
    [System.ComponentModel.TypeConverter(typeof(ValidatePropertiesTypeConverter))]
    public partial interface IValidateProperties

    {

    }
}