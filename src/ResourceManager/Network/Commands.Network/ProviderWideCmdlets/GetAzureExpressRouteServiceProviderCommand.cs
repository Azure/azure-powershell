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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteServiceProvider"), OutputType(typeof(PSExpressRouteServiceProvider))]
    public class GetAzureExpressRouteServiceProviderCommand : NetworkBaseCmdlet
    {
        public override void Execute()
        {
            base.Execute();
            var serviceProviderList = this.NetworkClient.NetworkManagementClient.ExpressRouteServiceProviders.List();

            var psProviders = new List<PSExpressRouteServiceProvider>();

            foreach (var provider in serviceProviderList)
            {
                var psProvider = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteServiceProvider>(provider);
                psProviders.Add(psProvider);
            }

            WriteObject(psProviders, true);
        }
    }
}
