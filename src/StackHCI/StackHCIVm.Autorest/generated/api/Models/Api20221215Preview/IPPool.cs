namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    public partial class IPPool :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPool,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInternal
    {

        /// <summary>Backing field for <see cref="End" /> property.</summary>
        private string _end;

        /// <summary>end of the ip address pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string End { get => this._end; set => this._end = value; }

        /// <summary>Backing field for <see cref="Info" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfo _info;

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfo Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPPoolInfo()); set => this._info = value; }

        /// <summary>no. of ip addresses available in the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string InfoAvailable { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Available; }

        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string InfoUsed { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Used; }

        /// <summary>Internal Acessors for Info</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfo Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInternal.Info { get => (this._info = this._info ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IPPoolInfo()); set { {_info = value;} } }

        /// <summary>Internal Acessors for InfoAvailable</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInternal.InfoAvailable { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Available; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Available = value; }

        /// <summary>Internal Acessors for InfoUsed</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInternal.InfoUsed { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Used; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfoInternal)Info).Used = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the IP-Pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Start" /> property.</summary>
        private string _start;

        /// <summary>start of the ip address pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public string Start { get => this._start; set => this._start = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum? _type;

        /// <summary>ip pool type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum? Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="IPPool" /> instance.</summary>
        public IPPool()
        {

        }
    }
    public partial interface IIPPool :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable
    {
        /// <summary>end of the ip address pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"end of the ip address pool",
        SerializedName = @"end",
        PossibleTypes = new [] { typeof(string) })]
        string End { get; set; }
        /// <summary>no. of ip addresses available in the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"no. of ip addresses available in the ip pool",
        SerializedName = @"available",
        PossibleTypes = new [] { typeof(string) })]
        string InfoAvailable { get;  }
        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"no. of ip addresses allocated from the ip pool",
        SerializedName = @"used",
        PossibleTypes = new [] { typeof(string) })]
        string InfoUsed { get;  }
        /// <summary>Name of the IP-Pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the IP-Pool",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>start of the ip address pool</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"start of the ip address pool",
        SerializedName = @"start",
        PossibleTypes = new [] { typeof(string) })]
        string Start { get; set; }
        /// <summary>ip pool type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ip pool type",
        SerializedName = @"ipPoolType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum? Type { get; set; }

    }
    internal partial interface IIPPoolInternal

    {
        /// <summary>end of the ip address pool</summary>
        string End { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IIPPoolInfo Info { get; set; }
        /// <summary>no. of ip addresses available in the ip pool</summary>
        string InfoAvailable { get; set; }
        /// <summary>no. of ip addresses allocated from the ip pool</summary>
        string InfoUsed { get; set; }
        /// <summary>Name of the IP-Pool</summary>
        string Name { get; set; }
        /// <summary>start of the ip address pool</summary>
        string Start { get; set; }
        /// <summary>ip pool type</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.IPPoolTypeEnum? Type { get; set; }

    }
}