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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.CloudService
{
    [Cmdlet(VerbsCommon.New, "WAPackCloudService")]
    public class NewWAPackCloudService : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "CloudService Name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "CloudService Label.")]
        [ValidateNotNullOrEmpty]
        public string Label
        {
            get;
            set;
        }

        public override void ExecuteCmdlet()
        {
            var cloudService = new Utilities.WAPackIaaS.DataContract.CloudService()
            {
                Name = this.Name,
                Label = this.Label
            };

            Guid? cloudServiceJobId = Guid.Empty;
            var cloudServiceOperations = new CloudServiceOperations(this.WebClientFactory);
            cloudServiceOperations.Create(cloudService, out cloudServiceJobId);
            WaitForJobCompletion(cloudServiceJobId);

            var createdCloudService = cloudServiceOperations.Read(this.Name);
            var results = new List<Utilities.WAPackIaaS.DataContract.CloudService>() { createdCloudService };
            this.GenerateCmdletOutput(results);
        }
    }
}
