namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Details about app recovery operation.</summary>
    [System.ComponentModel.TypeConverter(typeof(SnapshotRestoreRequestTypeConverter))]
    public partial class SnapshotRestoreRequest
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SnapshotRestoreRequest(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SnapshotRestoreRequest(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SnapshotRestoreRequest" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequest FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SnapshotRestoreRequest(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequestPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource) content.GetValueForProperty("RecoverySource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRecoverySourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).SnapshotTime = (string) content.GetValueForProperty("SnapshotTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).SnapshotTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Overwrite = (bool) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverConfiguration = (bool?) content.GetValueForProperty("RecoverConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverConfiguration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).IgnoreConflictingHostName = (bool?) content.GetValueForProperty("IgnoreConflictingHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).IgnoreConflictingHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).UseDrSecondary = (bool?) content.GetValueForProperty("UseDrSecondary",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).UseDrSecondary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceLocation = (string) content.GetValueForProperty("RecoverySourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceId = (string) content.GetValueForProperty("RecoverySourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceId, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequest"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SnapshotRestoreRequest(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRestoreRequestPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind = (string) content.GetValueForProperty("Kind",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Kind, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySource = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRecoverySource) content.GetValueForProperty("RecoverySource",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySource, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SnapshotRecoverySourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).SnapshotTime = (string) content.GetValueForProperty("SnapshotTime",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).SnapshotTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Overwrite = (bool) content.GetValueForProperty("Overwrite",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).Overwrite, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverConfiguration = (bool?) content.GetValueForProperty("RecoverConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverConfiguration, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).IgnoreConflictingHostName = (bool?) content.GetValueForProperty("IgnoreConflictingHostName",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).IgnoreConflictingHostName, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).UseDrSecondary = (bool?) content.GetValueForProperty("UseDrSecondary",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).UseDrSecondary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceLocation = (string) content.GetValueForProperty("RecoverySourceLocation",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceId = (string) content.GetValueForProperty("RecoverySourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISnapshotRestoreRequestInternal)this).RecoverySourceId, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Details about app recovery operation.
    [System.ComponentModel.TypeConverter(typeof(SnapshotRestoreRequestTypeConverter))]
    public partial interface ISnapshotRestoreRequest

    {

    }
}