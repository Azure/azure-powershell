namespace Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515
{
    using static Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Extensions;

    /// <summary>
    /// The structure of the property that a time series id can have. An environment can have multiple such properties.
    /// </summary>
    public partial class TimeSeriesIdProperty :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdProperty,
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Models.Api20200515.ITimeSeriesIdPropertyInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.PropertyType? _type;

        /// <summary>The type of the property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Origin(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.PropertyType? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="TimeSeriesIdProperty" /> instance.</summary>
        public TimeSeriesIdProperty()
        {

        }
    }
    /// The structure of the property that a time series id can have. An environment can have multiple such properties.
    public partial interface ITimeSeriesIdProperty :
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.IJsonSerializable
    {
        /// <summary>The name of the property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the property.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The type of the property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the property.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.PropertyType) })]
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.PropertyType? Type { get; set; }

    }
    /// The structure of the property that a time series id can have. An environment can have multiple such properties.
    internal partial interface ITimeSeriesIdPropertyInternal

    {
        /// <summary>The name of the property.</summary>
        string Name { get; set; }
        /// <summary>The type of the property.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.TimeSeriesInsights.Support.PropertyType? Type { get; set; }

    }
}