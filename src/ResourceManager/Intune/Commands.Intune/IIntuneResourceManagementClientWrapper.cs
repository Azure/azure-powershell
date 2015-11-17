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

        void Initialize(AzureContext defaultContext, string apiVersion);

        IPage<AndroidMAMPolicy> GetAndroidMAMPolicies(string hostName, string filter = null, int? top = null, string select = null);

        IPage<AndroidMAMPolicy> GetAndroidMAMPoliciesNext(string nextPageLink);

        AndroidMAMPolicy CreateOrUpdateAndroidMAMPolicy(string hostName, string policyId, AndroidMAMPolicy policyParams);

        IOSMAMPolicy CreateOrUpdateIosMAMPolicy(string hostName, string policyId, IOSMAMPolicy policyParams);

        Microsoft.Rest.Azure.AzureOperationResponse DeleteAndroidMAMPolicyWithHttpMessagesAsync(string hostName, string policyId);
        
        Location GetLocationByHostName();

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings GetDeserializationSettings();      

    }
}