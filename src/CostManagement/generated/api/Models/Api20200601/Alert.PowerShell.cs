namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>An individual alert.</summary>
    [System.ComponentModel.TypeConverter(typeof(AlertTypeConverter))]
    public partial class Alert
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Alert"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal Alert(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CreationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource?) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CostEntityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CloseTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).ModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType?) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCriterion = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria?) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCriterion, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceGroupFilter = (string[]) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceFilter = (string[]) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailMeterFilter = (string[]) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCategory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory?) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCategory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOperator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOperator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactEmail = (string[]) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactGroup = (string[]) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactRole = (string[]) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Alert"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal Alert(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type = (string) content.GetValueForProperty("Type",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Type, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceTags) content.GetValueForProperty("Tag",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IResourceInternal)this).Tag, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CreationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource?) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CostEntityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).CloseTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).ModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).StatusModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType?) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCriterion = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria?) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCriterion, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceGroupFilter = (string[]) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceFilter = (string[]) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailMeterFilter = (string[]) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCategory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory?) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DefinitionCategory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOperator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailOperator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactEmail = (string[]) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactGroup = (string[]) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactRole = (string[]) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Alert"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new Alert(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.Alert"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new Alert(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Alert" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlert FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// An individual alert.
    [System.ComponentModel.TypeConverter(typeof(AlertTypeConverter))]
    public partial interface IAlert

    {

    }
}