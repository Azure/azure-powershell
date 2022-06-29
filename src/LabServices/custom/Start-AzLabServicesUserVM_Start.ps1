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
API to start the assigned vm for the user.
.Description
API to start the assigned vm for the user.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine
.Link
https://docs.microsoft.com/powershell/module/az.labservices/start-azlabservicesuservm
#>
function Start-AzLabServicesUserVM_Start {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        [System.String]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        ${LabName},
   
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
        [System.String]
        # The name of the user that uniqely identifies it within containing lab.
        # Used in resource URIs.
        ${Email},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
        
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
        
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
        $vm = Az.LabServices\Get-AzLabServicesUserVM @PSBoundParameters
        if ($vm) {
            $PSBoundParameters.Add('VirtualMachineName', $vm.Name)
            $PSBoundParameters.Remove('Email') > $null
            return Az.LabServices\Start-AzLabServicesVM @PSBoundParameters
        } else {
            Write-Error "No VM assigned to Email: $Email"
        }
    }
    
    }
    