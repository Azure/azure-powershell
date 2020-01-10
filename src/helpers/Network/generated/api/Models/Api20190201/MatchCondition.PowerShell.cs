namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Define match conditions</summary>
    [System.ComponentModel.TypeConverter(typeof(MatchConditionTypeConverter))]
    public partial class MatchCondition
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchCondition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MatchCondition(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchCondition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MatchCondition(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MatchCondition" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchCondition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MatchCondition(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchValue = (string[]) content.GetValueForProperty("MatchValue",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchValue, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchVariable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[]) content.GetValueForProperty("MatchVariable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchVariable, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchVariableTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).NegationConditon = (bool?) content.GetValueForProperty("NegationConditon",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).NegationConditon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Operator = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Operator, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Transform = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[]) content.GetValueForProperty("Transform",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Transform, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform.CreateFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchCondition"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MatchCondition(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchValue = (string[]) content.GetValueForProperty("MatchValue",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchValue, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchVariable = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[]) content.GetValueForProperty("MatchVariable",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).MatchVariable, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchVariableTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).NegationConditon = (bool?) content.GetValueForProperty("NegationConditon",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).NegationConditon, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Operator = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Operator, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Transform = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[]) content.GetValueForProperty("Transform",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal)this).Transform, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform.CreateFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Define match conditions
    [System.ComponentModel.TypeConverter(typeof(MatchConditionTypeConverter))]
    public partial interface IMatchCondition

    {

    }
}