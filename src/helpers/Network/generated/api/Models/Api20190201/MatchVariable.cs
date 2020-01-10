namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Define match variables</summary>
    public partial class MatchVariable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariableInternal
    {

        /// <summary>Backing field for <see cref="Selector" /> property.</summary>
        private string _selector;

        /// <summary>Describes field of the matchVariable collection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Selector { get => this._selector; set => this._selector = value; }

        /// <summary>Backing field for <see cref="VariableName" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable _variableName;

        /// <summary>Match Variable</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable VariableName { get => this._variableName; set => this._variableName = value; }

        /// <summary>Creates an new <see cref="MatchVariable" /> instance.</summary>
        public MatchVariable()
        {

        }
    }
    /// Define match variables
    public partial interface IMatchVariable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Describes field of the matchVariable collection</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes field of the matchVariable collection",
        SerializedName = @"selector",
        PossibleTypes = new [] { typeof(string) })]
        string Selector { get; set; }
        /// <summary>Match Variable</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Match Variable",
        SerializedName = @"variableName",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable VariableName { get; set; }

    }
    /// Define match variables
    internal partial interface IMatchVariableInternal

    {
        /// <summary>Describes field of the matchVariable collection</summary>
        string Selector { get; set; }
        /// <summary>Match Variable</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallMatchVariable VariableName { get; set; }

    }
}