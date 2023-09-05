namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class IPPoolInfo :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfo,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal
    {

        /// <summary>Backing field for <see cref="Available" /> property.</summary>
        private string _available;

        /// <summary>no. of ip addresses available in the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Available { get => this._available; }

        /// <summary>Internal Acessors for Available</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal.Available { get => this._available; set { {_available = value;} } }

        /// <summary>Internal Acessors for Used</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal.Used { get => this._used; set { {_used = value;} } }

        /// <summary>Backing field for <see cref="Used" /> property.</summary>
        private string _used;

        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Used { get => this._used; }

        /// <summary>Creates an new <see cref="IPPoolInfo" /> instance.</summary>
        public IPPoolInfo()
        {

        }
    }
    public partial interface IIPPoolInfo :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>no. of ip addresses available in the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"no. of ip addresses available in the ip pool",
        SerializedName = @"available",
        PossibleTypes = new [] { typeof(string) })]
        string Available { get;  }
        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"no. of ip addresses allocated from the ip pool",
        SerializedName = @"used",
        PossibleTypes = new [] { typeof(string) })]
        string Used { get;  }

    }
    internal partial interface IIPPoolInfoInternal

    {
        /// <summary>no. of ip addresses available in the ip pool</summary>
        string Available { get; set; }
        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        string Used { get; set; }

    }
}