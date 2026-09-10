// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.PowerShell;

    /// <summary>
    /// A logical group of signals on an entity, evaluated under a configurable aggregation strategy. Groups are independent even
    /// when they share members. Each group's aggregated state is one of the inputs to the entity's composite health computation
    /// alongside any signals not declared in any group's members[].
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(SignalAggregationGroupTypeConverter))]
    public partial class SignalAggregationGroup
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalAggregationGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SignalAggregationGroup(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalAggregationGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SignalAggregationGroup(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SignalAggregationGroup" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="SignalAggregationGroup" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroup FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalAggregationGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SignalAggregationGroup(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("Member"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Member = (System.Collections.Generic.List<string>) content.GetValueForProperty("Member",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Member, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DegradedThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DegradedThreshold = (double?) content.GetValueForProperty("DegradedThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DegradedThreshold, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("UnhealthyThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnhealthyThreshold = (double?) content.GetValueForProperty("UnhealthyThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnhealthyThreshold, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("IgnoreUnknown"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).IgnoreUnknown = (bool?) content.GetValueForProperty("IgnoreUnknown",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).IgnoreUnknown, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AggregatedHealthState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregatedHealthState = (string) content.GetValueForProperty("AggregatedHealthState",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregatedHealthState, global::System.Convert.ToString);
            }
            if (content.Contains("UnresolvedMember"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnresolvedMember = (System.Collections.Generic.List<string>) content.GetValueForProperty("UnresolvedMember",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnresolvedMember, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.SignalAggregationGroup"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SignalAggregationGroup(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("DisplayName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DisplayName, global::System.Convert.ToString);
            }
            if (content.Contains("AggregationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregationType = (string) content.GetValueForProperty("AggregationType",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregationType, global::System.Convert.ToString);
            }
            if (content.Contains("Member"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Member = (System.Collections.Generic.List<string>) content.GetValueForProperty("Member",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Member, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DegradedThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DegradedThreshold = (double?) content.GetValueForProperty("DegradedThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).DegradedThreshold, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("UnhealthyThreshold"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnhealthyThreshold = (double?) content.GetValueForProperty("UnhealthyThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnhealthyThreshold, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            }
            if (content.Contains("Unit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).Unit, global::System.Convert.ToString);
            }
            if (content.Contains("IgnoreUnknown"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).IgnoreUnknown = (bool?) content.GetValueForProperty("IgnoreUnknown",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).IgnoreUnknown, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            }
            if (content.Contains("AggregatedHealthState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregatedHealthState = (string) content.GetValueForProperty("AggregatedHealthState",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).AggregatedHealthState, global::System.Convert.ToString);
            }
            if (content.Contains("UnresolvedMember"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnresolvedMember = (System.Collections.Generic.List<string>) content.GetValueForProperty("UnresolvedMember",((Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalAggregationGroupInternal)this).UnresolvedMember, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// A logical group of signals on an entity, evaluated under a configurable aggregation strategy. Groups are independent even
    /// when they share members. Each group's aggregated state is one of the inputs to the entity's composite health computation
    /// alongside any signals not declared in any group's members[].
    [System.ComponentModel.TypeConverter(typeof(SignalAggregationGroupTypeConverter))]
    public partial interface ISignalAggregationGroup

    {

    }
}