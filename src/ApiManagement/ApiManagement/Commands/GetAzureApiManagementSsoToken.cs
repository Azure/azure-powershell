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

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementSsoToken", DefaultParameterSetName = ExpandedParameterSet)]
    [OutputType(typeof(string), ParameterSetName = new[] { ExpandedParameterSet, ByInputObjectParameterSet })]
    public class GetAzureApiManagementSsoToken : AzureApiManagementCmdletBase
    {
        #region Parameter Set Names

        protected const string ExpandedParameterSet = "ExpandedParameter";
        protected const string ByInputObjectParameterSet = "ByInputObject";

        #endregion

        [Parameter(
           ParameterSetName = ByInputObjectParameterSet,
           ValueFromPipeline = true,
           Mandatory = true,
           HelpMessage = "Instance of PsApiManagement. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagement InputObject { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ExpandedParameterSet,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ExpandedParameterSet))
            {
                ExecuteCmdLetWrap(
                    () => Client.GetSsoToken(ResourceGroupName, Name),
                    passThru: true);
            }
            else
            {
                ExecuteCmdLetWrap(
                    () => Client.GetSsoToken(InputObject.ResourceGroupName, InputObject.Name),
                    passThru: true);
            }
        }
    }
}
