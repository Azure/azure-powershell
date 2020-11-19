namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class OperatingSystemConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperatingSystemConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Bitness" /> property.</summary>
        private string _bitness;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Bitness { get => this._bitness; set => this._bitness = value; }

        /// <summary>Backing field for <see cref="Family" /> property.</summary>
        private string _family;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Family { get => this._family; set => this._family = value; }

        /// <summary>Backing field for <see cref="FullName" /> property.</summary>
        private string _fullName;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FullName { get => this._fullName; set => this._fullName = value; }

        /// <summary>Creates an new <see cref="OperatingSystemConfiguration" /> instance.</summary>
        public OperatingSystemConfiguration()
        {

        }
    }
    public partial interface IOperatingSystemConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"bitness",
        PossibleTypes = new [] { typeof(string) })]
        string Bitness { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string Family { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"fullName",
        PossibleTypes = new [] { typeof(string) })]
        string FullName { get; set; }

    }
    internal partial interface IOperatingSystemConfigurationInternal

    {
        string Bitness { get; set; }

        string Family { get; set; }

        string FullName { get; set; }

    }
}