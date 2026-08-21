// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>For tracking mobo resources</summary>
    public partial class WithMoboBrokerResources :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResources,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal
    {

        /// <summary>Internal Acessors for MoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IWithMoboBrokerResourcesInternal.MoboBrokerResource { get => this._moboBrokerResource; set { {_moboBrokerResource = value;} } }

        /// <summary>Backing field for <see cref="MoboBrokerResource" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> _moboBrokerResource;

        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> MoboBrokerResource { get => this._moboBrokerResource; }

        /// <summary>Creates an new <see cref="WithMoboBrokerResources" /> instance.</summary>
        public WithMoboBrokerResources()
        {

        }
    }
    /// For tracking mobo resources
    public partial interface IWithMoboBrokerResources :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Managed-On-Behalf-Of broker resources",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> MoboBrokerResource { get;  }

    }
    /// For tracking mobo resources
    internal partial interface IWithMoboBrokerResourcesInternal

    {
        /// <summary>Managed-On-Behalf-Of broker resources</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource> MoboBrokerResource { get; set; }

    }
}