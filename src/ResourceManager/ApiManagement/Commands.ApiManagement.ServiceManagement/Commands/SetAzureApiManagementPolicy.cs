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
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Text;

    [Cmdlet(VerbsCommon.Set, Constants.ApiManagementPolicy, DefaultParameterSetName = TenantLevel)]
    [OutputType(typeof(bool))]
    public class SetAzureApiManagementPolicy : AzureApiManagementCmdletBase
    {
        private const string DefaultFormat = "application/vnd.ms-azure-apim.policy+xml";

        private const string TenantLevel = "Tenant level";
        private const string ProductLevel = "Product level";
        private const string ApiLevel = "API level";
        private const string OperationLevel = "Operation level";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Format of the policy. This parameter is optional. Default value is 'application/vnd.ms-azure-apim.policy+xml'.")]
        public String Format { get; set; }

        [Parameter(
            ParameterSetName = ProductLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing product. If specified will set product-scope policy. This parameters is required.")]
        public String ProductId { get; set; }

        [Parameter(
            ParameterSetName = ApiLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. If specified will set API-scope policy. This parameters is required.")]
        [Parameter(
            ParameterSetName = OperationLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. If specified will set API-scope policy. This parameters is required.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = OperationLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing operation. If specified with ApiId will set operation-scope policy. This parameters is required.")]
        public String OperationId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Policy document as a string. This parameter is required if -PolicyFilePath not specified.")]
        public String Policy { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Policy document file path. This parameter is required if -Policy not specified.")]
        public String PolicyFilePath { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "If specified will write true in case operation succeeds. This parameter is optional. Default value is false.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            Stream stream = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(Policy))
                {
                    stream = new MemoryStream(Encoding.UTF8.GetBytes(Policy));
                }
                else if (!string.IsNullOrEmpty(PolicyFilePath))
                {
                    stream = File.OpenRead(PolicyFilePath);
                }
                else
                {
                    throw new PSInvalidOperationException("Either Policy or PolicyFilePath should be specified.");
                }

                string format = Format ?? DefaultFormat;
                switch (ParameterSetName)
                {
                    case TenantLevel:
                        Client.PolicySetTenantLevel(Context, format, stream);
                        break;
                    case ProductLevel:
                        Client.PolicySetProductLevel(Context, format, stream, ProductId);
                        break;
                    case ApiLevel:
                        Client.PolicySetApiLevel(Context, format, stream, ApiId);
                        break;
                    case OperationLevel:
                        if (string.IsNullOrWhiteSpace(ApiId))
                        {
                            throw new PSArgumentNullException("ApiId");
                        }
                        Client.PolicySetOperationLevel(Context, format, stream, ApiId, OperationId);
                        break;
                    default:
                        throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
                }

                if (PassThru)
                {
                    WriteObject(true);
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }
    }
}
