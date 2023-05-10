
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
Swaps VIPs between two cloud service (extended support) load balancers.
.Description
Swaps VIPs between two cloud service (extended support) load balancers.

.Link
https://learn.microsoft.com/powershell/module/az.cloudservice/Switch-AzCloudService

#>
function Switch-AzCloudService {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='CloudServiceName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
    
        [Parameter(ParameterSetName='CloudService')]
        [Parameter(ParameterSetName='CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(Mandatory=$true, ParameterSetName="CloudService")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudService]
        ${CloudService},
    
        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        ${ResourceGroupName},
        
        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String] 
        ${CloudServiceName},

        [Parameter()]
        [switch] 
        ${Async},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break}
    )
    
    process {
        $ApiVersion = "2020-06-01"
        if (-not $PSBoundParameters.ContainsKey("SubscriptionId")) {
            $SubscriptionId = (Get-AzContext).Subscription.Id
        }

        # Fetch the services to ensure that we have the latest information
        if ($PSBoundParameters.ContainsKey("CloudService")) {
            $CloudServiceName = $CloudService.Name
            $ResourceGroupName = $CloudService.ResourceGroupName
        }

        $SourceCloudService = Get-AzCloudService -SubscriptionId $SubscriptionId -Name $CloudServiceName -ResourceGroupName $ResourceGroupName

        # Check that both have swappable property set.
        if ([string]::IsNullOrEmpty($SourceCloudService.NetworkProfile.SwappableCloudService.Id)) {
            throw "SwappableCloudServiceId is not set on the source cloud service $($SourceCloudService.Name)"
        }

        # Check that Public IPs counts are correct for source
        $validSourceIP = ValidateCloudServicePublicIPAddress($SourceCloudService)
        if ($validSourceIP -eq $false) {
            throw "Specified source cloud service must have a single public IP address specified in its FrontendIpConfigurations." 
        }
  
        # Parse target cloud service fields
        $elements = $SourceCloudService.NetworkProfile.SwappableCloudService.Id.Split("/")
        if (($elements.Count -lt 9) -or ("subscriptions" -ne $elements[1]) -or ("resourceGroups" -ne $elements[3]) -or ("cloudServices" -ne $elements[7]))
        {
            throw "SourceCloudService.NetworkProfile.SwappableCloudService.Id should match the format: /subscriptions/(?<TargetSubscriptionId>[^/]+)/resourceGroups/(?<TargetResourceGroupName>[^/]+/providers/Microsoft.Compute/cloudServices/(?<TargetCloudServiceName>[^/]+))"
        }
        $TargetSubscriptionId = $elements[2]
        $TargetResourceGroupName = $elements[4]
        $TargetCloudServiceName = $elements[8]
 
        # Fetch the target cloud service 
        $TargetCloudService = Get-AzCloudService -SubscriptionId $TargetSubscriptionId -Name $TargetCloudServiceName -ResourceGroupName $TargetResourceGroupName

        # Check that Public IPs counts are correct for target
        $validTargetIP = ValidateCloudServicePublicIPAddress($TargetCloudService)
        if ($validTargetIP -eq $false) {
            throw "Specified target cloud service must have a single public IP address specified in its FrontendIpConfigurations." 
        }

        # Get the LBs and FrontEndIpConfigs to create the request body
        $sourceLB = GetCloudServiceLoadBalancer($SubscriptionId, $ResourceGroupName, $SourceCloudService.NetworkProfile.LoadBalancerConfiguration[0].Name, $ApiVersion)
        $validSourceLB = ValidateLoadBalancerFrontEndIPConfiguration($sourceLB)
        if ($validSourceLB -eq $false) {
            throw "Source loadbBalancer must have a single value in its FrontendIpConfigurations." 
        }

        $targetLB =  GetCloudServiceLoadBalancer($TargetSubscriptionId, $TargetResourceGroupName, $TargetCloudService.NetworkProfile.LoadBalancerConfiguration[0].Name, $ApiVersion)      
        $validTargetLB = ValidateLoadBalancerFrontEndIPConfiguration($targetLB)
        if ($validTargetLB -eq $false) {
            throw "Target loadbBalancer must have a single value in its FrontendIpConfigurations." 
        }

        # Construct the request body
        $requestBody = GetVIPSwapRequestBody
        $requestBody = $requestBody -replace "#LBFE1#", $sourceLB.properties.frontendIPConfigurations[0].Id
        $requestBody = $requestBody -replace "#PIP2#", $TargetCloudService.NetworkProfile.LoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId
        $requestBody = $requestBody -replace "#LBFE2#", $targetLB.properties.frontendIPConfigurations[0].Id
        $requestBody = $requestBody -replace "#PIP1#", $SourceCloudService.NetworkProfile.LoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId

        # Set up API URI and Headers
        $uriToInvoke = "/subscriptions/$SubscriptionId/providers/Microsoft.Network/locations/$($SourceCloudService.Location)/setLoadBalancerFrontendPublicIpAddresses?api-version=$ApiVersion"

        # Display the information about the VIP swap being made
        Write-Host "Performing switch cloud service (VIP swap) action between $($SourceCloudService.Name) and $($TargetCloudService.Name)

Request URI : $uriToInvoke
POST

Request Body :
$requestBody"

        # Invoke the VIP swap API
        if ($PSCmdlet.ShouldProcess($SourceCloudService.Name + " <=> " + $TargetCloudService.Name,'VIP swap')) {
            $result = Invoke-AzRestMethod -Method POST -Path $uriToInvoke -Payload $requestBody 

            if ($Async.IsPresent) {
                Write-Host "Query the Azure-AsyncOperation URI from the response for operation progress"
                return $result
            }
            else {
               if ($result.StatusCode -eq 202) {
                   QueryVipSwapOperation($result)
               }
               else {
                   return $result
               }
            }
        }
    }
}

