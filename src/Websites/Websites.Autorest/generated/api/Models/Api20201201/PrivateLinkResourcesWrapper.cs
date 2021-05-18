namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Wrapper for a collection of private link resources</summary>
    public partial class PrivateLinkResourcesWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResourcesWrapper,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResourcesWrapperInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResource[] _value;

        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PrivateLinkResourcesWrapper" /> instance.</summary>
        public PrivateLinkResourcesWrapper()
        {

        }
    }
    /// Wrapper for a collection of private link resources
    public partial interface IPrivateLinkResourcesWrapper :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResource[] Value { get; set; }

    }
    /// Wrapper for a collection of private link resources
    internal partial interface IPrivateLinkResourcesWrapperInternal

    {
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.IPrivateLinkResource[] Value { get; set; }

    }
}