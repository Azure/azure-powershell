namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Monitoring Setting resource</summary>
    public partial class MonitoringSettingResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingResource,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.Resource();

        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string AppInsightsInstrumentationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).AppInsightsInstrumentationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).AppInsightsInstrumentationKey = value; }

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Code { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Code = value; }

        /// <summary>Fully qualified resource Id for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Message { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Message = value; }

        /// <summary>Internal Acessors for Error</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingResourceInternal.Error { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).Error = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.MonitoringSettingProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingProperties _property;

        /// <summary>Properties of the Monitoring Setting resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.MonitoringSettingProperties()); set => this._property = value; }

        /// <summary>State of the Monitoring Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Indicates whether enable the trace functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? TraceEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).TraceEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingPropertiesInternal)Property).TraceEnabled = value; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="MonitoringSettingResource" /> instance.</summary>
        public MonitoringSettingResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Monitoring Setting resource
    public partial interface IMonitoringSettingResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource
    {
        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target application insight instrumentation key",
        SerializedName = @"appInsightsInstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string AppInsightsInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string Code { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>State of the Monitoring Setting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the Monitoring Setting.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get;  }
        /// <summary>Indicates whether enable the trace functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether enable the trace functionality",
        SerializedName = @"traceEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TraceEnabled { get; set; }

    }
    /// Monitoring Setting resource
    public partial interface IMonitoringSettingResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal
    {
        /// <summary>Target application insight instrumentation key</summary>
        string AppInsightsInstrumentationKey { get; set; }
        /// <summary>The code of error.</summary>
        string Code { get; set; }
        /// <summary>Error when apply Monitoring Setting changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IError Error { get; set; }
        /// <summary>The message of error.</summary>
        string Message { get; set; }
        /// <summary>Properties of the Monitoring Setting resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IMonitoringSettingProperties Property { get; set; }
        /// <summary>State of the Monitoring Setting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.MonitoringSettingState? ProvisioningState { get; set; }
        /// <summary>Indicates whether enable the trace functionality</summary>
        bool? TraceEnabled { get; set; }

    }
}