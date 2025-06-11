// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>GetConnectionsWithConnectedMachineForFocusedMachine request model</summary>
    public partial class GetConnectionsWithConnectedMachineForFocusedMachineRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IGetConnectionsWithConnectedMachineForFocusedMachineRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IGetConnectionsWithConnectedMachineForFocusedMachineRequestInternal
    {

        /// <summary>Backing field for <see cref="ConnectedMachineId" /> property.</summary>
        private string _connectedMachineId;

        /// <summary>Destination machine arm id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string ConnectedMachineId { get => this._connectedMachineId; set => this._connectedMachineId = value; }

        /// <summary>End date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public global::System.DateTime? DateTimeEndDateTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTimeEndDateTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTimeEndDateTimeUtc = value ?? default(global::System.DateTime); }

        /// <summary>Start date time for dependency map visualization query</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public global::System.DateTime? DateTimeStartDateTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTimeStartDateTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTimeStartDateTimeUtc = value ?? default(global::System.DateTime); }

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilter _filter;

        /// <summary>Filters for GetNetworkConnectionsBetweenMachines</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilter Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.DependencyMapVisualizationFilter()); set => this._filter = value; }

        /// <summary>Backing field for <see cref="FocusedMachineId" /> property.</summary>
        private string _focusedMachineId;

        /// <summary>Source machine arm id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string FocusedMachineId { get => this._focusedMachineId; set => this._focusedMachineId = value; }

        /// <summary>Internal Acessors for Filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilter Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IGetConnectionsWithConnectedMachineForFocusedMachineRequestInternal.Filter { get => (this._filter = this._filter ?? new Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.DependencyMapVisualizationFilter()); set { {_filter = value;} } }

        /// <summary>Internal Acessors for FilterDateTime</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IGetConnectionsWithConnectedMachineForFocusedMachineRequestInternal.FilterDateTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).DateTime = value ?? null /* model class */; }

        /// <summary>Internal Acessors for FilterProcessNameFilter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IGetConnectionsWithConnectedMachineForFocusedMachineRequestInternal.FilterProcessNameFilter { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilter; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilter = value ?? null /* model class */; }

        /// <summary>Operator for process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public string ProcessNameFilterOperator { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilterOperator; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilterOperator = value ?? null; }

        /// <summary>List of process names on which the operator should be applied</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> ProcessNameFilterProcessName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilterProcessName; set => ((Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilterInternal)Filter).ProcessNameFilterProcessName = value ?? null /* arrayOf */; }

        /// <summary>
        /// Creates an new <see cref="GetConnectionsWithConnectedMachineForFocusedMachineRequest" /> instance.
        /// </summary>
        public GetConnectionsWithConnectedMachineForFocusedMachineRequest()
        {

        }
    }
    /// GetConnectionsWithConnectedMachineForFocusedMachine request model
    public partial interface IGetConnectionsWithConnectedMachineForFocusedMachineRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>Destination machine arm id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Destination machine arm id",
        SerializedName = @"connectedMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string ConnectedMachineId { get; set; }
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
        /// <summary>Source machine arm id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Source machine arm id",
        SerializedName = @"focusedMachineId",
        PossibleTypes = new [] { typeof(string) })]
        string FocusedMachineId { get; set; }
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
    /// GetConnectionsWithConnectedMachineForFocusedMachine request model
    internal partial interface IGetConnectionsWithConnectedMachineForFocusedMachineRequestInternal

    {
        /// <summary>Destination machine arm id</summary>
        string ConnectedMachineId { get; set; }
        /// <summary>End date time for dependency map visualization query</summary>
        global::System.DateTime? DateTimeEndDateTimeUtc { get; set; }
        /// <summary>Start date time for dependency map visualization query</summary>
        global::System.DateTime? DateTimeStartDateTimeUtc { get; set; }
        /// <summary>Filters for GetNetworkConnectionsBetweenMachines</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDependencyMapVisualizationFilter Filter { get; set; }
        /// <summary>DateTime filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IDateTimeFilter FilterDateTime { get; set; }
        /// <summary>Process name filter</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter FilterProcessNameFilter { get; set; }
        /// <summary>Source machine arm id</summary>
        string FocusedMachineId { get; set; }
        /// <summary>Operator for process name filter</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("contains", "notContains")]
        string ProcessNameFilterOperator { get; set; }
        /// <summary>List of process names on which the operator should be applied</summary>
        System.Collections.Generic.List<string> ProcessNameFilterProcessName { get; set; }

    }
}