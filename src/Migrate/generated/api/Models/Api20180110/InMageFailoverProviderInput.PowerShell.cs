namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Provider specific input for InMage failover.</summary>
    [System.ComponentModel.TypeConverter(typeof(InMageFailoverProviderInputTypeConverter))]
    public partial class InMageFailoverProviderInput
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageFailoverProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInput DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new InMageFailoverProviderInput(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageFailoverProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInput"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInput DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new InMageFailoverProviderInput(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="InMageFailoverProviderInput" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInput FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageFailoverProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal InMageFailoverProviderInput(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPointType?) content.GetValueForProperty("RecoveryPointType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPointType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.InMageFailoverProviderInput"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal InMageFailoverProviderInput(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointType = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPointType?) content.GetValueForProperty("RecoveryPointType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointType, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.RecoveryPointType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointId = (string) content.GetValueForProperty("RecoveryPointId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IInMageFailoverProviderInputInternal)this).RecoveryPointId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProviderSpecificFailoverInputInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Provider specific input for InMage failover.
    [System.ComponentModel.TypeConverter(typeof(InMageFailoverProviderInputTypeConverter))]
    public partial interface IInMageFailoverProviderInput

    {

    }
}