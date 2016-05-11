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
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Intune;
using Microsoft.Azure.Management.Intune.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Intune.Properties;

namespace Microsoft.Azure.Commands.Intune
{
    public class IntuneResourceManagementClientWrapper : IIntuneResourceManagementClientWrapper
    {
        /// <summary>
        /// Gets and sets the IntuneClient
        /// </summary>      
        private IIntuneResourceManagementClient IntuneClient { get; set; }

        /// <summary>
        /// Queue for the Android policyIds
        /// </summary>
        public static Queue<Guid> AndroidPolicyIdsQueue { get; private set; }

        /// <summary>
        /// Queue for the iOS policyIds
        /// </summary>
        public static Queue<Guid> iOSPolicyIdsQueue { get; private set; }
        
        private bool Initialized { get; set; }

        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public IntuneResourceManagementClientWrapper()
        {

        }

        /// <summary>
        /// Initialize the static variables on first load of class.
        /// </summary>
        static IntuneResourceManagementClientWrapper()
        {
            AndroidPolicyIdsQueue = new Queue<Guid>();
            iOSPolicyIdsQueue = new Queue<Guid>();
        }

        /// <summary>
        /// Initialize method
        /// </summary>
        public void Initialize(AzureContext defaultContext, string apiVersion)
        {
            if (!this.Initialized)
            {
                this.IntuneClient = IntuneBaseCmdlet.GetIntuneManagementClient(defaultContext, apiVersion);
                this.Initialized = true;
            }
        }


        /// <summary>
        /// Gets the GetOperationResults Page.
        /// </summary>
        public IPage<OperationResult> GetOperationResults(string hostName, string filter = null, int? top = null, string select = null)
        {
            if (this.Initialized)
            {
                IPage<OperationResult> operationResults = this.IntuneClient.GetOperationResults(hostName, filter, top, select);
                return operationResults;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the GetOperationResults Next Page.
        /// </summary>
        public IPage<OperationResult> GetOperationResultsNext(string nextPageLink)
        {
            if (this.Initialized)
            {
                IPage<OperationResult> operationResults = this.IntuneClient.GetOperationResultsNext(nextPageLink);
                return operationResults;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }


        /// <summary>
        /// Gets the Devices Page.
        /// </summary>
        public IPage<Device> GetUserDevices(string hostName, string userName, string filter = null, int? top = null, string select = null)
        {
            if (this.Initialized)
            {
                IPage<Device> devices = this.IntuneClient.GetMAMUserDevices(hostName, userName, filter, top, select);
                return devices;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the Devices Next Page.
        /// </summary>
        public IPage<Device> GetUserDevicesNext(string nextPageLink)
        {
            if (this.Initialized)
            {
                IPage<Device> devices = this.IntuneClient.GetMAMUserDevicesNext(nextPageLink);
                return devices;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the Android MAM Policies Page.
        /// </summary>
        public IPage<AndroidMAMPolicy> GetAndroidMAMPolicies(string hostName, string filter = null, int? top = null, string select = null)
        {
            if (this.Initialized)
            {
                IPage<AndroidMAMPolicy> androidPolicy = this.IntuneClient.Android.GetMAMPolicies(hostName, filter, top, select);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the Android MAM Policies Next Page.
        /// </summary>
        public IPage<AndroidMAMPolicy> GetAndroidMAMPoliciesNext(string nextPageLink)
        {
            if (this.Initialized)
            {
                IPage<AndroidMAMPolicy> androidPolicy = this.IntuneClient.Android.GetMAMPoliciesNext(nextPageLink);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Creates Or Updates Android MAM Policy.
        /// </summary>
        public AndroidMAMPolicy CreateOrUpdateAndroidMAMPolicy(string hostName, string policyId, AndroidMAMPolicy policyParams)
        {
            if (this.Initialized)
            {
                AndroidMAMPolicy androidPolicy = this.IntuneClient.Android.CreateOrUpdateMAMPolicy(hostName, policyId, policyParams);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Creates Or Updates iOS MAM Policy.
        /// </summary>
        public IOSMAMPolicy CreateOrUpdateIosMAMPolicy(string hostName, string policyId, IOSMAMPolicy policyParams)
        {
            if (this.Initialized)
            {
                IOSMAMPolicy iOSPolicy = this.IntuneClient.Ios.CreateOrUpdateMAMPolicy(hostName, policyId, policyParams);
                return iOSPolicy;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Deletes Android MAM Policy.
        /// </summary>
        public Microsoft.Rest.Azure.AzureOperationResponse DeleteAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId)
        {
            if (this.Initialized)
            {
                Microsoft.Rest.Azure.AzureOperationResponse respose = this.IntuneClient.Android.DeleteMAMPolicyWithHttpMessagesAsync(hostName, policyId).GetAwaiter().GetResult();
                return respose;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the Location by Host Name.
        /// </summary>
        public Location GetLocationByHostName()
        {
            if (this.Initialized)
            {
                Location location = this.IntuneClient.GetLocationByHostName();
                return location;
            }
            else
            {
                throw new InvalidOperationException(Resources.NotInitializedErrorMessage);
            }
        }

        /// <summary>
        /// Gets the JSON deserialization settings.
        /// </summary>
        public JsonSerializerSettings GetDeserializationSettings()
        {
            return IntuneClient.DeserializationSettings;
        }
    }
}
