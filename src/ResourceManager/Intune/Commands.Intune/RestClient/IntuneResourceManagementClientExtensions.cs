// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Commands.Intune.RestClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    public static partial class IntuneResourceManagementClientExtensions
    {
            /// <summary>
            /// Returns location for user tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static LocationCollection GetLocations(this IIntuneResourceManagementClient operations)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetLocationsAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns location for user tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LocationCollection> GetLocationsAsync( this IIntuneResourceManagementClient operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<LocationCollection> result = await operations.GetLocationsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns location for given tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static Location GetLocationByHostName(this IIntuneResourceManagementClient operations)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetLocationByHostNameAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns location for given tenant.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Location> GetLocationByHostNameAsync( this IIntuneResourceManagementClient operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<Location> result = await operations.GetLocationByHostNameWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune Manageable apps.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static ApplicationCollection GetApplications(this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetApplicationsAsync(hostName, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune Manageable apps.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ApplicationCollection> GetApplicationsAsync( this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<ApplicationCollection> result = await operations.GetApplicationsWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune iosPolicies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static IOSPolicyCollection GetiOSPolicies(this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSPoliciesAsync(hostName, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune iosPolicies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IOSPolicyCollection> GetiOSPoliciesAsync( this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicyCollection> result = await operations.GetiOSPoliciesWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune android Policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static AndroidPolicyCollection GetAndroidPolicies(this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAndroidPoliciesAsync(hostName, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune android Policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<AndroidPolicyCollection> GetAndroidPoliciesAsync( this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<AndroidPolicyCollection> result = await operations.GetAndroidPoliciesWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Deletes Intune iOS MAM policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            public static void RemoveiOSPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).RemoveiOSPolicyByIdAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes Intune iOS MAM policies.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task RemoveiOSPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.RemoveiOSPolicyByIdWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns androidPolicy with given Id.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static AndroidPolicy GetAndroidPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAndroidPolicyByIdAsync(hostName, policyId, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns androidPolicy with given Id.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<AndroidPolicy> GetAndroidPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<AndroidPolicy> result = await operations.GetAndroidPolicyByIdWithHttpMessagesAsync(hostName, policyId, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Creates or updates androidPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update an android policy operation.
            /// </param>
            public static AndroidPolicy CreateOrUpdateAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicy parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).CreateOrUpdateAndroidPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates androidPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update an android policy operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<AndroidPolicy> CreateOrUpdateAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicy parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<AndroidPolicy> result = await operations.CreateOrUpdateAndroidPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Delete Android Policy
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            public static void DeleteAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAndroidPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete Android Policy
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAndroidPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
