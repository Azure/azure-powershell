
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
Get the network interfaces of a cloud service.
.Description
Get the network interfaces of a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/get-AzCloudServiceNetworkInterfaces
#>

function Get-AzCloudServiceNetworkInterfaces {
    param(
        [Parameter(ParameterSetName="CloudServiceName", HelpMessage="Subscription.")]
        [Parameter(ParameterSetName = "CloudService", HelpMessage="Subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName", HelpMessage="ResourceGroupName.")]
        [string] $ResourceGroupName,
        
        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName", HelpMessage="CloudServiceName.")]
        [string] $CloudServiceName,

        [Parameter(ParameterSetName="CloudServiceName", HelpMessage="RoleInstanceName.")]
        [Parameter(ParameterSetName = "CloudService", HelpMessage="RoleInstanceName.")]
        [string] $RoleInstanceName,

        [Parameter(Mandatory=$true, ParameterSetName="CloudService", HelpMessage="CloudService instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService] $CloudService,

        [Parameter(DontShow)]
        [string] $ApiVersion = "2020-06-01"

    )
    process {
        if ($PSBoundParameters.ContainsKey("CloudService"))
        {
            $elements = $CloudService.Id.Split("/")
            $SubscriptionId = $elements[2]
            $ResourceGroupName = $elements[4]
            $CloudServiceName = $CloudService.Name
        }

        # Create the URI as per the input
        if ($PSBoundParameters.ContainsKey("RoleInstanceName"))
        {
            $uriToInvoke = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Compute/cloudServices/$CloudServiceName/roleInstances/$RoleInstanceName/networkInterfaces?api-version=$ApiVersion"
        }
        else
        {
            $uriToInvoke = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Compute/cloudServices/$CloudServiceName/networkInterfaces?api-version=$ApiVersion"
        }

        # Invoke and display the information
        $result = Invoke-AzRestMethod -Method GET -Path $uriToInvoke
        $result.Content
    }
}
