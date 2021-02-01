namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>
    /// Representation of an app PreAuthorizedApplicationExtension required by a pre authorized client app.
    /// </summary>
    public partial class PreAuthorizedApplicationExtension :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtension,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPreAuthorizedApplicationExtensionInternal
    {

        /// <summary>Backing field for <see cref="Condition" /> property.</summary>
        private string[] _condition;

        /// <summary>The extension's conditions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string[] Condition { get => this._condition; set => this._condition = value; }

        /// <summary>Creates an new <see cref="PreAuthorizedApplicationExtension" /> instance.</summary>
        public PreAuthorizedApplicationExtension()
        {

        }
    }
    /// Representation of an app PreAuthorizedApplicationExtension required by a pre authorized client app.
    public partial interface IPreAuthorizedApplicationExtension :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable
    {
        /// <summary>The extension's conditions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The extension's conditions.",
        SerializedName = @"conditions",
        PossibleTypes = new [] { typeof(string) })]
        string[] Condition { get; set; }

    }
    /// Representation of an app PreAuthorizedApplicationExtension required by a pre authorized client app.
    internal partial interface IPreAuthorizedApplicationExtensionInternal

    {
        /// <summary>The extension's conditions.</summary>
        string[] Condition { get; set; }

    }
}