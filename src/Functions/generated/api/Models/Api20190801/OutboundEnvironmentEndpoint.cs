namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Endpoints accessed for a common purpose that the App Service Environment requires outbound network access to.
    /// </summary>
    public partial class OutboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpoint,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IOutboundEnvironmentEndpointInternal
    {

        /// <summary>Backing field for <see cref="Category" /> property.</summary>
        private string _category;

        /// <summary>
        /// The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active
        /// Directory.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Category { get => this._category; set => this._category = value; }

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency[] _endpoint;

        /// <summary>The endpoints that the App Service Environment reaches the service at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency[] Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Creates an new <see cref="OutboundEnvironmentEndpoint" /> instance.</summary>
        public OutboundEnvironmentEndpoint()
        {

        }
    }
    /// Endpoints accessed for a common purpose that the App Service Environment requires outbound network access to.
    public partial interface IOutboundEnvironmentEndpoint :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active
        /// Directory.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of service accessed by the App Service Environment, e.g., Azure Storage, Azure SQL Database, and Azure Active Directory.",
        SerializedName = @"category",
        PossibleTypes = new [] { typeof(string) })]
        string Category { get; set; }
        /// <summary>The endpoints that the App Service Environment reaches the service at.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The endpoints that the App Service Environment reaches the service at.",
        SerializedName = @"endpoints",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency[] Endpoint { get; set; }

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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IEndpointDependency[] Endpoint { get; set; }

    }
}