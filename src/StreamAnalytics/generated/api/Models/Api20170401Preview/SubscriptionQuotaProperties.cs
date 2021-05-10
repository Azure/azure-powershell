namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>Describes the properties of the quota.</summary>
    public partial class SubscriptionQuotaProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotaProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotaPropertiesInternal
    {

        /// <summary>Backing field for <see cref="CurrentCount" /> property.</summary>
        private int? _currentCount;

        /// <summary>The current usage of this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? CurrentCount { get => this._currentCount; }

        /// <summary>Backing field for <see cref="MaxCount" /> property.</summary>
        private int? _maxCount;

        /// <summary>The max permitted usage of this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public int? MaxCount { get => this._maxCount; }

        /// <summary>Internal Acessors for CurrentCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotaPropertiesInternal.CurrentCount { get => this._currentCount; set { {_currentCount = value;} } }

        /// <summary>Internal Acessors for MaxCount</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ISubscriptionQuotaPropertiesInternal.MaxCount { get => this._maxCount; set { {_maxCount = value;} } }

        /// <summary>Creates an new <see cref="SubscriptionQuotaProperties" /> instance.</summary>
        public SubscriptionQuotaProperties()
        {

        }
    }
    /// Describes the properties of the quota.
    public partial interface ISubscriptionQuotaProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The current usage of this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The current usage of this resource.",
        SerializedName = @"currentCount",
        PossibleTypes = new [] { typeof(int) })]
        int? CurrentCount { get;  }
        /// <summary>The max permitted usage of this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The max permitted usage of this resource.",
        SerializedName = @"maxCount",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxCount { get;  }

    }
    /// Describes the properties of the quota.
    internal partial interface ISubscriptionQuotaPropertiesInternal

    {
        /// <summary>The current usage of this resource.</summary>
        int? CurrentCount { get; set; }
        /// <summary>The max permitted usage of this resource.</summary>
        int? MaxCount { get; set; }

    }
}