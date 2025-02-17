// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.Sql
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for DistributedAvailabilityGroupsOperations
    /// </summary>
    public static partial class DistributedAvailabilityGroupsOperationsExtensions
    {
        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<DistributedAvailabilityGroup> ListByInstance(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).ListByInstanceAsync(resourceGroupName, managedInstanceName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<DistributedAvailabilityGroup>> ListByInstanceAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListByInstanceWithHttpMessagesAsync(resourceGroupName, managedInstanceName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Gets a distributed availability group info.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup Get(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).GetAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a distributed availability group info.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> GetAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Creates a distributed availability group between Sql On-Prem and Sql
        /// Managed Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup CreateOrUpdate(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).CreateOrUpdateAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a distributed availability group between Sql On-Prem and Sql
        /// Managed Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> CreateOrUpdateAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Drops a distributed availability group between Sql On-Prem and Sql Managed
        /// Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static void Delete(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName)
        {
                ((IDistributedAvailabilityGroupsOperations)operations).DeleteAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Drops a distributed availability group between Sql On-Prem and Sql Managed
        /// Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task DeleteAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.DeleteWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Updates a distributed availability group replication mode.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup Update(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).UpdateAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Updates a distributed availability group replication mode.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> UpdateAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Performs requested failover type in this distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup Failover(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupsFailoverRequest parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).FailoverAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs requested failover type in this distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> FailoverAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupsFailoverRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.FailoverWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Sets the role for managed instance in a distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup SetRole(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupSetRole parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).SetRoleAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sets the role for managed instance in a distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> SetRoleAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupSetRole parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.SetRoleWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Creates a distributed availability group between Sql On-Prem and Sql
        /// Managed Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup BeginCreateOrUpdate(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).BeginCreateOrUpdateAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a distributed availability group between Sql On-Prem and Sql
        /// Managed Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> BeginCreateOrUpdateAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Drops a distributed availability group between Sql On-Prem and Sql Managed
        /// Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static void BeginDelete(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName)
        {
                ((IDistributedAvailabilityGroupsOperations)operations).BeginDeleteAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Drops a distributed availability group between Sql On-Prem and Sql Managed
        /// Instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task BeginDeleteAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            (await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }
        /// <summary>
        /// Updates a distributed availability group replication mode.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup BeginUpdate(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).BeginUpdateAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Updates a distributed availability group replication mode.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> BeginUpdateAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroup parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.BeginUpdateWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Performs requested failover type in this distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup BeginFailover(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupsFailoverRequest parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).BeginFailoverAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs requested failover type in this distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> BeginFailoverAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupsFailoverRequest parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.BeginFailoverWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Sets the role for managed instance in a distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        public static DistributedAvailabilityGroup BeginSetRole(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupSetRole parameters)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).BeginSetRoleAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sets the role for managed instance in a distributed availability group.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group that contains the resource. You can obtain
        /// this value from the Azure Resource Manager API or the portal.
        /// </param>
        /// <param name='managedInstanceName'>
        /// The name of the managed instance.
        /// </param>
        /// <param name='distributedAvailabilityGroupName'>
        /// The distributed availability group name.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<DistributedAvailabilityGroup> BeginSetRoleAsync(this IDistributedAvailabilityGroupsOperations operations, string resourceGroupName, string managedInstanceName, string distributedAvailabilityGroupName, DistributedAvailabilityGroupSetRole parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.BeginSetRoleWithHttpMessagesAsync(resourceGroupName, managedInstanceName, distributedAvailabilityGroupName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<DistributedAvailabilityGroup> ListByInstanceNext(this IDistributedAvailabilityGroupsOperations operations, string nextPageLink)
        {
                return ((IDistributedAvailabilityGroupsOperations)operations).ListByInstanceNextAsync(nextPageLink).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
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
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<DistributedAvailabilityGroup>> ListByInstanceNextAsync(this IDistributedAvailabilityGroupsOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListByInstanceNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
