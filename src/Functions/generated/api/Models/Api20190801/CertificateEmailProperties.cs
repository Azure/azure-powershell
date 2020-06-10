namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>CertificateEmail resource specific properties</summary>
    public partial class CertificateEmailProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateEmailProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateEmailPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EmailId" /> property.</summary>
        private string _emailId;

        /// <summary>Email id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string EmailId { get => this._emailId; set => this._emailId = value; }

        /// <summary>Backing field for <see cref="TimeStamp" /> property.</summary>
        private global::System.DateTime? _timeStamp;

        /// <summary>Time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? TimeStamp { get => this._timeStamp; set => this._timeStamp = value; }

        /// <summary>Creates an new <see cref="CertificateEmailProperties" /> instance.</summary>
        public CertificateEmailProperties()
        {

        }
    }
    /// CertificateEmail resource specific properties
    public partial interface ICertificateEmailProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Email id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Email id.",
        SerializedName = @"emailId",
        PossibleTypes = new [] { typeof(string) })]
        string EmailId { get; set; }
        /// <summary>Time stamp.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time stamp.",
        SerializedName = @"timeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? TimeStamp { get; set; }

    }
    /// CertificateEmail resource specific properties
    internal partial interface ICertificateEmailPropertiesInternal

    {
        /// <summary>Email id.</summary>
        string EmailId { get; set; }
        /// <summary>Time stamp.</summary>
        global::System.DateTime? TimeStamp { get; set; }

    }
}