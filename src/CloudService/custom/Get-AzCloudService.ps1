
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
Display information about a cloud service.
.Description
Display information about a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/get-azcloudservice
#>
function Get-AzCloudService {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudService], [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceInstanceView])]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Alias('CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the cloud service
        ${Name},
    
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='List1', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the Resource Group
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='Get')]
        [Parameter(ParameterSetName='List')]
        [Parameter(ParameterSetName='List1')]
        [Parameter(ParameterSetName='GetInstanceView')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='GetInstanceViewViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceViewViaIdentity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Name of the role instance
        ${InstanceView},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
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
        if ($PSBoundParameters.ContainsKey('InstanceView')) {
            $Null = $PSBoundParameters.Remove('InstanceView')
            $Null = $PSBoundParameters.Remove('Name')
            $PSBoundParameters.Add("CloudServiceName", $Name)
            Az.CloudService.internal\Get-AzCloudServiceInstanceView @PSBoundParameters
        } else {
            Az.CloudService.internal\Get-AzCloudService @PSBoundParameters
        }
    }
}
