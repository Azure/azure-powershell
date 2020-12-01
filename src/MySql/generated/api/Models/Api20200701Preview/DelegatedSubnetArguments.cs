namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>Delegated subnet arguments of a server</summary>
    public partial class DelegatedSubnetArguments :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArguments,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20200701Preview.IDelegatedSubnetArgumentsInternal
    {

        /// <summary>Backing field for <see cref="SubnetArmResourceId" /> property.</summary>
        private string _subnetArmResourceId;

        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public string SubnetArmResourceId { get => this._subnetArmResourceId; set => this._subnetArmResourceId = value; }

        /// <summary>Creates an new <see cref="DelegatedSubnetArguments" /> instance.</summary>
        public DelegatedSubnetArguments()
        {

        }
    }
    /// Delegated subnet arguments of a server
    public partial interface IDelegatedSubnetArguments :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"delegated subnet arm resource id.",
        SerializedName = @"subnetArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetArmResourceId { get; set; }

    }
    /// Delegated subnet arguments of a server
    internal partial interface IDelegatedSubnetArgumentsInternal

    {
        /// <summary>delegated subnet arm resource id.</summary>
        string SubnetArmResourceId { get; set; }

    }
}