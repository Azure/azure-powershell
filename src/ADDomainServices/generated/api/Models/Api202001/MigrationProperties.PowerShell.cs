namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.PowerShell;

    /// <summary>Migration Properties</summary>
    [System.ComponentModel.TypeConverter(typeof(MigrationPropertiesTypeConverter))]
    public partial class MigrationProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MigrationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MigrationProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MigrationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MigrationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgress = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress) content.GetValueForProperty("MigrationProgress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgress, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProgressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldSubnetId = (string) content.GetValueForProperty("OldSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldVnetSiteId = (string) content.GetValueForProperty("OldVnetSiteId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldVnetSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressCompletionPercentage = (double?) content.GetValueForProperty("MigrationProgressCompletionPercentage",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressCompletionPercentage, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressMessage = (string) content.GetValueForProperty("MigrationProgressMessage",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressMessage, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MigrationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgress = (Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress) content.GetValueForProperty("MigrationProgress",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgress, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProgressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldSubnetId = (string) content.GetValueForProperty("OldSubnetId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldSubnetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldVnetSiteId = (string) content.GetValueForProperty("OldVnetSiteId",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).OldVnetSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressCompletionPercentage = (double?) content.GetValueForProperty("MigrationProgressCompletionPercentage",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressCompletionPercentage, (__y)=> (double) global::System.Convert.ChangeType(__y, typeof(double)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressMessage = (string) content.GetValueForProperty("MigrationProgressMessage",((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal)this).MigrationProgressMessage, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Migration Properties
    [System.ComponentModel.TypeConverter(typeof(MigrationPropertiesTypeConverter))]
    public partial interface IMigrationProperties

    {

    }
}