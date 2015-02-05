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

using System.Linq;
using System.Management.Automation;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.HostedServices
{
    /// <summary>
    /// Retrieve a specified hosted account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureService"), OutputType(typeof(HostedServiceDetailedContext))]
    public class GetAzureServiceCommand : ServiceManagementBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ServiceName
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            if (this.ServiceName != null)
            {
                ExecuteClientActionNewSM(null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.HostedServices.Get(this.ServiceName),
                    (operation, service) =>
                    {
                        var context = ContextFactory<HostedServiceGetResponse, HostedServiceDetailedContext>(service, operation);
                        Mapper.Map(service.Properties, context);
                        return context;
                    });
            }
            else
            {
                ExecuteClientActionNewSM(null,
                    CommandRuntime.ToString(),
                    () => this.ComputeClient.HostedServices.List(),
                    (operation, services) => services.HostedServices.Select(
                        service =>
                        {
                            var context = ContextFactory<HostedServiceListResponse.HostedService, HostedServiceDetailedContext>(service, operation);
                            Mapper.Map(service.Properties, context);
                            return context;
                        }));
            }
        }
    }
}
