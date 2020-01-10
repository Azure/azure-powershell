namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Define match conditions</summary>
    public partial class MatchCondition :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchCondition,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchConditionInternal
    {

        /// <summary>Backing field for <see cref="MatchValue" /> property.</summary>
        private string[] _matchValue;

        /// <summary>Match value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] MatchValue { get => this._matchValue; set => this._matchValue = value; }

        /// <summary>Backing field for <see cref="MatchVariable" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[] _matchVariable;

        /// <summary>List of match variables</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[] MatchVariable { get => this._matchVariable; set => this._matchVariable = value; }

        /// <summary>Backing field for <see cref="NegationConditon" /> property.</summary>
        private bool? _negationConditon;

        /// <summary>Describes if this is negate condition or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? NegationConditon { get => this._negationConditon; set => this._negationConditon = value; }

        /// <summary>Backing field for <see cref="Operator" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator _operator;

        /// <summary>Describes operator to be matched</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Operator { get => this._operator; set => this._operator = value; }

        /// <summary>Backing field for <see cref="Transform" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[] _transform;

        /// <summary>List of transforms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[] Transform { get => this._transform; set => this._transform = value; }

        /// <summary>Creates an new <see cref="MatchCondition" /> instance.</summary>
        public MatchCondition()
        {

        }
    }
    /// Define match conditions
    public partial interface IMatchCondition :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Match value</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Match value",
        SerializedName = @"matchValues",
        PossibleTypes = new [] { typeof(string) })]
        string[] MatchValue { get; set; }
        /// <summary>List of match variables</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"List of match variables",
        SerializedName = @"matchVariables",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[] MatchVariable { get; set; }
        /// <summary>Describes if this is negate condition or not</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes if this is negate condition or not",
        SerializedName = @"negationConditon",
        PossibleTypes = new [] { typeof(bool) })]
        bool? NegationConditon { get; set; }
        /// <summary>Describes operator to be matched</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Describes operator to be matched",
        SerializedName = @"operator",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Operator { get; set; }
        /// <summary>List of transforms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of transforms",
        SerializedName = @"transforms",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[] Transform { get; set; }

    }
    /// Define match conditions
    internal partial interface IMatchConditionInternal

    {
        /// <summary>Match value</summary>
        string[] MatchValue { get; set; }
        /// <summary>List of match variables</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IMatchVariable[] MatchVariable { get; set; }
        /// <summary>Describes if this is negate condition or not</summary>
        bool? NegationConditon { get; set; }
        /// <summary>Describes operator to be matched</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallOperator Operator { get; set; }
        /// <summary>List of transforms</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.WebApplicationFirewallTransform[] Transform { get; set; }

    }
}