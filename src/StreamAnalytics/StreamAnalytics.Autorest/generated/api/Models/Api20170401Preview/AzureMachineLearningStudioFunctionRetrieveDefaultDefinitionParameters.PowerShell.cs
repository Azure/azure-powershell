namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.PowerShell;

    /// <summary>
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning Studio function.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersTypeConverter))]
    public partial class AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalProperty = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties) content.GetValueForProperty("BindingRetrievalProperty",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalProperty, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingRetrievalPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingType = (string) content.GetValueForProperty("BindingType",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyUdfType = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType?) content.GetValueForProperty("BindingRetrievalPropertyUdfType",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyUdfType, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyExecuteEndpoint = (string) content.GetValueForProperty("BindingRetrievalPropertyExecuteEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyExecuteEndpoint, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalProperty = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionBindingRetrievalProperties) content.GetValueForProperty("BindingRetrievalProperty",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalProperty, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionBindingRetrievalPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingType = (string) content.GetValueForProperty("BindingType",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyUdfType = (Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType?) content.GetValueForProperty("BindingRetrievalPropertyUdfType",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyUdfType, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Support.UdfType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyExecuteEndpoint = (string) content.GetValueForProperty("BindingRetrievalPropertyExecuteEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersInternal)this).BindingRetrievalPropertyExecuteEndpoint, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters" />, deserializing
        /// the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// The parameters needed to retrieve the default function definition for an Azure Machine Learning Studio function.
    [System.ComponentModel.TypeConverter(typeof(AzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParametersTypeConverter))]
    public partial interface IAzureMachineLearningStudioFunctionRetrieveDefaultDefinitionParameters

    {

    }
}