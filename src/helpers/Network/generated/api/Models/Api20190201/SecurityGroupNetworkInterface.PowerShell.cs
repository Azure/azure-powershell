namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Network interface and all its associated security rules.</summary>
    [System.ComponentModel.TypeConverter(typeof(SecurityGroupNetworkInterfaceTypeConverter))]
    public partial class SecurityGroupNetworkInterface
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityGroupNetworkInterface"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new SecurityGroupNetworkInterface(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityGroupNetworkInterface"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new SecurityGroupNetworkInterface(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="SecurityGroupNetworkInterface" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityGroupNetworkInterface"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal SecurityGroupNetworkInterface(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations) content.GetValueForProperty("SecurityRuleAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleAssociationsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationSubnetAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation) content.GetValueForProperty("SecurityRuleAssociationSubnetAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationSubnetAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubnetAssociationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationNetworkInterfaceAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation) content.GetValueForProperty("SecurityRuleAssociationNetworkInterfaceAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationNetworkInterfaceAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceAssociationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationDefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("SecurityRuleAssociationDefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationDefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationEffectiveSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[]) content.GetValueForProperty("SecurityRuleAssociationEffectiveSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationEffectiveSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationId = (string) content.GetValueForProperty("NetworkInterfaceAssociationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("NetworkInterfaceAssociationSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationId = (string) content.GetValueForProperty("SubnetAssociationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("SubnetAssociationSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityGroupNetworkInterface"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal SecurityGroupNetworkInterface(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRuleAssociations) content.GetValueForProperty("SecurityRuleAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleAssociationsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationSubnetAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnetAssociation) content.GetValueForProperty("SecurityRuleAssociationSubnetAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationSubnetAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubnetAssociationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationNetworkInterfaceAssociation = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceAssociation) content.GetValueForProperty("SecurityRuleAssociationNetworkInterfaceAssociation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationNetworkInterfaceAssociation, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceAssociationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationDefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("SecurityRuleAssociationDefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationDefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationEffectiveSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule[]) content.GetValueForProperty("SecurityRuleAssociationEffectiveSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SecurityRuleAssociationEffectiveSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEffectiveNetworkSecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EffectiveNetworkSecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationId = (string) content.GetValueForProperty("NetworkInterfaceAssociationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("NetworkInterfaceAssociationSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).NetworkInterfaceAssociationSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationId = (string) content.GetValueForProperty("SubnetAssociationId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[]) content.GetValueForProperty("SubnetAssociationSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterfaceInternal)this).SubnetAssociationSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SecurityRuleTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Network interface and all its associated security rules.
    [System.ComponentModel.TypeConverter(typeof(SecurityGroupNetworkInterfaceTypeConverter))]
    public partial interface ISecurityGroupNetworkInterface

    {

    }
}