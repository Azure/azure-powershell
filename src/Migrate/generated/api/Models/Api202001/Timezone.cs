namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class Timezone :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ITimezone,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.ITimezoneInternal
    {

        /// <summary>Backing field for <see cref="FullName" /> property.</summary>
        private string _fullName;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FullName { get => this._fullName; set => this._fullName = value; }

        /// <summary>Creates an new <see cref="Timezone" /> instance.</summary>
        public Timezone()
        {

        }
    }
    public partial interface ITimezone :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"fullName",
        PossibleTypes = new [] { typeof(string) })]
        string FullName { get; set; }

    }
    internal partial interface ITimezoneInternal

    {
        string FullName { get; set; }

    }
}