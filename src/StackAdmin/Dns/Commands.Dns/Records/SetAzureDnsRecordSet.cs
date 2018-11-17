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

using Microsoft.Azure.Commands.Dns.Models;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Updates an existing record set.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmDnsRecordSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(DnsRecordSet))]
    public class SetAzureDnsRecordSet : DnsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set in which to add the record.")]
        [ValidateNotNullOrEmpty]
        public DnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not use the ETag field of the RecordSet parameter for optimistic concurrency checks.", ParameterSetName = "Object")]
        public SwitchParameter Overwrite { get; set; }

        public override void ExecuteCmdlet()
        {
            if ((string.IsNullOrWhiteSpace(this.RecordSet.Etag) || this.RecordSet.Etag == "*") && !this.Overwrite.IsPresent)
            {
                throw new PSArgumentException(string.Format(ProjectResources.Error_EtagNotSpecified, typeof(DnsRecordSet).Name));
            }

            DnsRecordSet recordSetToUpdate = (DnsRecordSet)this.RecordSet.Clone();
                    if (recordSetToUpdate.ZoneName != null && recordSetToUpdate.ZoneName.EndsWith("."))
                    {
                        recordSetToUpdate.ZoneName = recordSetToUpdate.ZoneName.TrimEnd('.');
                        this.WriteWarning(string.Format("Modifying zone name to remove terminating '.'.  Zone name used is \"{0}\".", recordSetToUpdate.ZoneName));
                    }

            ConfirmAction(
                ProjectResources.Progress_Modifying,
                recordSetToUpdate.Name,
            () =>
            {
                DnsRecordSet result = this.DnsClient.UpdateDnsRecordSet(recordSetToUpdate, this.Overwrite.IsPresent);

                WriteVerbose(ProjectResources.Success);

                WriteObject(result);
            });
            }
    }
    }
