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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.Support.Common;
using Microsoft.Azure.Commands.Support.Helpers;
using Microsoft.Azure.Commands.Support.Models;
using Microsoft.Azure.Management.Support;
using Microsoft.Azure.Management.Support.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Support.Communications
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "SupportTicketCommunication", DefaultParameterSetName = GetByNameParameterSet, SupportsPaging = true), OutputType(typeof(PSSupportTicketCommunication))]
    public class GetAzSupportTicketCommunication : AzSupportCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = "Support ticket name.")]
        [ValidateNotNullOrEmpty]
        public string SupportTicketName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = "Communication name.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = "Communication name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = "Support ticket object.")]
        [ValidateNotNull]
        public PSSupportTicket SupportTicketObject { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByParentObjectParameterSet, HelpMessage = "Filter to be applied to the results of this cmdlet.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSet, HelpMessage = "Filter to be applied to the results of this cmdlet.")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.IsParameterBound(c => c.SupportTicketObject))
                {
                    this.SupportTicketName = this.SupportTicketObject.Name;
                }

                if (this.Name != null)
                {
                    var result = this.SupportClient.Communications.Get(this.SupportTicketName, this.Name);
                    this.WriteObject(result.ToPSSupportTicketCommunication());
                }
                else
                {
                    this.SkipNObjects(out var supportTicketCommunicationPage, out var supportTicketCommunications);

                    var result = new List<CommunicationDetails>(supportTicketCommunications);

                    // Retrieve all communications
                    if (!this.MyInvocation.BoundParameters.ContainsKey("First"))
                    {
                        this.WriteAllObjects(supportTicketCommunicationPage, result);
                    }
                    else
                    {
                        // Need to retrieve remaining communications
                        this.WriteFirstNObjects(supportTicketCommunicationPage, result);
                    }
                }
            }
            catch (ExceptionResponseException ex)
            {
                throw new PSArgumentException(string.Format("Error response received. Error Message: '{0}'",
                                     ex.Response.Content));
            }
        }

        private void WriteFirstNObjects(IPage<CommunicationDetails> supportTicketCommunicationPage, List<CommunicationDetails> result)
        {
            var remainingFirst = this.MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;

            if (remainingFirst <= (ulong)result.Count)
            {
                this.WriteObject(result.Take((int)remainingFirst).Select(x => x.ToPSSupportTicketCommunication()).ToList());
                return;
            }

            if (remainingFirst > (ulong)result.Count)
            {
                remainingFirst -= (ulong)result.Count;
                while (remainingFirst > 0 && supportTicketCommunicationPage != null && !string.IsNullOrWhiteSpace(supportTicketCommunicationPage.NextPageLink))
                {
                    supportTicketCommunicationPage = this.SupportClient.Communications.ListNext(supportTicketCommunicationPage.NextPageLink);
                    var resultsAdded = (int)Math.Min((ulong)supportTicketCommunicationPage.Count(), remainingFirst);
                    result.AddRange(supportTicketCommunicationPage.Take(resultsAdded));
                    remainingFirst -= (ulong)resultsAdded;
                }
            }

            this.WriteObject(result.Select(x => x.ToPSSupportTicketCommunication()).ToList());
        }

        private void WriteAllObjects(IPage<CommunicationDetails> supportTicketCommunicationPage, List<CommunicationDetails> result)
        {
            while (supportTicketCommunicationPage != null && !string.IsNullOrWhiteSpace(supportTicketCommunicationPage.NextPageLink))
            {
                supportTicketCommunicationPage = this.SupportClient.Communications.ListNext(supportTicketCommunicationPage.NextPageLink);
                result.AddRange(supportTicketCommunicationPage);
            }

            this.WriteObject(result.Select(x => x.ToPSSupportTicketCommunication()).ToList());
        }

        private void SkipNObjects(out Rest.Azure.IPage<CommunicationDetails> supportTicketCommunicationPage, out IEnumerable<CommunicationDetails> supportTicketCommunications)
        {
            var remainingSkip = this.MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

            supportTicketCommunicationPage = this.SupportClient.Communications.List(this.SupportTicketName, filter: this.Filter);

            var actualSkipCount = Math.Min(remainingSkip, (uint)supportTicketCommunicationPage.Count());

            supportTicketCommunications = supportTicketCommunicationPage.Skip((int)actualSkipCount);
            remainingSkip -= actualSkipCount;

            // Skip more
            while (remainingSkip > 0 &&
                   supportTicketCommunicationPage != null &&
                   !string.IsNullOrWhiteSpace(supportTicketCommunicationPage.NextPageLink))
            {
                supportTicketCommunicationPage = this.SupportClient.Communications.ListNext(supportTicketCommunicationPage.NextPageLink);
                actualSkipCount = Math.Min(remainingSkip, (uint)supportTicketCommunicationPage.Count());
                supportTicketCommunications = supportTicketCommunicationPage.Skip((int)actualSkipCount);
                remainingSkip -= actualSkipCount;
            }
        }
    }
}
