namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>
    /// Result of the GetQuotas operation. It contains a list of quotas for the subscription in a particular region.
    /// </summary>
    public partial class SubscriptionQuotasListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotasListResult,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotasListResultInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota[] Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotasListResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota[] _value;

        /// <summary>List of quotas for the subscription in a particular region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="SubscriptionQuotasListResult" /> instance.</summary>
        public SubscriptionQuotasListResult()
        {

        }
    }
    /// Result of the GetQuotas operation. It contains a list of quotas for the subscription in a particular region.
    public partial interface ISubscriptionQuotasListResult :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>List of quotas for the subscription in a particular region.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of quotas for the subscription in a particular region.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota) })]
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota[] Value { get;  }

    }
    /// Result of the GetQuotas operation. It contains a list of quotas for the subscription in a particular region.
    internal partial interface ISubscriptionQuotasListResultInternal

    {
        /// <summary>List of quotas for the subscription in a particular region.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuota[] Value { get; set; }

    }
}