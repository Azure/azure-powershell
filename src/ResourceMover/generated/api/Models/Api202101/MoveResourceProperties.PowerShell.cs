namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.PowerShell;

    /// <summary>Defines the move resource properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(MoveResourcePropertiesTypeConverter))]
    public partial class MoveResourceProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MoveResourceProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MoveResourceProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MoveResourceProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MoveResourceProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus) content.GetValueForProperty("MoveStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceId = (string) content.GetValueForProperty("SourceId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).TargetId = (string) content.GetValueForProperty("TargetId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).TargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ExistingTargetId = (string) content.GetValueForProperty("ExistingTargetId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ExistingTargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ResourceSetting = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) content.GetValueForProperty("ResourceSetting",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ResourceSetting, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceResourceSetting = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) content.GetValueForProperty("SourceResourceSetting",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceResourceSetting, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOn = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[]) content.GetValueForProperty("DependsOn",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOn, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceDependencyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOnOverride = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[]) content.GetValueForProperty("DependsOnOverride",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOnOverride, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceDependencyOverrideTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).IsResolveRequired = (bool?) content.GetValueForProperty("IsResolveRequired",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).IsResolveRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusJobStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus) content.GetValueForProperty("MoveStatusJobStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusJobStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.JobStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusMoveState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState?) content.GetValueForProperty("MoveStatusMoveState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusMoveState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusError = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("MoveStatusError",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusError, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobName = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName?) content.GetValueForProperty("JobStatusJobName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobName, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobProgress = (string) content.GetValueForProperty("JobStatusJobProgress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobProgress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("ErrorsProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("MoveStatusErrorsProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesCode = (string) content.GetValueForProperty("ErrorsPropertiesCode",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesMessage = (string) content.GetValueForProperty("ErrorsPropertiesMessage",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesTarget = (string) content.GetValueForProperty("ErrorsPropertiesTarget",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesDetail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("ErrorsPropertiesDetail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesCode = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesCode",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesMessage = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesMessage",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesTarget = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesTarget",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesDetail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("MoveStatusErrorsPropertiesDetail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MoveResourceProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceStatus) content.GetValueForProperty("MoveStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).Error = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("Error",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).Error, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ProvisioningState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState?) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ProvisioningState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.ProvisioningState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceId = (string) content.GetValueForProperty("SourceId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).TargetId = (string) content.GetValueForProperty("TargetId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).TargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ExistingTargetId = (string) content.GetValueForProperty("ExistingTargetId",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ExistingTargetId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ResourceSetting = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) content.GetValueForProperty("ResourceSetting",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ResourceSetting, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceResourceSetting = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IResourceSettings) content.GetValueForProperty("SourceResourceSetting",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).SourceResourceSetting, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOn = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency[]) content.GetValueForProperty("DependsOn",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOn, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependency>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceDependencyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOnOverride = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride[]) content.GetValueForProperty("DependsOnOverride",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).DependsOnOverride, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceDependencyOverride>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceDependencyOverrideTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).IsResolveRequired = (bool?) content.GetValueForProperty("IsResolveRequired",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).IsResolveRequired, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusJobStatus = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IJobStatus) content.GetValueForProperty("MoveStatusJobStatus",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusJobStatus, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.JobStatusTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusMoveState = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState?) content.GetValueForProperty("MoveStatusMoveState",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusMoveState, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveState.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusError = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceError) content.GetValueForProperty("MoveStatusError",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusError, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobName = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName?) content.GetValueForProperty("JobStatusJobName",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobName, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.JobName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobProgress = (string) content.GetValueForProperty("JobStatusJobProgress",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).JobStatusJobProgress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("ErrorsProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsProperty = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody) content.GetValueForProperty("MoveStatusErrorsProperty",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsProperty, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesCode = (string) content.GetValueForProperty("ErrorsPropertiesCode",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesMessage = (string) content.GetValueForProperty("ErrorsPropertiesMessage",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesTarget = (string) content.GetValueForProperty("ErrorsPropertiesTarget",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesDetail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("ErrorsPropertiesDetail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).ErrorsPropertiesDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesCode = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesCode",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesMessage = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesMessage",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesTarget = (string) content.GetValueForProperty("MoveStatusErrorsPropertiesTarget",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesDetail = (Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody[]) content.GetValueForProperty("MoveStatusErrorsPropertiesDetail",((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourcePropertiesInternal)this).MoveStatusErrorsPropertiesDetail, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResourceErrorBody>(__y, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.MoveResourceErrorBodyTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Defines the move resource properties.
    [System.ComponentModel.TypeConverter(typeof(MoveResourcePropertiesTypeConverter))]
    public partial interface IMoveResourceProperties

    {

    }
}