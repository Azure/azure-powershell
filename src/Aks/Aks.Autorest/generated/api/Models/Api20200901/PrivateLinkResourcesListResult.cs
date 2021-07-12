namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>A list of private link resources</summary>
    public partial class PrivateLinkResourcesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResourcesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResourcesListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource[] _value;

        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PrivateLinkResourcesListResult" /> instance.</summary>
        public PrivateLinkResourcesListResult()
        {

        }
    }
    /// A list of private link resources
    public partial interface IPrivateLinkResourcesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection value.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource[] Value { get; set; }

    }
    /// A list of private link resources
    internal partial interface IPrivateLinkResourcesListResultInternal

    {
        /// <summary>The collection value.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IPrivateLinkResource[] Value { get; set; }

    }
}