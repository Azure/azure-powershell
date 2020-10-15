
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
Swaps VIPs between two load balancers.
.Description
Swaps VIPs between two load balancers.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.ILoadBalancerVipSwapRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FRONTENDIPCONFIGURATION <ILoadBalancerVipSwapRequestFrontendIPConfiguration[]>: A list of frontend IP configuration resources that should swap VIPs.
  [Id <String>]: The ID of frontend IP configuration resource.
  [PublicIPAddressId <String>]: Resource ID.


PARAMETER <ILoadBalancerVipSwapRequest>: The request for a VIP swap.
  [FrontendIPConfiguration <ILoadBalancerVipSwapRequestFrontendIPConfiguration[]>]: A list of frontend IP configuration resources that should swap VIPs.
    [Id <String>]: The ID of frontend IP configuration resource.
    [PublicIPAddressId <String>]: Resource ID.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/switch-azcloudserviceloadbalancerpublicipaddress
#>
function Switch-AzCloudService {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='Swap', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
    
        [Parameter(ParameterSetName='Swap')]
        [Parameter(ParameterSetName='CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(Mandatory=$true, ParameterSetName="CloudService")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService]
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
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if (-not $PSBoundParameters.ContainsKey("SubscriptionId")) {
            $SubscriptionId = (Get-AzContext).Subscription.Id
        }

        # Fetch the services to ensure that we have the latest information
        if ($PSBoundParameters.ContainsKey("CloudService"))
        {
            $CloudServiceName = $CloudService.Name     
        }

        $SourceCloudService = Get-AzCloudService -SubscriptionId $SubscriptionId -Name $CloudServiceName -ResourceGroupName $ResourceGroupName

        # Check that both have swappable property set.
        if ([string]::IsNullOrEmpty($SourceCloudService.SwappableCloudServiceId))
        {
            throw "SwappableCloudServiceId is not set on the source cloud service " + $SourceCloudService.Name 
        }

        # Check that Public IPs counts are correct for source
        $validSourceIP = ValidateCloudServicePublicIPAddress($SourceCloudService)
        if ($validSourceIP -eq $false)
        {
            throw "Specified source cloud service must have a single public IP address specified in its FrontendIpConfigurations." 
        }
  
        # Parse target cloud service fields
        $elements = $SourceCloudService.SwappableCloudServiceId.Split("/")
        $TargetSubscriptionId = $elements[2]
        $TargetResourceGroupName = $elements[4]
        $TargetCloudServiceName = $elements[8]
 
        # Fetch the target cloud service 
        $TargetCloudService = Get-AzCloudService -SubscriptionId $TargetSubscriptionId -Name $TargetCloudServiceName -ResourceGroupName $TargetResourceGroupName

        # Check that Public IPs counts are correct for target
        $validTargetIP = ValidateCloudServicePublicIPAddress($TargetCloudService)
        if ($validTargetIP -eq $false)
        {
            throw "Specified target cloud service must have a single public IP address specified in its FrontendIpConfigurations." 
        }

        # Get the LB FrontEndIpConfigs to create the request body
        $sourceLB = Get-AzLoadBalancer -ResourceGroupName $ResourceGroupName -Name $SourceCloudService.NetworkProfileLoadBalancerConfiguration.Name
        $validSourceLB = ValidateLoadBalancerFrontEndIPConfiguration($sourceLB)
        if ($validSourceLB -eq $false)
        {
            throw "Source loadbBalancer must have a single value in its FrontendIpConfigurations." 
        }

        $targetLB = Get-AzLoadBalancer -ResourceGroupName $TargetResourceGroupName -Name $TargetCloudService.NetworkProfileLoadBalancerConfiguration.Name        
        $validTargetLB = ValidateLoadBalancerFrontEndIPConfiguration($targetLB)
        if ($validTargetLB -eq $false)
        {
            throw "Target loadbBalancer must have a single value in its FrontendIpConfigurations." 
        }

        # Construct the request body
        $requestBody = GetVIPSwapRequestBody
        $requestBody = $requestBody -replace "#LBFE1#", $sourceLB.FrontendIpConfigurations[0].Id
        $requestBody = $requestBody -replace "#PIP2#", $TargetCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId
        $requestBody = $requestBody -replace "#LBFE2#", $targetLB.FrontendIpConfigurations[0].Id
        $requestBody = $requestBody -replace "#PIP1#", $SourceCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId

        # Set up API URI and Headers
        $uriToInvoke = "/subscriptions/" + $SubscriptionId + "/providers/Microsoft.Network/locations/" + $SourceCloudService.Location + "/setLoadBalancerFrontendPublicIpAddresses?api-version=" + $ApiVersion

        # Display the information about the VIP swap being made
        Write-Host "Performing switch cloud service action between" $SourceCloudService.Name "and" $TargetCloudService.Name
        Write-Host "Request URI :"
        Write-Host "POST " $uriToInvoke
        Write-Host "Request Body :"
        Write-Host $requestBody

        # Invoke the VIP swap API
        if ($PSCmdlet.ShouldProcess($SourceCloudService.Name,'Switch Cloud Service')) 
        {
            $SourcePublicIPAddress = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.PublicIPAddress]::New()
            $SourcePublicIPAddress.Id = $SourceCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId
            $TargetPublicIPAddress = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.PublicIPAddress]::New()
            $TargetPublicIPAddress.Id = $TargetCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId
        
            $SourceFrontendIPConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.FrontendIPConfiguration]::New()
            $SourceFrontendIPConfiguration.Id = $sourceLB.FrontendIpConfigurations[0].Id
            $SourceFrontendIPConfiguration.PublicIPAddress = $TargetPublicIPAddress
            $TargetFrontendIPConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.FrontendIPConfiguration]::New()
            $TargetFrontendIPConfiguration.Id = $targetLB.FrontendIpConfigurations[0].Id
            $TargetFrontendIPConfiguration.PublicIPAddress = $SourcePublicIPAddress

            $Null = $PSBoundParameters.Remove("CloudService")
            $Null = $PSBoundParameters.Remove("CloudServiceName")
            $Null = $PSBoundParameters.Remove("ResourceGroupName")

            $PSBoundParameters.Add("Location", $SourceCloudService.Location)
            $PSBoundParameters.Add("FrontendIPConfiguration", @($SourceFrontendIPConfiguration, $TargetFrontendIPConfiguration))
            Az.CloudService.internal\Switch-AzCloudServiceLoadBalancerPublicIPAddress @PSBoundParameters
        }
    }
}

function ValidateLoadBalancerFrontEndIPConfiguration($lb)
{
    if ($lb.FrontendIpConfigurations.Count -eq 1)
    {   
        if (-not [string]::IsNullOrEmpty($lb.FrontendIpConfigurations[0].Id))
        {
            return $true;
        }
    }

    return $false;
}

function ValidateCloudServicePublicIPAddress($cs)
{
    if ($cs.NetworkProfileLoadBalancerConfiguration.Count -eq 1)
    {
        if ($cs.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration.Count -eq 1)
        {
            if (-not [string]::IsNullOrEmpty($cs.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration[0].PublicIPAddressId))
            {
                return $true;
            }
        }
    }

    return $false;
}

function GetVIPSwapRequestBody()
{
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

