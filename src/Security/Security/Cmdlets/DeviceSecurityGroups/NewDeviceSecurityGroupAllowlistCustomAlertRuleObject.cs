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
// ------------------------------------
using Commands.Security;
using Microsoft.Azure.Commands.Security.Common;
using Microsoft.Azure.Commands.Security.Models.DeviceSecurityGroups;
using Microsoft.Azure.Management.Security.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.SecurityCenter.Cmdlets.DeviceSecurityGroups
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DeviceSecurityGroupAllowlistCustomAlertRuleObject", DefaultParameterSetName = ParameterSetNames.GeneralScope), OutputType(typeof(PSAllowlistCustomAlertRule))]
    public class NewDeviceSecurityGroupAllowlistCustomAlertRuleObject : SecurityCenterCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.IsEnabled)]
        public bool Enabled { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.RuleType)]
        public string Type { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.GeneralScope, Mandatory = true, HelpMessage = ParameterHelpMessages.AllowlistValues)]
        public string[] AllowlistValue { get; set; }

        public override void ExecuteCmdlet()
        {
            PSAllowlistCustomAlertRule rule = new PSAllowlistCustomAlertRule
            {
                IsEnabled = Enabled,
               AllowlistValues = AllowlistValue,
                RuleType = Type
            };

            WriteObject(rule, enumerateCollection: false);
        }
    }
}
