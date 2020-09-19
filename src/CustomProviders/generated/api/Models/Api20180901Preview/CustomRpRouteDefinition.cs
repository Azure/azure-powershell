namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>
    /// A route definition that defines an action or resource that can be interacted with through the custom resource provider.
    /// </summary>
    public partial class CustomRpRouteDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal
    {

        /// <summary>Backing field for <see cref="Endpoint" /> property.</summary>
        private string _endpoint;

        /// <summary>
        /// The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of
        /// a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Endpoint { get => this._endpoint; set => this._endpoint = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="CustomRpRouteDefinition" /> instance.</summary>
        public CustomRpRouteDefinition()
        {

        }
    }
    /// A route definition that defines an action or resource that can be interacted with through the custom resource provider.
    public partial interface ICustomRpRouteDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of
        /// a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')",
        SerializedName = @"endpoint",
        PossibleTypes = new [] { typeof(string) })]
        string Endpoint { get; set; }
        /// <summary>
        /// The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// A route definition that defines an action or resource that can be interacted with through the custom resource provider.
    internal partial interface ICustomRpRouteDefinitionInternal

    {
        /// <summary>
        /// The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of
        /// a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
        /// </summary>
        string Endpoint { get; set; }
        /// <summary>
        /// The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
        /// </summary>
        string Name { get; set; }

    }
}