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
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations;

namespace Microsoft.WindowsAzure.Commands.WAPackIaaS.Networking
{
    [Cmdlet(VerbsCommon.Remove, "WAPackStaticIPAddressPool")]
    public class RemoveWAPackStaticIPAddressPool : IaaSCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Existing StaticIPAddressPool Object.")]
        [ValidateNotNullOrEmpty]
        public StaticIPAddressPool StaticIPAddressPool
        {
            get;
            set;
        }

        [Parameter(Position = 1, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Position = 2, HelpMessage = "Confirm the removal of the StaticIPAddressPool.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
            Force.IsPresent,
            string.Format(Resources.RemoveStaticIPAddressPoolConfirmationMessage, StaticIPAddressPool.Name),
            string.Format(Resources.RemoveStaticIPAddressPoolMessage), StaticIPAddressPool.Name,
            () =>
            {
                Guid? jobId = Guid.Empty;
                var staticIPAddressPoolOperations = new StaticIPAddressPoolOperations(this.WebClientFactory);

                var filter = new Dictionary<string, string>
                {
                    {"StampId", StaticIPAddressPool.StampId.ToString()},
                    {"ID ", StaticIPAddressPool.ID.ToString()}
                };
                var deletedSstaticIPAddressPool = staticIPAddressPoolOperations.Read(filter)[0];
                staticIPAddressPoolOperations.Delete(deletedSstaticIPAddressPool.ID, out jobId);
                var jobInfo = WaitForJobCompletion(jobId);
                
                if (this.PassThru)
                {
                    WriteObject(jobInfo.jobStatus != JobStatusEnum.Failed);
                }
            });
        }
    }
}
