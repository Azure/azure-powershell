// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    /// <summary>Properties of an Operation.</summary>
    public partial class OperationsDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionInternal
    {

        /// <summary>Backing field for <see cref="ActionType" /> property.</summary>
        private string _actionType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ActionType { get => this._actionType; set => this._actionType = value; }

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionDisplay _display;

        /// <summary>Display information of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.OperationsDefinitionDisplay()); set => this._display = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Description = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Operation = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Provider = value ; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDisplayDefinitionInternal)Display).Resource = value ; }

        /// <summary>Backing field for <see cref="IsDataAction" /> property.</summary>
        private bool? _isDataAction;

        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? IsDataAction { get => this._isDataAction; set => this._isDataAction = value; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionDisplay Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.OperationsDefinitionDisplay()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny _property;

        /// <summary>Anything</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Any()); set => this._property = value; }

        /// <summary>Creates an new <see cref="OperationsDefinition" /> instance.</summary>
        public OperationsDefinition()
        {

        }
    }
    /// Properties of an Operation.
    public partial interface IOperationsDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Internal")]
        string ActionType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Indicates whether the operation applies to data-plane.",
        SerializedName = @"isDataAction",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDataAction { get; set; }
        /// <summary>Name of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the operation.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "User", "System")]
        string Origin { get; set; }
        /// <summary>Anything</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Anything",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Property { get; set; }

    }
    /// Properties of an Operation.
    internal partial interface IOperationsDefinitionInternal

    {
        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "Internal")]
        string ActionType { get; set; }
        /// <summary>Display information of the operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IOperationsDefinitionDisplay Display { get; set; }

        string DisplayDescription { get; set; }

        string DisplayOperation { get; set; }

        string DisplayProvider { get; set; }

        string DisplayResource { get; set; }
        /// <summary>Indicates whether the operation applies to data-plane.</summary>
        bool? IsDataAction { get; set; }
        /// <summary>Name of the operation.</summary>
        string Name { get; set; }

        [global::Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PSArgumentCompleterAttribute("NotSpecified", "User", "System")]
        string Origin { get; set; }
        /// <summary>Anything</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IAny Property { get; set; }

    }
}