namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class DatadogSetPasswordLink :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSetPasswordLink,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IDatadogSetPasswordLinkInternal
    {

        /// <summary>Backing field for <see cref="SetPasswordLink" /> property.</summary>
        private string _setPasswordLink;

        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string SetPasswordLink { get => this._setPasswordLink; set => this._setPasswordLink = value; }

        /// <summary>Creates an new <see cref="DatadogSetPasswordLink" /> instance.</summary>
        public DatadogSetPasswordLink()
        {

        }
    }
    public partial interface IDatadogSetPasswordLink :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"setPasswordLink",
        PossibleTypes = new [] { typeof(string) })]
        string SetPasswordLink { get; set; }

    }
    internal partial interface IDatadogSetPasswordLinkInternal

    {
        string SetPasswordLink { get; set; }

    }
}