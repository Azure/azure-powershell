namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Results of IP flow verification on the target resource.</summary>
    public partial class VerificationIPFlowResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVerificationIPFlowResultInternal
    {

        /// <summary>Backing field for <see cref="Access" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access? _access;

        /// <summary>Indicates whether the traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access? Access { get => this._access; set => this._access = value; }

        /// <summary>Backing field for <see cref="RuleName" /> property.</summary>
        private string _ruleName;

        /// <summary>
        /// Name of the rule. If input is not matched against any security rule, it is not displayed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string RuleName { get => this._ruleName; set => this._ruleName = value; }

        /// <summary>Creates an new <see cref="VerificationIPFlowResult" /> instance.</summary>
        public VerificationIPFlowResult()
        {

        }
    }
    /// Results of IP flow verification on the target resource.
    public partial interface IVerificationIPFlowResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Indicates whether the traffic is allowed or denied.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether the traffic is allowed or denied.",
        SerializedName = @"access",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access? Access { get; set; }
        /// <summary>
        /// Name of the rule. If input is not matched against any security rule, it is not displayed.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the rule. If input is not matched against any security rule, it is not displayed.",
        SerializedName = @"ruleName",
        PossibleTypes = new [] { typeof(string) })]
        string RuleName { get; set; }

    }
    /// Results of IP flow verification on the target resource.
    internal partial interface IVerificationIPFlowResultInternal

    {
        /// <summary>Indicates whether the traffic is allowed or denied.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.Access? Access { get; set; }
        /// <summary>
        /// Name of the rule. If input is not matched against any security rule, it is not displayed.
        /// </summary>
        string RuleName { get; set; }

    }
}