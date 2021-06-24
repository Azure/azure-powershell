namespace Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.PowerShell;

    /// <summary>Scaling plan properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(ScalingPlanPropertiesTypeConverter))]
    public partial class ScalingPlanProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ScalingPlanProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ScalingPlanProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ScalingPlanProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ScalingPlanProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).TimeZone = (string) content.GetValueForProperty("TimeZone",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).TimeZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolType = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType?) content.GetValueForProperty("HostPoolType",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolType, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).ExclusionTag = (string) content.GetValueForProperty("ExclusionTag",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).ExclusionTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Schedule = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[]) content.GetValueForProperty("Schedule",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Schedule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule>(__y, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingScheduleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolReference = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[]) content.GetValueForProperty("HostPoolReference",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolReference, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingHostPoolReferenceTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingPlanProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ScalingPlanProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).FriendlyName = (string) content.GetValueForProperty("FriendlyName",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).FriendlyName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).TimeZone = (string) content.GetValueForProperty("TimeZone",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).TimeZone, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolType = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType?) content.GetValueForProperty("HostPoolType",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolType, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).ExclusionTag = (string) content.GetValueForProperty("ExclusionTag",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).ExclusionTag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Schedule = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule[]) content.GetValueForProperty("Schedule",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).Schedule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingSchedule>(__y, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingScheduleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolReference = (Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference[]) content.GetValueForProperty("HostPoolReference",((Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingPlanPropertiesInternal)this).HostPoolReference, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.IScalingHostPoolReference>(__y, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20210201Preview.ScalingHostPoolReferenceTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Scaling plan properties.
    [System.ComponentModel.TypeConverter(typeof(ScalingPlanPropertiesTypeConverter))]
    public partial interface IScalingPlanProperties

    {

    }
}