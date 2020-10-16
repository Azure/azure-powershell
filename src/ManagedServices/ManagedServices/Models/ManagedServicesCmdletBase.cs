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

namespace Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models
{
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Management.ManagedServices.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The Microsoft Azure Managed Services cmdlets base class.
    /// </summary>
    public abstract class ManagedServicesCmdletBase : AzureRMCmdlet
    {
        public const string SubscriptionScopeStringFormat = "/subscriptions/{0}";

        private PSManagedServicesClient client;

        public PSManagedServicesClient PSManagedServicesClient
        {
            get
            {
                if (this.client == null)
                {
                    this.client = new PSManagedServicesClient(DefaultProfile.DefaultContext);
                }
                return this.client;
            }
            set
            {
                this.client = value;
            }
        }

        protected void WriteRegistrationAssignmentList(IPage<RegistrationAssignment> assignments)
        {
            List<PSRegistrationAssignment> output = new List<PSRegistrationAssignment>();
            assignments?.ForEach(assignment => output.Add(new PSRegistrationAssignment(assignment)));
            WriteObject(output, true);
        }

        protected void WriteRegistrationDefinitionsList(IPage<RegistrationDefinition> definitions)
        {
            List<PSRegistrationDefinition> output = new List<PSRegistrationDefinition>();
            definitions?.ForEach(definition => output.Add(new PSRegistrationDefinition(definition)));
            WriteObject(output, true);
        }

        public string GetDefaultScope()
        {
            return string.Format(ManagedServicesCmdletBase.SubscriptionScopeStringFormat, DefaultContext.Subscription.Id);
        }
    }
}