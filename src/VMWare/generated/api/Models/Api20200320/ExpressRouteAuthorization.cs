namespace Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Extensions;

    /// <summary>ExpressRoute Circuit Authorization</summary>
    public partial class ExpressRouteAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorization,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.Resource();

        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string ExpressRouteAuthorizationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationId; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Id; }

        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string Key { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationKey; }

        /// <summary>Internal Acessors for ExpressRouteAuthorizationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationInternal.ExpressRouteAuthorizationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationId = value; }

        /// <summary>Internal Acessors for Key</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationInternal.Key { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ExpressRouteAuthorizationKey = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationProperties Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.ExpressRouteAuthorizationProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ExpressRouteAuthorizationProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationProperties _property;

        /// <summary>The properties of an ExpressRoute Circuit Authorization resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.ExpressRouteAuthorizationProperties()); set => this._property = value; }

        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ExpressRouteAuthorization" /> instance.</summary>
        public ExpressRouteAuthorization()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// ExpressRoute Circuit Authorization
    public partial interface IExpressRouteAuthorization :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResource
    {
        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The ID of the ExpressRoute Circuit Authorization",
        SerializedName = @"expressRouteAuthorizationId",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteAuthorizationId { get;  }
        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The key of the ExpressRoute Circuit Authorization",
        SerializedName = @"expressRouteAuthorizationKey",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get;  }
        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the  ExpressRoute Circuit Authorization provisioning",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ExpressRouteAuthorizationProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get;  }

    }
    /// ExpressRoute Circuit Authorization
    internal partial interface IExpressRouteAuthorizationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IResourceInternal
    {
        /// <summary>The ID of the ExpressRoute Circuit Authorization</summary>
        string ExpressRouteAuthorizationId { get; set; }
        /// <summary>The key of the ExpressRoute Circuit Authorization</summary>
        string Key { get; set; }
        /// <summary>The properties of an ExpressRoute Circuit Authorization resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IExpressRouteAuthorizationProperties Property { get; set; }
        /// <summary>The state of the ExpressRoute Circuit Authorization provisioning</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Support.ExpressRouteAuthorizationProvisioningState? ProvisioningState { get; set; }

    }
}