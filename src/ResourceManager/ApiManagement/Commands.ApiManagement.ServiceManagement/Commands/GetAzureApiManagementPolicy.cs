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
    using System;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Text;
    using Management.ApiManagement.Models;
    using Models;
    using Properties;

    [Cmdlet(VerbsCommon.Get, 
        Constants.ApiManagementPolicy,
        SupportsShouldProcess = true,        
        DefaultParameterSetName = TenantLevel)]
    [OutputType(typeof(string))]
    public class GetAzureApiManagementPolicy : AzureApiManagementCmdletBase
    {
        private const string DefaultFormat = "application/vnd.ms-azure-apim.policy+xml";
        private const string TenantLevel = "GetTenantLevel";
        private const string ProductLevel = "GetProductLevel";
        private const string ApiLevel = "GetApiLevel";
        private const string OperationLevel = "GetOperationLevel";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Format of the policy. Default value is ‘application/vnd.ms-azure-apim.policy+xml’." +
                          " This parameter is optional.")]
        public String Format { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "File path to save the result to. If not specified the result will be sent to pipeline as a sting." +
                          " This parameter is optional.")]
        public String SaveAs { get; set; }

        [Parameter(
            ParameterSetName = ProductLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing product. If specified will return product-scope policy." +
                          " This parameters is optional.")]
        public String ProductId { get; set; }

        [Parameter(
            ParameterSetName = ApiLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. If specified will return API-scope policy. This parameters is required.")]
        [Parameter(
            ParameterSetName = OperationLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing API. If specified will return API-scope policy. This parameters is required.")]
        public String ApiId { get; set; }

        [Parameter(
            ParameterSetName = ApiLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the policy will be " +
            "retrieved from the currently active api revision.")]
        [Parameter(
            ParameterSetName = OperationLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of API Revision. This parameter is optional. If not specified, the policy will be " +
            "retrieved from the currently active api revision.")]
        public String ApiRevision { get; set; }

        [Parameter(
            ParameterSetName = OperationLevel,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Identifier of existing operation. If specified with ApiId will return operation-scope policy." +
                          " This parameters is required.")]
        public String OperationId { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of existing operation. If specified with ApiId will return operation-scope policy." +
                          " This parameters is optional.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            string policyContent;
            string apiId;
            switch (ParameterSetName)
            {
                case TenantLevel:
                    policyContent = Client.PolicyGetTenantLevel(Context);
                    break;
                case ProductLevel:
                    policyContent = Client.PolicyGetProductLevel(Context, ProductId);
                    break;
                case ApiLevel:
                    apiId = ApiId;
                    if (!string.IsNullOrEmpty(ApiRevision))
                    {
                        apiId = ApiId.ApiRevisionIdentifier(ApiRevision);
                    }
                    policyContent = Client.PolicyGetApiLevel(Context, apiId);
                    break;
                case OperationLevel:
                    if (string.IsNullOrWhiteSpace(ApiId))
                    {
                        throw new PSArgumentNullException("ApiId");
                    }
                    apiId = ApiId;
                    if (!string.IsNullOrEmpty(ApiRevision))
                    {
                        apiId = ApiId.ApiRevisionIdentifier(ApiRevision);
                    }
                    policyContent = Client.PolicyGetOperationLevel(Context, apiId, OperationId);
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }

            if (policyContent == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(SaveAs))
            {
                var actionDescription = string.Format(CultureInfo.CurrentCulture, Resources.SavePolicyDescription, ParameterSetName, SaveAs);
                var actionWarning = string.Format(CultureInfo.CurrentCulture, Resources.SavePolicyWarning, SaveAs);

                // Do nothing if force is not specified and user cancelled the operation
                if (!ShouldProcess(ApiId, actionDescription) || (File.Exists(SaveAs) &&
                    !Force.IsPresent &&
                    !ShouldContinue(
                        actionWarning,
                        Resources.ShouldProcessCaption)))
                {
                    return;
                }

                File.WriteAllText(SaveAs, policyContent, Encoding.UTF8);
            }
            else
            {
                WriteObject(policyContent);
            }
        }
    }
}
