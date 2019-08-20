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
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Commands.Network.Common;
using Microsoft.Azure.Management.Network.Models;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateLinkService"), OutputType(typeof(PSPrivateLinkService))]
    public class SetAzurePrivateLinkServiceCommand : PrivateLinkServiceBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The privateLinkService")]
        public PSPrivateLinkService PrivateLinkService { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsPrivateLinkServicePresent(this.PrivateLinkService.ResourceGroupName, this.PrivateLinkService.Name))
            {
                throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.PrivateLinkService.Name));
            }

            // Map to the sdk object
            var plsModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PrivateLinkService>(this.PrivateLinkService);
            plsModel.Tags = TagsConversionHelper.CreateTagDictionary(this.PrivateLinkService.Tag, validate: true);

            // Execute the CreateOrUpdate PrivateLinkService call
            this.PrivateLinkServiceClient.CreateOrUpdate(this.PrivateLinkService.ResourceGroupName, this.PrivateLinkService.Name, plsModel);

            var getPrivateLinkService = this.GetPrivateLinkService(this.PrivateLinkService.ResourceGroupName, this.PrivateLinkService.Name);
            WriteObject(getPrivateLinkService);
        }
    }
}
