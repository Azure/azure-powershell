namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>The restriction because of which SKU cannot be used.</summary>
    public partial class Restriction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestriction,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestrictionInternal
    {

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestrictionInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IRestrictionInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="ReasonCode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ReasonCode? _reasonCode;

        /// <summary>
        /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when
        /// the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription"
        /// is related to capacity at DC.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ReasonCode? ReasonCode { get => this._reasonCode; set => this._reasonCode = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of restrictions. As of now only possible value for this is location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string[] _value;

        /// <summary>
        /// The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU
        /// is restricted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="Restriction" /> instance.</summary>
        public Restriction()
        {

        }
    }
    /// The restriction because of which SKU cannot be used.
    public partial interface IRestriction :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when
        /// the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription"
        /// is related to capacity at DC.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reason for the restriction. As of now this can be ""QuotaId"" or ""NotAvailableForSubscription"". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The ""NotAvailableForSubscription"" is related to capacity at DC.",
        SerializedName = @"reasonCode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ReasonCode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ReasonCode? ReasonCode { get; set; }
        /// <summary>The type of restrictions. As of now only possible value for this is location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The type of restrictions. As of now only possible value for this is location.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>
        /// The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU
        /// is restricted.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU is restricted.",
        SerializedName = @"values",
        PossibleTypes = new [] { typeof(string) })]
        string[] Value { get;  }

    }
    /// The restriction because of which SKU cannot be used.
    internal partial interface IRestrictionInternal

    {
        /// <summary>
        /// The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when
        /// the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription"
        /// is related to capacity at DC.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ReasonCode? ReasonCode { get; set; }
        /// <summary>The type of restrictions. As of now only possible value for this is location.</summary>
        string Type { get; set; }
        /// <summary>
        /// The value of restrictions. If the restriction type is set to location. This would be different locations where the SKU
        /// is restricted.
        /// </summary>
        string[] Value { get; set; }

    }
}