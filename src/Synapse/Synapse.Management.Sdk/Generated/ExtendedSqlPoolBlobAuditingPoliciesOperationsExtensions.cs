// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.Management.Synapse
{
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for ExtendedSqlPoolBlobAuditingPoliciesOperations
    /// </summary>
    public static partial class ExtendedSqlPoolBlobAuditingPoliciesOperationsExtensions
    {
        /// <summary>
        /// Gets an extended Sql pool&#39;s blob auditing policy.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        public static ExtendedSqlPoolBlobAuditingPolicy Get(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName)
        {
                return ((IExtendedSqlPoolBlobAuditingPoliciesOperations)operations).GetAsync(resourceGroupName, workspaceName, sqlPoolName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets an extended Sql pool&#39;s blob auditing policy.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<ExtendedSqlPoolBlobAuditingPolicy> GetAsync(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, workspaceName, sqlPoolName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Creates or updates an extended Sql pool&#39;s blob auditing policy.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        public static ExtendedSqlPoolBlobAuditingPolicy CreateOrUpdate(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName, ExtendedSqlPoolBlobAuditingPolicy parameters)
        {
                return ((IExtendedSqlPoolBlobAuditingPoliciesOperations)operations).CreateOrUpdateAsync(resourceGroupName, workspaceName, sqlPoolName, parameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates or updates an extended Sql pool&#39;s blob auditing policy.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<ExtendedSqlPoolBlobAuditingPolicy> CreateOrUpdateAsync(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName, ExtendedSqlPoolBlobAuditingPolicy parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, workspaceName, sqlPoolName, parameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Lists extended auditing settings of a Sql pool.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        public static Microsoft.Rest.Azure.IPage<ExtendedSqlPoolBlobAuditingPolicy> ListBySqlPool(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName)
        {
                return ((IExtendedSqlPoolBlobAuditingPoliciesOperations)operations).ListBySqlPoolAsync(resourceGroupName, workspaceName, sqlPoolName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists extended auditing settings of a Sql pool.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name='workspaceName'>
        /// The name of the workspace.
        /// </param>
        /// <param name='sqlPoolName'>
        /// SQL pool name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<ExtendedSqlPoolBlobAuditingPolicy>> ListBySqlPoolAsync(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string resourceGroupName, string workspaceName, string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListBySqlPoolWithHttpMessagesAsync(resourceGroupName, workspaceName, sqlPoolName, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
        /// <summary>
        /// Lists extended auditing settings of a Sql pool.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='nextPageLink'>
        /// The NextLink from the previous successful call to List operation.
        /// </param>
        public static Microsoft.Rest.Azure.IPage<ExtendedSqlPoolBlobAuditingPolicy> ListBySqlPoolNext(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string nextPageLink)
        {
                return ((IExtendedSqlPoolBlobAuditingPoliciesOperations)operations).ListBySqlPoolNextAsync(nextPageLink).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Lists extended auditing settings of a Sql pool.
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
        public static async System.Threading.Tasks.Task<Microsoft.Rest.Azure.IPage<ExtendedSqlPoolBlobAuditingPolicy>> ListBySqlPoolNextAsync(this IExtendedSqlPoolBlobAuditingPoliciesOperations operations, string nextPageLink, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            using (var _result = await operations.ListBySqlPoolNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
