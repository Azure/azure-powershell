namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>VMwareV2 fabric specific details.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMwareV2FabricSpecificDetailsTypeConverter))]
    public partial class VMwareV2FabricSpecificDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareV2FabricSpecificDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMwareV2FabricSpecificDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareV2FabricSpecificDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMwareV2FabricSpecificDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMwareV2FabricSpecificDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareV2FabricSpecificDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMwareV2FabricSpecificDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).VmwareSiteId = (string) content.GetValueForProperty("VmwareSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).VmwareSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).PhysicalSiteId = (string) content.GetValueForProperty("PhysicalSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).PhysicalSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).MigrationSolutionId = (string) content.GetValueForProperty("MigrationSolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).MigrationSolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceResourceId = (string) content.GetValueForProperty("ServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.VMwareV2FabricSpecificDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMwareV2FabricSpecificDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).VmwareSiteId = (string) content.GetValueForProperty("VmwareSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).VmwareSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).PhysicalSiteId = (string) content.GetValueForProperty("PhysicalSiteId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).PhysicalSiteId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).MigrationSolutionId = (string) content.GetValueForProperty("MigrationSolutionId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).MigrationSolutionId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceEndpoint = (string) content.GetValueForProperty("ServiceEndpoint",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceEndpoint, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceResourceId = (string) content.GetValueForProperty("ServiceResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IVMwareV2FabricSpecificDetailsInternal)this).ServiceResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType = (string) content.GetValueForProperty("InstanceType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFabricSpecificDetailsInternal)this).InstanceType, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// VMwareV2 fabric specific details.
    [System.ComponentModel.TypeConverter(typeof(VMwareV2FabricSpecificDetailsTypeConverter))]
    public partial interface IVMwareV2FabricSpecificDetails

    {

    }
}