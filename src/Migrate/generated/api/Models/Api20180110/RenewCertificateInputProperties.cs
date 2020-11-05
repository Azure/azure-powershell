namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Renew Certificate input properties.</summary>
    public partial class RenewCertificateInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="RenewCertificateType" /> property.</summary>
        private string _renewCertificateType;

        /// <summary>Renew certificate type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string RenewCertificateType { get => this._renewCertificateType; set => this._renewCertificateType = value; }

        /// <summary>Creates an new <see cref="RenewCertificateInputProperties" /> instance.</summary>
        public RenewCertificateInputProperties()
        {

        }
    }
    /// Renew Certificate input properties.
    public partial interface IRenewCertificateInputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Renew certificate type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Renew certificate type.",
        SerializedName = @"renewCertificateType",
        PossibleTypes = new [] { typeof(string) })]
        string RenewCertificateType { get; set; }

    }
    /// Renew Certificate input properties.
    internal partial interface IRenewCertificateInputPropertiesInternal

    {
        /// <summary>Renew certificate type.</summary>
        string RenewCertificateType { get; set; }

    }
}