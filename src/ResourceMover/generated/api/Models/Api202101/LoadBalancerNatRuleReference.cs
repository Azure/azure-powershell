namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines reference to load balancer NAT rules.</summary>
    public partial class LoadBalancerNatRuleReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerNatRuleReference,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILoadBalancerNatRuleReferenceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference __proxyResourceReference = new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ProxyResourceReference();

        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReferenceInternal)__proxyResourceReference).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReferenceInternal)__proxyResourceReference).Name = value ?? null; }

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inherited)]
        public string SourceArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)__proxyResourceReference).SourceArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IAzureResourceReferenceInternal)__proxyResourceReference).SourceArmResourceId = value ; }

        /// <summary>Creates an new <see cref="LoadBalancerNatRuleReference" /> instance.</summary>
        public LoadBalancerNatRuleReference()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyResourceReference), __proxyResourceReference);
            await eventListener.AssertObjectIsValid(nameof(__proxyResourceReference), __proxyResourceReference);
        }
    }
    /// Defines reference to load balancer NAT rules.
    public partial interface ILoadBalancerNatRuleReference :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReference
    {

    }
    /// Defines reference to load balancer NAT rules.
    internal partial interface ILoadBalancerNatRuleReferenceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IProxyResourceReferenceInternal
    {

    }
}