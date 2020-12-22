//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

/*subscriptionId	path	True	
string
Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

api-version	query	True	
string
Version of the API to be used with the client request.
*/

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Properties;

    [Cmdlet("Reset", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementBackendConnection", SupportsShouldProcess = true, DefaultParameterSetName = ContextParameterSet)]
    [OutputType(typeof(PsApiManagementBackend))]
    public class ResetAzureApiManagementBackendConnection : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names
        protected const string ContextParameterSet = "ContextParameterSet";
        protected const string ByInputObjectParameterSet = "ByInputObject";
        #endregion

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ContextParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of new backend. This parameter is required.")]
        public String BackendId { get; set; }

        [Parameter(
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementBackend. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementBackend InputObject { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Backend Communication protocol. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet("http", "soap")]
        public String Protocol { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Runtime Url for the Backend. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        [ValidateLength(1, 2000)]
        public String Url { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Credential to be used when talking to the Backend. This parameter is optional.")]
        public PsApiManagementBackendCredential Credential { get; set; }

        [Parameter(
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "Defines how long you would like to wait until the connection is reset.")]
        public int TimeUntilReset { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Proxy Server details to be used while sending request to the Backend. This parameter is optional.")]
        public PsApiManagementBackendProxy Proxy { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                          "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementBackend type " +
                          " representing the modified backend will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string resourcegroupName;
            string serviceName;
            string backendId;

            if (ParameterSetName.Equals(ByInputObjectParameterSet))
            {
                resourcegroupName = InputObject.ResourceGroupName;
                serviceName = InputObject.ServiceName;
                backendId = InputObject.BackendId;
            }
            else 
            {
                resourcegroupName = Context.ResourceGroupName;
                serviceName = Context.ServiceName;
                backendId = BackendId;
            }

            if (ShouldProcess(backendId, Resources.SetBackend))
            {
                Client.BackendReset(
                    resourcegroupName,
                    serviceName,
                    backendId,
                    Url,
                    Protocol,
                    TimeUntilReset,
                    Credential,
                    Proxy);

                if (PassThru)
                {
                    var @backend = Client.BackendById(resourcegroupName, serviceName, backendId);
                    WriteObject(@backend);
                }
                if(TimeUntilReset == 0)
                {
                    TimeUntilReset = 120;
                }
                string result = String.Format("Successfully scheduled the backend connection reset for {0}. The Reset will occur in {1} seconds(s)", serviceName, TimeUntilReset);
                WriteObject(result);
            }
        }
    }
}
