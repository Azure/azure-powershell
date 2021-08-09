namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.PowerShell;

    /// <summary>Azure App Configuration error object.</summary>
    [System.ComponentModel.TypeConverter(typeof(ErrorTypeConverter))]
    public partial class Error
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.Error"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Error(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.Error"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Error(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.Error"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Error(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Title = (string) content.GetValueForProperty("Title",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Title, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Detail = (string) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Detail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Status = (int?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Status, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.Error"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Error(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Title = (string) content.GetValueForProperty("Title",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Title, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Detail = (string) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Detail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Status = (int?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal)this).Status, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Error" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Azure App Configuration error object.
    [System.ComponentModel.TypeConverter(typeof(ErrorTypeConverter))]
    public partial interface IError

    {

    }
}