namespace Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Extensions;

    /// <summary>Specifies the return carrier and customer's account with the carrier.</summary>
    public partial class ReturnShipping :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShipping,
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IReturnShippingInternal
    {

        /// <summary>Backing field for <see cref="CarrierAccountNumber" /> property.</summary>
        private string _carrierAccountNumber;

        /// <summary>The customer's account number with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string CarrierAccountNumber { get => this._carrierAccountNumber; set => this._carrierAccountNumber = value; }

        /// <summary>Backing field for <see cref="CarrierName" /> property.</summary>
        private string _carrierName;

        /// <summary>The carrier's name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImportExport.PropertyOrigin.Owned)]
        public string CarrierName { get => this._carrierName; set => this._carrierName = value; }

        /// <summary>Creates an new <see cref="ReturnShipping" /> instance.</summary>
        public ReturnShipping()
        {

        }
    }
    /// Specifies the return carrier and customer's account with the carrier.
    public partial interface IReturnShipping :
        Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.IJsonSerializable
    {
        /// <summary>The customer's account number with the carrier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The customer's account number with the carrier.",
        SerializedName = @"carrierAccountNumber",
        PossibleTypes = new [] { typeof(string) })]
        string CarrierAccountNumber { get; set; }
        /// <summary>The carrier's name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The carrier's name.",
        SerializedName = @"carrierName",
        PossibleTypes = new [] { typeof(string) })]
        string CarrierName { get; set; }

    }
    /// Specifies the return carrier and customer's account with the carrier.
    internal partial interface IReturnShippingInternal

    {
        /// <summary>The customer's account number with the carrier.</summary>
        string CarrierAccountNumber { get; set; }
        /// <summary>The carrier's name.</summary>
        string CarrierName { get; set; }

    }
}