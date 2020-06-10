namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Wrapper for a collection of private link resources</summary>
    public partial class PrivateLinkResourcesWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcesWrapper,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResourcesWrapperInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PrivateLinkResourcesWrapper" /> instance.</summary>
        public PrivateLinkResourcesWrapper()
        {

        }
    }
    /// Wrapper for a collection of private link resources
    public partial interface IPrivateLinkResourcesWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource[] Value { get; set; }

    }
    /// Wrapper for a collection of private link resources
    internal partial interface IPrivateLinkResourcesWrapperInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPrivateLinkResource[] Value { get; set; }

    }
}