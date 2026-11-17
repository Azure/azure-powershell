// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Policy.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Extensions;

    /// <summary>The policy token request properties.</summary>
    public partial class PolicyTokenRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenRequest,
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenRequestInternal
    {

        /// <summary>Backing field for <see cref="ChangeReference" /> property.</summary>
        private string _changeReference;

        /// <summary>The change reference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        public string ChangeReference { get => this._changeReference; set => this._changeReference = value; }

        /// <summary>Internal Acessors for Operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperation Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenRequestInternal.Operation { get => (this._operation = this._operation ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenOperation()); set { {_operation = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperation _operation;

        /// <summary>The resource operation to acquire a token for.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperation Operation { get => (this._operation = this._operation ?? new Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.PolicyTokenOperation()); set => this._operation = value; }

        /// <summary>The payload of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny OperationContent { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).Content; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).Content = value ?? null /* model class */; }

        /// <summary>The http method of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string OperationHttpMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).HttpMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).HttpMethod = value ; }

        /// <summary>The request URI of the resource operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Origin(Microsoft.Azure.PowerShell.Cmdlets.Policy.PropertyOrigin.Inlined)]
        public string OperationUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).Uri; set => ((Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperationInternal)Operation).Uri = value ; }

        /// <summary>Creates an new <see cref="PolicyTokenRequest" /> instance.</summary>
        public PolicyTokenRequest()
        {

        }
    }
    /// The policy token request properties.
    public partial interface IPolicyTokenRequest :
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.IJsonSerializable
    {
        /// <summary>The change reference.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Policy.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The change reference.",
        SerializedName = @"changeReference",
        PossibleTypes = new [] { typeof(string) })]
        string ChangeReference { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny OperationContent { get; set; }
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
        string OperationHttpMethod { get; set; }
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
        string OperationUri { get; set; }

    }
    /// The policy token request properties.
    internal partial interface IPolicyTokenRequestInternal

    {
        /// <summary>The change reference.</summary>
        string ChangeReference { get; set; }
        /// <summary>The resource operation to acquire a token for.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyTokenOperation Operation { get; set; }
        /// <summary>The payload of the resource operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IAny OperationContent { get; set; }
        /// <summary>The http method of the resource operation.</summary>
        string OperationHttpMethod { get; set; }
        /// <summary>The request URI of the resource operation.</summary>
        string OperationUri { get; set; }

    }
}