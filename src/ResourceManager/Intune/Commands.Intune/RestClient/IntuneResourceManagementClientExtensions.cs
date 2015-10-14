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
            public static ApplicationCollection GetApplications(this IIntuneResourceManagementClient operations, string hostName)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetApplicationsAsync(hostName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ApplicationCollection> GetApplicationsAsync( this IIntuneResourceManagementClient operations, string hostName, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<ApplicationCollection> result = await operations.GetApplicationsWithHttpMessagesAsync(hostName, null, cancellationToken).ConfigureAwait(false);
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
            public static IOSPolicyCollection GetiOSPolicies(this IIntuneResourceManagementClient operations, string hostName)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSPoliciesAsync(hostName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IOSPolicyCollection> GetiOSPoliciesAsync( this IIntuneResourceManagementClient operations, string hostName, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicyCollection> result = await operations.GetiOSPoliciesWithHttpMessagesAsync(hostName, null, cancellationToken).ConfigureAwait(false);
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
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            public static IOSPolicy GetiOSPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSPolicyByIdAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            /// <param name='policyId'>
            /// policy unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IOSPolicy> GetiOSPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicy> result = await operations.GetiOSPolicyByIdWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

    }
}
