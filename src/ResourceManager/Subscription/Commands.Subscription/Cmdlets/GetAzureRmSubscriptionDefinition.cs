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

using Microsoft.Azure.Commands.Subscription.Common;
using Microsoft.Azure.Commands.Subscription.Models;
using Microsoft.Azure.Management.Subscription;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Subscription.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSubscriptionDefinition", DefaultParameterSetName = ParameterSetNames.Default), OutputType(typeof(List<PSSubscriptionDefinition>))]
    public class GetAzureRmSubscriptionDefinition : AzureSubscriptionDefinitionCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.Default, Mandatory = false, HelpMessage = "Name of the subscription definition to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                this.WriteSubscriptionDefinitionObject(this.SubscriptionDefinitionsClient.SubscriptionDefinitions.Get(this.Name));
            }
            else
            {
                var subscriptionDefinitions = this.SubscriptionDefinitionsClient.SubscriptionDefinitions.List();
                this.WriteSubscriptionDefinitionObjects(subscriptionDefinitions);
            }
        }
    }
}
