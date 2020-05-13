namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.</summary>
    public partial class MSDeployCoreSetParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployCoreSetParametersInternal
    {

        /// <summary>Creates an new <see cref="MSDeployCoreSetParameters" /> instance.</summary>
        public MSDeployCoreSetParameters()
        {

        }
    }
    /// MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.
    public partial interface IMSDeployCoreSetParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used.
    internal partial interface IMSDeployCoreSetParametersInternal

    {

    }
}