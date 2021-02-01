namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(UserBaseTypeConverter))]
    public partial class UserBase
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.UserBase"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new UserBase(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.UserBase"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new UserBase(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="UserBase" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBase FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.UserBase"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal UserBase(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).GivenName = (string) content.GetValueForProperty("GivenName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).GivenName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).ImmutableId = (string) content.GetValueForProperty("ImmutableId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).ImmutableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).Surname = (string) content.GetValueForProperty("Surname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).Surname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UsageLocation = (string) content.GetValueForProperty("UsageLocation",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UsageLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UserType = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType?) content.GetValueForProperty("UserType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UserType, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType.CreateFrom);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.UserBase"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal UserBase(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).GivenName = (string) content.GetValueForProperty("GivenName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).GivenName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).ImmutableId = (string) content.GetValueForProperty("ImmutableId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).ImmutableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).Surname = (string) content.GetValueForProperty("Surname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).Surname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UsageLocation = (string) content.GetValueForProperty("UsageLocation",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UsageLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UserType = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType?) content.GetValueForProperty("UserType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserBaseInternal)this).UserType, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType.CreateFrom);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }
    }
    [System.ComponentModel.TypeConverter(typeof(UserBaseTypeConverter))]
    public partial interface IUserBase

    {

    }
}