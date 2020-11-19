namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>The properties of an update mobility service request.</summary>
    public partial class UpdateMobilityServiceRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMobilityServiceRequestProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateMobilityServiceRequestPropertiesInternal
    {

        /// <summary>Backing field for <see cref="RunAsAccountId" /> property.</summary>
        private string _runAsAccountId;

        /// <summary>The CS run as account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RunAsAccountId { get => this._runAsAccountId; set => this._runAsAccountId = value; }

        /// <summary>Creates an new <see cref="UpdateMobilityServiceRequestProperties" /> instance.</summary>
        public UpdateMobilityServiceRequestProperties()
        {

        }
    }
    /// The properties of an update mobility service request.
    public partial interface IUpdateMobilityServiceRequestProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The CS run as account Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CS run as account Id.",
        SerializedName = @"runAsAccountId",
        PossibleTypes = new [] { typeof(string) })]
        string RunAsAccountId { get; set; }

    }
    /// The properties of an update mobility service request.
    internal partial interface IUpdateMobilityServiceRequestPropertiesInternal

    {
        /// <summary>The CS run as account Id.</summary>
        string RunAsAccountId { get; set; }

    }
}