namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.PowerShell;

    /// <summary>Second level object returned as part of Machine REST resource.</summary>
    [System.ComponentModel.TypeConverter(typeof(VMwareDiskTypeConverter))]
    public partial class VMwareDisk
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareDisk"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VMwareDisk(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareDisk"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VMwareDisk(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VMwareDisk" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDisk FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareDisk"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VMwareDisk(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Uuid = (string) content.GetValueForProperty("Uuid",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Uuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Label = (string) content.GetValueForProperty("Label",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Label, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskProvisioningPolicy = (string) content.GetValueForProperty("DiskProvisioningPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskProvisioningPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskScrubbingPolicy = (string) content.GetValueForProperty("DiskScrubbingPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskScrubbingPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskMode = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode?) content.GetValueForProperty("DiskMode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskMode, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).MaxSizeInByte = (long?) content.GetValueForProperty("MaxSizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).MaxSizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskType = (string) content.GetValueForProperty("DiskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Lun = (int?) content.GetValueForProperty("Lun",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Lun, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Path, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.VMwareDisk"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VMwareDisk(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Uuid = (string) content.GetValueForProperty("Uuid",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Uuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Label = (string) content.GetValueForProperty("Label",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Label, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskProvisioningPolicy = (string) content.GetValueForProperty("DiskProvisioningPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskProvisioningPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskScrubbingPolicy = (string) content.GetValueForProperty("DiskScrubbingPolicy",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskScrubbingPolicy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskMode = (Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode?) content.GetValueForProperty("DiskMode",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskMode, Microsoft.Azure.PowerShell.Cmdlets.Migrate.Support.VirtualDiskMode.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).MaxSizeInByte = (long?) content.GetValueForProperty("MaxSizeInByte",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).MaxSizeInByte, (__y)=> (long) global::System.Convert.ChangeType(__y, typeof(long)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskType = (string) content.GetValueForProperty("DiskType",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).DiskType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Lun = (int?) content.GetValueForProperty("Lun",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Lun, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Path = (string) content.GetValueForProperty("Path",((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareDiskInternal)this).Path, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }
    }
    /// Second level object returned as part of Machine REST resource.
    [System.ComponentModel.TypeConverter(typeof(VMwareDiskTypeConverter))]
    public partial interface IVMwareDisk

    {

    }
}