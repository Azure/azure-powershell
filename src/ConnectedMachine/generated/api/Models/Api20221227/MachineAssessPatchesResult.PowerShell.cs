namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227
{
    using Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.PowerShell;

    /// <summary>Describes the properties of an AssessPatches result.</summary>
    [System.ComponentModel.TypeConverter(typeof(MachineAssessPatchesResultTypeConverter))]
    public partial class MachineAssessPatchesResult
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.MachineAssessPatchesResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResult DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new MachineAssessPatchesResult(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.MachineAssessPatchesResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResult"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResult DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new MachineAssessPatchesResult(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="MachineAssessPatchesResult" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResult FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.MachineAssessPatchesResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal MachineAssessPatchesResult(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassification = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAvailablePatchCountByClassification) content.GetValueForProperty("AvailablePatchCountByClassification",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassification, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AvailablePatchCountByClassificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail) content.GetValueForProperty("ErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.ErrorDetailTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AssessmentActivityId = (string) content.GetValueForProperty("AssessmentActivityId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AssessmentActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).RebootPending = (bool?) content.GetValueForProperty("RebootPending",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).RebootPending, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartDateTime = (global::System.DateTime?) content.GetValueForProperty("StartDateTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).LastModifiedDateTime = (global::System.DateTime?) content.GetValueForProperty("LastModifiedDateTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).LastModifiedDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartedBy = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStartedBy?) content.GetValueForProperty("StartedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartedBy, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStartedBy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).PatchServiceUsed = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchServiceUsed?) content.GetValueForProperty("PatchServiceUsed",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).PatchServiceUsed, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchServiceUsed.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.OSType?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationSecurity = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationSecurity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationSecurity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationCritical = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationCritical",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationCritical, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationDefinition = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationDefinition",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationDefinition, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdateRollup = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationUpdateRollup",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdateRollup, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationFeaturePack = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationFeaturePack",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationFeaturePack, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationServicePack = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationServicePack",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationServicePack, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationTool = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationTool",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationTool, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdate = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationUpdate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdate, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationOther = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationOther",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationOther, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailCode = (string) content.GetValueForProperty("ErrorDetailCode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailMessage = (string) content.GetValueForProperty("ErrorDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailTarget = (string) content.GetValueForProperty("ErrorDetailTarget",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailsDetails = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail[]) content.GetValueForProperty("ErrorDetailsDetails",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailsDetails, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.ErrorDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailAdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.IErrorAdditionalInfo[]) content.GetValueForProperty("ErrorDetailAdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailAdditionalInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.MachineAssessPatchesResult"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal MachineAssessPatchesResult(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassification = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IAvailablePatchCountByClassification) content.GetValueForProperty("AvailablePatchCountByClassification",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassification, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.AvailablePatchCountByClassificationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetail = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail) content.GetValueForProperty("ErrorDetail",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetail, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.ErrorDetailTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AssessmentActivityId = (string) content.GetValueForProperty("AssessmentActivityId",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AssessmentActivityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).RebootPending = (bool?) content.GetValueForProperty("RebootPending",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).RebootPending, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartDateTime = (global::System.DateTime?) content.GetValueForProperty("StartDateTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).LastModifiedDateTime = (global::System.DateTime?) content.GetValueForProperty("LastModifiedDateTime",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).LastModifiedDateTime, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartedBy = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStartedBy?) content.GetValueForProperty("StartedBy",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).StartedBy, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchOperationStartedBy.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).PatchServiceUsed = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchServiceUsed?) content.GetValueForProperty("PatchServiceUsed",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).PatchServiceUsed, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchServiceUsed.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).OSType = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.OSType?) content.GetValueForProperty("OSType",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).OSType, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.OSType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationSecurity = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationSecurity",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationSecurity, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationCritical = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationCritical",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationCritical, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationDefinition = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationDefinition",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationDefinition, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdateRollup = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationUpdateRollup",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdateRollup, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationFeaturePack = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationFeaturePack",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationFeaturePack, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationServicePack = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationServicePack",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationServicePack, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationTool = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationTool",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationTool, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdate = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationUpdate",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationUpdate, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationOther = (int?) content.GetValueForProperty("AvailablePatchCountByClassificationOther",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).AvailablePatchCountByClassificationOther, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailCode = (string) content.GetValueForProperty("ErrorDetailCode",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailCode, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailMessage = (string) content.GetValueForProperty("ErrorDetailMessage",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailMessage, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailTarget = (string) content.GetValueForProperty("ErrorDetailTarget",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailTarget, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailsDetails = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail[]) content.GetValueForProperty("ErrorDetailsDetails",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailsDetails, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.IErrorDetail>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api30.ErrorDetailTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailAdditionalInfo = (Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.IErrorAdditionalInfo[]) content.GetValueForProperty("ErrorDetailAdditionalInfo",((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20221227.IMachineAssessPatchesResultInternal)this).ErrorDetailAdditionalInfo, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.IErrorAdditionalInfo>(__y, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20.ErrorAdditionalInfoTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Describes the properties of an AssessPatches result.
    [System.ComponentModel.TypeConverter(typeof(MachineAssessPatchesResultTypeConverter))]
    public partial interface IMachineAssessPatchesResult

    {

    }
}