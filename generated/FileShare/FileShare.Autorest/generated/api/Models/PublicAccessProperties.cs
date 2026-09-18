// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Extensions;

    /// <summary>The set of properties for control public access.</summary>
    public partial class PublicAccessProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessProperties,
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.IPublicAccessPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowedSubnet" /> property.</summary>
        private System.Collections.Generic.List<string> _allowedSubnet;

        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Origin(Microsoft.Azure.PowerShell.Cmdlets.FileShare.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> AllowedSubnet { get => this._allowedSubnet; set => this._allowedSubnet = value; }

        /// <summary>Creates an new <see cref="PublicAccessProperties" /> instance.</summary>
        public PublicAccessProperties()
        {

        }
    }
    /// The set of properties for control public access.
    public partial interface IPublicAccessProperties :
        Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.IJsonSerializable
    {
        /// <summary>The allowed set of subnets when access is restricted.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The allowed set of subnets when access is restricted.",
        SerializedName = @"allowedSubnets",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> AllowedSubnet { get; set; }

    }
    /// The set of properties for control public access.
    internal partial interface IPublicAccessPropertiesInternal

    {
        /// <summary>The allowed set of subnets when access is restricted.</summary>
        System.Collections.Generic.List<string> AllowedSubnet { get; set; }

    }
}