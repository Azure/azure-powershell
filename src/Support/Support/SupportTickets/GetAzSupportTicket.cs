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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Support.SupportTickets
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "SupportTicket", DefaultParameterSetName = ListParameterSet, SupportsPaging = true), 
        OutputType(typeof(PSSupportTicket))]
    public class GetAzSupportTicket : AzSupportCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet, HelpMessage = "Name of support ticket that this cmdlet gets.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet, HelpMessage = "Filter to be applied to the results of this cmdlet.")]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (this.Name != null)
                {
                    var result = this.SupportClient.SupportTickets.Get(this.Name);
                    this.WriteObject(result.ToPSSupportTicket());
                }
                else
                {
                    this.SkipNObjects(out var supportTicketPage, out var supportTickets);

                    var result = new List<SupportTicketDetails>(supportTickets);

                    // Retrieve all tickets
                    if (!this.MyInvocation.BoundParameters.ContainsKey("First"))
                    {
                        this.WriteAllObjects(supportTicketPage, result);
                    }
                    else
                    {
                        // Need to retrieve remaining tickets
                        this.WriteFirstNObjects(supportTicketPage, result);
                    }
                }
            }
            catch (ExceptionResponseException ex)
            {
                throw new PSArgumentException(string.Format("Error response received. Error Message: '{0}'",
                                     ex.Response.Content));
            }
        }

        private void WriteFirstNObjects(IPage<SupportTicketDetails> supportTicketPage, List<SupportTicketDetails> result)
        {
            var remainingFirst = this.MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;

            if (remainingFirst <= (ulong)result.Count)
            {
                this.WriteObject(result.Take((int)remainingFirst).Select(x => x.ToPSSupportTicket()).ToList());
                return;
            }

            if (remainingFirst > (ulong)result.Count)
            {
                remainingFirst -= (uint)result.Count;
                while (remainingFirst > 0 && supportTicketPage != null && !string.IsNullOrWhiteSpace(supportTicketPage.NextPageLink))
                {
                    supportTicketPage = this.SupportClient.SupportTickets.ListNext(supportTicketPage.NextPageLink);
                    var resultsAdded = (int)Math.Min((ulong)supportTicketPage.Count(), remainingFirst);
                    result.AddRange(supportTicketPage.Take(resultsAdded));
                    remainingFirst -= (ulong)resultsAdded;
                }
            }

            this.WriteObject(result.Select(x => x.ToPSSupportTicket()).ToList());
        }

        private void WriteAllObjects(IPage<SupportTicketDetails> supportTicketPage, List<SupportTicketDetails> result)
        {
            while (supportTicketPage != null && !string.IsNullOrWhiteSpace(supportTicketPage.NextPageLink))
            {
                supportTicketPage = this.SupportClient.SupportTickets.ListNext(supportTicketPage.NextPageLink);
                result.AddRange(supportTicketPage);
            }

            this.WriteObject(result.Select(x => x.ToPSSupportTicket()).ToList());
        }

        private void SkipNObjects(out IPage<SupportTicketDetails> supportTicketPage, out IEnumerable<SupportTicketDetails> supportTickets)
        {
            var remainingSkip = this.MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;

            supportTicketPage = this.SupportClient.SupportTickets.List(filter: this.Filter);

            var actualSkipCount = Math.Min(remainingSkip, (uint)supportTicketPage.Count());

            supportTickets = supportTicketPage.Skip((int)actualSkipCount);
            remainingSkip -= actualSkipCount;

            // Skip more
            while (remainingSkip > 0 &&
                   supportTicketPage != null &&
                   !string.IsNullOrWhiteSpace(supportTicketPage.NextPageLink))
            {
                supportTicketPage = this.SupportClient.SupportTickets.ListNext(supportTicketPage.NextPageLink);
                actualSkipCount = Math.Min(remainingSkip, (uint)supportTicketPage.Count());
                supportTickets = supportTicketPage.Skip((int)actualSkipCount);
                remainingSkip -= actualSkipCount;
            }
        }
    }
}
