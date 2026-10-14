// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a pair of virtual endpoints.</summary>
    public partial class VirtualEndpointResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndpointType" /> property.</summary>
        private string _endpointType;

        /// <summary>Type of endpoint for the virtual endpoints.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string EndpointType { get => this._endpointType; set => this._endpointType = value; }

        /// <summary>Backing field for <see cref="Member" /> property.</summary>
        private System.Collections.Generic.List<string> _member;

        /// <summary>List of servers that one of the virtual endpoints can refer to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Member { get => this._member; set => this._member = value; }

        /// <summary>Internal Acessors for VirtualEndpoint</summary>
        System.Collections.Generic.List<string> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IVirtualEndpointResourcePropertiesInternal.VirtualEndpoint { get => this._virtualEndpoint; set { {_virtualEndpoint = value;} } }

        /// <summary>Backing field for <see cref="VirtualEndpoint" /> property.</summary>
        private System.Collections.Generic.List<string> _virtualEndpoint;

        /// <summary>List of virtual endpoints for a server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> VirtualEndpoint { get => this._virtualEndpoint; }

        /// <summary>Creates an new <see cref="VirtualEndpointResourceProperties" /> instance.</summary>
        public VirtualEndpointResourceProperties()
        {

        }
    }
    /// Properties of a pair of virtual endpoints.
    public partial interface IVirtualEndpointResourceProperties :
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
    /// Properties of a pair of virtual endpoints.
    internal partial interface IVirtualEndpointResourcePropertiesInternal

    {
        /// <summary>Type of endpoint for the virtual endpoints.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("ReadWrite")]
        string EndpointType { get; set; }
        /// <summary>List of servers that one of the virtual endpoints can refer to.</summary>
        System.Collections.Generic.List<string> Member { get; set; }
        /// <summary>List of virtual endpoints for a server.</summary>
        System.Collections.Generic.List<string> VirtualEndpoint { get; set; }

    }
}