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

using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicySqlSetting", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicySqlSetting))]
    public class NewAzureFirewallSqlSettingCommand : NetworkBaseCmdlet
    {

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allow SQL server redirect mode traffic. By default this type of traffic is not allowed."
        )]
        public SwitchParameter AllowSqlRedirect { get; set; }

        public override void Execute()
        {
            base.Execute();

            var sqlSetting = new PSAzureFirewallPolicySqlSetting
            {
                AllowSqlRedirect = this.AllowSqlRedirect.IsPresent ? true : (bool?)null,
            };

            WriteObject(sqlSetting);
        }

    }
}
