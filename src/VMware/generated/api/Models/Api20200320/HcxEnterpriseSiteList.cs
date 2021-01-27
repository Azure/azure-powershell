namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>A paged list of HCX Enterprise Sites</summary>
    public partial class HcxEnterpriseSiteList :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteList,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteListInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteListInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite[] Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>URL to get the next page if any</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite[] _value;

        /// <summary>The items on a page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="HcxEnterpriseSiteList" /> instance.</summary>
        public HcxEnterpriseSiteList()
        {

        }
    }
    /// A paged list of HCX Enterprise Sites
    public partial interface IHcxEnterpriseSiteList :
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
        /// <summary>The items on a page</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The items on a page",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite[] Value { get;  }

    }
    /// A paged list of HCX Enterprise Sites
    internal partial interface IHcxEnterpriseSiteListInternal

    {
        /// <summary>URL to get the next page if any</summary>
        string NextLink { get; set; }
        /// <summary>The items on a page</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite[] Value { get; set; }

    }
}