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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Models;
using static Microsoft.WindowsAzure.Management.Models.SubscriptionServicePrincipalListResponse;

namespace Microsoft.WindowsAzure.Commands.Profile
{

    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureSubscriptionServicePrincipalNounName)]
    [OutputType(typeof(PSSubscriptionServicePrincipal))]
    public class NewAzureSubscriptionServicePrincipal : ServiceManagementBaseCmdlet
    {
        public NewAzureSubscriptionServicePrincipal() 
            : base()
        {

        }

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "ServicePrincipal Object Id")]
        [ValidateNotNullOrEmpty]
        [Alias("ObjectId")]
        public string ServicePrincipalObjectId { get; set; }


        public override void ExecuteCmdlet()
        {
            try
            {
                ManagementClient.SubscriptionServicePrincipals.Create(new SubscriptionServicePrincipalCreateParameters(ServicePrincipalObjectId));
                SubscriptionServicePrincipalGetResponse response = ManagementClient.SubscriptionServicePrincipals.Get(ServicePrincipalObjectId);
                WriteObject(response.ToPSSubscriptionServicePrincipal());
            }
            catch(Exception ex)
            {
                WriteWarning("Not able to add service principal to the subscription");
                WriteErrorWithTimestamp(ex.Message);
            }
        }
    }
}
