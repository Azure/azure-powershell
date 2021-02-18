namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Job settings.</summary>
    public partial class WebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebJobPropertiesSettingsInternal
    {

        /// <summary>Creates an new <see cref="WebJobPropertiesSettings" /> instance.</summary>
        public WebJobPropertiesSettings()
        {

        }
    }
    /// Job settings.
    public partial interface IWebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Job settings.
    internal partial interface IWebJobPropertiesSettingsInternal

    {

    }
}