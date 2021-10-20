
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for Lab Services Lab Plan.
.Description
Create a in-memory object for Lab Services Lab Plan.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab
.Link
https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesLabPlanObject
#>
function New-AzLabServicesLabPlanObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(Mandatory)]
        [String]        
        ${Location},
    
        [Parameter(Mandatory)]
        [String[]]
        ${AllowedRegion},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${DefaultConnectionProfileClientRdpAccess},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${DefaultConnectionProfileClientSshAccess},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${DefaultConnectionProfileWebRdpAccess},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${DefaultConnectionProfileWebSshAccess}    

    )

    process {

        $labPlanBody = @{
            location = $Location
            properties = @{
                allowedRegions = $AllowedRegion
                defaultConnectionProfile = @{
                    webSshAccess = $($DefaultConnectionProfileWebSshAccess.ToString())
                    webRdpAccess = $($DefaultConnectionProfileWebRdpAccess.ToString())
                    clientSshAccess = $($DefaultConnectionProfileClientSshAccess.ToString())
                    clientRdpAccess = $($DefaultConnectionProfileClientRdpAccess.ToString())
                }
                defaultAutoShutdownProfile = @{
                    shutdownOnDisconnect = "Disabled"
                    shutdownWhenNotConnected = "Disabled"
                    shutdownOnIdle = "None"
                }
            }
        }
        return $labPlanBody | ConvertTo-Json -Depth 10
    }
}
