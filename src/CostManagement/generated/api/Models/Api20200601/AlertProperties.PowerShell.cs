namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesTypeConverter))]
    public partial class AlertProperties
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AlertProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource?) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CostEntityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CreationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CloseTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).ModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType?) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCriterion = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria?) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCriterion, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceGroupFilter = (string[]) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceFilter = (string[]) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailMeterFilter = (string[]) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCategory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory?) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCategory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOperator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOperator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactEmail = (string[]) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactGroup = (string[]) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactRole = (string[]) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AlertProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Definition = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDefinition) content.GetValueForProperty("Definition",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Definition, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDefinitionTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Detail = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails) content.GetValueForProperty("Detail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Detail, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetailsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Description = (string) content.GetValueForProperty("Description",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Description, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Source = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource?) content.GetValueForProperty("Source",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Source, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertSource.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CostEntityId = (string) content.GetValueForProperty("CostEntityId",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CostEntityId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Status = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus?) content.GetValueForProperty("Status",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).Status, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertStatus.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CreationTime = (string) content.GetValueForProperty("CreationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CreationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CloseTime = (string) content.GetValueForProperty("CloseTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).CloseTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).ModificationTime = (string) content.GetValueForProperty("ModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).ModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationUserName = (string) content.GetValueForProperty("StatusModificationUserName",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationUserName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationTime = (string) content.GetValueForProperty("StatusModificationTime",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).StatusModificationTime, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("DetailTagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType?) content.GetValueForProperty("DefinitionType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCriterion = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria?) content.GetValueForProperty("DefinitionCriterion",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCriterion, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCriteria.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("DetailTimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailPeriodStartDate = (string) content.GetValueForProperty("DetailPeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailPeriodStartDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTriggeredBy = (string) content.GetValueForProperty("DetailTriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailTriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceGroupFilter = (string[]) content.GetValueForProperty("DetailResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceFilter = (string[]) content.GetValueForProperty("DetailResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailMeterFilter = (string[]) content.GetValueForProperty("DetailMeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailMeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCategory = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory?) content.GetValueForProperty("DefinitionCategory",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DefinitionCategory, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertCategory.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailThreshold = (decimal?) content.GetValueForProperty("DetailThreshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailThreshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOperator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("DetailOperator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOperator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailAmount = (decimal?) content.GetValueForProperty("DetailAmount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailAmount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailUnit = (string) content.GetValueForProperty("DetailUnit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailUnit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailCurrentSpend = (decimal?) content.GetValueForProperty("DetailCurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailCurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactEmail = (string[]) content.GetValueForProperty("DetailContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactGroup = (string[]) content.GetValueForProperty("DetailContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactRole = (string[]) content.GetValueForProperty("DetailContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOverridingAlert = (string) content.GetValueForProperty("DetailOverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesInternal)this).DetailOverridingAlert, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AlertProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties" />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AlertProperties(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AlertProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesTypeConverter))]
    public partial interface IAlertProperties

    {

    }
}