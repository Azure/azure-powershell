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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceBus
{
    /// <summary>
    /// Lists all service bus locations available for a subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSBLocation"), OutputType(typeof(List<ServiceBusLocation>))]
    public class GetAzureSBLocationCommand : AzureSMCmdlet
    {
        internal ServiceBusClientExtensions Client { get; set; }

        /// <summary>
        /// Gets list of service bus regions on the given subscription.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Client = Client ?? new ServiceBusClientExtensions(Profile);
            WriteObject(Client.GetServiceBusRegions(), true);
        }
    }
}