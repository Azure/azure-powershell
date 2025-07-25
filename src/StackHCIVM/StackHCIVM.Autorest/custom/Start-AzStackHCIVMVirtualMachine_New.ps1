
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
The operation to start a virtual machine instance.
.Description
The operation to start a virtual machine instance.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance
.Notes
COMPLEX PARAMETER PROPERTIES


.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/start-azstackhcivmvirtualmachine
#>
function Start-AzStackHCIVMVirtualMachine {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance])]
    [CmdletBinding( PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Alias('VirtualMachineName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # Name of the virtual machine
        ${Name},
        
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByResourceId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # The ARM Resource ID of the virtual machine.
        ${ResourceId},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}

    )       
    if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
        if ($ResourceId -match $vmRegex){
            $SubscriptionId = $($Matches['subscriptionId'])
            $ResourceGroupName = $($Matches['resourceGroupName'])
            $Name = $($Matches['machineName'])
        }
        $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
        $PSBoundParameters.Add("ResourceUri", $resourceUri)
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("ResourceId")
        $null = $PSBoundParameters.Remove("Name")

        try{
            Az.StackHCIVM.internal\Start-AzStackHCIVMVirtualMachine -ErrorAction Stop @PSBoundParameters 
        } catch {
            $e = $_
            if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
            } else {
                Write-Error $e.Exception.Message -ErrorAction Stop
            }
        }
          
        } else {             
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid"
        }    
}   