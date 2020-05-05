namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>The response to a list Active Directory Administrators request.</summary>
    public partial class ServerAdministratorResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResourceListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResourceListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource[] _value;

        /// <summary>The list of server Active Directory Administrators for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ServerAdministratorResourceListResult" /> instance.</summary>
        public ServerAdministratorResourceListResult()
        {

        }
    }
    /// The response to a list Active Directory Administrators request.
    public partial interface IServerAdministratorResourceListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The list of server Active Directory Administrators for the server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of server Active Directory Administrators for the server.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource[] Value { get; set; }

    }
    /// The response to a list Active Directory Administrators request.
    internal partial interface IServerAdministratorResourceListResultInternal

    {
        /// <summary>The list of server Active Directory Administrators for the server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerAdministratorResource[] Value { get; set; }

    }
}