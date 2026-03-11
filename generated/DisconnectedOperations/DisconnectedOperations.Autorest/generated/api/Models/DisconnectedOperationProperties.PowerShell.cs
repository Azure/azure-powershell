// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.PowerShell;

    /// <summary>The disconnected operation properties</summary>
    [System.ComponentModel.TypeConverter(typeof(DisconnectedOperationPropertiesTypeConverter))]
    public partial class DisconnectedOperationProperties
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
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <paramref name="returnNow" /> output
        /// parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// <c>OverrideToString</c> will be called if it is implemented. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="stringResult">/// instance serialized to a string, normally it is a Json</param>
        /// <param name="returnNow">/// set returnNow to true if you provide a customized OverrideToString function</param>

        partial void OverrideToString(ref string stringResult, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new DisconnectedOperationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new DisconnectedOperationProperties(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal DisconnectedOperationProperties(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("BillingConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration) content.GetValueForProperty("BillingConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfiguration, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("BenefitPlan"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlan = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans) content.GetValueForProperty("BenefitPlan",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlan, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlansTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("StampId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).StampId = (string) content.GetValueForProperty("StampId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).StampId, global::System.Convert.ToString);
            }
            if (content.Contains("BillingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingModel = (string) content.GetValueForProperty("BillingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingModel, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionIntent"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionIntent = (string) content.GetValueForProperty("ConnectionIntent",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionIntent, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionStatus = (string) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionStatus, global::System.Convert.ToString);
            }
            if (content.Contains("RegistrationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).RegistrationStatus = (string) content.GetValueForProperty("RegistrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).RegistrationStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DeviceVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).DeviceVersion = (string) content.GetValueForProperty("DeviceVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).DeviceVersion, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationAutoRenew"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationAutoRenew = (string) content.GetValueForProperty("BillingConfigurationAutoRenew",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationAutoRenew, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationBillingStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationBillingStatus = (string) content.GetValueForProperty("BillingConfigurationBillingStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationBillingStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationCurrent"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationCurrent = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod) content.GetValueForProperty("BillingConfigurationCurrent",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationCurrent, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingPeriodTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingConfigurationUpcoming"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationUpcoming = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod) content.GetValueForProperty("BillingConfigurationUpcoming",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationUpcoming, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingPeriodTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentPricingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentPricingModel = (string) content.GetValueForProperty("CurrentPricingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentPricingModel, global::System.Convert.ToString);
            }
            if (content.Contains("UpcomingPricingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingPricingModel = (string) content.GetValueForProperty("UpcomingPricingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingPricingModel, global::System.Convert.ToString);
            }
            if (content.Contains("BenefitPlanAzureHybridWindowsServerBenefit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanAzureHybridWindowsServerBenefit = (string) content.GetValueForProperty("BenefitPlanAzureHybridWindowsServerBenefit",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanAzureHybridWindowsServerBenefit, global::System.Convert.ToString);
            }
            if (content.Contains("BenefitPlanWindowsServerVMCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanWindowsServerVMCount = (int?) content.GetValueForProperty("BenefitPlanWindowsServerVMCount",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanWindowsServerVMCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CurrentCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentCore = (int?) content.GetValueForProperty("CurrentCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CurrentStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentStartDate = (global::System.DateTime?) content.GetValueForProperty("CurrentStartDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentStartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CurrentEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentEndDate = (global::System.DateTime?) content.GetValueForProperty("CurrentEndDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentEndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UpcomingCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingCore = (int?) content.GetValueForProperty("UpcomingCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("UpcomingStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingStartDate = (global::System.DateTime?) content.GetValueForProperty("UpcomingStartDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingStartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UpcomingEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingEndDate = (global::System.DateTime?) content.GetValueForProperty("UpcomingEndDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingEndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.DisconnectedOperationProperties"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal DisconnectedOperationProperties(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            if (content.Contains("BillingConfiguration"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingConfiguration) content.GetValueForProperty("BillingConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfiguration, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingConfigurationTypeConverter.ConvertFrom);
            }
            if (content.Contains("BenefitPlan"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlan = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBenefitPlans) content.GetValueForProperty("BenefitPlan",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlan, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BenefitPlansTypeConverter.ConvertFrom);
            }
            if (content.Contains("ProvisioningState"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ProvisioningState, global::System.Convert.ToString);
            }
            if (content.Contains("StampId"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).StampId = (string) content.GetValueForProperty("StampId",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).StampId, global::System.Convert.ToString);
            }
            if (content.Contains("BillingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingModel = (string) content.GetValueForProperty("BillingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingModel, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionIntent"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionIntent = (string) content.GetValueForProperty("ConnectionIntent",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionIntent, global::System.Convert.ToString);
            }
            if (content.Contains("ConnectionStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionStatus = (string) content.GetValueForProperty("ConnectionStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).ConnectionStatus, global::System.Convert.ToString);
            }
            if (content.Contains("RegistrationStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).RegistrationStatus = (string) content.GetValueForProperty("RegistrationStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).RegistrationStatus, global::System.Convert.ToString);
            }
            if (content.Contains("DeviceVersion"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).DeviceVersion = (string) content.GetValueForProperty("DeviceVersion",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).DeviceVersion, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationAutoRenew"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationAutoRenew = (string) content.GetValueForProperty("BillingConfigurationAutoRenew",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationAutoRenew, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationBillingStatus"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationBillingStatus = (string) content.GetValueForProperty("BillingConfigurationBillingStatus",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationBillingStatus, global::System.Convert.ToString);
            }
            if (content.Contains("BillingConfigurationCurrent"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationCurrent = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod) content.GetValueForProperty("BillingConfigurationCurrent",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationCurrent, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingPeriodTypeConverter.ConvertFrom);
            }
            if (content.Contains("BillingConfigurationUpcoming"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationUpcoming = (Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IBillingPeriod) content.GetValueForProperty("BillingConfigurationUpcoming",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BillingConfigurationUpcoming, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.BillingPeriodTypeConverter.ConvertFrom);
            }
            if (content.Contains("CurrentPricingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentPricingModel = (string) content.GetValueForProperty("CurrentPricingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentPricingModel, global::System.Convert.ToString);
            }
            if (content.Contains("UpcomingPricingModel"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingPricingModel = (string) content.GetValueForProperty("UpcomingPricingModel",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingPricingModel, global::System.Convert.ToString);
            }
            if (content.Contains("BenefitPlanAzureHybridWindowsServerBenefit"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanAzureHybridWindowsServerBenefit = (string) content.GetValueForProperty("BenefitPlanAzureHybridWindowsServerBenefit",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanAzureHybridWindowsServerBenefit, global::System.Convert.ToString);
            }
            if (content.Contains("BenefitPlanWindowsServerVMCount"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanWindowsServerVMCount = (int?) content.GetValueForProperty("BenefitPlanWindowsServerVMCount",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).BenefitPlanWindowsServerVMCount, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CurrentCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentCore = (int?) content.GetValueForProperty("CurrentCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("CurrentStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentStartDate = (global::System.DateTime?) content.GetValueForProperty("CurrentStartDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentStartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("CurrentEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentEndDate = (global::System.DateTime?) content.GetValueForProperty("CurrentEndDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).CurrentEndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UpcomingCore"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingCore = (int?) content.GetValueForProperty("UpcomingCore",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingCore, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            }
            if (content.Contains("UpcomingStartDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingStartDate = (global::System.DateTime?) content.GetValueForProperty("UpcomingStartDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingStartDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            if (content.Contains("UpcomingEndDate"))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingEndDate = (global::System.DateTime?) content.GetValueForProperty("UpcomingEndDate",((Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationPropertiesInternal)this).UpcomingEndDate, (v) => v is global::System.DateTime _v ? _v : global::System.Xml.XmlConvert.ToDateTime( v.ToString() , global::System.Xml.XmlDateTimeSerializationMode.Unspecified));
            }
            AfterDeserializePSObject(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="DisconnectedOperationProperties" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="DisconnectedOperationProperties" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationProperties FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.SerializationMode.IncludeAll)?.ToString();

        public override string ToString()
        {
            var returnNow = false;
            var result = global::System.String.Empty;
            OverrideToString(ref result, ref returnNow);
            if (returnNow)
            {
                return result;
            }
            return ToJsonString();
        }
    }
    /// The disconnected operation properties
    [System.ComponentModel.TypeConverter(typeof(DisconnectedOperationPropertiesTypeConverter))]
    public partial interface IDisconnectedOperationProperties

    {

    }
}