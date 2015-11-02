// Copyright (c) Microsoft Corporation. All rights reserved.

namespace Microsoft.Azure.Commands.Intune.RestClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
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
                AzureOperationResponse<LocationCollection> result = await operations.GetLocationsWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
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
                AzureOperationResponse<Location> result = await operations.GetLocationByHostNameWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
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
                AzureOperationResponse<ApplicationCollection> result = await operations.GetApplicationsWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune iOSPolicies.
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
            public static IOSMAMPolicyCollection GetiOSMAMPolicies(this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSMAMPoliciesAsync(hostName, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune iOSPolicies.
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
            public static async Task<IOSMAMPolicyCollection> GetiOSMAMPoliciesAsync( this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IOSMAMPolicyCollection> result = await operations.GetiOSMAMPoliciesWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune Android policies.
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
            public static AndroidMAMPolicyCollection GetAndroidMAMPolicies(this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAndroidMAMPoliciesAsync(hostName, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune Android policies.
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
            public static async Task<AndroidMAMPolicyCollection> GetAndroidMAMPoliciesAsync( this IIntuneResourceManagementClient operations, string hostName, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<AndroidMAMPolicyCollection> result = await operations.GetAndroidMAMPoliciesWithHttpMessagesAsync(hostName, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns Intune iOS policies.
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
            public static IOSMAMPolicy GetiOSMAMPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSMAMPolicyByIdAsync(hostName, policyId, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns Intune iOS policies.
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
            public static async Task<IOSMAMPolicy> GetiOSMAMPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IOSMAMPolicy> result = await operations.GetiOSMAMPolicyByIdWithHttpMessagesAsync(hostName, policyId, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Creates or updates iOSMAMPolicy.
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
            public static IOSMAMPolicy CreateOrUpdateiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSMAMPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).CreateOrUpdateiOSMAMPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates iOSMAMPolicy.
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
            public static async Task<IOSMAMPolicy> CreateOrUpdateiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSMAMPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IOSMAMPolicy> result = await operations.CreateOrUpdateiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// patch an iOSMAMPolicy.
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
            public static IOSMAMPolicy PatchiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSMAMPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).PatchiOSMAMPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// patch an iOSMAMPolicy.
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
            public static async Task<IOSMAMPolicy> PatchiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSMAMPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<IOSMAMPolicy> result = await operations.PatchiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Delete Ios Policy
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
            public static void DeleteiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteiOSMAMPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete Ios Policy
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
            public static async Task DeleteiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns AndroidMAMPolicy with given Id.
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
            public static AndroidMAMPolicy GetAndroidMAMPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAndroidMAMPolicyByIdAsync(hostName, policyId, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns AndroidMAMPolicy with given Id.
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
            public static async Task<AndroidMAMPolicy> GetAndroidMAMPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<AndroidMAMPolicy> result = await operations.GetAndroidMAMPolicyByIdWithHttpMessagesAsync(hostName, policyId, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Creates or updates AndroidMAMPolicy.
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
            public static AndroidMAMPolicy CreateOrUpdateAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidMAMPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).CreateOrUpdateAndroidMAMPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates AndroidMAMPolicy.
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
            public static async Task<AndroidMAMPolicy> CreateOrUpdateAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidMAMPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<AndroidMAMPolicy> result = await operations.CreateOrUpdateAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Patch AndroidMAMPolicy.
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
            public static AndroidMAMPolicy PatchAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidMAMPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).PatchAndroidMAMPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch AndroidMAMPolicy.
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
            public static async Task<AndroidMAMPolicy> PatchAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidMAMPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<AndroidMAMPolicy> result = await operations.PatchAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
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
            public static void DeleteAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAndroidMAMPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get apps for an iOSMAMPolicy.
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
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static ApplicationCollection GetAppForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAppForiOSMAMPolicyAsync(hostName, policyId, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get apps for an iOSMAMPolicy.
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
            public static async Task<ApplicationCollection> GetAppForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ApplicationCollection> result = await operations.GetAppForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Get apps for an AndroidMAMPolicy.
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
            /// <param name='filter'>
            /// The filter to apply on the operation.
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='select'>
            /// select specific fields in entity.
            /// </param>
            public static ApplicationCollection GetAppForAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetAppForAndroidMAMPolicyAsync(hostName, policyId, filter, top, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get apps for an AndroidMAMPolicy.
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
            public static async Task<ApplicationCollection> GetAppForAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string filter = default(string), int? top = default(int?), string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<ApplicationCollection> result = await operations.GetAppForAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, filter, top, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Add app to an iOSMAMPolicy.
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to add an app to an ios policy.
            /// </param>
            public static void AddAppForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddAppForiOSMAMPolicyAsync(hostName, policyId, appId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add app to an iOSMAMPolicy.
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to add an app to an ios policy.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddAppForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddAppForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, appId, parameters, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete App for Ios Policy
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            public static void DeleteAppForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAppForiOSMAMPolicyAsync(hostName, policyId, appId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete App for Ios Policy
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAppForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAppForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, appId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Add app to an AndroidMAMPolicy.
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            public static void AddAppForAndriodPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddAppForAndriodPolicyAsync(hostName, policyId, appId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add app to an AndroidMAMPolicy.
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddAppForAndriodPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddAppForAndriodPolicyWithHttpMessagesAsync(hostName, policyId, appId, parameters, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete App for Android Policy
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            public static void DeleteAppForAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAppForAndroidMAMPolicyAsync(hostName, policyId, appId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete App for Android Policy
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
            /// <param name='appId'>
            /// application unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAppForAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAppForAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, appId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns groups for a given iOSMAMPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy name for the tenant
            /// </param>
            public static GroupsCollection GetGroupsForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetGroupsForiOSMAMPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns groups for a given iOSMAMPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy name for the tenant
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GroupsCollection> GetGroupsForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<GroupsCollection> result = await operations.GetGroupsForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns groups for a given AndroidMAMPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy name for the tenant
            /// </param>
            public static GroupsCollection GetGroupsForAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetGroupsForAndroidMAMPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns groups for a given AndroidMAMPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy name for the tenant
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GroupsCollection> GetGroupsForAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                AzureOperationResponse<GroupsCollection> result = await operations.GetGroupsForAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Add group to an iOSMAMPolicy.
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
            /// <param name='groupId'>
            /// group Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            public static void AddGroupForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddGroupForiOSMAMPolicyAsync(hostName, policyId, groupId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add group to an iOSMAMPolicy.
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
            /// <param name='groupId'>
            /// group Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddGroupForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddGroupForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, groupId, parameters, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete Group for iOS Policy
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
            /// <param name='groupId'>
            /// application unique Id
            /// </param>
            public static void DeleteGroupForiOSMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteGroupForiOSMAMPolicyAsync(hostName, policyId, groupId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete Group for iOS Policy
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
            /// <param name='groupId'>
            /// application unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteGroupForiOSMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteGroupForiOSMAMPolicyWithHttpMessagesAsync(hostName, policyId, groupId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Add group to an AndroidMAMPolicy.
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
            /// <param name='groupId'>
            /// group Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            public static void AddGroupForAndriodPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddGroupForAndriodPolicyAsync(hostName, policyId, groupId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add group to an AndroidMAMPolicy.
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
            /// <param name='groupId'>
            /// group Id
            /// </param>
            /// <param name='parameters'>
            /// Parameters supplied to the Create or update app to an android policy
            /// operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task AddGroupForAndriodPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddGroupForAndriodPolicyWithHttpMessagesAsync(hostName, policyId, groupId, parameters, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete Group for Android Policy
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
            /// <param name='groupId'>
            /// application unique Id
            /// </param>
            public static void DeleteGroupForAndroidMAMPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteGroupForAndroidMAMPolicyAsync(hostName, policyId, groupId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete Group for Android Policy
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
            /// <param name='groupId'>
            /// application unique Id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteGroupForAndroidMAMPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteGroupForAndroidMAMPolicyWithHttpMessagesAsync(hostName, policyId, groupId, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
