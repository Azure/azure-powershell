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


using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Office365PolicyProperty"), OutputType(typeof(PSOffice365PolicyProperties))]
    public class NewOffice365PolicyPropertyCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Breakout the allow category traffic.")]
        public SwitchParameter Allow { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Breakout the optimize category traffic.")]
        public SwitchParameter Optimize { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "Breakout the default category traffic.")]
        public SwitchParameter Default { get; set; }

        public override void Execute()
        {
            base.Execute();
            var o365Policy = new PSOffice365PolicyProperties();
            o365Policy.BreakOutCategories = new PSBreakOutCategoryPolicies();
            o365Policy.BreakOutCategories.Allow = this.Allow;
            o365Policy.BreakOutCategories.Optimize = this.Optimize;
            o365Policy.BreakOutCategories.DefaultProperty = this.Default;
            WriteObject(o365Policy);
        }
    }
}
