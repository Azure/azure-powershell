// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Cdn.AfdModels
{
    public class PSAfdOrigin : PSArmBaseResource
    {
        public string OriginGroupName { get; set; }

        public string HostName { get; set; }

        public int? HttpPort { get; set; }

        public int? HttpsPort { get; set; }

        public string OriginHostHeader { get; set; }

        public int? Priority { get; set; }

        public int? Weight { get; set; }

        public string EnabledState { get; set; }

        public string PrivateLinkId { get; set; }

        public string GroupId { get; set; }

        public string PrivateLinkLocation { get; set; }

        public string PrivateLinkStatus { get; set; }

        public string PrivateLinkRequestMessage { get; set; }
    }
}

/*
      "id": "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourcegroups/jomejia-dev-resourcegroup/providers/Microsoft.Cdn/profiles/jomejia-dev-afdx-profile-1/originGroups/jomejia-dev-afdx-origingroup-1/origins/jomejia-dev-afdx-origin-1",
      "type": "Microsoft.Cdn/profiles/originGroups/origins",
      "name": "jomejia-dev-afdx-origin-1",
      "properties": {
        "originGroupName": "jomejia-dev-afdx-origingroup-1",
        "hostName": "contoso.com",
        "httpPort": 80,
        "httpsPort": 443,
        "originHostHeader": null,
        "priority": 3,
        "weight": 200,
        "enabledState": "Enabled",
        "sharedPrivateLinkResource": {
          "privateLink": {
            "id": "/subscriptions/da61bba1-cbd5-438c-a738-c717a6b2d59f/resourceGroups/moeidrg/providers/Microsoft.Network/privateLinkServices/pls-east-3"
          },
          "groupId": null,
          "privateLinkLocation": "eastus",
          "status": null,
          "requestMessage": "Private link service from AFD"
        },
        "provisioningState": "Succeeded",
        "deploymentStatus": "NotStarted" 

 */
