// Copyright (c) Microsoft Corporation. All rights reserved.

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
            public static IOSPolicy GetiOSPolicyById(this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string))
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetiOSPolicyByIdAsync(hostName, policyId, select), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task<IOSPolicy> GetiOSPolicyByIdAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string select = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicy> result = await operations.GetiOSPolicyByIdWithHttpMessagesAsync(hostName, policyId, select, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Creates or updates iosPolicy.
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
            public static IOSPolicy CreateOrUpdateIOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).CreateOrUpdateIOSPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates iosPolicy.
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
            public static async Task<IOSPolicy> CreateOrUpdateIOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicy> result = await operations.CreateOrUpdateIOSPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// patch an iosPolicy.
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
            public static IOSPolicy PatchIOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).PatchIOSPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// patch an iosPolicy.
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
            public static async Task<IOSPolicy> PatchIOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, IOSPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<IOSPolicy> result = await operations.PatchIOSPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
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
            public static void DeleteIosPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteIosPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteIosPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteIosPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
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
            public static AndroidPolicy CreateOrUpdateAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicyRequestBody parameters)
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
            public static async Task<AndroidPolicy> CreateOrUpdateAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<AndroidPolicy> result = await operations.CreateOrUpdateAndroidPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Patch androidPolicy.
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
            public static AndroidPolicy PatchAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicyRequestBody parameters)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).PatchAndroidPolicyAsync(hostName, policyId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Patch androidPolicy.
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
            public static async Task<AndroidPolicy> PatchAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, AndroidPolicyRequestBody parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<AndroidPolicy> result = await operations.PatchAndroidPolicyWithHttpMessagesAsync(hostName, policyId, parameters, null, cancellationToken).ConfigureAwait(false);
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

            /// <summary>
            /// Add app to an iosPolicy.
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
            public static void AddAppForIOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddAppForIOSPolicyAsync(hostName, policyId, appId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add app to an iosPolicy.
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
            public static async Task AddAppForIOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddAppForIOSPolicyWithHttpMessagesAsync(hostName, policyId, appId, parameters, null, cancellationToken).ConfigureAwait(false);
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
            public static void DeleteAppForIosPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAppForIosPolicyAsync(hostName, policyId, appId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteAppForIosPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAppForIosPolicyWithHttpMessagesAsync(hostName, policyId, appId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Add app to an androidPolicy.
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
            /// Add app to an androidPolicy.
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
            public static void DeleteAppForAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteAppForAndroidPolicyAsync(hostName, policyId, appId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteAppForAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string appId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteAppForAndroidPolicyWithHttpMessagesAsync(hostName, policyId, appId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Returns groups for a given ioSPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy id for the tenant
            /// </param>
            public static GroupsCollection GetGroupsForiOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetGroupsForiOSPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns groups for a given ioSPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy id for the tenant
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GroupsCollection> GetGroupsForiOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<GroupsCollection> result = await operations.GetGroupsForiOSPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Returns groups for a given androidPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy id for the tenant
            /// </param>
            public static GroupsCollection GetGroupsForAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId)
            {
                return Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).GetGroupsForAndroidPolicyAsync(hostName, policyId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns groups for a given androidPolicy.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='hostName'>
            /// Location hostName for the tenant
            /// </param>
            /// <param name='policyId'>
            /// policy id for the tenant
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<GroupsCollection> GetGroupsForAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, CancellationToken cancellationToken = default(CancellationToken))
            {
                HttpOperationResponse<GroupsCollection> result = await operations.GetGroupsForAndroidPolicyWithHttpMessagesAsync(hostName, policyId, null, cancellationToken).ConfigureAwait(false);
                return result.Body;
            }

            /// <summary>
            /// Add group to an iosPolicy.
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
            public static void AddGroupForiOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).AddGroupForiOSPolicyAsync(hostName, policyId, groupId, parameters), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Add group to an iosPolicy.
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
            public static async Task AddGroupForiOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, MAMPolicyAppIdOrGroupIdPayload parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.AddGroupForiOSPolicyWithHttpMessagesAsync(hostName, policyId, groupId, parameters, null, cancellationToken).ConfigureAwait(false);
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
            public static void DeleteGroupForiOSPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteGroupForiOSPolicyAsync(hostName, policyId, groupId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteGroupForiOSPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteGroupForiOSPolicyWithHttpMessagesAsync(hostName, policyId, groupId, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Add group to an androidPolicy.
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
            /// Add group to an androidPolicy.
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
            public static void DeleteGroupForAndroidPolicy(this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId)
            {
                Task.Factory.StartNew(s => ((IIntuneResourceManagementClient)s).DeleteGroupForAndroidPolicyAsync(hostName, policyId, groupId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
            public static async Task DeleteGroupForAndroidPolicyAsync( this IIntuneResourceManagementClient operations, string hostName, string policyId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteGroupForAndroidPolicyWithHttpMessagesAsync(hostName, policyId, groupId, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
