namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.PowerShell;

    /// <summary>Active Directory user information.</summary>
    [System.ComponentModel.TypeConverter(typeof(UserTypeConverter))]
    public partial class User
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.User"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new User(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.User"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new User(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="User" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.User"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal User(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).GivenName = (string) content.GetValueForProperty("GivenName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).GivenName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).ImmutableId = (string) content.GetValueForProperty("ImmutableId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).ImmutableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Mail = (string) content.GetValueForProperty("Mail",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Mail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).MailNickname = (string) content.GetValueForProperty("MailNickname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).MailNickname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).SignInName = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[]) content.GetValueForProperty("SignInName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).SignInName, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.SignInNameTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Surname = (string) content.GetValueForProperty("Surname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Surname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).UsageLocation = (string) content.GetValueForProperty("UsageLocation",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).UsageLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).PrincipalName = (string) content.GetValueForProperty("PrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).PrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.User"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal User(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).AccountEnabled = (bool?) content.GetValueForProperty("AccountEnabled",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).AccountEnabled, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).DisplayName = (string) content.GetValueForProperty("DisplayName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).DisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).GivenName = (string) content.GetValueForProperty("GivenName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).GivenName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).ImmutableId = (string) content.GetValueForProperty("ImmutableId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).ImmutableId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Mail = (string) content.GetValueForProperty("Mail",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Mail, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).MailNickname = (string) content.GetValueForProperty("MailNickname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).MailNickname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).SignInName = (Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName[]) content.GetValueForProperty("SignInName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).SignInName, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.ISignInName>(__y, Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.SignInNameTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Surname = (string) content.GetValueForProperty("Surname",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Surname, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).UsageLocation = (string) content.GetValueForProperty("UsageLocation",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).UsageLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).PrincipalName = (string) content.GetValueForProperty("PrincipalName",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).PrincipalName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Type = (Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType?) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUserInternal)this).Type, Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp = (global::System.DateTime?) content.GetValueForProperty("DeletionTimestamp",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).DeletionTimestamp, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId = (string) content.GetValueForProperty("ObjectId",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType = (string) content.GetValueForProperty("ObjectType",((Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObjectInternal)this).ObjectType, global::System.Convert.ToString);
            // this type is a dictionary; copy elements from source to here.
            CopyFrom(content);
            AfterDeserializePSObject(content);
        }
    }
    /// Active Directory user information.
    [System.ComponentModel.TypeConverter(typeof(UserTypeConverter))]
    public partial interface IUser

    {

    }
}