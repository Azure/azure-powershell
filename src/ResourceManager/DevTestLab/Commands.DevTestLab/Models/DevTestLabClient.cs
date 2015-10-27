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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.DevTestLab;
using Microsoft.Azure.Management.DevTestLab.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure;
using Environment = Microsoft.Azure.Management.DevTestLab.Models.Environment;

namespace Microsoft.Azure.Commands.DevTestLab.Models
{
    internal class DevTestLabClient
    {
        public DevTestLabClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<DevTestLabManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public DevTestLabClient(IDevTestLabManagementClient managementClient)
        {
            this.DTLManagementClient = managementClient;
        }

        public IDevTestLabManagementClient DTLManagementClient { get; set; }

        public List<Lab> ListLabs()
        {
            List<Lab> labs = new List<Lab>();
            foreach (var lab in this.DTLManagementClient.Labs.ListAll())
            {
                labs.Add(lab);
            }
            return labs;
        }

        public List<Lab> ListLabsByResourceGroup(string resoureGroupName)
        {
            List<Lab> labs = new List<Lab>();
            foreach (var lab in this.DTLManagementClient.Labs.ListByResourceGroup(resoureGroupName))
            {
                labs.Add(lab);
            }
            return labs;
        }

        public Lab GetLab(string resoureGroupName, string labName)
        {
            return this.DTLManagementClient.Labs.Get(resoureGroupName, labName).Lab;
        }

        public List<Environment> ListEnvironments()
        {
            List<Environment> environments = new List<Environment>();
            foreach (var environment in this.DTLManagementClient.Environments.ListAll())
            {
                environments.Add(environment);
            }
            return environments;
        }

        public List<Environment> ListEnvironmentByResourceGroup(string resourceGroupName)
        {
            List<Environment> environments = new List<Environment>();
            foreach (var environment in this.DTLManagementClient.Environments.ListByResourceGroup(resourceGroupName))
            {
                environments.Add(environment);
            }
            return environments;
        }

        public List<Environment> ListEnvironmentByLab(string resourceGroupName, string labName)
        {
            List<Environment> environments = new List<Environment>();
            foreach (var environment in this.DTLManagementClient.Environments.ListByLab(labName, resourceGroupName))
            {
                environments.Add(environment);
            }
            return environments;
        }

        public Environment GetEnvironment(string resourceGroupName, string environmentName)
        {
            return this.DTLManagementClient.Environments.Get(resourceGroupName, environmentName).Environment;
        }

        public List<VMTemplate> ListVMTemplatesByLab(string labName, string resourceGroupName)
        {
            List<VMTemplate> vmTemplates = new List<VMTemplate>();
            foreach (var vmTemplate in this.DTLManagementClient.VMTemplates.ListByLab(labName, resourceGroupName))
            {
                vmTemplates.Add(vmTemplate);
            }
            return vmTemplates;
        }

        public VMTemplate GetVMTemplate(string labName, string resourceGroupName, string vmTemplateName)
        {
            return this.DTLManagementClient.VMTemplates.Get(resourceGroupName, labName, vmTemplateName).VMTemplate;
        }

    }
}