namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class HostingConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHostingConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IHostingConfigurationInternal
    {

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Creates an new <see cref="HostingConfiguration" /> instance.</summary>
        public HostingConfiguration()
        {

        }
    }
    public partial interface IHostingConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }

    }
    internal partial interface IHostingConfigurationInternal

    {
        string Provider { get; set; }

    }
}