// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Runtime.PowerShell;

    /// <summary>The updatable properties of the FileSystemResource.</summary>
    [System.ComponentModel.TypeConverter(typeof(FileSystemResourceUpdatePropertiesTypeConverter))]
    public partial class FileSystemResourceUpdateProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.FileSystemResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdateProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new FileSystemResourceUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.FileSystemResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdateProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdateProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new FileSystemResourceUpdateProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.FileSystemResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal FileSystemResourceUpdateProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MarketplaceDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetail = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IMarketplaceDetails) content.GetValueForProperty("MarketplaceDetail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetail, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.MarketplaceDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("UserDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetail = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IUserDetails) content.GetValueForProperty("UserDetail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetail, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.UserDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DelegatedSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).DelegatedSubnetId = (string) content.GetValueForProperty("DelegatedSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).DelegatedSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterLoginUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).ClusterLoginUrl = (string) content.GetValueForProperty("ClusterLoginUrl",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).ClusterLoginUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateIP"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).PrivateIP = (string[]) content.GetValueForProperty("PrivateIP",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).PrivateIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("MarketplaceDetailPlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPlanId = (string) content.GetValueForProperty("MarketplaceDetailPlanId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPlanId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailOfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailOfferId = (string) content.GetValueForProperty("MarketplaceDetailOfferId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailOfferId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPublisherId = (string) content.GetValueForProperty("MarketplaceDetailPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("UserDetailEmail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetailEmail = (string) content.GetValueForProperty("UserDetailEmail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetailEmail, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailMarketplaceSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionId = (string) content.GetValueForProperty("MarketplaceDetailMarketplaceSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailMarketplaceSubscriptionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceDetailMarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.MarketplaceSubscriptionStatus.CreateFrom);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.FileSystemResourceUpdateProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal FileSystemResourceUpdateProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("MarketplaceDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetail = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IMarketplaceDetails) content.GetValueForProperty("MarketplaceDetail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetail, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.MarketplaceDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("UserDetail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetail = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IUserDetails) content.GetValueForProperty("UserDetail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetail, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.UserDetailsTypeConverter.ConvertFrom);
            }
            if (content.Contains("DelegatedSubnetId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).DelegatedSubnetId = (string) content.GetValueForProperty("DelegatedSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).DelegatedSubnetId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterLoginUrl"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).ClusterLoginUrl = (string) content.GetValueForProperty("ClusterLoginUrl",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).ClusterLoginUrl, global::System.Convert.ToString);
            }
            if (content.Contains("PrivateIP"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).PrivateIP = (string[]) content.GetValueForProperty("PrivateIP",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).PrivateIP, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            }
            if (content.Contains("MarketplaceDetailPlanId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPlanId = (string) content.GetValueForProperty("MarketplaceDetailPlanId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPlanId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailOfferId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailOfferId = (string) content.GetValueForProperty("MarketplaceDetailOfferId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailOfferId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailPublisherId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPublisherId = (string) content.GetValueForProperty("MarketplaceDetailPublisherId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailPublisherId, global::System.Convert.ToString);
            }
            if (content.Contains("UserDetailEmail"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetailEmail = (string) content.GetValueForProperty("UserDetailEmail",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).UserDetailEmail, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailMarketplaceSubscriptionId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionId = (string) content.GetValueForProperty("MarketplaceDetailMarketplaceSubscriptionId",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionId, global::System.Convert.ToString);
            }
            if (content.Contains("MarketplaceDetailMarketplaceSubscriptionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionStatus = (Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.MarketplaceSubscriptionStatus?) content.GetValueForProperty("MarketplaceDetailMarketplaceSubscriptionStatus",((Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdatePropertiesInternal)this).MarketplaceDetailMarketplaceSubscriptionStatus, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Support.MarketplaceSubscriptionStatus.CreateFrom);
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="FileSystemResourceUpdateProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>
        /// an instance of the <see cref="FileSystemResourceUpdateProperties" /> model class.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Models.Api20221012Preview.IFileSystemResourceUpdateProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Qumulo.Runtime.SerializationMode.IncludeAll)?.ToString();

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
    /// The updatable properties of the FileSystemResource.
    [System.ComponentModel.TypeConverter(typeof(FileSystemResourceUpdatePropertiesTypeConverter))]
    public partial interface IFileSystemResourceUpdateProperties

    {

    }
}