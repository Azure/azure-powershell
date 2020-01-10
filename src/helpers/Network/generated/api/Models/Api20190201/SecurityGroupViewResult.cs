namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The information about security rules applied to the specified VM.</summary>
    public partial class SecurityGroupViewResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupViewResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupViewResultInternal
    {

        /// <summary>Backing field for <see cref="NetworkInterface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface[] _networkInterface;

        /// <summary>List of network interfaces on the specified VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface[] NetworkInterface { get => this._networkInterface; set => this._networkInterface = value; }

        /// <summary>Creates an new <see cref="SecurityGroupViewResult" /> instance.</summary>
        public SecurityGroupViewResult()
        {

        }
    }
    /// The information about security rules applied to the specified VM.
    public partial interface ISecurityGroupViewResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>List of network interfaces on the specified VM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of network interfaces on the specified VM.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface[] NetworkInterface { get; set; }

    }
    /// The information about security rules applied to the specified VM.
    internal partial interface ISecurityGroupViewResultInternal

    {
        /// <summary>List of network interfaces on the specified VM.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityGroupNetworkInterface[] NetworkInterface { get; set; }

    }
}