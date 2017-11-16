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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System.Linq;

    [Cmdlet(VerbsCommon.Set, "AzureRmSecureGatewayApplicationRuleCollection"), OutputType(typeof(PSSecureGateway))]
    public class SetAzureSecureGatewayApplicationRuleCollectionCommand : AzureSecureGatewayApplicationRuleCollectionBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecureGateway")]
        public PSSecureGateway SecureGateway { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.Rules == null || this.Rules.Count == 0)
            {
                throw new ArgumentException("At least one application rule should be specified!");
            }

            // Verify if the applicationRuleCollection exists in the SecureGateway
            var applicationRuleCollection = this.SecureGateway.ApplicationRuleCollections.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (applicationRuleCollection == null)
            {
                throw new ArgumentException("Application rule collection with the specified name does not exist");
            }

            applicationRuleCollection.Name = this.Name;
            applicationRuleCollection.Rules = this.Rules;
            WriteObject(this.SecureGateway);
        }
    }
}
