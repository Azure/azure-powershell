namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Resource validation request content.</summary>
    [System.ComponentModel.TypeConverter(typeof(ValidateRequestTypeConverter))]
    public partial class ValidateRequest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ValidateRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ValidateRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ValidateRequest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ValidateRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidatePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ServerFarmId = (string) content.GetValueForProperty("ServerFarmId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ServerFarmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).NeedLinuxWorker = (bool?) content.GetValueForProperty("NeedLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).NeedLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryBaseUrl = (string) content.GetValueForProperty("ContainerRegistryBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryUsername = (string) content.GetValueForProperty("ContainerRegistryUsername",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryPassword = (string) content.GetValueForProperty("ContainerRegistryPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageRepository = (string) content.GetValueForProperty("ContainerImageRepository",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageRepository, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageTag = (string) content.GetValueForProperty("ContainerImageTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImagePlatform = (string) content.GetValueForProperty("ContainerImagePlatform",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImagePlatform, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidateRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ValidateRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ValidatePropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ValidateResourceTypes.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Location, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsXenon = (bool?) content.GetValueForProperty("IsXenon",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsXenon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ServerFarmId = (string) content.GetValueForProperty("ServerFarmId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ServerFarmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).NeedLinuxWorker = (bool?) content.GetValueForProperty("NeedLinuxWorker",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).NeedLinuxWorker, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsSpot = (bool?) content.GetValueForProperty("IsSpot",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).IsSpot, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Capacity = (int?) content.GetValueForProperty("Capacity",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).Capacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).HostingEnvironment = (string) content.GetValueForProperty("HostingEnvironment",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).HostingEnvironment, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).SkuName = (string) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).SkuName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryBaseUrl = (string) content.GetValueForProperty("ContainerRegistryBaseUrl",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryBaseUrl, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryUsername = (string) content.GetValueForProperty("ContainerRegistryUsername",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryUsername, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryPassword = (string) content.GetValueForProperty("ContainerRegistryPassword",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerRegistryPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageRepository = (string) content.GetValueForProperty("ContainerImageRepository",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageRepository, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageTag = (string) content.GetValueForProperty("ContainerImageTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImageTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImagePlatform = (string) content.GetValueForProperty("ContainerImagePlatform",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IValidateRequestInternal)this).ContainerImagePlatform, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Resource validation request content.
    [System.ComponentModel.TypeConverter(typeof(ValidateRequestTypeConverter))]
    public partial interface IValidateRequest

    {

    }
}