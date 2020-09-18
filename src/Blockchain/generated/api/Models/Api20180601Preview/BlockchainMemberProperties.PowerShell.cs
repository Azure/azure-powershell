namespace Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview
{
    using Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.PowerShell;

    /// <summary>Payload of the blockchain member properties for a blockchain member.</summary>
    [System.ComponentModel.TypeConverter(typeof(BlockchainMemberPropertiesTypeConverter))]
    public partial class BlockchainMemberProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal BlockchainMemberProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodesSku = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku) content.GetValueForProperty("ValidatorNodesSku",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodesSku, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberNodesSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Dns = (string) content.GetValueForProperty("Dns",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Dns, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).UserName = (string) content.GetValueForProperty("UserName",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).UserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Password = (string) content.GetValueForProperty("Password",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Password, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Consortium = (string) content.GetValueForProperty("Consortium",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Consortium, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountAddress = (string) content.GetValueForProperty("ConsortiumManagementAccountAddress",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountPassword = (string) content.GetValueForProperty("ConsortiumManagementAccountPassword",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumRole = (string) content.GetValueForProperty("ConsortiumRole",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumRole, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumMemberDisplayName = (string) content.GetValueForProperty("ConsortiumMemberDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumMemberDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).RootContractAddress = (string) content.GetValueForProperty("RootContractAddress",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).RootContractAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).PublicKey = (string) content.GetValueForProperty("PublicKey",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).PublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).FirewallRule = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[]) content.GetValueForProperty("FirewallRule",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).FirewallRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.FirewallRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodeSkuCapacity = (int?) content.GetValueForProperty("ValidatorNodeSkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodeSkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal BlockchainMemberProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodesSku = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberNodesSku) content.GetValueForProperty("ValidatorNodesSku",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodesSku, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberNodesSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol?) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainProtocol.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Support.BlockchainMemberProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Dns = (string) content.GetValueForProperty("Dns",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Dns, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).UserName = (string) content.GetValueForProperty("UserName",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).UserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Password = (string) content.GetValueForProperty("Password",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Password, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Consortium = (string) content.GetValueForProperty("Consortium",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).Consortium, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountAddress = (string) content.GetValueForProperty("ConsortiumManagementAccountAddress",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountPassword = (string) content.GetValueForProperty("ConsortiumManagementAccountPassword",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumManagementAccountPassword, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumRole = (string) content.GetValueForProperty("ConsortiumRole",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumRole, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumMemberDisplayName = (string) content.GetValueForProperty("ConsortiumMemberDisplayName",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ConsortiumMemberDisplayName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).RootContractAddress = (string) content.GetValueForProperty("RootContractAddress",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).RootContractAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).PublicKey = (string) content.GetValueForProperty("PublicKey",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).PublicKey, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).FirewallRule = (Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule[]) content.GetValueForProperty("FirewallRule",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).FirewallRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IFirewallRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.FirewallRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodeSkuCapacity = (int?) content.GetValueForProperty("ValidatorNodeSkuCapacity",((Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberPropertiesInternal)this).ValidatorNodeSkuCapacity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new BlockchainMemberProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.BlockchainMemberProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new BlockchainMemberProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="BlockchainMemberProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Models.Api20180601Preview.IBlockchainMemberProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Blockchain.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Payload of the blockchain member properties for a blockchain member.
    [System.ComponentModel.TypeConverter(typeof(BlockchainMemberPropertiesTypeConverter))]
    public partial interface IBlockchainMemberProperties

    {

    }
}