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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmSecureGateway"), OutputType(typeof(PSSecureGateway))]
    public class SetAzureSecureGatewayCommand : SecureGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The SecureGateway")]
        public PSSecureGateway SecureGateway { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsSecureGatewayPresent(this.SecureGateway.ResourceGroupName, this.SecureGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var secureGwModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecureGateway>(this.SecureGateway);
            secureGwModel.Tags = TagsConversionHelper.CreateTagDictionary(this.SecureGateway.Tag, validate: true);

            // Execute the PUT SecureGateway call
            this.SecureGatewayClient.CreateOrUpdate(this.SecureGateway.ResourceGroupName, this.SecureGateway.Name, secureGwModel);

            var getSecureGateway = this.GetSecureGateway(this.SecureGateway.ResourceGroupName, this.SecureGateway.Name);
            WriteObject(getSecureGateway);
        }
    }
}
