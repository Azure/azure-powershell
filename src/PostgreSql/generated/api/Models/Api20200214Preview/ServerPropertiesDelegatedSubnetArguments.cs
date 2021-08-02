namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Extensions;

    public partial class ServerPropertiesDelegatedSubnetArguments :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerPropertiesDelegatedSubnetArguments,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Models.Api20200214Preview.IServerPropertiesDelegatedSubnetArgumentsInternal
    {

        /// <summary>Backing field for <see cref="SubnetArmResourceId" /> property.</summary>
        private string _subnetArmResourceId;

        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.PropertyOrigin.Owned)]
        public string SubnetArmResourceId { get => this._subnetArmResourceId; set => this._subnetArmResourceId = value; }

        /// <summary>
        /// Creates an new <see cref="ServerPropertiesDelegatedSubnetArguments" /> instance.
        /// </summary>
        public ServerPropertiesDelegatedSubnetArguments()
        {

        }
    }
    public partial interface IServerPropertiesDelegatedSubnetArguments :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.IJsonSerializable
    {
        /// <summary>delegated subnet arm resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"delegated subnet arm resource id.",
        SerializedName = @"subnetArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetArmResourceId { get; set; }

    }
    internal partial interface IServerPropertiesDelegatedSubnetArgumentsInternal

    {
        /// <summary>delegated subnet arm resource id.</summary>
        string SubnetArmResourceId { get; set; }

    }
}