namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Defines web application firewall policy.</summary>
    public partial class WebApplicationFirewallPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicy,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>A collection of references to application gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ApplicationGateway; }

        /// <summary>Describes custom rules inside the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).CustomRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).CustomRule = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for ApplicationGateway</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal.ApplicationGateway { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ApplicationGateway; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ApplicationGateway = value; }

        /// <summary>Internal Acessors for PolicySetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal.PolicySetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySetting = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for ResourceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyInternal.ResourceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ResourceState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ResourceState = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySettingEnabledState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySettingEnabledState = value; }

        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySettingMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).PolicySettingMode = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat _property;

        /// <summary>Properties of the web application firewall policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.WebApplicationFirewallPolicyPropertiesFormat()); set => this._property = value; }

        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>Resource status of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormatInternal)Property).ResourceState; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="WebApplicationFirewallPolicy" /> instance.</summary>
        public WebApplicationFirewallPolicy()
        {

        }
    }
    /// Defines web application firewall policy.
    public partial interface IWebApplicationFirewallPolicy :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>A collection of references to application gateways.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to application gateways.",
        SerializedName = @"applicationGateways",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get;  }
        /// <summary>Describes custom rules inside the policy</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes custom rules inside the policy",
        SerializedName = @"customRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if the policy is in enabled state or disabled state",
        SerializedName = @"enabledState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if it is in detection mode  or prevention mode at policy level",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get; set; }
        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the WebApplicationFirewallPolicy.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Resource status of the policy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource status of the policy.",
        SerializedName = @"resourceState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get;  }

    }
    /// Defines web application firewall policy.
    internal partial interface IWebApplicationFirewallPolicyInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>A collection of references to application gateways.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGateway[] ApplicationGateway { get; set; }
        /// <summary>Describes custom rules inside the policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallCustomRule[] CustomRule { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>Describes policySettings for policy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPolicySettings PolicySetting { get; set; }
        /// <summary>Describes if the policy is in enabled state or disabled state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallEnabledState? PolicySettingEnabledState { get; set; }
        /// <summary>Describes if it is in detection mode or prevention mode at policy level</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMode? PolicySettingMode { get; set; }
        /// <summary>Properties of the web application firewall policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IWebApplicationFirewallPolicyPropertiesFormat Property { get; set; }
        /// <summary>Provisioning state of the WebApplicationFirewallPolicy.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Resource status of the policy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallPolicyResourceState? ResourceState { get; set; }

    }
}