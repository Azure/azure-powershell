namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Hyper V VM network details.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMNicDetailsTypeConverter))]
    public partial class VMNicDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMNicDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMNicDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMNicDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMNicDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicId = (string) content.GetValueForProperty("ReplicaNicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SourceNicArmId = (string) content.GetValueForProperty("SourceNicArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SourceNicArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMSubnetName = (string) content.GetValueForProperty("VMSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMNetworkName = (string) content.GetValueForProperty("VMNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMNetworkId = (string) content.GetValueForProperty("RecoveryVMNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMSubnetName = (string) content.GetValueForProperty("RecoveryVMSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).IPAddressType = (string) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).IPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).PrimaryNicStaticIPAddress = (string) content.GetValueForProperty("PrimaryNicStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).PrimaryNicStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicStaticIPAddress = (string) content.GetValueForProperty("ReplicaNicStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SelectionType = (string) content.GetValueForProperty("SelectionType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SelectionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryNicIPAddressType = (string) content.GetValueForProperty("RecoveryNicIPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryNicIPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).EnableAcceleratedNetworkingOnRecovery = (bool?) content.GetValueForProperty("EnableAcceleratedNetworkingOnRecovery",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).EnableAcceleratedNetworkingOnRecovery, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMNicDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMNicDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).NicId = (string) content.GetValueForProperty("NicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).NicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicId = (string) content.GetValueForProperty("ReplicaNicId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SourceNicArmId = (string) content.GetValueForProperty("SourceNicArmId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SourceNicArmId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMSubnetName = (string) content.GetValueForProperty("VMSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMNetworkName = (string) content.GetValueForProperty("VMNetworkName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).VMNetworkName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMNetworkId = (string) content.GetValueForProperty("RecoveryVMNetworkId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMNetworkId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMSubnetName = (string) content.GetValueForProperty("RecoveryVMSubnetName",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryVMSubnetName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).IPAddressType = (string) content.GetValueForProperty("IPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).IPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).PrimaryNicStaticIPAddress = (string) content.GetValueForProperty("PrimaryNicStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).PrimaryNicStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicStaticIPAddress = (string) content.GetValueForProperty("ReplicaNicStaticIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).ReplicaNicStaticIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SelectionType = (string) content.GetValueForProperty("SelectionType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).SelectionType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryNicIPAddressType = (string) content.GetValueForProperty("RecoveryNicIPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).RecoveryNicIPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).EnableAcceleratedNetworkingOnRecovery = (bool?) content.GetValueForProperty("EnableAcceleratedNetworkingOnRecovery",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMNicDetailsInternal)this).EnableAcceleratedNetworkingOnRecovery, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            AfterDeserializePSObject(content);
        }
    }
    /// Hyper V VM network details.
    [System.ComponentModel.TypeConverter(typeof(VMNicDetailsTypeConverter))]
    public partial interface IVMNicDetails

    {

    }
}