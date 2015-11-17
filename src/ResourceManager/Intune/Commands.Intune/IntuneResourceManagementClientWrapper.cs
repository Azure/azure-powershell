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

namespace Microsoft.Azure.Commands.Intune
{
    public class IntuneResourceManagementClientWrapper : IIntuneResourceManagementClientWrapper
    {
        private IIntuneResourceManagementClient IntuneClient { get; set; }

        public JsonSerializerSettings GetDeserializationSettings() 
        {
            return IntuneClient.DeserializationSettings;
        }

        private bool Initialized { get; set; }
        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public IntuneResourceManagementClientWrapper()
        {

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

        public IPage<AndroidMAMPolicy> GetAndroidMAMPolicies(string hostName, string filter = null, int? top = null, string select = null)
        {
            if (this.Initialized)
            {
                IPage<AndroidMAMPolicy> androidPolicy = this.IntuneClient.Android.GetMAMPolicies(hostName, filter, top, select);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }

        public IPage<AndroidMAMPolicy> GetAndroidMAMPoliciesNext(string nextPageLink)
        {
            if (this.Initialized)
            {
                IPage<AndroidMAMPolicy> androidPolicy = this.IntuneClient.Android.GetMAMPoliciesNext(nextPageLink);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }

        public AndroidMAMPolicy CreateOrUpdateAndroidMAMPolicy(string hostName, string policyId, AndroidMAMPolicy policyParams)
        {
            if (this.Initialized)
            {
                AndroidMAMPolicy androidPolicy = this.IntuneClient.Android.CreateOrUpdateMAMPolicy(hostName, policyId, policyParams);
                return androidPolicy;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }

        public IOSMAMPolicy CreateOrUpdateIosMAMPolicy(string hostName, string policyId, IOSMAMPolicy policyParams)
        {
            if (this.Initialized)
            {
                IOSMAMPolicy iOSPolicy = this.IntuneClient.Ios.CreateOrUpdateMAMPolicy(hostName, policyId, policyParams);
                return iOSPolicy;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }


        public Microsoft.Rest.Azure.AzureOperationResponse DeleteAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId)
        {
            if (this.Initialized)
            {
                Microsoft.Rest.Azure.AzureOperationResponse respose = this.IntuneClient.Android.DeleteMAMPolicyWithHttpMessagesAsync(hostName, policyId).GetAwaiter().GetResult();
                return respose;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }


        public Location GetLocationByHostName()
        {
            if (this.Initialized)
            {
                Location location = this.IntuneClient.GetLocationByHostName();
                return location;
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }
    }
}
