namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the VM to check security groups for.</summary>
    public partial class SecurityGroupViewParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupViewParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupViewParametersInternal
    {

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>ID of the target VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="SecurityGroupViewParameters" /> instance.</summary>
        public SecurityGroupViewParameters()
        {

        }
    }
    /// Parameters that define the VM to check security groups for.
    public partial interface ISecurityGroupViewParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>ID of the target VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ID of the target VM.",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Parameters that define the VM to check security groups for.
    internal partial interface ISecurityGroupViewParametersInternal

    {
        /// <summary>ID of the target VM.</summary>
        string TargetResourceId { get; set; }

    }
}