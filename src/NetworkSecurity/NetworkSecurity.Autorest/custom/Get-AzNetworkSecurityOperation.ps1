# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
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
Lists operations supported by the Microsoft.NetworkSecurity provider.
.Description
Lists operations supported by the Microsoft.NetworkSecurity provider.
.Example
Get-AzNetworkSecurityOperation
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.IOperation
.Link
https://learn.microsoft.com/powershell/module/az.networksecurity/get-aznetworksecurityoperation
#>
function Get-AzNetworkSecurityOperation {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.IOperation])]
    [CmdletBinding(DefaultParameterSetName = 'List', PositionalBinding = $false)]
    param(
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        Az.NetworkSecurity.internal\Get-AzNetworkSecurityOperation @PSBoundParameters
    }
}
