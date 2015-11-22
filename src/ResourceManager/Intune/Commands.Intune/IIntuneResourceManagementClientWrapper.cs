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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Intune
{
    public interface IIntuneResourceManagementClientWrapper
    {
        /// <summary>
        /// Gets the JSON deserialization settings.
        /// </summary>
        void Initialize(AzureContext defaultContext, string apiVersion);

        /// <summary>
        /// Gets the GetOperationResults Page.
        /// </summary>
        IPage<OperationResult> GetOperationResults(string hostName, string filter = null, int? top = null, string select = null);
        
        /// <summary>
        /// Gets the GetOperationResults Next Page.
        /// </summary>
        IPage<OperationResult> GetOperationResultsNext(string nextPageLink);

        /// <summary>
        /// Gets the Devices Page.
        /// </summary>
        IPage<Device> GetUserDevices(string hostName, string userName, string filter = null, int? top = null, string select = null);

        /// <summary>
        /// Gets the Devices Next Page.
        /// </summary>
        IPage<Device> GetUserDevicesNext(string nextPageLink);

        /// <summary>
        /// Gets the Android MAM Policies Page.
        /// </summary>
        IPage<AndroidMAMPolicy> GetAndroidMAMPolicies(string hostName, string filter = null, int? top = null, string select = null);

        /// <summary>
        /// Gets the Android MAM Policies Next Page.
        /// </summary>
        IPage<AndroidMAMPolicy> GetAndroidMAMPoliciesNext(string nextPageLink);

        /// <summary>
        /// Creates Or Updates Android MAM Policy.
        /// </summary>
        AndroidMAMPolicy CreateOrUpdateAndroidMAMPolicy(string hostName, string policyId, AndroidMAMPolicy policyParams);

        /// <summary>
        /// Creates Or Updates iOS MAM Policy.
        /// </summary>
        IOSMAMPolicy CreateOrUpdateIosMAMPolicy(string hostName, string policyId, IOSMAMPolicy policyParams);

        /// <summary>
        /// Deletes Android MAM Policy.
        /// </summary>
        Microsoft.Rest.Azure.AzureOperationResponse DeleteAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId);

        /// <summary>
        /// Gets the Location by Host Name.
        /// </summary>
        Location GetLocationByHostName();

        /// <summary>
        /// Gets the JSON deserialization settings.
        /// </summary>
        JsonSerializerSettings GetDeserializationSettings();
    }
}