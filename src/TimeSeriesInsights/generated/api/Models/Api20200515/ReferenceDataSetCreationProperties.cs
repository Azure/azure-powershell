namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>Properties used to create a reference data set.</summary>
    public partial class ReferenceDataSetCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetCreationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetCreationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="DataStringComparisonBehavior" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.DataStringComparisonBehavior? _dataStringComparisonBehavior;

        /// <summary>
        /// The reference data set key comparison behavior can be set using this property. By default, the value is 'Ordinal' - which
        /// means case sensitive key comparison will be performed while joining reference data with events or while adding new reference
        /// data. When 'OrdinalIgnoreCase' is set, case insensitive comparison will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.DataStringComparisonBehavior? DataStringComparisonBehavior { get => this._dataStringComparisonBehavior; set => this._dataStringComparisonBehavior = value; }

        /// <summary>Backing field for <see cref="KeyProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetKeyProperty[] _keyProperty;

        /// <summary>The list of key properties for the reference data set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetKeyProperty[] KeyProperty { get => this._keyProperty; set => this._keyProperty = value; }

        /// <summary>Creates an new <see cref="ReferenceDataSetCreationProperties" /> instance.</summary>
        public ReferenceDataSetCreationProperties()
        {

        }
    }
    /// Properties used to create a reference data set.
    public partial interface IReferenceDataSetCreationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The reference data set key comparison behavior can be set using this property. By default, the value is 'Ordinal' - which
        /// means case sensitive key comparison will be performed while joining reference data with events or while adding new reference
        /// data. When 'OrdinalIgnoreCase' is set, case insensitive comparison will be used.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference data set key comparison behavior can be set using this property. By default, the value is 'Ordinal' - which means case sensitive key comparison will be performed while joining reference data with events or while adding new reference data. When 'OrdinalIgnoreCase' is set, case insensitive comparison will be used.",
        SerializedName = @"dataStringComparisonBehavior",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.DataStringComparisonBehavior) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.DataStringComparisonBehavior? DataStringComparisonBehavior { get; set; }
        /// <summary>The list of key properties for the reference data set.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The list of key properties for the reference data set.",
        SerializedName = @"keyProperties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetKeyProperty) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetKeyProperty[] KeyProperty { get; set; }

    }
    /// Properties used to create a reference data set.
    internal partial interface IReferenceDataSetCreationPropertiesInternal

    {
        /// <summary>
        /// The reference data set key comparison behavior can be set using this property. By default, the value is 'Ordinal' - which
        /// means case sensitive key comparison will be performed while joining reference data with events or while adding new reference
        /// data. When 'OrdinalIgnoreCase' is set, case insensitive comparison will be used.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.DataStringComparisonBehavior? DataStringComparisonBehavior { get; set; }
        /// <summary>The list of key properties for the reference data set.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.IReferenceDataSetKeyProperty[] KeyProperty { get; set; }

    }
}