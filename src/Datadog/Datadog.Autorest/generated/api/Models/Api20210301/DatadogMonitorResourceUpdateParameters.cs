namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>The parameters for a PATCH request to a monitor resource.</summary>
    public partial class DatadogMonitorResourceUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdateProperties Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorUpdateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSku()); set { {_sku = value;} } }

        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdatePropertiesInternal)Property).MonitoringStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdatePropertiesInternal)Property).MonitoringStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus)""); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdateProperties _property;

        /// <summary>
        /// The set of properties that can be update in a PATCH request to a monitor resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.MonitorUpdateProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku _sku;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.ResourceSku()); set => this._sku = value; }

        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSkuInternal)Sku).Name = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags _tag;

        /// <summary>The new tags of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.DatadogMonitorResourceUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="DatadogMonitorResourceUpdateParameters" /> instance.</summary>
        public DatadogMonitorResourceUpdateParameters()
        {

        }
    }
    /// The parameters for a PATCH request to a monitor resource.
    public partial interface IDatadogMonitorResourceUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag specifying if the resource monitoring is enabled or disabled.",
        SerializedName = @"monitoringStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }
        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The new tags of the monitor resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The new tags of the monitor resource.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags Tag { get; set; }

    }
    /// The parameters for a PATCH request to a monitor resource.
    internal partial interface IDatadogMonitorResourceUpdateParametersInternal

    {
        /// <summary>Flag specifying if the resource monitoring is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.MonitoringStatus? MonitoringStatus { get; set; }
        /// <summary>
        /// The set of properties that can be update in a PATCH request to a monitor resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IMonitorUpdateProperties Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku Sku { get; set; }
        /// <summary>Name of the SKU.</summary>
        string SkuName { get; set; }
        /// <summary>The new tags of the monitor resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogMonitorResourceUpdateParametersTags Tag { get; set; }

    }
}