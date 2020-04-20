namespace Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Extensions;

    /// <summary>A list of servers.</summary>
    public partial class ServerListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServerListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer[] _value;

        /// <summary>The list of servers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Origin(Microsoft.Azure.PowerShell.Cmdlets.MySql.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ServerListResult" /> instance.</summary>
        public ServerListResult()
        {

        }
    }
    /// A list of servers.
    public partial interface IServerListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.IJsonSerializable
    {
        /// <summary>The list of servers</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MySql.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of servers",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer) })]
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer[] Value { get; set; }

    }
    /// A list of servers.
    internal partial interface IServerListResultInternal

    {
        /// <summary>The list of servers</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MySql.Models.Api20171201.IServer[] Value { get; set; }

    }
}