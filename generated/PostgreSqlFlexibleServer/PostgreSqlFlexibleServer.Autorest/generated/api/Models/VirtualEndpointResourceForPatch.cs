// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Pair of virtual endpoints for a server.</summary>
    public partial class VirtualEndpointResourceForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceForPatch,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceForPatchInternal
    {

        /// <summary>Type of endpoint for the virtual endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string EndpointType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).EndpointType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).EndpointType = value ?? null; }

        /// <summary>List of servers that one of the virtual endpoints can refer to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> Member { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).Member; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).Member = value ?? null /* arrayOf */; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceProperties Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceForPatchInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.VirtualEndpointResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for VirtualEndpoint</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceForPatchInternal.VirtualEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).VirtualEndpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).VirtualEndpoint = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceProperties _property;

        /// <summary>Properties of the pair of virtual endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.VirtualEndpointResourceProperties()); set => this._property = value; }

        /// <summary>List of virtual endpoints for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> VirtualEndpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal)Property).VirtualEndpoint; }

        /// <summary>Creates an new <see cref="VirtualEndpointResourceForPatch" /> instance.</summary>
        public VirtualEndpointResourceForPatch()
        {

        }
    }
    /// Pair of virtual endpoints for a server.
    public partial interface IVirtualEndpointResourceForPatch :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Type of endpoint for the virtual endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of endpoint for the virtual endpoints.",
        SerializedName = @"endpointType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("ReadWrite")]
        string EndpointType { get; set; }
        /// <summary>List of servers that one of the virtual endpoints can refer to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"List of servers that one of the virtual endpoints can refer to.",
        SerializedName = @"members",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> Member { get; set; }
        /// <summary>List of virtual endpoints for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of virtual endpoints for a server.",
        SerializedName = @"virtualEndpoints",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> VirtualEndpoint { get;  }

    }
    /// Pair of virtual endpoints for a server.
    internal partial interface IVirtualEndpointResourceForPatchInternal

    {
        /// <summary>Type of endpoint for the virtual endpoints.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("ReadWrite")]
        string EndpointType { get; set; }
        /// <summary>List of servers that one of the virtual endpoints can refer to.</summary>
        System.Collections.Generic.List<string> Member { get; set; }
        /// <summary>Properties of the pair of virtual endpoints.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceProperties Property { get; set; }
        /// <summary>List of virtual endpoints for a server.</summary>
        System.Collections.Generic.List<string> VirtualEndpoint { get; set; }

    }
}