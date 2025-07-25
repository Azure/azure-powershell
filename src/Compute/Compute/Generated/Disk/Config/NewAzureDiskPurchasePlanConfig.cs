// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;


namespace Microsoft.Azure.Commands.Compute.Generated.Disk.Config
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DiskPurchasePlanConfig", SupportsShouldProcess = true)]
    [OutputType(typeof(PSPurchasePlan))]
    public class NewAzureDiskPurchasePlanConfig : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set Publisher value")]
        public string Publisher { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set Purchase Plan Name")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set Product value")]
        public string Product { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Set Promotion Code")]
        public string PromotionCode { get; set; }

        protected override void ProcessRecord()
        {
            if (ShouldProcess("DiskPurchasePlan", "New"))
            {
                Run();
            }
        }

        private void Run()
        {
            var purchasePlan = new PSPurchasePlan
            {
                Publisher = this.IsParameterBound(c => c.Publisher) ? this.Publisher : null,
                Name = this.IsParameterBound(c => c.Name) ? this.Name : null,
                Product = this.IsParameterBound(c => c.Product) ? this.Product : null,
                PromotionCode = this.IsParameterBound(c => c.PromotionCode) ? this.PromotionCode : null
            };

            WriteObject(purchasePlan);
        }

    }

}
