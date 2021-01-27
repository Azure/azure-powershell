namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>A paged list of private clouds</summary>
    public partial class PrivateCloudList :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudList,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudListInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudListInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloudListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next page if any</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud[] _value;

        /// <summary>The items on the page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="PrivateCloudList" /> instance.</summary>
        public PrivateCloudList()
        {

        }
    }
    /// A paged list of private clouds
    public partial interface IPrivateCloudList :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>URL to get the next page if any</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"URL to get the next page if any",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>The items on the page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The items on the page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud[] Value { get;  }

    }
    /// A paged list of private clouds
    internal partial interface IPrivateCloudListInternal

    {
        /// <summary>URL to get the next page if any</summary>
        string NextLink { get; set; }
        /// <summary>The items on the page</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IPrivateCloud[] Value { get; set; }

    }
}