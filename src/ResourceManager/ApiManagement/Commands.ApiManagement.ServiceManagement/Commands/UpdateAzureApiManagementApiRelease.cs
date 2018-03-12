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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Properties;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsData.Update, 
        Constants.ApiManagementApiRelease, 
        DefaultParameterSetName = ExpandedParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementApiRelease))]
    public class UpdateAzureApiManagementApiRelease : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names
        
        private const string ExpandedParameterSet = "ExpandedParameter";
        private const string ByValueParameterSet = "ByValue";

        #endregion

        [Parameter(
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }
        
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedParameterSet,
            Mandatory = true,
            HelpMessage = "Identifier for the Api Revision ReleaseId. This parameter is required.")]
        public String ReleaseId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedParameterSet,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String ApiId { get; set; }
                
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ExpandedParameterSet,
            Mandatory = false,
            HelpMessage = "Api Release Notes. This parameter is optional.")]
        public String Note { get; set; }

        [Parameter(
            ParameterSetName = ByValueParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Instance of type Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease.")]
        public PsApiManagementApiRelease ApiRelease { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified then instance of" +
                          " Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiRelease type " +
                          "representing the set API Release.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ShouldProcess(ReleaseId, Resources.SetApiRelease))
            {
                if (ParameterSetName == ExpandedParameterSet)
                {
                    Client.UpdateApiRelease(
                        Context,
                        ApiId,
                        ReleaseId,
                        Note,
                        null);
                }
                else
                {
                    ApiId = ApiRelease.ApiId;
                    ReleaseId = ApiRelease.ReleaseId;
                    Client.UpdateApiRelease(
                        Context,
                        apiId: ApiId,
                        releaseId: ReleaseId,
                        notes : null,
                        release: ApiRelease);
                }

                if (PassThru.IsPresent)
                {
                    var apiRelease = Client.GetApiReleaseById(Context, ApiId, ReleaseId);
                    WriteObject(apiRelease);
                }
            }
        }
    }
}
