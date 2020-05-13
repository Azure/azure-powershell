namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Routing rules in production experiments.</summary>
    public partial class Experiments :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperimentsInternal
    {

        /// <summary>Backing field for <see cref="RampUpRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] _rampUpRule;

        /// <summary>List of ramp-up rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] RampUpRule { get => this._rampUpRule; set => this._rampUpRule = value; }

        /// <summary>Creates an new <see cref="Experiments" /> instance.</summary>
        public Experiments()
        {

        }
    }
    /// Routing rules in production experiments.
    public partial interface IExperiments :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>List of ramp-up rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of ramp-up rules.",
        SerializedName = @"rampUpRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] RampUpRule { get; set; }

    }
    /// Routing rules in production experiments.
    internal partial interface IExperimentsInternal

    {
        /// <summary>List of ramp-up rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] RampUpRule { get; set; }

    }
}