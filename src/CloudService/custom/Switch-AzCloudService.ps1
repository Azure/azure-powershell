
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
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService]
        ${SourceCloudService},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService]
        ${TargetCloudService},
    
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
        if ($SourceCloudService.Location -ne $TargetCloudService.Location) {
            Throw "Two CloudService should be in the same location."
        }
        $SourcePublicIPAddress = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.PublicIPAddress]::New()
        $SourcePublicIPAddress.Id = $SourceCloudService.NetworkProfileLoadBalancerConfiguration.FrontendIPConfiguration.PublicIPAddressId
        $TargetPublicIPAddress = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.PublicIPAddress]::New()
        $TargetPublicIPAddress.Id = $TargetCloudService.NetworkProfileLoadBalancerConfiguration.FrontendIPConfiguration.PublicIPAddressId
        if (SourcePublicIPAddress.Id -eq TargetPublicIPAddress.Id) {
            return $TargetCloudService
        }
        $SourceFrontendIPConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.FrontendIPConfiguration]::New()
        $SourceFrontendIPConfiguration.Id = $SourceCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration.Id
        $SourceFrontendIPConfiguration.PublicIPAddress = $TargetPublicIPAddress
        $TargetFrontendIPConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20200401.FrontendIPConfiguration]::New()
        $TargetFrontendIPConfiguration.Id = $TargetCloudService.NetworkProfileLoadBalancerConfiguration[0].FrontendIPConfiguration.Id
        $TargetFrontendIPConfiguration.PublicIPAddress = $SourcePublicIPAddress
        $Null = $PSBoundParameters.Remove("SourceCloudService")
        $Null = $PSBoundParameters.Remove("TargetCloudService")
        $PSBoundParameters.Add("Location", $SourceCloudService.Location)
        $PSBoundParameters.Add("InputObject", $SourcePublicIPAddress)
        $PSBoundParameters.Add("FrontendIPConfiguration", @($SourceFrontendIPConfiguration, $TargetFrontendIPConfiguration))
        Az.CloudService.internal\Switch-AzCloudServiceLoadBalancerPublicIPAddress @PSBoundParameters
    }
}
