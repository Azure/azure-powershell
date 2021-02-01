namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Server response for get tenant service principals API call.</summary>
    public partial class ServicePrincipalListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipalListResultInternal
    {

        /// <summary>Backing field for <see cref="OdataNextLink" /> property.</summary>
        private string _odataNextLink;

        /// <summary>the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string OdataNextLink { get => this._odataNextLink; set => this._odataNextLink = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal[] _value;

        /// <summary>the list of service principals.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ServicePrincipalListResult" /> instance.</summary>
        public ServicePrincipalListResult()
        {

        }
    }
    /// Server response for get tenant service principals API call.
    public partial interface IServicePrincipalListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>the URL to get the next set of results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the URL to get the next set of results.",
        SerializedName = @"odata.nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string OdataNextLink { get; set; }
        /// <summary>the list of service principals.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"the list of service principals.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal) })]
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal[] Value { get; set; }

    }
    /// Server response for get tenant service principals API call.
    internal partial interface IServicePrincipalListResultInternal

    {
        /// <summary>the URL to get the next set of results.</summary>
        string OdataNextLink { get; set; }
        /// <summary>the list of service principals.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal[] Value { get; set; }

    }
}