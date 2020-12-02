namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class representing the register tool input.</summary>
    public partial class RegisterToolInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRegisterToolInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IRegisterToolInputInternal
    {

        /// <summary>Backing field for <see cref="Tool" /> property.</summary>
        private string _tool;

        /// <summary>Gets or sets the tool to be registered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Tool { get => this._tool; set => this._tool = value; }

        /// <summary>Creates an new <see cref="RegisterToolInput" /> instance.</summary>
        public RegisterToolInput()
        {

        }
    }
    /// Class representing the register tool input.
    public partial interface IRegisterToolInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the tool to be registered.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the tool to be registered.",
        SerializedName = @"tool",
        PossibleTypes = new [] { typeof(string) })]
        string Tool { get; set; }

    }
    /// Class representing the register tool input.
    internal partial interface IRegisterToolInputInternal

    {
        /// <summary>Gets or sets the tool to be registered.</summary>
        string Tool { get; set; }

    }
}