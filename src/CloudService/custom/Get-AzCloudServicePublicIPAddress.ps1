
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Get the public IP address of a cloud service.
.Description
Get the public IP address of a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/get-AzCloudServicePublicIPAddress
#>
function Get-AzCloudServicePublicIPAddress {
    param(
        [string] $SubscriptionId,

        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [string] $ResourceGroupName,
        
        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [string] $CloudServiceName,

        [Parameter(Mandatory=$true, ParameterSetName="CloudService")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService] $CloudService,

        [Parameter(DontShow)]
        [string] $ApiVersion = "2020-06-01"

    )
    process {

        if (-not $PSBoundParameters.ContainsKey("SubscriptionId")) 
        {
            $SubscriptionId = (Get-AzContext).Subscription.Id
        }

        if ($PSBoundParameters.ContainsKey("CloudService"))
        {
            $elements = $CloudService.Id.Split("/")
            $SubscriptionId = $elements[2]
            $ResourceGroupName = $elements[4]
            $CloudServiceName = $CloudService.Name
        }

        # Create the URI as per the input
        $uriToInvoke = "/subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.Compute/cloudServices/" + $CloudServiceName + "/publicIPAddresses?api-version=" + $ApiVersion

        # Invoke and display the information
        $result = Az.Accounts\Invoke-AzRestMethod -Method GET -Path $uriToInvoke
        $result.Content
    }
}
