// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ApplicationInsights.Management.Models;
using Microsoft.Azure.Management.ApplicationInsights.Management;

namespace Microsoft.Azure.Commands.ApplicationInsights
{
    /// <summary>
    /// Class to define Utility methods 
    /// </summary>
    internal static class Utilities
    {
        internal static List<ApplicationInsightsComponent> GetComponents(IApplicationInsightsManagementClient applicationInsightsClient)
        {
            Func<IPage<ApplicationInsightsComponent>> listAsync =
                () => applicationInsightsClient
                        .Components
                        .ListWithHttpMessagesAsync()
                        .GetAwaiter()
                        .GetResult()
                        .Body;

            Func<string, IPage<ApplicationInsightsComponent>> listNextAsync =
                nextLink => applicationInsightsClient
                                .Components
                                .ListNextWithHttpMessagesAsync(
                                    nextLink)
                                .GetAwaiter()
                                .GetResult()
                                .Body;

            return Utilities.GetPagedList(listAsync, listNextAsync);
        }

        internal static List<ApplicationInsightsComponent> GetComponents(IApplicationInsightsManagementClient applicationInsightsClient, string resourceGroupName)
        {
            Func<IPage<ApplicationInsightsComponent>> listAsync =
                () => applicationInsightsClient
                        .Components
                        .ListByResourceGroupWithHttpMessagesAsync(resourceGroupName)
                        .GetAwaiter()
                        .GetResult()
                        .Body;

            Func<string, IPage<ApplicationInsightsComponent>> listNextAsync =
                nextLink => applicationInsightsClient
                                .Components
                                .ListByResourceGroupNextWithHttpMessagesAsync(
                                    nextLink)
                                .GetAwaiter()
                                .GetResult()
                                .Body;

            return Utilities.GetPagedList(listAsync, listNextAsync);
        }


        internal static List<T> GetPagedList<T>(Func<IPage<T>> listResources, Func<string, IPage<T>> listNext)
            where T : class
        {
            var resources = new List<T>();
            string nextLink = null;

            var pagedResources = listResources();

            foreach (var pagedResource in pagedResources)
            {
                resources.Add(pagedResource);
            }

            nextLink = pagedResources.NextPageLink;

            while (!string.IsNullOrEmpty(nextLink))
            {
                pagedResources = listNext(nextLink);
                nextLink = pagedResources.NextPageLink;

                foreach (var pagedResource in pagedResources)
                {
                    resources.Add(pagedResource);
                }
            }

            return resources;
        }
    }
}
