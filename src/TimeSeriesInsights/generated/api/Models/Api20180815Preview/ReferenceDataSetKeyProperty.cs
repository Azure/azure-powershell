namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// A key property for the reference data set. A reference data set can have multiple key properties.
    /// </summary>
    public partial class ReferenceDataSetKeyProperty :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IReferenceDataSetKeyProperty,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20180815Preview.IReferenceDataSetKeyPropertyInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the key property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.ReferenceDataKeyPropertyType? _type;

        /// <summary>The type of the key property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.ReferenceDataKeyPropertyType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="ReferenceDataSetKeyProperty" /> instance.</summary>
        public ReferenceDataSetKeyProperty()
        {

        }
    }
    /// A key property for the reference data set. A reference data set can have multiple key properties.
    public partial interface IReferenceDataSetKeyProperty :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>The name of the key property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the key property.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of the key property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the key property.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.ReferenceDataKeyPropertyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.ReferenceDataKeyPropertyType? Type { get; set; }

    }
    /// A key property for the reference data set. A reference data set can have multiple key properties.
    internal partial interface IReferenceDataSetKeyPropertyInternal

    {
        /// <summary>The name of the key property.</summary>
        string Name { get; set; }
        /// <summary>The type of the key property.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.ReferenceDataKeyPropertyType? Type { get; set; }

    }
}