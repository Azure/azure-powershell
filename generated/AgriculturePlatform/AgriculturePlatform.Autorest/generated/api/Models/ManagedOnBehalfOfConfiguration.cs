// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Extensions;

    /// <summary>Configuration of the managed on behalf of resource.</summary>
    public partial class ManagedOnBehalfOfConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfigurationInternal
    {

        /// <summary>Internal Acessors for MoboBrokerResource</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IManagedOnBehalfOfConfigurationInternal.MoboBrokerResource { get => this._moboBrokerResource; set { {_moboBrokerResource = value;} } }

        /// <summary>Backing field for <see cref="MoboBrokerResource" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> _moboBrokerResource;

        /// <summary>Associated MoboBrokerResources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Origin(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> MoboBrokerResource { get => this._moboBrokerResource; }

        /// <summary>Creates an new <see cref="ManagedOnBehalfOfConfiguration" /> instance.</summary>
        public ManagedOnBehalfOfConfiguration()
        {

        }
    }
    /// Configuration of the managed on behalf of resource.
    public partial interface IManagedOnBehalfOfConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.IJsonSerializable
    {
        /// <summary>Associated MoboBrokerResources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Associated MoboBrokerResources.",
        SerializedName = @"moboBrokerResources",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> MoboBrokerResource { get;  }

    }
    /// Configuration of the managed on behalf of resource.
    internal partial interface IManagedOnBehalfOfConfigurationInternal

    {
        /// <summary>Associated MoboBrokerResources.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.AgriculturePlatform.Models.IMoboBrokerResource> MoboBrokerResource { get; set; }

    }
}