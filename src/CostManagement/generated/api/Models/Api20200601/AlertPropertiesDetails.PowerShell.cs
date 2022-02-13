namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.PowerShell;

    /// <summary>Alert details</summary>
    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesDetailsTypeConverter))]
    public partial class AlertPropertiesDetails
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal AlertPropertiesDetails(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("TimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).PeriodStartDate = (string) content.GetValueForProperty("PeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).PeriodStartDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TriggeredBy = (string) content.GetValueForProperty("TriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceGroupFilter = (string[]) content.GetValueForProperty("ResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceFilter = (string[]) content.GetValueForProperty("ResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).MeterFilter = (string[]) content.GetValueForProperty("MeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).MeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("TagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Threshold = (decimal?) content.GetValueForProperty("Threshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Threshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Operator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Operator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Amount = (decimal?) content.GetValueForProperty("Amount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Amount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Unit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).CurrentSpend = (decimal?) content.GetValueForProperty("CurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).CurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactEmail = (string[]) content.GetValueForProperty("ContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactGroup = (string[]) content.GetValueForProperty("ContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactRole = (string[]) content.GetValueForProperty("ContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).OverridingAlert = (string) content.GetValueForProperty("OverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).OverridingAlert, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal AlertPropertiesDetails(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TimeGrainType = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType?) content.GetValueForProperty("TimeGrainType",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TimeGrainType, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertTimeGrainType.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).PeriodStartDate = (string) content.GetValueForProperty("PeriodStartDate",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).PeriodStartDate, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TriggeredBy = (string) content.GetValueForProperty("TriggeredBy",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TriggeredBy, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceGroupFilter = (string[]) content.GetValueForProperty("ResourceGroupFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceGroupFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceFilter = (string[]) content.GetValueForProperty("ResourceFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ResourceFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).MeterFilter = (string[]) content.GetValueForProperty("MeterFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).MeterFilter, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TagFilter = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.IAny) content.GetValueForProperty("TagFilter",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).TagFilter, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.AnyTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Threshold = (decimal?) content.GetValueForProperty("Threshold",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Threshold, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Operator = (Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator?) content.GetValueForProperty("Operator",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Operator, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.AlertOperator.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Amount = (decimal?) content.GetValueForProperty("Amount",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Amount, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Unit = (string) content.GetValueForProperty("Unit",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).Unit, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).CurrentSpend = (decimal?) content.GetValueForProperty("CurrentSpend",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).CurrentSpend, (__y)=> (decimal) global::System.Convert.ChangeType(__y, typeof(decimal)));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactEmail = (string[]) content.GetValueForProperty("ContactEmail",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactEmail, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactGroup = (string[]) content.GetValueForProperty("ContactGroup",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactGroup, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactRole = (string[]) content.GetValueForProperty("ContactRole",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).ContactRole, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).OverridingAlert = (string) content.GetValueForProperty("OverridingAlert",((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetailsInternal)this).OverridingAlert, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new AlertPropertiesDetails(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.AlertPropertiesDetails"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new AlertPropertiesDetails(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="AlertPropertiesDetails" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IAlertPropertiesDetails FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// Alert details
    [System.ComponentModel.TypeConverter(typeof(AlertPropertiesDetailsTypeConverter))]
    public partial interface IAlertPropertiesDetails

    {

    }
}