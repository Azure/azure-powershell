namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Defines the move resource status.</summary>
    [System.ComponentModel.TypeConverter(typeof(MoveResourceStatusTypeConverter))]
    public partial class MoveResourceStatus
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MoveResourceStatus(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MoveResourceStatus(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MoveResourceStatus" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MoveResourceStatus(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus) content.GetValueForProperty("JobStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.JobStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).MoveState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState?) content.GetValueForProperty("MoveState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).MoveState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobName = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName?) content.GetValueForProperty("JobStatusJobName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobName, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobProgress = (string) content.GetValueForProperty("JobStatusJobProgress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobProgress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).ErrorProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("ErrorProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).ErrorProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatus"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MoveResourceStatus(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus) content.GetValueForProperty("JobStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.JobStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).MoveState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState?) content.GetValueForProperty("MoveState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).MoveState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobName = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName?) content.GetValueForProperty("JobStatusJobName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobName, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobProgress = (string) content.GetValueForProperty("JobStatusJobProgress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).JobStatusJobProgress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).ErrorProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("ErrorProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).ErrorProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Code = (string) content.GetValueForProperty("Code",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Code, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Message = (string) content.GetValueForProperty("Message",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Message, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Target = (string) content.GetValueForProperty("Target",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Target, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatusInternal)this).Detail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Defines the move resource status.
    [System.ComponentModel.TypeConverter(typeof(MoveResourceStatusTypeConverter))]
    public partial interface IMoveResourceStatus

    {

    }
}