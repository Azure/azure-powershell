namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Results of network security group evaluation.</summary>
    [System.ComponentModel.TypeConverter(typeof(EvaluatedNetworkSecurityGroupTypeConverter))]
    public partial class EvaluatedNetworkSecurityGroup
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new EvaluatedNetworkSecurityGroup(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new EvaluatedNetworkSecurityGroup(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal EvaluatedNetworkSecurityGroup(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule) content.GetValueForProperty("MatchedRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRule, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchedRuleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).AppliedTo = (string) content.GetValueForProperty("AppliedTo",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).AppliedTo, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).RulesEvaluationResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[]) content.GetValueForProperty("RulesEvaluationResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).RulesEvaluationResult, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityRulesEvaluationResultTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleAction = (string) content.GetValueForProperty("MatchedRuleAction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleName = (string) content.GetValueForProperty("MatchedRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleName, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EvaluatedNetworkSecurityGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal EvaluatedNetworkSecurityGroup(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchedRule) content.GetValueForProperty("MatchedRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRule, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.MatchedRuleTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).AppliedTo = (string) content.GetValueForProperty("AppliedTo",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).AppliedTo, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).RulesEvaluationResult = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult[]) content.GetValueForProperty("RulesEvaluationResult",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).RulesEvaluationResult, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityRulesEvaluationResult>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityRulesEvaluationResultTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleAction = (string) content.GetValueForProperty("MatchedRuleAction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleAction, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleName = (string) content.GetValueForProperty("MatchedRuleName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroupInternal)this).MatchedRuleName, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="EvaluatedNetworkSecurityGroup" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEvaluatedNetworkSecurityGroup FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Results of network security group evaluation.
    [System.ComponentModel.TypeConverter(typeof(EvaluatedNetworkSecurityGroupTypeConverter))]
    public partial interface IEvaluatedNetworkSecurityGroup

    {

    }
}