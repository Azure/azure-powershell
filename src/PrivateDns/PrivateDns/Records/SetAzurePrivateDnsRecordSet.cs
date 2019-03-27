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

namespace Microsoft.Azure.Commands.PrivateDns.Records
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using ProjectResources = Microsoft.Azure.Commands.PrivateDns.Properties.Resources;

    /// <summary>
    /// Updates an existing record set.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsRecordSet", SupportsShouldProcess = true), OutputType(typeof(PSPrivateDnsRecordSet))]
    public class SetAzurePrivateDnsRecordSet : PrivateDnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.")]
        [ValidateNotNullOrEmpty]
        public PSPrivateDnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Does not use the ETag field of the RecordSet parameter for optimistic concurrency checks.")]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            if ((string.IsNullOrWhiteSpace(this.RecordSet.Etag) || this.RecordSet.Etag == "*") && !this.Overwrite.IsPresent)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(PSPrivateDnsRecordSet).Name));
            }

            var recordSetToUpdate = (PSPrivateDnsRecordSet)this.RecordSet.Clone();
                    if (recordSetToUpdate.ZoneName != null)
                    {
                        recordSetToUpdate.ZoneName = TrimTrailingDotInZoneName(recordSetToUpdate.ZoneName);
                    }

            ConfirmAction(
                ProjectResources.Progress_Modifying,
                recordSetToUpdate.Name,
            () =>
            {
                var result = this.PrivateDnsClient.UpdatePrivateDnsRecordSet(recordSetToUpdate, this.Overwrite.IsPresent);

                WriteVerbose(ProjectResources.Success);
                WriteObject(result);
            });
        }
    }
}
