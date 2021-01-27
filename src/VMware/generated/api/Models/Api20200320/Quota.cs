namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>Subscription quotas</summary>
    public partial class Quota :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuota,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaInternal
    {

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled? _enabled;

        /// <summary>Host quota is active for current subscription</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled? Enabled { get => this._enabled; }

        /// <summary>Backing field for <see cref="HostsRemaining" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining _hostsRemaining;

        /// <summary>Remaining hosts quota by sku type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining HostsRemaining { get => (this._hostsRemaining = this._hostsRemaining ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.QuotaHostsRemaining()); }

        /// <summary>Internal Acessors for Enabled</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaInternal.Enabled { get => this._enabled; set { {_enabled = value;} } }

        /// <summary>Internal Acessors for HostsRemaining</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaInternal.HostsRemaining { get => (this._hostsRemaining = this._hostsRemaining ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.QuotaHostsRemaining()); set { {_hostsRemaining = value;} } }

        /// <summary>Creates an new <see cref="Quota" /> instance.</summary>
        public Quota()
        {

        }
    }
    /// Subscription quotas
    public partial interface IQuota :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Host quota is active for current subscription</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Host quota is active for current subscription",
        SerializedName = @"quotaEnabled",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled? Enabled { get;  }
        /// <summary>Remaining hosts quota by sku type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Remaining hosts quota by sku type",
        SerializedName = @"hostsRemaining",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining HostsRemaining { get;  }

    }
    /// Subscription quotas
    internal partial interface IQuotaInternal

    {
        /// <summary>Host quota is active for current subscription</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.QuotaEnabled? Enabled { get; set; }
        /// <summary>Remaining hosts quota by sku type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IQuotaHostsRemaining HostsRemaining { get; set; }

    }
}