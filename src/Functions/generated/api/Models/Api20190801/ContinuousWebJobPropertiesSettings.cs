namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Job settings.</summary>
    public partial class ContinuousWebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContinuousWebJobPropertiesSettingsInternal
    {

        /// <summary>Creates an new <see cref="ContinuousWebJobPropertiesSettings" /> instance.</summary>
        public ContinuousWebJobPropertiesSettings()
        {

        }
    }
    /// Job settings.
    public partial interface IContinuousWebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Job settings.
    internal partial interface IContinuousWebJobPropertiesSettingsInternal

    {

    }
}