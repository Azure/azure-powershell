namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The response containing cached images.</summary>
    public partial class CachedImagesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImagesListResult,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImagesListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI to fetch the next page of cached images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages[] _value;

        /// <summary>The list of cached images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="CachedImagesListResult" /> instance.</summary>
        public CachedImagesListResult()
        {

        }
    }
    /// The response containing cached images.
    public partial interface ICachedImagesListResult :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The URI to fetch the next page of cached images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI to fetch the next page of cached images.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of cached images.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of cached images.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages[] Value { get; set; }

    }
    /// The response containing cached images.
    internal partial interface ICachedImagesListResultInternal

    {
        /// <summary>The URI to fetch the next page of cached images.</summary>
        string NextLink { get; set; }
        /// <summary>The list of cached images.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ICachedImages[] Value { get; set; }

    }
}