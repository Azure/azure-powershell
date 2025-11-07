// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>Filters for dependency map visualization apis</summary>
    public partial class DependencyMapVisualizationFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilter,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal
    {

        /// <summary>Backing field for <see cref="DateTime" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter _dateTime;

        /// <summary>DateTime filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter DateTime { get => (this._dateTime = this._dateTime ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.DateTimeFilter()); set => this._dateTime = value; }

        /// <summary>End date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public global::System.DateTime? DateTimeEndDateTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilterInternal)DateTime).EndDateTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilterInternal)DateTime).EndDateTimeUtc = value ?? default(global::System.DateTime); }

        /// <summary>Start date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public global::System.DateTime? DateTimeStartDateTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilterInternal)DateTime).StartDateTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilterInternal)DateTime).StartDateTimeUtc = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for DateTime</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal.DateTime { get => (this._dateTime = this._dateTime ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.DateTimeFilter()); set { {_dateTime = value;} } }

        /// <summary>Internal Acessors for ProcessNameFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal.ProcessNameFilter { get => (this._processNameFilter = this._processNameFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ProcessNameFilter()); set { {_processNameFilter = value;} } }

        /// <summary>Backing field for <see cref="ProcessNameFilter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter _processNameFilter;

        /// <summary>Process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter ProcessNameFilter { get => (this._processNameFilter = this._processNameFilter ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ProcessNameFilter()); set => this._processNameFilter = value; }

        /// <summary>Operator for process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public string ProcessNameFilterOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilterInternal)ProcessNameFilter).Operator; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilterInternal)ProcessNameFilter).Operator = value ?? null; }

        /// <summary>List of process names on which the operator should be applied</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> ProcessNameFilterProcessName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilterInternal)ProcessNameFilter).ProcessName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilterInternal)ProcessNameFilter).ProcessName = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="DependencyMapVisualizationFilter" /> instance.</summary>
        public DependencyMapVisualizationFilter()
        {

        }
    }
    /// Filters for dependency map visualization apis
    public partial interface IDependencyMapVisualizationFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>End date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"End date time for dependency map visualization query",
        SerializedName = @"endDateTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DateTimeEndDateTimeUtc { get; set; }
        /// <summary>Start date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Start date time for dependency map visualization query",
        SerializedName = @"startDateTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? DateTimeStartDateTimeUtc { get; set; }
        /// <summary>Operator for process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operator for process name filter",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("contains", "notContains")]
        string ProcessNameFilterOperator { get; set; }
        /// <summary>List of process names on which the operator should be applied</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of process names on which the operator should be applied",
        SerializedName = @"processNames",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ProcessNameFilterProcessName { get; set; }

    }
    /// Filters for dependency map visualization apis
    internal partial interface IDependencyMapVisualizationFilterInternal

    {
        /// <summary>DateTime filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter DateTime { get; set; }
        /// <summary>End date time for dependency map visualization query</summary>
        global::System.DateTime? DateTimeEndDateTimeUtc { get; set; }
        /// <summary>Start date time for dependency map visualization query</summary>
        global::System.DateTime? DateTimeStartDateTimeUtc { get; set; }
        /// <summary>Process name filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter ProcessNameFilter { get; set; }
        /// <summary>Operator for process name filter</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("contains", "notContains")]
        string ProcessNameFilterOperator { get; set; }
        /// <summary>List of process names on which the operator should be applied</summary>
        System.Collections.Generic.List<string> ProcessNameFilterProcessName { get; set; }

    }
}