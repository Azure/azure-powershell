﻿// ----------------------------------------------------------------------------------
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

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common;
using System.IO;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmApplicationGatewayAvailableWafRuleSets"), 
        OutputType(typeof(PSApplicationGatewayAvailableWafRuleSetsResult))]
    [Alias("List-AzureRmApplicationGatewayAvailableWafRuleSets")]
    public class GetAzureApplicationGatewayAvailableWafRuleSets : ApplicationGatewayBaseCmdlet, IModuleAssemblyInitializer
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var availableWafRuleSets = this.ApplicationGatewayClient.ListAvailableWafRuleSets();
            var psAvailableWafRuleSets = Mapper.Map<PSApplicationGatewayAvailableWafRuleSetsResult>(availableWafRuleSets);
            WriteObject(psAvailableWafRuleSets);
        }

        /// <summary>
        /// Setup necessary functionality when module gets imported.
        /// </summary>
        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureRmNetworkStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }
    }
}

