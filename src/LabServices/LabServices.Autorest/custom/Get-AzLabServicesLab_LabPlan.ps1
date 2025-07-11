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
API to get labs.
.Description
API to get labs.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILab
.Link
https://learn.microsoft.com/powershell/module/az.labservices/get-azlabserviceslab
#>
function Get-AzLabServicesLab_LabPlan {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.ILab])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.LabPlan]
        # The object of lab service lab plan.
        ${LabPlan},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        # The name of the user that uniquely identifies it within containing lab.
        # Used in resource URIs.
        ${Name},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}

    )
    
    process {
        $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
        
        $labPlanId = $LabPlan.Id
        $PSBoundParameters.Remove("LabPlan") > $null
        $PSBoundParameters.Remove("LabPlanName") > $null
        
        $CheckForWildcards = Join-Path $PSScriptRoot 'Utilities' 'CheckForWildcards.ps1'
        if ($PSBoundParameters.ContainsKey('Name')) {            
            # If there is a lab name do a get for the specific lab or check for wildcard.
            if ($(. $CheckForWildcards -ResourceId $PSBoundParameters.Name))
            {
                $currentLab = $PSBoundParameters.Name
                $PSBoundParameters.Remove('Name') > $null

                return Az.LabServices.internal\Get-AzLabServicesLab @PSBoundParameters |  Where-Object { $_.Name -like $currentLab }
            } else {
                return Az.LabServices.internal\Get-AzLabServicesLab @PSBoundParameters
            }
        } else {
            # Get all labs for the lab plan.
            $PSBoundParameters.Remove("Filter") > $null
            $PSBoundParameters.Remove("ResourceGroupName") > $null
            $PSBoundParameters.Add("Filter","Properties/LabPlanId eq '$labPlanId'")
            return Az.LabServices.internal\Get-AzLabServicesLab @PSBoundParameters
        }
        
    }
}