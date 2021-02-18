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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Orders
{
    [Cmdlet(VerbsCommon.New,
         Constants.Order,
         DefaultParameterSetName = CreateByNewParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSStackEdgeOrder))]
    public class StackEdgeOrderNewCmdlet : AzureStackEdgeCmdletBase
    {
        private const string CreateByNewParameterSet = "CreateByNewParameterSet";

        [Parameter(Mandatory = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = Constants.NameHelpMessage,
            ValueFromPipelineByPropertyName = true,
            Position = 1)]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.ContactPerson)]
        [ValidateNotNullOrEmpty]
        public string ContactPerson { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.CompanyName)]
        [ValidateNotNullOrEmpty]
        public string CompanyName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.Phone)]
        [ValidateNotNullOrEmpty]
        public string Phone { get; set; }


        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.Email)]
        [ValidateNotNullOrEmpty]
        public string[] Email { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.AddressLine1)]
        [ValidateNotNullOrEmpty]
        public string AddressLine1 { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.PostalCode)]
        [ValidateNotNullOrEmpty]
        public string PostalCode { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.City)]
        [ValidateNotNullOrEmpty]
        public string City { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.State)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = HelpMessageOrder.Country)]
        [ValidateNotNullOrEmpty]
        public string Country { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.AddressLine2)]
        [ValidateNotNullOrEmpty]
        public string AddressLine2 { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = HelpMessageOrder.AddressLine3)]
        [ValidateNotNullOrEmpty]
        public string AddressLine3 { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }


        private Order GetResourceModel()
        {
            return this.StackEdgeManagementClient.Orders.Get(
                this.DeviceName,
                this.ResourceGroupName);
        }

        private string GetResourceAlreadyExistMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageOrder.ObjectName, Constants.ResourceAlreadyExists, this.DeviceName);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                throw new Exception(GetResourceAlreadyExistMessage());
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSStackEdgeOrder CreateResourceModel()
        {
            var contactDetails = new ContactDetails(ContactPerson, CompanyName, Phone, Email);
            var address = new Address(AddressLine1, PostalCode, City, State, Country, AddressLine2, AddressLine3);
            if (this.IsParameterBound(c => c.AddressLine2))
            {
                address.AddressLine2 = this.AddressLine2;
            }

            if (this.IsParameterBound(c => c.AddressLine3))
            {
                address.AddressLine3 = this.AddressLine3;
            }

            var order = new Order(contactDetails, address);
            var psResourceModel = new PSStackEdgeOrder(
                this.StackEdgeManagementClient.Orders.CreateOrUpdate(
                    this.DeviceName,
                    order,
                    this.ResourceGroupName));
            return psResourceModel;
        }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess(this.DeviceName,
                string.Format("Creating '{0}' with name '{1}'.",
                    HelpMessageOrder.ObjectName, this.DeviceName)))
            {
                DoesResourceExists();
                var results = new List<PSStackEdgeOrder>
                {
                    CreateResourceModel()
                };
                WriteObject(results, true);
            }
        }
    }
}