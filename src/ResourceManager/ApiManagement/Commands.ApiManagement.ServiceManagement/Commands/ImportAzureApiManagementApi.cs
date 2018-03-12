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
    using Models;
    using System;
    using System.Management.Automation;
    using Management.ApiManagement.Models;

    [Cmdlet(VerbsData.Import, Constants.ApiManagementApi, DefaultParameterSetName = FromLocalFile)]
    [OutputType(typeof(PsApiManagementApi))]
    public class ImportAzureApiManagementApi : AzureApiManagementCmdletBase
    {
        private const string FromLocalFile = "ImportFromLocalFile";
        private const string FromUrl = "ImportFromUrl";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier for importing API. This parameter is optional. If not specified the identifier will be generated.")]
        public String ApiId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the import will be " +
            "done onto the currently active revision or a new api.")]
        public String ApiRevision { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Specification format (Wadl, Swagger, Wsdl). This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementApiFormat SpecificationFormat { get; set; }

        [Parameter(
            ParameterSetName = FromLocalFile,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Specification file path. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String SpecificationPath { get; set; }

        [Parameter(
            ParameterSetName = FromUrl,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Specification URL. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public String SpecificationUrl { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Web API Path. Last part of the API's public URL. This URL will be used by API consumers for sending requests to the web service. Must be 1 to 400 characters long. This parameter is optional. Default value is $null.")]
        public String Path { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Local name of WSDL Service to be imported. Must be 1 to 400 characters long." +
                          " This parameter is optional and only required for importing Wsdl . Default value is $null.")]
        public String WsdlServiceName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false, 
            HelpMessage = "Local name of WSDL Endpoint (port) to be imported." +
            " Must be 1 to 400 characters long. This parameter is optional and only required for importing Wsdl. Default value is $null.")]
        public String WsdlEndpointName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "This parameter is optional with a default value of Http. " +
                          "The Soap option is only applicable when importing WSDL and will create a SOAP Passthrough API.")]
        public PsApiManagementApiType? ApiType { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string apiId = ApiId;
            if (!string.IsNullOrEmpty(ApiId))
            {
                if (!string.IsNullOrEmpty(ApiRevision))
                {
                    apiId = ApiId.ApiRevisionIdentifier(ApiRevision);
                }
            }
            else
            {
                apiId = Guid.NewGuid().ToString("N");
            }

            if (ParameterSetName.Equals(FromLocalFile))
            {
                Client.ApiImportFromFile(
                    Context,
                    apiId,
                    SpecificationFormat,
                    SpecificationPath,
                    Path,
                    WsdlServiceName, 
                    WsdlEndpointName,
                    ApiType);
            }
            else if (ParameterSetName.Equals(FromUrl))
            {
                Client.ApiImportFromUrl(
                    Context,
                    apiId,
                    SpecificationFormat, 
                    SpecificationUrl,
                    Path,
                    WsdlServiceName,
                    WsdlEndpointName,
                    ApiType);
            }
            else
            {
                throw new InvalidOperationException(string.Format("ParameterSetName '{0}' not supported", ParameterSetName));
            }

            var api = Client.ApiById(Context, apiId);
            WriteObject(api);
        }
    }
}
