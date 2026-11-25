// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The resource operation to acquire a token for.</summary>
    public partial class PolicyTokenOperation :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperation,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal
    {

        /// <summary>Backing field for <see cref="Content" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny _content;

        /// <summary>The payload of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Content { get => (this._content = this._content ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.Any()); set => this._content = value; }

        /// <summary>Backing field for <see cref="HttpMethod" /> property.</summary>
        private string _httpMethod;

        /// <summary>The http method of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string HttpMethod { get => this._httpMethod; set => this._httpMethod = value; }

        /// <summary>Backing field for <see cref="Uri" /> property.</summary>
        private string _uri;

        /// <summary>The request URI of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string Uri { get => this._uri; set => this._uri = value; }

        /// <summary>Creates an new <see cref="PolicyTokenOperation" /> instance.</summary>
        public PolicyTokenOperation()
        {

        }
    }
    /// The resource operation to acquire a token for.
    public partial interface IPolicyTokenOperation :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The payload of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The payload of the resource operation.",
        SerializedName = @"content",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Content { get; set; }
        /// <summary>The http method of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The http method of the resource operation.",
        SerializedName = @"httpMethod",
        PossibleTypes = new [] { typeof(string) })]
        string HttpMethod { get; set; }
        /// <summary>The request URI of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The request URI of the resource operation.",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string Uri { get; set; }

    }
    /// The resource operation to acquire a token for.
    internal partial interface IPolicyTokenOperationInternal

    {
        /// <summary>The payload of the resource operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny Content { get; set; }
        /// <summary>The http method of the resource operation.</summary>
        string HttpMethod { get; set; }
        /// <summary>The request URI of the resource operation.</summary>
        string Uri { get; set; }

    }
}