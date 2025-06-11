// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>Process name filter for dependency map visualization apis</summary>
    public partial class ProcessNameFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilter,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.IProcessNameFilterInternal
    {

        /// <summary>Backing field for <see cref="Operator" /> property.</summary>
        private string _operator;

        /// <summary>Operator for process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public string Operator { get => this._operator; set => this._operator = value; }

        /// <summary>Backing field for <see cref="ProcessName" /> property.</summary>
        private System.Collections.Generic.List<string> _processName;

        /// <summary>List of process names on which the operator should be applied</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Origin(Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> ProcessName { get => this._processName; set => this._processName = value; }

        /// <summary>Creates an new <see cref="ProcessNameFilter" /> instance.</summary>
        public ProcessNameFilter()
        {

        }
    }
    /// Process name filter for dependency map visualization apis
    public partial interface IProcessNameFilter :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable
    {
        /// <summary>Operator for process name filter</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operator for process name filter",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("contains", "notContains")]
        string Operator { get; set; }
        /// <summary>List of process names on which the operator should be applied</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of process names on which the operator should be applied",
        SerializedName = @"processNames",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> ProcessName { get; set; }

    }
    /// Process name filter for dependency map visualization apis
    internal partial interface IProcessNameFilterInternal

    {
        /// <summary>Operator for process name filter</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.PSArgumentCompleterAttribute("contains", "notContains")]
        string Operator { get; set; }
        /// <summary>List of process names on which the operator should be applied</summary>
        System.Collections.Generic.List<string> ProcessName { get; set; }

    }
}