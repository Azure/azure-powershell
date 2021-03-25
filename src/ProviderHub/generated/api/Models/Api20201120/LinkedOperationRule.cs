namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LinkedOperationRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRule,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILinkedOperationRuleInternal
    {

        /// <summary>Backing field for <see cref="LinkedAction" /> property.</summary>
        private string _linkedAction;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedAction { get => this._linkedAction; set => this._linkedAction = value; }

        /// <summary>Backing field for <see cref="LinkedOperation" /> property.</summary>
        private string _linkedOperation;

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Owned)]
        public string LinkedOperation { get => this._linkedOperation; set => this._linkedOperation = value; }

        /// <summary>Creates an new <see cref="LinkedOperationRule" /> instance.</summary>
        public LinkedOperationRule()
        {

        }
    }
    public partial interface ILinkedOperationRule :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedAction",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedAction { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"linkedOperation",
        PossibleTypes = new [] { typeof(string) })]
        string LinkedOperation { get; set; }

    }
    internal partial interface ILinkedOperationRuleInternal

    {
        string LinkedAction { get; set; }

        string LinkedOperation { get; set; }

    }
}