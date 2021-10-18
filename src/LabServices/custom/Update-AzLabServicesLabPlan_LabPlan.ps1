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

function Update-AzLabServicesLabPlan_LabPlan {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${LabPlan},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${AllowedRegions},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileDisconnectDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileIdleDelay},

    [Parameter()]
    [timespan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultAutoShutdownProfileNoConnectDelay},
    
    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    ${DefaultAutoShutdownProfileShutdownOnDisconnect},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ShutdownOnIdleMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ShutdownOnIdleMode]
    ${DefaultAutoShutdownProfileShutdownOnIdle},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    ${DefaultAutoShutdownProfileShutdownWhenNotConnected},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
    ${DefaultConnectionProfileClientRdpAccessEnabled},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
    ${DefaultConnectionProfileClientSshAccessEnabled},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${DefaultNetworkProfileSubnetId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${LinkedLmsInstance},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SharedGalleryId},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoEmail},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoInstructions},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoPhone},

    [Parameter()]
    [String]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${SupportInfoUrl},

    [Parameter()]
    [String[]]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    ${Tags},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {    
    $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
    $PSBoundParameters.Remove("LabPlan") > $null
    return Az.LabServices\Update-AzLabServicesLabPlan @PSBoundParameters
}

}
