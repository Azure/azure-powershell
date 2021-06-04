namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Parameters in Policy</summary>
    public partial class PolicyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParameters,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IPolicyParametersInternal
    {

        /// <summary>Backing field for <see cref="DataStoreParametersList" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreParameters[] _dataStoreParametersList;

        /// <summary>Gets or sets the DataStore Parameters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreParameters[] DataStoreParametersList { get => this._dataStoreParametersList; set => this._dataStoreParametersList = value; }

        /// <summary>Creates an new <see cref="PolicyParameters" /> instance.</summary>
        public PolicyParameters()
        {

        }
    }
    /// Parameters in Policy
    public partial interface IPolicyParameters :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the DataStore Parameters</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the DataStore Parameters",
        SerializedName = @"dataStoreParametersList",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreParameters[] DataStoreParametersList { get; set; }

    }
    /// Parameters in Policy
    internal partial interface IPolicyParametersInternal

    {
        /// <summary>Gets or sets the DataStore Parameters</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDataStoreParameters[] DataStoreParametersList { get; set; }

    }
}