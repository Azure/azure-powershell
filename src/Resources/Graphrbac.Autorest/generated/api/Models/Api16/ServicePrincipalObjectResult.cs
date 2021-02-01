namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Service Principal Object Result.</summary>
    public partial class ServicePrincipalObjectResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalObjectResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalObjectResultInternal
    {

        /// <summary>Backing field for <see cref="OdataMetadata" /> property.</summary>
        private string _odataMetadata;

        /// <summary>The URL representing edm equivalent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataMetadata { get => this._odataMetadata; set => this._odataMetadata = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>The Object ID of the service principal with the specified application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ServicePrincipalObjectResult" /> instance.</summary>
        public ServicePrincipalObjectResult()
        {

        }
    }
    /// Service Principal Object Result.
    public partial interface IServicePrincipalObjectResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The URL representing edm equivalent.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL representing edm equivalent.",
        SerializedName = @"odata.metadata",
        PossibleTypes = new [] { typeof(string) })]
        string OdataMetadata { get; set; }
        /// <summary>The Object ID of the service principal with the specified application ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Object ID of the service principal with the specified application ID.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    /// Service Principal Object Result.
    internal partial interface IServicePrincipalObjectResultInternal

    {
        /// <summary>The URL representing edm equivalent.</summary>
        string OdataMetadata { get; set; }
        /// <summary>The Object ID of the service principal with the specified application ID.</summary>
        string Value { get; set; }

    }
}