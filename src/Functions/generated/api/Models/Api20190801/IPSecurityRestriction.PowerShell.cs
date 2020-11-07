namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.PowerShell;

    /// <summary>IP security restriction on an app.</summary>
    [System.ComponentModel.TypeConverter(typeof(IPSecurityRestrictionTypeConverter))]
    public partial class IPSecurityRestriction
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new IPSecurityRestriction(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new IPSecurityRestriction(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="IPSecurityRestriction" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal IPSecurityRestriction(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Action = (string) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Action, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetMask = (string) content.GetValueForProperty("SubnetMask",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetMask, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetTrafficTag = (int?) content.GetValueForProperty("SubnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetTrafficTag, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag?) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetSubnetResourceId = (string) content.GetValueForProperty("VnetSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetSubnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetTrafficTag = (int?) content.GetValueForProperty("VnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetTrafficTag, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPSecurityRestriction"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal IPSecurityRestriction(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Action = (string) content.GetValueForProperty("Action",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Action, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Priority = (int?) content.GetValueForProperty("Priority",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Priority, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetMask = (string) content.GetValueForProperty("SubnetMask",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetMask, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetTrafficTag = (int?) content.GetValueForProperty("SubnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).SubnetTrafficTag, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag?) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.IPFilterTag.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetSubnetResourceId = (string) content.GetValueForProperty("VnetSubnetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetSubnetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetTrafficTag = (int?) content.GetValueForProperty("VnetTrafficTag",((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestrictionInternal)this).VnetTrafficTag, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// IP security restriction on an app.
    [System.ComponentModel.TypeConverter(typeof(IPSecurityRestrictionTypeConverter))]
    public partial interface IIPSecurityRestriction

    {

    }
}