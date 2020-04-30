namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>A list of server configurations.</summary>
    public partial class ConfigurationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationListResult,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfigurationListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration[] _value;

        /// <summary>The list of server configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Origin(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="ConfigurationListResult" /> instance.</summary>
        public ConfigurationListResult()
        {

        }
    }
    /// A list of server configurations.
    public partial interface IConfigurationListResult :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable
    {
        /// <summary>The list of server configurations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of server configurations.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration[] Value { get; set; }

    }
    /// A list of server configurations.
    internal partial interface IConfigurationListResultInternal

    {
        /// <summary>The list of server configurations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration[] Value { get; set; }

    }
}