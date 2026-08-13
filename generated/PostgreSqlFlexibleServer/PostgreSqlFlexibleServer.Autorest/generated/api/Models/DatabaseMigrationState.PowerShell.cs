// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    /// <summary>Migration state of a database.</summary>
    [System.ComponentModel.TypeConverter(typeof(DatabaseMigrationStateTypeConverter))]
    public partial class DatabaseMigrationState
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DatabaseMigrationState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DatabaseMigrationState(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).DatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationState = (string) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationState, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationOperation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationOperation = (string) content.GetValueForProperty("MigrationOperation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationOperation, global::System.Convert.ToString);
            }
            if (content.Contains("StartedOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).StartedOn = (global::System.DateTime?) content.GetValueForProperty("StartedOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).StartedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("EndedOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).EndedOn = (global::System.DateTime?) content.GetValueForProperty("EndedOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).EndedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("FullLoadQueuedTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadQueuedTable = (int?) content.GetValueForProperty("FullLoadQueuedTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadQueuedTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadErroredTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadErroredTable = (int?) content.GetValueForProperty("FullLoadErroredTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadErroredTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadLoadingTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadLoadingTable = (int?) content.GetValueForProperty("FullLoadLoadingTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadLoadingTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadCompletedTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadCompletedTable = (int?) content.GetValueForProperty("FullLoadCompletedTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadCompletedTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcUpdateCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcUpdateCounter = (int?) content.GetValueForProperty("CdcUpdateCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcUpdateCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcDeleteCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcDeleteCounter = (int?) content.GetValueForProperty("CdcDeleteCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcDeleteCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcInsertCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcInsertCounter = (int?) content.GetValueForProperty("CdcInsertCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcInsertCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AppliedChange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).AppliedChange = (int?) content.GetValueForProperty("AppliedChange",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).AppliedChange, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("IncomingChange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).IncomingChange = (int?) content.GetValueForProperty("IncomingChange",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).IncomingChange, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Latency"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Latency = (int?) content.GetValueForProperty("Latency",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Latency, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Message, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DatabaseMigrationState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DatabaseMigrationState(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("DatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).DatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationState = (string) content.GetValueForProperty("MigrationState",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationState, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationOperation"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationOperation = (string) content.GetValueForProperty("MigrationOperation",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).MigrationOperation, global::System.Convert.ToString);
            }
            if (content.Contains("StartedOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).StartedOn = (global::System.DateTime?) content.GetValueForProperty("StartedOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).StartedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("EndedOn"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).EndedOn = (global::System.DateTime?) content.GetValueForProperty("EndedOn",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).EndedOn, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("FullLoadQueuedTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadQueuedTable = (int?) content.GetValueForProperty("FullLoadQueuedTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadQueuedTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadErroredTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadErroredTable = (int?) content.GetValueForProperty("FullLoadErroredTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadErroredTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadLoadingTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadLoadingTable = (int?) content.GetValueForProperty("FullLoadLoadingTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadLoadingTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("FullLoadCompletedTable"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadCompletedTable = (int?) content.GetValueForProperty("FullLoadCompletedTable",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).FullLoadCompletedTable, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcUpdateCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcUpdateCounter = (int?) content.GetValueForProperty("CdcUpdateCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcUpdateCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcDeleteCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcDeleteCounter = (int?) content.GetValueForProperty("CdcDeleteCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcDeleteCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CdcInsertCounter"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcInsertCounter = (int?) content.GetValueForProperty("CdcInsertCounter",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).CdcInsertCounter, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("AppliedChange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).AppliedChange = (int?) content.GetValueForProperty("AppliedChange",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).AppliedChange, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("IncomingChange"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).IncomingChange = (int?) content.GetValueForProperty("IncomingChange",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).IncomingChange, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Latency"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Latency = (int?) content.GetValueForProperty("Latency",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Latency, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("Message"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationStateInternal)this).Message, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DatabaseMigrationState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DatabaseMigrationState(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.DatabaseMigrationState"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DatabaseMigrationState(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DatabaseMigrationState" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DatabaseMigrationState" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IDatabaseMigrationState FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

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
    /// Migration state of a database.
    [System.ComponentModel.TypeConverter(typeof(DatabaseMigrationStateTypeConverter))]
    public partial interface IDatabaseMigrationState

    {

    }
}