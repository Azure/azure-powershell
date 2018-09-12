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

namespace Microsoft.Azure.Commands.Network
{

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Management.Network;
    using System.Collections.Generic;
    using System.Management.Automation;

    using AutoMapper;

    [Cmdlet(VerbsCommon.Get, "AzureRmBgpServiceCommunity"), OutputType(typeof(PSBgpServiceCommunity))]
    public class GetAzureBgpServiceCommunityCommand: NetworkBaseCmdlet
    {
        public override void Execute()
        {
            base.Execute();
            var communityList = this.NetworkClient.NetworkManagementClient.BgpServiceCommunities.List();

            var psCommunities = new List<PSBgpServiceCommunity>();

            foreach (var community in communityList)
            {
                var psProvider = NetworkResourceManagerProfile.Mapper.Map<PSBgpServiceCommunity>(community);
                psCommunities.Add(psProvider);
            }

            WriteObject(psCommunities, true);
        }

    }
}
