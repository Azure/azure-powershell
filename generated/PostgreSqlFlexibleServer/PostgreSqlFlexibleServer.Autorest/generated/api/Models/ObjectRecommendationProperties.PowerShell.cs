// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Object recommendation properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ObjectRecommendationPropertiesTypeConverter))]
    public partial class ObjectRecommendationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ObjectRecommendationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ObjectRecommendationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ObjectRecommendationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="ObjectRecommendationProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ObjectRecommendationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ImplementationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails) content.GetValueForProperty("ImplementationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesImplementationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("AnalyzedWorkload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkload = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload) content.GetValueForProperty("AnalyzedWorkload",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkload, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesAnalyzedWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("InitialRecommendedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).InitialRecommendedTime = (global::System.DateTime?) content.GetValueForProperty("InitialRecommendedTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).InitialRecommendedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("LastRecommendedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).LastRecommendedTime = (global::System.DateTime?) content.GetValueForProperty("LastRecommendedTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).LastRecommendedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("TimesRecommended"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).TimesRecommended = (int?) content.GetValueForProperty("TimesRecommended",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).TimesRecommended, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImprovedQueryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImprovedQueryId = (System.Collections.Generic.List<long>) content.GetValueForProperty("ImprovedQueryId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImprovedQueryId, __y => TypeConverterExtensions.SelectToList<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            }
            if (content.Contains("RecommendationReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationReason = (string) content.GetValueForProperty("RecommendationReason",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationReason, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).CurrentState = (string) content.GetValueForProperty("CurrentState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).CurrentState, global::System.Convert.ToString);
            }
            if (content.Contains("RecommendationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationType = (string) content.GetValueForProperty("RecommendationType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationType, global::System.Convert.ToString);
            }
            if (content.Contains("EstimatedImpact"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).EstimatedImpact = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord>) content.GetValueForProperty("EstimatedImpact",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).EstimatedImpact, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ImpactRecordTypeConverter.ConvertFrom));
            }
            if (content.Contains("AnalyzedWorkloadQueryCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadQueryCount = (int?) content.GetValueForProperty("AnalyzedWorkloadQueryCount",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadQueryCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImplementationDetailMethod"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailMethod = (string) content.GetValueForProperty("ImplementationDetailMethod",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailMethod, global::System.Convert.ToString);
            }
            if (content.Contains("ImplementationDetailScript"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailScript = (string) content.GetValueForProperty("ImplementationDetailScript",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailScript, global::System.Convert.ToString);
            }
            if (content.Contains("AnalyzedWorkloadStartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadStartTime = (global::System.DateTime?) content.GetValueForProperty("AnalyzedWorkloadStartTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AnalyzedWorkloadEndTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadEndTime = (global::System.DateTime?) content.GetValueForProperty("AnalyzedWorkloadEndTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadEndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("DetailDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailDatabaseName = (string) content.GetValueForProperty("DetailDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailDatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailSchema"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailSchema = (string) content.GetValueForProperty("DetailSchema",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailSchema, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailTable = (string) content.GetValueForProperty("DetailTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailTable, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexType = (string) content.GetValueForProperty("DetailIndexType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexType, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexName = (string) content.GetValueForProperty("DetailIndexName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexColumn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexColumn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailIndexColumn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexColumn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailIncludedColumn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIncludedColumn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailIncludedColumn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIncludedColumn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ObjectRecommendationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ImplementationDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesImplementationDetails) content.GetValueForProperty("ImplementationDetail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesImplementationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("AnalyzedWorkload"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkload = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesAnalyzedWorkload) content.GetValueForProperty("AnalyzedWorkload",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkload, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationPropertiesAnalyzedWorkloadTypeConverter.ConvertFrom);
            }
            if (content.Contains("Detail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ObjectRecommendationDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("InitialRecommendedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).InitialRecommendedTime = (global::System.DateTime?) content.GetValueForProperty("InitialRecommendedTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).InitialRecommendedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("LastRecommendedTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).LastRecommendedTime = (global::System.DateTime?) content.GetValueForProperty("LastRecommendedTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).LastRecommendedTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("TimesRecommended"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).TimesRecommended = (int?) content.GetValueForProperty("TimesRecommended",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).TimesRecommended, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImprovedQueryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImprovedQueryId = (System.Collections.Generic.List<long>) content.GetValueForProperty("ImprovedQueryId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImprovedQueryId, __y => TypeConverterExtensions.SelectToList<long>(__y, (__w)=> (long) global::System.Convert.ChangeType(__w, typeof(long))));
            }
            if (content.Contains("RecommendationReason"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationReason = (string) content.GetValueForProperty("RecommendationReason",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationReason, global::System.Convert.ToString);
            }
            if (content.Contains("CurrentState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).CurrentState = (string) content.GetValueForProperty("CurrentState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).CurrentState, global::System.Convert.ToString);
            }
            if (content.Contains("RecommendationType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationType = (string) content.GetValueForProperty("RecommendationType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).RecommendationType, global::System.Convert.ToString);
            }
            if (content.Contains("EstimatedImpact"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).EstimatedImpact = (System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord>) content.GetValueForProperty("EstimatedImpact",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).EstimatedImpact, __y => TypeConverterExtensions.SelectToList<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IImpactRecord>(__y, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ImpactRecordTypeConverter.ConvertFrom));
            }
            if (content.Contains("AnalyzedWorkloadQueryCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadQueryCount = (int?) content.GetValueForProperty("AnalyzedWorkloadQueryCount",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadQueryCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("ImplementationDetailMethod"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailMethod = (string) content.GetValueForProperty("ImplementationDetailMethod",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailMethod, global::System.Convert.ToString);
            }
            if (content.Contains("ImplementationDetailScript"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailScript = (string) content.GetValueForProperty("ImplementationDetailScript",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).ImplementationDetailScript, global::System.Convert.ToString);
            }
            if (content.Contains("AnalyzedWorkloadStartTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadStartTime = (global::System.DateTime?) content.GetValueForProperty("AnalyzedWorkloadStartTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadStartTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("AnalyzedWorkloadEndTime"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadEndTime = (global::System.DateTime?) content.GetValueForProperty("AnalyzedWorkloadEndTime",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).AnalyzedWorkloadEndTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("DetailDatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailDatabaseName = (string) content.GetValueForProperty("DetailDatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailDatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailSchema"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailSchema = (string) content.GetValueForProperty("DetailSchema",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailSchema, global::System.Convert.ToString);
            }
            if (content.Contains("DetailTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailTable = (string) content.GetValueForProperty("DetailTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailTable, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexType"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexType = (string) content.GetValueForProperty("DetailIndexType",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexType, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexName = (string) content.GetValueForProperty("DetailIndexName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexName, global::System.Convert.ToString);
            }
            if (content.Contains("DetailIndexColumn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexColumn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailIndexColumn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIndexColumn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("DetailIncludedColumn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIncludedColumn = (System.Collections.Generic.List<string>) content.GetValueForProperty("DetailIncludedColumn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IObjectRecommendationPropertiesInternal)this).DetailIncludedColumn, __y => TypeConverterExtensions.SelectToList<string>(__y, global::System.Convert.ToString));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// Object recommendation properties.
    [System.ComponentModel.TypeConverter(typeof(ObjectRecommendationPropertiesTypeConverter))]
    public partial interface IObjectRecommendationProperties

    {

    }
}