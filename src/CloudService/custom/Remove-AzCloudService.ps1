
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
Deletes a cloud service.
.Description
Deletes a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/remove-azcloudservice
#>
function Remove-AzCloudService {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(ParameterSetName='Delete', Mandatory)]
        [Parameter(ParameterSetName='DeleteRoleInstance', Mandatory)]
        [Alias('CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the cloud service
        ${Name},
    
        [Parameter(ParameterSetName='Delete', Mandatory)]
        [Parameter(ParameterSetName='DeleteRoleInstance', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the Resource Group
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='Delete')]
        [Parameter(ParameterSetName='DeleteRoleInstance')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(ParameterSetName='DeleteRoleInstance', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.String]
        # Name of the role instance.
        ${RoleInstance},
    
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
        if ($PSBoundParameters.ContainsKey('RoleInstance')) {
            $PSBoundParameters.Add('CloudServiceName', $Name)
            $PSBoundParameters.Add('RoleInstanceName', $RoleInstance)
            $Null = $PSBoundParameters.Remove('Name')
            $Null = $PSBoundParameters.Remove('RoleInstance')
            if ($PSCmdlet.ShouldProcess("Will remove role instance $RoleInstance?")) {
                Az.CloudService.internal\Remove-AzCloudServiceRoleInstance @PSBoundParameters
            }
        } else {
            if ($PSCmdlet.ShouldProcess("Will remove cloud service?")) {
                Az.CloudService.internal\Remove-AzCloudService @PSBoundParameters
            }
        }
    }
}
