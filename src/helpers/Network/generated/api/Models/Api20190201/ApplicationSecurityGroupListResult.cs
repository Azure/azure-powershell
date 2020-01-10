namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A list of application security groups.</summary>
    public partial class ApplicationSecurityGroupListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroupListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroupListResultInternal
    {

        /// <summary>Internal Acessors for NextLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroupListResultInternal.NextLink { get => this._nextLink; set { {_nextLink = value;} } }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] _value;

        /// <summary>A list of application security groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ApplicationSecurityGroupListResult" /> instance.</summary>
        public ApplicationSecurityGroupListResult()
        {

        }
    }
    /// A list of application security groups.
    public partial interface IApplicationSecurityGroupListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The URL to get the next set of results.",
        SerializedName = @"nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get;  }
        /// <summary>A list of application security groups.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of application security groups.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] Value { get; set; }

    }
    /// A list of application security groups.
    internal partial interface IApplicationSecurityGroupListResultInternal

    {
        /// <summary>The URL to get the next set of results.</summary>
        string NextLink { get; set; }
        /// <summary>A list of application security groups.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationSecurityGroup[] Value { get; set; }

    }
}