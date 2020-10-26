
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
Gets a role instance from a cloud service.
.Description
Gets a role instance from a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/get-azcloudserviceroleinstance
#>
function Get-AzCloudServiceRoleInstance {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IRoleInstance], [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceInstanceView])]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='List', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # .
        ${CloudServiceName},
    
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='List', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # .
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the role instance
        ${RoleInstanceName},
    
        [Parameter(ParameterSetName='Get')]
        [Parameter(ParameterSetName='List')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='GetInstanceView', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Name of the role instance
        ${InstanceView},
    
        [Parameter(ParameterSetName='Get')]
        [Parameter(ParameterSetName='List')]
        [Parameter(ParameterSetName='GetViaIdentity')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.InstanceViewTypes])]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.InstanceViewTypes]
        # The expand expression to apply to the operation.
        ${Expand},
    
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
            Az.CloudService.internal\Get-AzCloudServiceRoleInstanceView @PSBoundParameters
        } else {
            Az.CloudService.internal\Get-AzCloudServiceRoleInstance @PSBoundParameters
        }
    }
}
    