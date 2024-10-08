// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.Network
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for VirtualRouterPeeringsOperations
    /// </summary>
    public static partial class VirtualRouterPeeringsOperationsExtensions
    {
        /// <summary>
        /// Deletes the specified peering from a Virtual Router.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the peering.
        /// </param>
        public static void Delete(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName)
        {
                ((IVirtualRouterPeeringsOperations)operations).DeleteAsync(resourceGroupName, virtualRouterName, peeringName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes the specified peering from a Virtual Router.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the peering.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task DeleteAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, virtualRouterName, peeringName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Gets the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        public static VirtualRouterPeering Get(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName)
        {
                return ((IVirtualRouterPeeringsOperations)operations).GetAsync(resourceGroupName, virtualRouterName, peeringName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<VirtualRouterPeering> GetAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, virtualRouterName, peeringName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Creates or updates the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        public static VirtualRouterPeering CreateOrUpdate(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, VirtualRouterPeering parameters)
        {
                return ((IVirtualRouterPeeringsOperations)operations).CreateOrUpdateAsync(resourceGroupName, virtualRouterName, peeringName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates or updates the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<VirtualRouterPeering> CreateOrUpdateAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, VirtualRouterPeering parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, virtualRouterName, peeringName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Lists all Virtual Router Peerings in a Virtual Router resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<VirtualRouterPeering> List(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName)
        {
                return ((IVirtualRouterPeeringsOperations)operations).ListAsync(resourceGroupName, virtualRouterName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists all Virtual Router Peerings in a Virtual Router resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<VirtualRouterPeering>> ListAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, virtualRouterName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Deletes the specified peering from a Virtual Router.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the peering.
        /// </param>
        public static void BeginDelete(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName)
        {
                ((IVirtualRouterPeeringsOperations)operations).BeginDeleteAsync(resourceGroupName, virtualRouterName, peeringName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes the specified peering from a Virtual Router.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the peering.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task BeginDeleteAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, virtualRouterName, peeringName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Creates or updates the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        public static VirtualRouterPeering BeginCreateOrUpdate(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, VirtualRouterPeering parameters)
        {
                return ((IVirtualRouterPeeringsOperations)operations).BeginCreateOrUpdateAsync(resourceGroupName, virtualRouterName, peeringName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates or updates the specified Virtual Router Peering.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='virtualRouterName'>
        /// The name of the Virtual Router.
        /// </param>
        /// <param name='peeringName'>
        /// The name of the Virtual Router Peering.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<VirtualRouterPeering> BeginCreateOrUpdateAsync(this IVirtualRouterPeeringsOperations operations, string resourceGroupName, string virtualRouterName, string peeringName, VirtualRouterPeering parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, virtualRouterName, peeringName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Lists all Virtual Router Peerings in a Virtual Router resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<VirtualRouterPeering> ListNext(this IVirtualRouterPeeringsOperations operations, string nextPageLink)
        {
                return ((IVirtualRouterPeeringsOperations)operations).ListNextAsync(nextPageLink).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists all Virtual Router Peerings in a Virtual Router resource.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<VirtualRouterPeering>> ListNextAsync(this IVirtualRouterPeeringsOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
