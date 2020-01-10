namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>Parameters that define the IP flow to be verified.</summary>
    [System.ComponentModel.TypeConverter(typeof(VerificationIPFlowParametersTypeConverter))]
    public partial class VerificationIPFlowParameters
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VerificationIPFlowParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new VerificationIPFlowParameters(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VerificationIPFlowParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new VerificationIPFlowParameters(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="VerificationIPFlowParameters" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParameters FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VerificationIPFlowParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal VerificationIPFlowParameters(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalIPAddress = (string) content.GetValueForProperty("LocalIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalPort = (string) content.GetValueForProperty("LocalPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalPort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemoteIPAddress = (string) content.GetValueForProperty("RemoteIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemoteIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemotePort = (string) content.GetValueForProperty("RemotePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemotePort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetNicResourceId = (string) content.GetValueForProperty("TargetNicResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetNicResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetResourceId = (string) content.GetValueForProperty("TargetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol.CreateFrom);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VerificationIPFlowParameters"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal VerificationIPFlowParameters(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Direction = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction) content.GetValueForProperty("Direction",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Direction, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Direction.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalIPAddress = (string) content.GetValueForProperty("LocalIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalPort = (string) content.GetValueForProperty("LocalPort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).LocalPort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemoteIPAddress = (string) content.GetValueForProperty("RemoteIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemoteIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemotePort = (string) content.GetValueForProperty("RemotePort",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).RemotePort, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetNicResourceId = (string) content.GetValueForProperty("TargetNicResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetNicResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetResourceId = (string) content.GetValueForProperty("TargetResourceId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).TargetResourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Protocol = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol) content.GetValueForProperty("Protocol",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowParametersInternal)this).Protocol, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPFlowProtocol.CreateFrom);
            AfterDeserializePSObject(content);
        }
    }
    /// Parameters that define the IP flow to be verified.
    [System.ComponentModel.TypeConverter(typeof(VerificationIPFlowParametersTypeConverter))]
    public partial interface IVerificationIPFlowParameters

    {

    }
}