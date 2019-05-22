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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementSamplingSetting")]
    [OutputType(typeof(PsApiManagementSamplingSetting))]
    public class NewAzureApiManagementSamplingSetting : AzureApiManagementCmdletBase
    {
        [Parameter(
           ValueFromPipelineByPropertyName = false,
           Mandatory = false,
           HelpMessage = "The Type of Sampling. This parameter is optional.")]
        [PSArgumentCompleter(Constants.FixedSamplingType)]
        public string SamplingType { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Rate of Sampling for Fixed Rate Sampling. This parameter is optional.")]        
        public double? SamplingPercentage { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var samplingType = Utils.GetSamplingType(SamplingType);
            var psSamplingSetting = new PsApiManagementSamplingSetting();
            if (samplingType != null)
            {
                psSamplingSetting.SamplingType = samplingType;
            }

            if (SamplingPercentage != null)
            {
                psSamplingSetting.SamplingPercentage = SamplingPercentage;
            }

            WriteObject(psSamplingSetting);
        }
    }
}
