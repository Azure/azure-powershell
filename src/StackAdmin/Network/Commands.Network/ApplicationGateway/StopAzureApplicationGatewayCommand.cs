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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsLifecycle.Stop, "AzureRmApplicationGateway"), OutputType(typeof(PSApplicationGateway))]
    public class StopAzureApplicationGatewayCommand : ApplicationGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ApplicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsApplicationGatewayPresent(this.ApplicationGateway.ResourceGroupName, this.ApplicationGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var appGwModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ApplicationGateway>(this.ApplicationGateway);
            appGwModel.Tags = TagsConversionHelper.CreateTagDictionary(this.ApplicationGateway.Tag, validate: true);

            this.ApplicationGatewayClient.Stop(this.ApplicationGateway.ResourceGroupName, this.ApplicationGateway.Name);

            var getApplicationGateway = this.GetApplicationGateway(this.ApplicationGateway.ResourceGroupName, this.ApplicationGateway.Name);

            WriteObject(getApplicationGateway);
        }
    }
}
