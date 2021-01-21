namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Input definition for planned failover.</summary>
    [System.ComponentModel.TypeConverter(typeof(TestFailoverInputTypeConverter))]
    public partial class TestFailoverInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new TestFailoverInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInput" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new TestFailoverInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="TestFailoverInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal TestFailoverInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInputPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificFailoverInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).FailoverDirection = (string) content.GetValueForProperty("FailoverDirection",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).FailoverDirection, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkType = (string) content.GetValueForProperty("NetworkType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkId = (string) content.GetValueForProperty("NetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).SkipTestFailoverCleanup = (string) content.GetValueForProperty("SkipTestFailoverCleanup",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).SkipTestFailoverCleanup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal TestFailoverInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.TestFailoverInputPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetail = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInput) content.GetValueForProperty("ProviderSpecificDetail",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetail, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProviderSpecificFailoverInputTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).FailoverDirection = (string) content.GetValueForProperty("FailoverDirection",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).FailoverDirection, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkType = (string) content.GetValueForProperty("NetworkType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkId = (string) content.GetValueForProperty("NetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).NetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).SkipTestFailoverCleanup = (string) content.GetValueForProperty("SkipTestFailoverCleanup",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).SkipTestFailoverCleanup, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetailInstanceType = (string) content.GetValueForProperty("ProviderSpecificDetailInstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverInputInternal)this).ProviderSpecificDetailInstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Input definition for planned failover.
    [System.ComponentModel.TypeConverter(typeof(TestFailoverInputTypeConverter))]
    public partial interface ITestFailoverInput

    {

    }
}