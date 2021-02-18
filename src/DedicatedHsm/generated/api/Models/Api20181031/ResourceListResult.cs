namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>List of dedicated HSM resources.</summary>
    public partial class ResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceListResult,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceListResultInternal
    {

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of dedicated HSM resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource[] _value;

        /// <summary>The list of dedicated HSM resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ResourceListResult" /> instance.</summary>
        public ResourceListResult()
        {

        }
    }
    /// List of dedicated HSM resources.
    public partial interface IResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of dedicated HSM resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL to get the next set of dedicated HSM resources.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }
        /// <summary>The list of dedicated HSM resources.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of dedicated HSM resources.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource[] Value { get; set; }

    }
    /// List of dedicated HSM resources.
    internal partial interface IResourceListResultInternal

    {
        /// <summary>The URL to get the next set of dedicated HSM resources.</summary>
        string NextLink { get; set; }
        /// <summary>The list of dedicated HSM resources.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource[] Value { get; set; }

    }
}