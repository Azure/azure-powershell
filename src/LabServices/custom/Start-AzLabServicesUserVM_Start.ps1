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
https://docs.microsoft.com/powershell/module/az.labservices/Start-AzLabServicesUserVM
#>
function Start-AzLabServicesUserVM_Start {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
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
    
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob}
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
    