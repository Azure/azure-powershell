namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>RelayServiceConnectionEntity resource specific properties</summary>
    public partial class RelayServiceConnectionEntityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntityProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRelayServiceConnectionEntityPropertiesInternal
    {

        /// <summary>Backing field for <see cref="BiztalkUri" /> property.</summary>
        private string _biztalkUri;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BiztalkUri { get => this._biztalkUri; set => this._biztalkUri = value; }

        /// <summary>Backing field for <see cref="EntityConnectionString" /> property.</summary>
        private string _entityConnectionString;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string EntityConnectionString { get => this._entityConnectionString; set => this._entityConnectionString = value; }

        /// <summary>Backing field for <see cref="EntityName" /> property.</summary>
        private string _entityName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string EntityName { get => this._entityName; set => this._entityName = value; }

        /// <summary>Backing field for <see cref="Hostname" /> property.</summary>
        private string _hostname;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Hostname { get => this._hostname; set => this._hostname = value; }

        /// <summary>Backing field for <see cref="Port" /> property.</summary>
        private int? _port;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Port { get => this._port; set => this._port = value; }

        /// <summary>Backing field for <see cref="ResourceConnectionString" /> property.</summary>
        private string _resourceConnectionString;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceConnectionString { get => this._resourceConnectionString; set => this._resourceConnectionString = value; }

        /// <summary>Backing field for <see cref="ResourceType" /> property.</summary>
        private string _resourceType;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceType { get => this._resourceType; set => this._resourceType = value; }

        /// <summary>Creates an new <see cref="RelayServiceConnectionEntityProperties" /> instance.</summary>
        public RelayServiceConnectionEntityProperties()
        {

        }
    }
    /// RelayServiceConnectionEntity resource specific properties
    public partial interface IRelayServiceConnectionEntityProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"biztalkUri",
        PossibleTypes = new [] { typeof(string) })]
        string BiztalkUri { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"entityConnectionString",
        PossibleTypes = new [] { typeof(string) })]
        string EntityConnectionString { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"entityName",
        PossibleTypes = new [] { typeof(string) })]
        string EntityName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"hostname",
        PossibleTypes = new [] { typeof(string) })]
        string Hostname { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"port",
        PossibleTypes = new [] { typeof(int) })]
        int? Port { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceConnectionString",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceConnectionString { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"resourceType",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceType { get; set; }

    }
    /// RelayServiceConnectionEntity resource specific properties
    internal partial interface IRelayServiceConnectionEntityPropertiesInternal

    {
        string BiztalkUri { get; set; }

        string EntityConnectionString { get; set; }

        string EntityName { get; set; }

        string Hostname { get; set; }

        int? Port { get; set; }

        string ResourceConnectionString { get; set; }

        string ResourceType { get; set; }

    }
}