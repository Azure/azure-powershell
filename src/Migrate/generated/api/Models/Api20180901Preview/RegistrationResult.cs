namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the registration status of a tool with the migrate project.</summary>
    public partial class RegistrationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRegistrationResult,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRegistrationResultInternal
    {

        /// <summary>Backing field for <see cref="IsRegistered" /> property.</summary>
        private bool? _isRegistered;

        /// <summary>Gets or sets a value indicating whether the tool is registered or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? IsRegistered { get => this._isRegistered; set => this._isRegistered = value; }

        /// <summary>Creates an new <see cref="RegistrationResult" /> instance.</summary>
        public RegistrationResult()
        {

        }
    }
    /// Class representing the registration status of a tool with the migrate project.
    public partial interface IRegistrationResult :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets a value indicating whether the tool is registered or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether the tool is registered or not.",
        SerializedName = @"isRegistered",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsRegistered { get; set; }

    }
    /// Class representing the registration status of a tool with the migrate project.
    internal partial interface IRegistrationResultInternal

    {
        /// <summary>Gets or sets a value indicating whether the tool is registered or not.</summary>
        bool? IsRegistered { get; set; }

    }
}