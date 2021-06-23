namespace Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Extensions;

    /// <summary>
    /// Endpoints accessed for a common purpose that the App Service Environment requires outbound network access to.
    /// </summary>
    public partial class OutboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IOutboundEnvironmentEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IOutboundEnvironmentEndpointInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>
        /// The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active
        /// Directory.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 0)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IEndpointDependency[] _endpoint;

        /// <summary>The endpoints that the App Service Environment reaches the service at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Origin(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.FormatTable(Index = 1)]
        public Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IEndpointDependency[] Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Creates an new <see cref="OutboundEnvironmentEndpoint" /> instance.</summary>
        public OutboundEnvironmentEndpoint()
        {

        }
    }
    /// Endpoints accessed for a common purpose that the App Service Environment requires outbound network access to.
    public partial interface IOutboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active
        /// Directory.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active Directory.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>The endpoints that the App Service Environment reaches the service at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The endpoints that the App Service Environment reaches the service at.",
        SerializedName = @"endpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IEndpointDependency) })]
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IEndpointDependency[] Endpoint { get; set; }

    }
    /// Endpoints accessed for a common purpose that the App Service Environment requires outbound network access to.
    internal partial interface IOutboundEnvironmentEndpointInternal

    {
        /// <summary>
        /// The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active
        /// Directory.
        /// </summary>
        string Category { get; set; }
        /// <summary>The endpoints that the App Service Environment reaches the service at.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IEndpointDependency[] Endpoint { get; set; }

    }
}