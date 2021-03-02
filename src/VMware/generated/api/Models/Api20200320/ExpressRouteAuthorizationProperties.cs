namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>The properties of an ExpressRoute Circuit Authorization resource</summary>
    public partial class ExpressRouteAuthorizationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IExpressRouteAuthorizationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ExpressRouteAuthorizationId" /> property.</summary>
        private string _expressRouteAuthorizationId;

        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ExpressRouteAuthorizationId { get => this._expressRouteAuthorizationId; }

        /// <summary>Backing field for <see cref="ExpressRouteAuthorizationKey" /> property.</summary>
        private string _expressRouteAuthorizationKey;

        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ExpressRouteAuthorizationKey { get => this._expressRouteAuthorizationKey; }

        /// <summary>Internal Acessors for ExpressRouteAuthorizationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal.ExpressRouteAuthorizationId { get => this._expressRouteAuthorizationId; set { {_expressRouteAuthorizationId = value;} } }

        /// <summary>Internal Acessors for ExpressRouteAuthorizationKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal.ExpressRouteAuthorizationKey { get => this._expressRouteAuthorizationKey; set { {_expressRouteAuthorizationKey = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState? _provisioningState;

        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="ExpressRouteAuthorizationProperties" /> instance.</summary>
        public ExpressRouteAuthorizationProperties()
        {

        }
    }
    /// The properties of an ExpressRoute Circuit Authorization resource
    public partial interface IExpressRouteAuthorizationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ID of the ExpressRoute Circuit Authorization",
        SerializedName = @"expressRouteAuthorizationId",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteAuthorizationId { get;  }
        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key of the ExpressRoute Circuit Authorization",
        SerializedName = @"expressRouteAuthorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteAuthorizationKey { get;  }
        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the  ExpressRoute Circuit Authorization provisioning",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get;  }

    }
    /// The properties of an ExpressRoute Circuit Authorization resource
    internal partial interface IExpressRouteAuthorizationPropertiesInternal

    {
        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        string ExpressRouteAuthorizationId { get; set; }
        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        string ExpressRouteAuthorizationKey { get; set; }
        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get; set; }

    }
}