namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class ResourceMovePolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicy,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.IResourceMovePolicyInternal
    {

        /// <summary>Backing field for <see cref="CrossResourceGroupMoveEnabled" /> property.</summary>
        private bool? _crossResourceGroupMoveEnabled;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? CrossResourceGroupMoveEnabled { get => this._crossResourceGroupMoveEnabled; set => this._crossResourceGroupMoveEnabled = value; }

        /// <summary>Backing field for <see cref="CrossSubscriptionMoveEnabled" /> property.</summary>
        private bool? _crossSubscriptionMoveEnabled;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? CrossSubscriptionMoveEnabled { get => this._crossSubscriptionMoveEnabled; set => this._crossSubscriptionMoveEnabled = value; }

        /// <summary>Backing field for <see cref="ValidationRequired" /> property.</summary>
        private bool? _validationRequired;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public bool? ValidationRequired { get => this._validationRequired; set => this._validationRequired = value; }

        /// <summary>Creates an new <see cref="ResourceMovePolicy" /> instance.</summary>
        public ResourceMovePolicy()
        {

        }
    }
    public partial interface IResourceMovePolicy :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"crossResourceGroupMoveEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CrossResourceGroupMoveEnabled { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"crossSubscriptionMoveEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CrossSubscriptionMoveEnabled { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"validationRequired",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ValidationRequired { get; set; }

    }
    internal partial interface IResourceMovePolicyInternal

    {
        bool? CrossResourceGroupMoveEnabled { get; set; }

        bool? CrossSubscriptionMoveEnabled { get; set; }

        bool? ValidationRequired { get; set; }

    }
}