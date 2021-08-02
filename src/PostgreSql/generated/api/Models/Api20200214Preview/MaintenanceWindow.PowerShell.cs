namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.PowerShell;

    /// <summary>Maintenance window of a server.</summary>
    [System.ComponentModel.TypeConverter(typeof(MaintenanceWindowTypeConverter))]
    public partial class MaintenanceWindow
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.MaintenanceWindow"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MaintenanceWindow(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.MaintenanceWindow"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MaintenanceWindow(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MaintenanceWindow" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindow FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.MaintenanceWindow"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MaintenanceWindow(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).CustomWindow = (string) content.GetValueForProperty("CustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).CustomWindow, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartHour = (int?) content.GetValueForProperty("StartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartMinute = (int?) content.GetValueForProperty("StartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).DayOfWeek = (int?) content.GetValueForProperty("DayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).DayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.MaintenanceWindow"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MaintenanceWindow(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).CustomWindow = (string) content.GetValueForProperty("CustomWindow",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).CustomWindow, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartHour = (int?) content.GetValueForProperty("StartHour",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartHour, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartMinute = (int?) content.GetValueForProperty("StartMinute",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).StartMinute, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).DayOfWeek = (int?) content.GetValueForProperty("DayOfWeek",((Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IMaintenanceWindowInternal)this).DayOfWeek, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Maintenance window of a server.
    [System.ComponentModel.TypeConverter(typeof(MaintenanceWindowTypeConverter))]
    public partial interface IMaintenanceWindow

    {

    }
}