namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>Application stack.</summary>
    [System.ComponentModel.TypeConverter(typeof(ApplicationStackTypeConverter))]
    public partial class ApplicationStack
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal ApplicationStack(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Dependency = (string) content.GetValueForProperty("Dependency",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Dependency, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Display = (string) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Display, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Framework = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[]) content.GetValueForProperty("Framework",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Framework, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStackTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).MajorVersion = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[]) content.GetValueForProperty("MajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).MajorVersion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersionTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal ApplicationStack(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Dependency = (string) content.GetValueForProperty("Dependency",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Dependency, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Display = (string) content.GetValueForProperty("Display",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Display, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Framework = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack[]) content.GetValueForProperty("Framework",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).Framework, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStackTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).MajorVersion = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion[]) content.GetValueForProperty("MajorVersion",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStackInternal)this).MajorVersion, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStackMajorVersion>(__y, Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.StackMajorVersionTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new ApplicationStack(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApplicationStack"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new ApplicationStack(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="ApplicationStack" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApplicationStack FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Application stack.
    [System.ComponentModel.TypeConverter(typeof(ApplicationStackTypeConverter))]
    public partial interface IApplicationStack

    {

    }
}