namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LinkedAccessCheck :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheck,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedAccessCheckInternal
    {

        /// <summary>Backing field for <see cref="ActionName" /> property.</summary>
        private string _actionName;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string ActionName { get => this._actionName; set => this._actionName = value; }

        /// <summary>Backing field for <see cref="LinkedAction" /> property.</summary>
        private string _linkedAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedAction { get => this._linkedAction; set => this._linkedAction = value; }

        /// <summary>Backing field for <see cref="LinkedActionVerb" /> property.</summary>
        private string _linkedActionVerb;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedActionVerb { get => this._linkedActionVerb; set => this._linkedActionVerb = value; }

        /// <summary>Backing field for <see cref="LinkedProperty" /> property.</summary>
        private string _linkedProperty;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedProperty { get => this._linkedProperty; set => this._linkedProperty = value; }

        /// <summary>Backing field for <see cref="LinkedType" /> property.</summary>
        private string _linkedType;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedType { get => this._linkedType; set => this._linkedType = value; }

        /// <summary>Creates an new <see cref="LinkedAccessCheck" /> instance.</summary>
        public LinkedAccessCheck()
        {

        }
    }
    public partial interface ILinkedAccessCheck :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"actionName",
        PossibleTypes = new [] { typeof(string) })]
        string ActionName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedAction",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedAction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedActionVerb",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedActionVerb { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedProperty",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedProperty { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedType",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedType { get; set; }

    }
    internal partial interface ILinkedAccessCheckInternal

    {
        string ActionName { get; set; }

        string LinkedAction { get; set; }

        string LinkedActionVerb { get; set; }

        string LinkedProperty { get; set; }

        string LinkedType { get; set; }

    }
}