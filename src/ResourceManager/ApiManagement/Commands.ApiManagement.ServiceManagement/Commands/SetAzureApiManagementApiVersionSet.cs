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

    [Cmdlet(VerbsCommon.Set, 
        Constants.ApiManagementApiVersionSet,
        DefaultParameterSetName = ExpandedParameterSet,
        SupportsShouldProcess = true)]
    [OutputType(typeof(PsApiManagementApiVersionSet))]
    public class SetAzureApiManagementApiVersionSet : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        private const string ExpandedParameterSet = "ExpandedParameter";
        private const string ByValueParameterSet = "ByValue";

        #endregion

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = ByValueParameterSet,
            ValueFromPipeline = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementApiVersionSet. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiVersionSet ApiVersionSetObject { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier for new API Version Set.")]
        public String ApiVersionSetId { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The name of the ApiVersion Set. This parameter is optional.")]
        public String Name { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Versioning Scheme to select for the Api Versioning Set. This parameter is optional.")]
        public PsApiManagementVersioningScheme Scheme { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The Header value which will contain the versioning information. " +
            "If versioning Scheme HEADER is choosen, then this value must be specified.")]
        public String HeaderName { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "The Query value which will contain the versioning information. " +
            "If versioning Scheme Query is choosen, then this value must be specified.")]
        public String QueryName { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Description of the Api Version set.")]
        public String Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "If specified then instance of " +
                  "Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementApiVersionSet type " +
                  " representing the modified apiVersionSet will be written to output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ApiVersionSetObject != null)
            {
                ApiVersionSetId = ApiVersionSetObject.ApiVersionSetId;
            }

            if (ShouldProcess(ApiVersionSetId, Resources.SetApiVersionSet))
            {
                var apiVersionSet = Client.SetApiVersionSet(
                    Context,
                    ApiVersionSetId,
                    Name,
                    Scheme,
                    HeaderName,
                    QueryName,
                    Description,
                    ApiVersionSetObject);

                if (PassThru.IsPresent)
                {
                    WriteObject(apiVersionSet);
                }
            }
        }
    }
}
