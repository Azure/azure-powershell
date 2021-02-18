namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Settings.</summary>
    public partial class StringDictionaryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionaryProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStringDictionaryPropertiesInternal
    {

        /// <summary>Creates an new <see cref="StringDictionaryProperties" /> instance.</summary>
        public StringDictionaryProperties()
        {

        }
    }
    /// Settings.
    public partial interface IStringDictionaryProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Settings.
    internal partial interface IStringDictionaryPropertiesInternal

    {

    }
}