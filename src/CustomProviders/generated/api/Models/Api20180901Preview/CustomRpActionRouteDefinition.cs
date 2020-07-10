namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>The route definition for an action implemented by the custom resource provider.</summary>
    public partial class CustomRpActionRouteDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpActionRouteDefinitionInternal,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinition"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinition __customRpRouteDefinition = new Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.CustomRpRouteDefinition();

        /// <summary>
        /// The route definition endpoint URI that the custom resource provider will proxy requests to. This can be in the form of
        /// a flat URI (e.g. 'https://testendpoint/') or can specify to route via a path (e.g. 'https://testendpoint/{requestPath}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Endpoint { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal)__customRpRouteDefinition).Endpoint; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal)__customRpRouteDefinition).Endpoint = value; }

        /// <summary>
        /// The name of the route definition. This becomes the name for the ARM extension (e.g. '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CustomProviders/resourceProviders/{resourceProviderName}/{name}')
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal)__customRpRouteDefinition).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal)__customRpRouteDefinition).Name = value; }

        /// <summary>Backing field for <see cref="RoutingType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ActionRouting? _routingType;

        /// <summary>The routing types that are supported for action requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ActionRouting? RoutingType { get => this._routingType; set => this._routingType = value; }

        /// <summary>Creates an new <see cref="CustomRpActionRouteDefinition" /> instance.</summary>
        public CustomRpActionRouteDefinition()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__customRpRouteDefinition), __customRpRouteDefinition);
            await eventListener.AssertObjectIsValid(nameof(__customRpRouteDefinition), __customRpRouteDefinition);
        }
    }
    /// The route definition for an action implemented by the custom resource provider.
    public partial interface ICustomRpActionRouteDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinition
    {
        /// <summary>The routing types that are supported for action requests.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The routing types that are supported for action requests.",
        SerializedName = @"routingType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ActionRouting) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ActionRouting? RoutingType { get; set; }

    }
    /// The route definition for an action implemented by the custom resource provider.
    internal partial interface ICustomRpActionRouteDefinitionInternal :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ICustomRpRouteDefinitionInternal
    {
        /// <summary>The routing types that are supported for action requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Support.ActionRouting? RoutingType { get; set; }

    }
}