namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Job settings.</summary>
    public partial class TriggeredWebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ITriggeredWebJobPropertiesSettingsInternal
    {

        /// <summary>Creates an new <see cref="TriggeredWebJobPropertiesSettings" /> instance.</summary>
        public TriggeredWebJobPropertiesSettings()
        {

        }
    }
    /// Job settings.
    public partial interface ITriggeredWebJobPropertiesSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Job settings.
    internal partial interface ITriggeredWebJobPropertiesSettingsInternal

    {

    }
}