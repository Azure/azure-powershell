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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Properties;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Profile;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using static Microsoft.WindowsAzure.Management.Models.SubscriptionServicePrincipalListResponse;
using Microsoft.WindowsAzure.Management.Models;

namespace Microsoft.WindowsAzure.Commands.Profile
{
    [Cmdlet(VerbsCommon.Remove, "AzureSubscriptionServicePrincipal", DefaultParameterSetName = ServicePrincipalObjectIdParameterSet)]
    [OutputType(typeof(Boolean))]
    public class RemoveAzureSubscriptionServicePrincipal : ServiceManagementBaseCmdlet
    {
        protected const string ServicePrincipalObjectIdParameterSet = "ServicePrincipalObjectIdParameterSet";
        protected RemoveAzureSubscriptionServicePrincipal()
            : base()
        {

        }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "ServicePrincipal Object Id", ParameterSetName = ServicePrincipalObjectIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("ObjectId")]
        public string ServicePrincipalObjectId { get; set; }

        public override void ExecuteCmdlet()
        {
            var response = ManagementClient.SubscriptionServicePrincipals.Delete(ServicePrincipalObjectId);

            WriteObject(true);

        }
    }
}
