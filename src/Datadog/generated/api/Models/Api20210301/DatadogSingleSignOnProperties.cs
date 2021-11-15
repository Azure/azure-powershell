namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogSingleSignOnProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EnterpriseAppId" /> property.</summary>
        private string _enterpriseAppId;

        /// <summary>The Id of the Enterprise App used for Single sign-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string EnterpriseAppId { get => this._enterpriseAppId; set => this._enterpriseAppId = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SingleSignOnUrl</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSingleSignOnPropertiesInternal.SingleSignOnUrl { get => this._singleSignOnUrl; set { {_singleSignOnUrl = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? _provisioningState;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SingleSignOnState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates? _singleSignOnState;

        /// <summary>Various states of the SSO resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates? SingleSignOnState { get => this._singleSignOnState; set => this._singleSignOnState = value; }

        /// <summary>Backing field for <see cref="SingleSignOnUrl" /> property.</summary>
        private string _singleSignOnUrl;

        /// <summary>The login URL specific to this Datadog Organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string SingleSignOnUrl { get => this._singleSignOnUrl; }

        /// <summary>Creates an new <see cref="DatadogSingleSignOnProperties" /> instance.</summary>
        public DatadogSingleSignOnProperties()
        {

        }
    }
    public partial interface IDatadogSingleSignOnProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>The Id of the Enterprise App used for Single sign-on.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Id of the Enterprise App used for Single sign-on.",
        SerializedName = @"enterpriseAppId",
        PossibleTypes = new [] { typeof(string) })]
        string EnterpriseAppId { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Various states of the SSO resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Various states of the SSO resource",
        SerializedName = @"singleSignOnState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates) })]
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates? SingleSignOnState { get; set; }
        /// <summary>The login URL specific to this Datadog Organization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The login URL specific to this Datadog Organization.",
        SerializedName = @"singleSignOnUrl",
        PossibleTypes = new [] { typeof(string) })]
        string SingleSignOnUrl { get;  }

    }
    internal partial interface IDatadogSingleSignOnPropertiesInternal

    {
        /// <summary>The Id of the Enterprise App used for Single sign-on.</summary>
        string EnterpriseAppId { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Various states of the SSO resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Support.SingleSignOnStates? SingleSignOnState { get; set; }
        /// <summary>The login URL specific to this Datadog Organization.</summary>
        string SingleSignOnUrl { get; set; }

    }
}