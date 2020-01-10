namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>
    /// Information about an issue encountered in the process of checking for connectivity.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(ConnectivityIssueTypeConverter))]
    public partial class ConnectivityIssue
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityIssue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ConnectivityIssue(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Context = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[]) content.GetValueForProperty("Context",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Context, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IssueContextTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Origin = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin?) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Origin, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Severity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity?) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Severity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityIssue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ConnectivityIssue(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IssueType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Context = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext[]) content.GetValueForProperty("Context",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Context, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IIssueContext>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IssueContextTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Origin = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin?) content.GetValueForProperty("Origin",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Origin, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Origin.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Severity = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity?) content.GetValueForProperty("Severity",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssueInternal)this).Severity, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Severity.CreateFrom);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityIssue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ConnectivityIssue(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ConnectivityIssue"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ConnectivityIssue(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ConnectivityIssue" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectivityIssue FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Information about an issue encountered in the process of checking for connectivity.
    [System.ComponentModel.TypeConverter(typeof(ConnectivityIssueTypeConverter))]
    public partial interface IConnectivityIssue

    {

    }
}