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

using Microsoft.Azure.Commands.ServiceBus.Models;
using Microsoft.Azure.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Namespace
{
    /// <summary>
    /// 'Test-AzureRmCheckNameAvailability' Cmdlet Check Availability of the NameSpace Name
    /// </summary>
    [Cmdlet("Test", "AzureRmServiceBusName"), OutputType(typeof(List<CheckNameAvailabilityResultAttributes>))]
    public class TestAzureServiceBusCheckNameAvailability : AzureServiceBusCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Relay Namespace Name.")]
        public string Namespace { get; set; }

        public override void ExecuteCmdlet()
        {   
            //Check the Relay namespaces name is availability
            CheckNameAvailabilityResultAttributes checkNameAvailabilityResult = Client.GetCheckNameAvailability(Namespace);
            WriteObject(checkNameAvailabilityResult, true);

        }
    }
}