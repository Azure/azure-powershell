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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.AnalysisServices.Models;
using Microsoft.Azure.Commands.AnalysisServices.Properties;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.AnalysisServices
{
    [Cmdlet(VerbsCommon.New, "AzureRmAnalysisServicesFirewallConfig"), OutputType(typeof(PsAzureAnalysisServicesFirewallConfig))]
    public class NewAzureRmAnalysisServicesFirewallConfig : AnalysisServicesCmdletBase
    {       
        [Parameter(Mandatory = false,
            HelpMessage = "Option to enable PowerBI service")]
        public SwitchParameter EnablePowerBIService { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "Firewall rules")]
        public List<PsAzureAnalysisServicesFirewallRule> FirewallRule { get; set; }

        public override void ExecuteCmdlet()
        {
            PsAzureAnalysisServicesFirewallConfig config = new PsAzureAnalysisServicesFirewallConfig((EnablePowerBIService) ? true : false, FirewallRule);
            WriteObject(config);
        }
    }
}