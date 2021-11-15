namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class SubscriptionStateRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRule,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISubscriptionStateRuleInternal
    {

        /// <summary>Backing field for <see cref="AllowedAction" /> property.</summary>
        private string[] _allowedAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string[] AllowedAction { get => this._allowedAction; set => this._allowedAction = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionState? _state;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionState? State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="SubscriptionStateRule" /> instance.</summary>
        public SubscriptionStateRule()
        {

        }
    }
    public partial interface ISubscriptionStateRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"allowedActions",
        PossibleTypes = new [] { typeof(string) })]
        string[] AllowedAction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionState? State { get; set; }

    }
    internal partial interface ISubscriptionStateRuleInternal

    {
        string[] AllowedAction { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Support.SubscriptionState? State { get; set; }

    }
}