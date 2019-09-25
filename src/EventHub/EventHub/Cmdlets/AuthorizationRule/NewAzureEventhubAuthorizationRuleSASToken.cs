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

using System.Management.Automation;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.EventHub.Models;
using System;
using System.Security.Cryptography;
using System.Web;
using System.Globalization;
using System.Text;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'New-AzEventHubAuthorizationRuleSASToken' Cmdlet creates a new AuthorizationRule
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubAuthorizationRuleSASToken", DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSharedAccessSignatureAttributes))]
    public class NewAzureAuthorizationRuleSASToken : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "ARM ResourceId of the Authoraization Rule")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceId)]
        public string AuthorizationRuleId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Key Type")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Primary", "Secondary")]
        public string KeyType { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Expiry Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true,  HelpMessage = "Start Time")]
        [ValidateNotNullOrEmpty]
        public DateTime? StartTime { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                LocalResourceIdentifier identifier = new LocalResourceIdentifier(AuthorizationRuleId);
                string resourceUri = string.Empty, strPolicyName = string.Empty, sakey = string.Empty;

                PSListKeysAttributes listkeys;
                if (identifier.ParentResource1 != null)
                {
                    listkeys =  Client.GetEventHubListKeys(identifier.ResourceGroupName, identifier.ParentResource, identifier.ParentResource1, identifier.ResourceName);
                }
                else
                {
                    listkeys = Client.GetNamespaceListKeys(identifier.ResourceGroupName, identifier.ParentResource, identifier.ResourceName);
                }

                string[] connectionstring = KeyType == "Primary" ? listkeys.PrimaryConnectionString.Split(';') : listkeys.SecondaryConnectionString.Split(';');

                switch (connectionstring.Length)
                {
                    case 4:
                        {
                            resourceUri = connectionstring[0].Replace("Endpoint=sb://", "") + connectionstring[3].Replace("EntityPath=", "");
                            strPolicyName = connectionstring[1].Replace("SharedAccessKeyName=", "");
                            sakey = connectionstring[2].Replace("SharedAccessKey=", "");
                            break;
                        }
                    case 3:
                        {
                            resourceUri = connectionstring[0].Replace("Endpoint=sb://", "");
                            strPolicyName = connectionstring[1].Replace("SharedAccessKeyName=", "");
                            sakey = connectionstring[2].Replace("SharedAccessKey=", "");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                string stringToSign = StartTime.HasValue ? StartTime.ToString() + "\n" + System.Web.HttpUtility.UrlEncode(resourceUri) + "\n" + ExpiryTime.ToString() : System.Web.HttpUtility.UrlEncode(resourceUri) + "\n" + ExpiryTime.ToString();
                HMACSHA256 hmac = new HMACSHA256(System.Text.Encoding.UTF8.GetBytes(sakey));
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
                string sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), ExpiryTime, KeyType);
                PSSharedAccessSignatureAttributes psSastoken = new PSSharedAccessSignatureAttributes(sasToken);
                WriteObject(psSastoken, true);

            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
