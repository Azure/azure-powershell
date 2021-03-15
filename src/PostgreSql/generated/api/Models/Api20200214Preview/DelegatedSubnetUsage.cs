namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    /// <summary>Delegated subnet usage data.</summary>
    public partial class DelegatedSubnetUsage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsage,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsageInternal
    {

        /// <summary>Internal Acessors for SubnetName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsageInternal.SubnetName { get => this._subnetName; set { {_subnetName = value;} } }

        /// <summary>Internal Acessors for Usage</summary>
        long? Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IDelegatedSubnetUsageInternal.Usage { get => this._usage; set { {_usage = value;} } }

        /// <summary>Backing field for <see cref="SubnetName" /> property.</summary>
        private string _subnetName;

        /// <summary>name of the subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string SubnetName { get => this._subnetName; }

        /// <summary>Backing field for <see cref="Usage" /> property.</summary>
        private long? _usage;

        /// <summary>Number of used delegated subnets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public long? Usage { get => this._usage; }

        /// <summary>Creates an new <see cref="DelegatedSubnetUsage" /> instance.</summary>
        public DelegatedSubnetUsage()
        {

        }
    }
    /// Delegated subnet usage data.
    public partial interface IDelegatedSubnetUsage :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>name of the subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"name of the subnet",
        SerializedName = @"subnetName",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get;  }
        /// <summary>Number of used delegated subnets</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Number of used delegated subnets",
        SerializedName = @"usage",
        PossibleTypes = new [] { typeof(long) })]
        long? Usage { get;  }

    }
    /// Delegated subnet usage data.
    internal partial interface IDelegatedSubnetUsageInternal

    {
        /// <summary>name of the subnet</summary>
        string SubnetName { get; set; }
        /// <summary>Number of used delegated subnets</summary>
        long? Usage { get; set; }

    }
}