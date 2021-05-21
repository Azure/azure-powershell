namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Specifies a list of role instances from the cloud service.</summary>
    public partial class RoleInstances :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstances,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancesInternal
    {

        /// <summary>Backing field for <see cref="RoleInstance" /> property.</summary>
        private string[] _roleInstance;

        /// <summary>
        /// List of cloud service role instance names. Value of '*' will signify all role instances of the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string[] RoleInstance { get => this._roleInstance; set => this._roleInstance = value; }

        /// <summary>Creates an new <see cref="RoleInstances" /> instance.</summary>
        public RoleInstances()
        {

        }
    }
    /// Specifies a list of role instances from the cloud service.
    public partial interface IRoleInstances :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// List of cloud service role instance names. Value of '*' will signify all role instances of the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of cloud service role instance names. Value of '*' will signify all role instances of the cloud service.",
        SerializedName = @"roleInstances",
        PossibleTypes = new [] { typeof(string) })]
        string[] RoleInstance { get; set; }

    }
    /// Specifies a list of role instances from the cloud service.
    internal partial interface IRoleInstancesInternal

    {
        /// <summary>
        /// List of cloud service role instance names. Value of '*' will signify all role instances of the cloud service.
        /// </summary>
        string[] RoleInstance { get; set; }

    }
}