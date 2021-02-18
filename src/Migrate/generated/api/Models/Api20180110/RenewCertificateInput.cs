namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Certificate renewal input.</summary>
    public partial class RenewCertificateInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RenewCertificateInputProperties()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputProperties _property;

        /// <summary>Renew certificate input properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.RenewCertificateInputProperties()); set => this._property = value; }

        /// <summary>Renew certificate type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RenewCertificateType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputPropertiesInternal)Property).RenewCertificateType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputPropertiesInternal)Property).RenewCertificateType = value ?? null; }

        /// <summary>Creates an new <see cref="RenewCertificateInput" /> instance.</summary>
        public RenewCertificateInput()
        {

        }
    }
    /// Certificate renewal input.
    public partial interface IRenewCertificateInput :
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
    /// Certificate renewal input.
    internal partial interface IRenewCertificateInputInternal

    {
        /// <summary>Renew certificate input properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IRenewCertificateInputProperties Property { get; set; }
        /// <summary>Renew certificate type.</summary>
        string RenewCertificateType { get; set; }

    }
}