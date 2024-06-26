// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(WebsitesIdentityTypeConverter))]
    public partial class WebsitesIdentity
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.WebsitesIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new WebsitesIdentity(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.WebsitesIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new WebsitesIdentity(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="WebsitesIdentity" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="WebsitesIdentity" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.SerializationMode.IncludeAll)?.ToString();

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

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.WebsitesIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal WebsitesIdentity(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("SubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Authprovider"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Authprovider = (string) content.GetValueForProperty("Authprovider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Authprovider, global::System.Convert.ToString);
            }
            if (content.Contains("Userid"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Userid = (string) content.GetValueForProperty("Userid",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Userid, global::System.Convert.ToString);
            }
            if (content.Contains("EnvironmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).EnvironmentName = (string) content.GetValueForProperty("EnvironmentName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).EnvironmentName, global::System.Convert.ToString);
            }
            if (content.Contains("FunctionAppName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).FunctionAppName = (string) content.GetValueForProperty("FunctionAppName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).FunctionAppName, global::System.Convert.ToString);
            }
            if (content.Contains("DomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).DomainName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("WebJobName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).WebJobName, global::System.Convert.ToString);
            }
            if (content.Contains("Slot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Slot = (string) content.GetValueForProperty("Slot",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Slot, global::System.Convert.ToString);
            }
            if (content.Contains("JobHistoryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).JobHistoryId = (string) content.GetValueForProperty("JobHistoryId",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).JobHistoryId, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Id, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.WebsitesIdentity"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal WebsitesIdentity(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("Location"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Location = (string) content.GetValueForProperty("Location",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Location, global::System.Convert.ToString);
            }
            if (content.Contains("SubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).SubscriptionId = (string) content.GetValueForProperty("SubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).SubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("ResourceGroupName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).ResourceGroupName = (string) content.GetValueForProperty("ResourceGroupName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).ResourceGroupName, global::System.Convert.ToString);
            }
            if (content.Contains("Name"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Name, global::System.Convert.ToString);
            }
            if (content.Contains("Authprovider"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Authprovider = (string) content.GetValueForProperty("Authprovider",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Authprovider, global::System.Convert.ToString);
            }
            if (content.Contains("Userid"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Userid = (string) content.GetValueForProperty("Userid",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Userid, global::System.Convert.ToString);
            }
            if (content.Contains("EnvironmentName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).EnvironmentName = (string) content.GetValueForProperty("EnvironmentName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).EnvironmentName, global::System.Convert.ToString);
            }
            if (content.Contains("FunctionAppName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).FunctionAppName = (string) content.GetValueForProperty("FunctionAppName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).FunctionAppName, global::System.Convert.ToString);
            }
            if (content.Contains("DomainName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).DomainName = (string) content.GetValueForProperty("DomainName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).DomainName, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateEndpointConnectionName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).PrivateEndpointConnectionName = (string) content.GetValueForProperty("PrivateEndpointConnectionName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).PrivateEndpointConnectionName, global::System.Convert.ToString);
            }
            if (content.Contains("WebJobName"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).WebJobName = (string) content.GetValueForProperty("WebJobName",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).WebJobName, global::System.Convert.ToString);
            }
            if (content.Contains("Slot"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Slot = (string) content.GetValueForProperty("Slot",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Slot, global::System.Convert.ToString);
            }
            if (content.Contains("JobHistoryId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).JobHistoryId = (string) content.GetValueForProperty("JobHistoryId",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).JobHistoryId, global::System.Convert.ToString);
            }
            if (content.Contains("Id"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentityInternal)this).Id, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }
    }
    [System.ComponentModel.TypeConverter(typeof(WebsitesIdentityTypeConverter))]
    public partial interface IWebsitesIdentity

    {

    }
}