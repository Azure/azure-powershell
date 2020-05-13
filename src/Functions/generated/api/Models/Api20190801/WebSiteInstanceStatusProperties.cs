namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>WebSiteInstanceStatus resource specific properties</summary>
    public partial class WebSiteInstanceStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ConsoleUrl" /> property.</summary>
        private string _consoleUrl;

        /// <summary>Link to the Diagnose and Solve Portal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ConsoleUrl { get => this._consoleUrl; set => this._consoleUrl = value; }

        /// <summary>Backing field for <see cref="Container" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers _container;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers Container { get => (this._container = this._container ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.WebSiteInstanceStatusPropertiesContainers()); set => this._container = value; }

        /// <summary>Backing field for <see cref="DetectorUrl" /> property.</summary>
        private string _detectorUrl;

        /// <summary>Link to the Diagnose and Solve Portal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DetectorUrl { get => this._detectorUrl; set => this._detectorUrl = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteRuntimeState? _state;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteRuntimeState? State { get => this._state; set => this._state = value; }

        /// <summary>Backing field for <see cref="StatusUrl" /> property.</summary>
        private string _statusUrl;

        /// <summary>Link to the GetStatusApi in Kudu</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string StatusUrl { get => this._statusUrl; set => this._statusUrl = value; }

        /// <summary>Creates an new <see cref="WebSiteInstanceStatusProperties" /> instance.</summary>
        public WebSiteInstanceStatusProperties()
        {

        }
    }
    /// WebSiteInstanceStatus resource specific properties
    public partial interface IWebSiteInstanceStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Link to the Diagnose and Solve Portal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the Diagnose and Solve Portal",
        SerializedName = @"consoleUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ConsoleUrl { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"containers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers Container { get; set; }
        /// <summary>Link to the Diagnose and Solve Portal</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the Diagnose and Solve Portal",
        SerializedName = @"detectorUrl",
        PossibleTypes = new [] { typeof(string) })]
        string DetectorUrl { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteRuntimeState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteRuntimeState? State { get; set; }
        /// <summary>Link to the GetStatusApi in Kudu</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Link to the GetStatusApi in Kudu",
        SerializedName = @"statusUrl",
        PossibleTypes = new [] { typeof(string) })]
        string StatusUrl { get; set; }

    }
    /// WebSiteInstanceStatus resource specific properties
    internal partial interface IWebSiteInstanceStatusPropertiesInternal

    {
        /// <summary>Link to the Diagnose and Solve Portal</summary>
        string ConsoleUrl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IWebSiteInstanceStatusPropertiesContainers Container { get; set; }
        /// <summary>Link to the Diagnose and Solve Portal</summary>
        string DetectorUrl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteRuntimeState? State { get; set; }
        /// <summary>Link to the GetStatusApi in Kudu</summary>
        string StatusUrl { get; set; }

    }
}