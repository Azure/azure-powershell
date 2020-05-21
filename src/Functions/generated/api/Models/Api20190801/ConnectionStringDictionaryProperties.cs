namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Connection strings.</summary>
    public partial class ConnectionStringDictionaryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnectionStringDictionaryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnectionStringDictionaryPropertiesInternal
    {

        /// <summary>Creates an new <see cref="ConnectionStringDictionaryProperties" /> instance.</summary>
        public ConnectionStringDictionaryProperties()
        {

        }
    }
    /// Connection strings.
    public partial interface IConnectionStringDictionaryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringValueTypePair>
    {

    }
    /// Connection strings.
    internal partial interface IConnectionStringDictionaryPropertiesInternal

    {

    }
}