function QueryVipSwapOperation($result) {

    $uri = [System.Uri]($result.Headers.GetValues('Azure-AsyncOperation')[0]);
    $uriToInvoke = $uri.PathAndQuery
    $retryLimit = 100
    $retry = 0

    while ($retry -lt $retryLimit) {
        $statusResult = Invoke-AzRestMethod -Method GET -Path $uriToInvoke  
        if ($statusResult.StatusCode -eq 200) {
            $status = $statusResult.Content | ConvertFrom-Json
            if (-not $status.status.Equals("InProgress",[System.StringComparison]::OrdinalIgnoreCase)) {
                return $statusResult
            }

            $retry++
            Write-Progress -Activity "Performing VIP swap" -PercentComplete $retry -CurrentOperation "Status : InProgress"

            Start-Sleep -Seconds 10
        }
    }
}

function ValidateLoadBalancerFrontEndIPConfiguration($lb) {

    if ($lb.properties.frontendIPConfigurations.Count -eq 1) {   
        if (-not [string]::IsNullOrEmpty($lb.properties.frontendIPConfigurations[0].Id)) {
            return $true;
        }
    }

    return $false;
}

function ValidateCloudServicePublicIPAddress($cs) {

    if ($cs.NetworkProfile.LoadBalancerConfiguration.Count -eq 1) {
        if ($cs.NetworkProfile.LoadBalancerConfiguration[0].FrontendIPConfiguration.Count -eq 1) {
            if (-not [string]::IsNullOrEmpty($cs.NetworkProfile.LoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId)) {
                return $true;
            }
        }
    }

    return $false;
}

function GetCloudServiceLoadBalancer($parameters) {

    # Set up API URI and Headers
    $uriToInvoke = "/subscriptions/" + $parameters[0] + "/resourceGroups/" + $parameters[1] + "/providers/Microsoft.Network/loadBalancers/" + $parameters[2] + "?api-version=" + $parameters[3]
    $lbResponse = Invoke-AzRestMethod -Method GET -Path $uriToInvoke
    if ($lbResponse.StatusCode -ne 200) {
       throw $lbResponse.Content
    }

    $lb = $lbResponse.Content | ConvertFrom-Json
    return $lb
}

function GetVIPSwapRequestBody() {

    return @"
{
	"frontendIPConfigurations": [
		{
			"id": "#LBFE1#",
			"properties": {
				"publicIPAddress": {
					"id": "#PIP2#"
				}
			}
		},
		{
			"id": "#LBFE2#",
			"properties": {
				"publicIPAddress": {
					"id": "#PIP1#"
				}
			}
		}
	]
}
"@
}

