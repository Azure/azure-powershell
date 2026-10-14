// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(PostgreSqlFlexibleServerIdentityTypeConverter))]
    public partial class PostgreSqlFlexibleServerIdentity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PostgreSqlFlexibleServerIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new PostgreSqlFlexibleServerIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PostgreSqlFlexibleServerIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new PostgreSqlFlexibleServerIdentity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PostgreSqlFlexibleServerIdentity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="PostgreSqlFlexibleServerIdentity" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PostgreSqlFlexibleServerIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal PostgreSqlFlexibleServerIdentity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("ServerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ServerName = (string) content.GetValueForProperty("ServerName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ServerName, global::System.Convert.ToString);
            }
            if (content.Contains("ObjectId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ObjectId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).MigrationName = (string) content.GetValueForProperty("MigrationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).MigrationName, global::System.Convert.ToString);
            }
            if (content.Contains("BackupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).BackupName = (string) content.GetValueForProperty("BackupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).BackupName, global::System.Convert.ToString);
            }
            if (content.Contains("ThreatProtectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ThreatProtectionName = (string) content.GetValueForProperty("ThreatProtectionName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ThreatProtectionName, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigurationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ConfigurationName = (string) content.GetValueForProperty("ConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ConfigurationName, global::System.Convert.ToString);
            }
            if (content.Contains("DatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).DatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("FirewallRuleName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).FirewallRuleName = (string) content.GetValueForProperty("FirewallRuleName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).FirewallRuleName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("GroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).GroupName = (string) content.GetValueForProperty("GroupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).GroupName, global::System.Convert.ToString);
            }
            if (content.Contains("TuningOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).TuningOption = (string) content.GetValueForProperty("TuningOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).TuningOption, global::System.Convert.ToString);
            }
            if (content.Contains("VirtualEndpointName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).VirtualEndpointName = (string) content.GetValueForProperty("VirtualEndpointName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).VirtualEndpointName, global::System.Convert.ToString);
            }
            if (content.Contains("LocationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).LocationName = (string) content.GetValueForProperty("LocationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).LocationName, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).Id, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.PostgreSqlFlexibleServerIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal PostgreSqlFlexibleServerIdentity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("SubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("ServerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ServerName = (string) content.GetValueForProperty("ServerName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ServerName, global::System.Convert.ToString);
            }
            if (content.Contains("ObjectId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ObjectId, global::System.Convert.ToString);
            }
            if (content.Contains("MigrationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).MigrationName = (string) content.GetValueForProperty("MigrationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).MigrationName, global::System.Convert.ToString);
            }
            if (content.Contains("BackupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).BackupName = (string) content.GetValueForProperty("BackupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).BackupName, global::System.Convert.ToString);
            }
            if (content.Contains("ThreatProtectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ThreatProtectionName = (string) content.GetValueForProperty("ThreatProtectionName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ThreatProtectionName, global::System.Convert.ToString);
            }
            if (content.Contains("ConfigurationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ConfigurationName = (string) content.GetValueForProperty("ConfigurationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).ConfigurationName, global::System.Convert.ToString);
            }
            if (content.Contains("DatabaseName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).DatabaseName = (string) content.GetValueForProperty("DatabaseName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).DatabaseName, global::System.Convert.ToString);
            }
            if (content.Contains("FirewallRuleName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).FirewallRuleName = (string) content.GetValueForProperty("FirewallRuleName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).FirewallRuleName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("GroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).GroupName = (string) content.GetValueForProperty("GroupName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).GroupName, global::System.Convert.ToString);
            }
            if (content.Contains("TuningOption"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).TuningOption = (string) content.GetValueForProperty("TuningOption",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).TuningOption, global::System.Convert.ToString);
            }
            if (content.Contains("VirtualEndpointName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).VirtualEndpointName = (string) content.GetValueForProperty("VirtualEndpointName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).VirtualEndpointName, global::System.Convert.ToString);
            }
            if (content.Contains("LocationName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).LocationName = (string) content.GetValueForProperty("LocationName",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).LocationName, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IPostgreSqlFlexibleServerIdentityInternal)this).Id, global::System.Convert.ToString);
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
    [System.ComponentModel.TypeConverter(typeof(PostgreSqlFlexibleServerIdentityTypeConverter))]
    public partial interface IPostgreSqlFlexibleServerIdentity

    {

    }
}