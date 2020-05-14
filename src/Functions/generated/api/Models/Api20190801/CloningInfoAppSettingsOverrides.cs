namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
    /// from source app. Otherwise, application settings from source app are retained.
    /// </summary>
    public partial class CloningInfoAppSettingsOverrides :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverridesInternal
    {

        /// <summary>Creates an new <see cref="CloningInfoAppSettingsOverrides" /> instance.</summary>
        public CloningInfoAppSettingsOverrides()
        {

        }
    }
    /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
    /// from source app. Otherwise, application settings from source app are retained.
    public partial interface ICloningInfoAppSettingsOverrides :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IAssociativeArray<string>
    {

    }
    /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
    /// from source app. Otherwise, application settings from source app are retained.
    internal partial interface ICloningInfoAppSettingsOverridesInternal

    {

    }
}