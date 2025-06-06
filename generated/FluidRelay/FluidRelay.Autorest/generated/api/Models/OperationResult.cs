// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Extensions;

    /// <summary>A FluidRelay REST API operation.</summary>
    public partial class OperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationResult,
        Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationResultInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplay _display;

        /// <summary>The object that represents the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.OperationDisplay()); set => this._display = value; }

        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Description = value ?? null; }

        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Operation = value ?? null; }

        /// <summary>Service provider: Microsoft.FluidRelay</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Provider = value ?? null; }

        /// <summary>Type on which the operation is performed, e.g., 'servers'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplayInternal)Display).Resource = value ?? null; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationResultInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Origin(Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="OperationResult" /> instance.</summary>
        public OperationResult()
        {

        }
    }
    /// A FluidRelay REST API operation.
    public partial interface IOperationResult :
        Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Description of the operation, e.g., 'Write confluent'.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operation type, e.g., read, write, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft.FluidRelay</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Service provider: Microsoft.FluidRelay",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'servers'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type on which the operation is performed, e.g., 'servers'.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether the operation is a data action",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Operation name: {provider}/{resource}/{operation}",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// A FluidRelay REST API operation.
    internal partial interface IOperationResultInternal

    {
        /// <summary>The object that represents the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IOperationDisplay Display { get; set; }
        /// <summary>Description of the operation, e.g., 'Write confluent'.</summary>
        string DisplayDescription { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft.FluidRelay</summary>
        string DisplayProvider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'servers'.</summary>
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation is a data action</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}</summary>
        string Name { get; set; }

    }
}