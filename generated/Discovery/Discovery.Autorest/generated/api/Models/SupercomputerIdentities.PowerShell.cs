// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.PowerShell;

    /// <summary>Dictionary of identity properties for the Supercomputer.</summary>
    [System.ComponentModel.TypeConverter(typeof(SupercomputerIdentitiesTypeConverter))]
    public partial class SupercomputerIdentities
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SupercomputerIdentities(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SupercomputerIdentities(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SupercomputerIdentities" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="SupercomputerIdentities" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SupercomputerIdentities(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("ClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("KubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).WorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("WorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).WorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentities"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SupercomputerIdentities(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("ClusterIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("ClusterIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("KubeletIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity) content.GetValueForProperty("KubeletIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IdentityTypeConverter.ConvertFrom);
            }
            if (content.Contains("WorkloadIdentity"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).WorkloadIdentity = (Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) content.GetValueForProperty("WorkloadIdentity",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).WorkloadIdentity, Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentitiesTypeConverter.ConvertFrom);
            }
            if (content.Contains("ClusterIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityId = (string) content.GetValueForProperty("ClusterIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityId = (string) content.GetValueForProperty("KubeletIdentityId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityPrincipalId = (string) content.GetValueForProperty("ClusterIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("ClusterIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityClientId = (string) content.GetValueForProperty("ClusterIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).ClusterIdentityClientId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityPrincipalId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityPrincipalId = (string) content.GetValueForProperty("KubeletIdentityPrincipalId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityPrincipalId, global::System.Convert.ToString);
            }
            if (content.Contains("KubeletIdentityClientId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityClientId = (string) content.GetValueForProperty("KubeletIdentityClientId",((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal)this).KubeletIdentityClientId, global::System.Convert.ToString);
            }
            AfterDeserializePSObject(content);
        }

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
    /// Dictionary of identity properties for the Supercomputer.
    [System.ComponentModel.TypeConverter(typeof(SupercomputerIdentitiesTypeConverter))]
    public partial interface ISupercomputerIdentities

    {

    }
}