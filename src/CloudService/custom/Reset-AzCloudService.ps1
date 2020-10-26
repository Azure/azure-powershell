
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
Reimages one or more role instances in a cloud service.
.Description
Reimages one or more role instances in a cloud service.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/Reset-azcloudservice
#>
function Reset-AzCloudService {
    [OutputType([System.Boolean], [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudService])]
    [CmdletBinding(DefaultParameterSetName='ReimageExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ReimageExpanded', Mandatory)]
        [Parameter(ParameterSetName='RebuildExpanded', Mandatory)]
        [Parameter(ParameterSetName='RestartExpanded', Mandatory)]
        [Alias('CloudServiceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the cloud service
        ${Name},
    
        [Parameter(ParameterSetName='ReimageExpanded', Mandatory)]
        [Parameter(ParameterSetName='RebuildExpanded', Mandatory)]
        [Parameter(ParameterSetName='RestartExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [System.String]
        # Name of the Resource Group
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='ReimageExpanded')]
        [Parameter(ParameterSetName='RebuildExpanded')]
        [Parameter(ParameterSetName='RestartExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='ReimageViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='RebuildViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName='RestartViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='ReimageViaIdentityExpanded')]
        [Parameter(ParameterSetName='RebuildViaIdentityExpanded')]
        [Parameter(ParameterSetName='RestartViaIdentityExpanded')]
        [Parameter(ParameterSetName='ReimageExpanded')]
        [Parameter(ParameterSetName='RebuildExpanded')]
        [Parameter(ParameterSetName='RestartExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [System.String[]]
        # .
        ${RoleInstance},
    
        [Parameter(ParameterSetName='RestartExpanded', Mandatory)]
        [Parameter(ParameterSetName='RestartViaIdentityExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTags]))]
        [System.Management.Automation.SwitchParameter]
        ${Restart},
    
        [Parameter(ParameterSetName='ReimageExpanded', Mandatory)]
        [Parameter(ParameterSetName='ReimageViaIdentityExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTags]))]
        [System.Management.Automation.SwitchParameter]
        ${Reimage},
    
        [Parameter(ParameterSetName='RebuildExpanded', Mandatory)]
        [Parameter(ParameterSetName='RebuildViaIdentityExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTags]))]
        [System.Management.Automation.SwitchParameter]
        ${Rebuild},
    
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
    
        [Parameter(ParameterSetName='ReimageExpanded')]
        [Parameter(ParameterSetName='ReimageViaIdentityExpanded')]
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
        if ($PSBoundParameters.ContainsKey('Restart')) {
            $Null = $PSBoundParameters.Remove('Restart')
            Az.CloudService.internal\Restart-AzCloudService @PSBoundParameters
        }
        if ($PSBoundParameters.ContainsKey('Reimage')) {
            $Null = $PSBoundParameters.Remove('Reimage')
            Az.CloudService.internal\Update-AzCloudService @PSBoundParameters
        }
        if ($PSBoundParameters.ContainsKey('Rebuild')) {
            $Null = $PSBoundParameters.Remove('Rebuild')
            if ($PSBoundParameters.ContainsKey('Name')) {
                $Null = $PSBoundParameters.Remove('Name')
                $PSBoundParameters.Add("CloudServiceName", $Name)
            }
            Az.CloudService.internal\Invoke-AzCloudServiceRebuildCloudService @PSBoundParameters
        }
    }
}
