namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Parameters supplied to the CreateOrUpdate Environment operation.</summary>
    public partial class EnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourceProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourceProperties __createOrUpdateTrackedResourceProperties = new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.CreateOrUpdateTrackedResourceProperties();

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind _kind;

        /// <summary>The kind of the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get => this._kind; set => this._kind = value; }

        /// <summary>The location of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Location = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IEnvironmentCreateOrUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.Sku()); set { {_sku = value;} } }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku _sku;

        /// <summary>
        /// The sku determines the type of environment, either standard (S1 or S2) or long-term (L1). For standard environments the
        /// sku determines the capacity of the environment, the ingress rate, and the billing rate.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.Sku()); set => this._sku = value; }

        /// <summary>
        /// The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after
        /// they have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public int SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISkuInternal)Sku).Capacity = value; }

        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISkuInternal)Sku).Name = value; }

        /// <summary>Key-value pairs of additional properties for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal)__createOrUpdateTrackedResourceProperties).Tag = value; }

        /// <summary>Creates an new <see cref="EnvironmentCreateOrUpdateParameters" /> instance.</summary>
        public EnvironmentCreateOrUpdateParameters()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__createOrUpdateTrackedResourceProperties), __createOrUpdateTrackedResourceProperties);
            await eventListener.AssertObjectIsValid(nameof(__createOrUpdateTrackedResourceProperties), __createOrUpdateTrackedResourceProperties);
        }
    }
    /// Parameters supplied to the CreateOrUpdate Environment operation.
    public partial interface IEnvironmentCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourceProperties
    {
        /// <summary>The kind of the environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The kind of the environment.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get; set; }
        /// <summary>
        /// The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after
        /// they have been created.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after they have been created.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        int SkuCapacity { get; set; }
        /// <summary>The name of this SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of this SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get; set; }

    }
    /// Parameters supplied to the CreateOrUpdate Environment operation.
    internal partial interface IEnvironmentCreateOrUpdateParametersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ICreateOrUpdateTrackedResourcePropertiesInternal
    {
        /// <summary>The kind of the environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.Kind Kind { get; set; }
        /// <summary>
        /// The sku determines the type of environment, either standard (S1 or S2) or long-term (L1). For standard environments the
        /// sku determines the capacity of the environment, the ingress rate, and the billing rate.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.ISku Sku { get; set; }
        /// <summary>
        /// The capacity of the sku. For standard environments, this value can be changed to support scale out of environments after
        /// they have been created.
        /// </summary>
        int SkuCapacity { get; set; }
        /// <summary>The name of this SKU.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.SkuName SkuName { get; set; }

    }
}