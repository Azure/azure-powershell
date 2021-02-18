namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>File list.</summary>
    public partial class FunctionEnvelopePropertiesFiles :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFiles,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IFunctionEnvelopePropertiesFilesInternal
    {

        /// <summary>Creates an new <see cref="FunctionEnvelopePropertiesFiles" /> instance.</summary>
        public FunctionEnvelopePropertiesFiles()
        {

        }
    }
    /// File list.
    public partial interface IFunctionEnvelopePropertiesFiles :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// File list.
    internal partial interface IFunctionEnvelopePropertiesFilesInternal

    {

    }
}