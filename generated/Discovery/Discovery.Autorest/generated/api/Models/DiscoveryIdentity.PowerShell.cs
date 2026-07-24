// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(DiscoveryIdentityTypeConverter))]
    public partial class DiscoveryIdentity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.DiscoveryIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DiscoveryIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.DiscoveryIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DiscoveryIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.DiscoveryIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DiscoveryIdentity(global::System.Collections.IDictionary content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("BookshelfName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).BookshelfName = (string) content.GetValueForProperty("BookshelfName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).BookshelfName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateLinkResourceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateLinkResourceName = (string) content.GetValueForProperty("PrivateLinkResourceName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateLinkResourceName, global::System.Convert.ToString);
            }
            if (content.Contains("ToolName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ToolName = (string) content.GetValueForProperty("ToolName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ToolName, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).WorkspaceName = (string) content.GetValueForProperty("WorkspaceName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).WorkspaceName, global::System.Convert.ToString);
            }
            if (content.Contains("ProjectName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ProjectName = (string) content.GetValueForProperty("ProjectName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ProjectName, global::System.Convert.ToString);
            }
            if (content.Contains("ChatModelDeploymentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ChatModelDeploymentName = (string) content.GetValueForProperty("ChatModelDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ChatModelDeploymentName, global::System.Convert.ToString);
            }
            if (content.Contains("SupercomputerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SupercomputerName = (string) content.GetValueForProperty("SupercomputerName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SupercomputerName, global::System.Convert.ToString);
            }
            if (content.Contains("NodePoolName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).NodePoolName = (string) content.GetValueForProperty("NodePoolName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).NodePoolName, global::System.Convert.ToString);
            }
            if (content.Contains("StorageContainerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageContainerName = (string) content.GetValueForProperty("StorageContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageContainerName, global::System.Convert.ToString);
            }
            if (content.Contains("StorageAssetName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageAssetName = (string) content.GetValueForProperty("StorageAssetName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageAssetName, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).Id, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.DiscoveryIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DiscoveryIdentity(global::System.Management.Automation.PSObject content)
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
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("BookshelfName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).BookshelfName = (string) content.GetValueForProperty("BookshelfName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).BookshelfName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateLinkResourceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateLinkResourceName = (string) content.GetValueForProperty("PrivateLinkResourceName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).PrivateLinkResourceName, global::System.Convert.ToString);
            }
            if (content.Contains("ToolName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ToolName = (string) content.GetValueForProperty("ToolName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ToolName, global::System.Convert.ToString);
            }
            if (content.Contains("WorkspaceName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).WorkspaceName = (string) content.GetValueForProperty("WorkspaceName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).WorkspaceName, global::System.Convert.ToString);
            }
            if (content.Contains("ProjectName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ProjectName = (string) content.GetValueForProperty("ProjectName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ProjectName, global::System.Convert.ToString);
            }
            if (content.Contains("ChatModelDeploymentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ChatModelDeploymentName = (string) content.GetValueForProperty("ChatModelDeploymentName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).ChatModelDeploymentName, global::System.Convert.ToString);
            }
            if (content.Contains("SupercomputerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SupercomputerName = (string) content.GetValueForProperty("SupercomputerName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).SupercomputerName, global::System.Convert.ToString);
            }
            if (content.Contains("NodePoolName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).NodePoolName = (string) content.GetValueForProperty("NodePoolName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).NodePoolName, global::System.Convert.ToString);
            }
            if (content.Contains("StorageContainerName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageContainerName = (string) content.GetValueForProperty("StorageContainerName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageContainerName, global::System.Convert.ToString);
            }
            if (content.Contains("StorageAssetName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageAssetName = (string) content.GetValueForProperty("StorageAssetName",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).StorageAssetName, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentityInternal)this).Id, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DiscoveryIdentity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DiscoveryIdentity" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    [System.ComponentModel.TypeConverter(typeof(DiscoveryIdentityTypeConverter))]
    public partial interface IDiscoveryIdentity

    {

    }
}