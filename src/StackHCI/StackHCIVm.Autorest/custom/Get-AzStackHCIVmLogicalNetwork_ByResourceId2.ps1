
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
Gets a logical network
.Description
Gets a logical network


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks

.Link
https://learn.microsoft.com/powershell/module/az.stackhci/get-azstackhcivmlogicalnetwork
#>
function Get-AzStackHCIVmLogicalNetwork_ByResourceId {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.ILogicalNetworks])]
    [CmdletBinding(PositionalBinding=$false)]
    
    param(
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # The ARM ID of the logical network.
        ${ResourceId},

                
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
        
    )
      process {
           
            if ($ResourceId -match $lnetRegex){
            
                $subscriptionId = $($Matches['subscriptionId'])
                $resourceGroupName = $($Matches['resourceGroupName'])
                $resourceName = $($Matches['logicalNetworkName'])
                $null = $PSBoundParameters.Remove("ResourceId")
                $PSBoundParameters.Add("Name", $resourceName)
                $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                $null = $PSBoundParameters.Remove("SubscriptionId")
                $PSBoundParameters.Add("SubscriptionId", $subscriptionId)
                
                return  Az.StackHCIVm\Get-AzStackHCIVmLogicalNetwork @PSBoundParameters
    
            } else {             
                Write-Error "Resource ID is invalid: $ResourceId"
            }
            
        }
    } 