namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Purchase plan configuration for platform image.</summary>
    public partial class PlatformImagePurchasePlan :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlan,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IPlatformImagePurchasePlanInternal
    {

        /// <summary>Backing field for <see cref="PlanName" /> property.</summary>
        private string _planName;

        /// <summary>Name of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string PlanName { get => this._planName; set => this._planName = value; }

        /// <summary>Backing field for <see cref="PlanProduct" /> property.</summary>
        private string _planProduct;

        /// <summary>Product of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string PlanProduct { get => this._planProduct; set => this._planProduct = value; }

        /// <summary>Backing field for <see cref="PlanPublisher" /> property.</summary>
        private string _planPublisher;

        /// <summary>Publisher of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string PlanPublisher { get => this._planPublisher; set => this._planPublisher = value; }

        /// <summary>Creates an new <see cref="PlatformImagePurchasePlan" /> instance.</summary>
        public PlatformImagePurchasePlan()
        {

        }
    }
    /// Purchase plan configuration for platform image.
    public partial interface IPlatformImagePurchasePlan :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>Name of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the purchase plan.",
        SerializedName = @"planName",
        PossibleTypes = new [] { typeof(string) })]
        string PlanName { get; set; }
        /// <summary>Product of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Product of the purchase plan.",
        SerializedName = @"planProduct",
        PossibleTypes = new [] { typeof(string) })]
        string PlanProduct { get; set; }
        /// <summary>Publisher of the purchase plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Publisher of the purchase plan.",
        SerializedName = @"planPublisher",
        PossibleTypes = new [] { typeof(string) })]
        string PlanPublisher { get; set; }

    }
    /// Purchase plan configuration for platform image.
    public partial interface IPlatformImagePurchasePlanInternal

    {
        /// <summary>Name of the purchase plan.</summary>
        string PlanName { get; set; }
        /// <summary>Product of the purchase plan.</summary>
        string PlanProduct { get; set; }
        /// <summary>Publisher of the purchase plan.</summary>
        string PlanPublisher { get; set; }

    }
}