
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
Create a in-memory object for Lab Services Lab.
.Description
Create a in-memory object for Lab Services Lab.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab
.Link
https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesLabObject
#>
function New-AzLabServicesLabObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(
        [Parameter(Mandatory)]
        [String]        
        ${Location},

        [Parameter(Mandatory)]
        [String]
        ${Title},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
        ${AdditionalCapabilityInstallGpuDriver},

        [Parameter(Mandatory)]
        [SecureString]
        ${AdminUserPassword},

        [Parameter(Mandatory)]
        [String]        
        ${AdminUserUsername},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${ConnectionProfileClientRdpAccess},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType]
        ${ConnectionProfileClientSshAccess},
    
        [Parameter(Mandatory)]
        [String]
        ${ImageReferenceOffer},

        [Parameter(Mandatory)]
        [String]
        ${ImageReferencePublisher},

        [Parameter(Mandatory)]
        [String]
        ${ImageReferenceSku},

        [Parameter(Mandatory)]
        [String]
        ${ImageReferenceVersion},
    
        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
        ${SecurityProfileOpenAccess},
    
        [Parameter(Mandatory)]
        [Int32]
        ${SkuCapacity},

        [Parameter(Mandatory)]
        [String]
        ${SkuName},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreateOption])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreateOption]
        ${VirtualMachineProfileCreateOption},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
        ${VirtualMachineProfileUseSharedPassword}
    )

    process {
        #[Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab]Object = $labBody
        if ($PSBoundParameters.ContainsKey('AdminUserPassword')) {
            $psAdminTxt = . "$PSScriptRoot/../utils/Unprotect-SecureString.ps1" $PSBoundParameters['AdminUserPassword']
        }

        $labBody = @{
            properties = @{
                autoShutdownProfile = @{
                    shutdownOnDisconnect = "Disabled"
                    shutdownWhenNotConnected = "Disabled"
                    shutdownOnIdle = "None"
                }
                connectionProfile = @{
                    clientSshAccess = $($ConnectionProfileClientSshAccess.ToString())
                    clientRdpAccess = $($ConnectionProfileClientRdpAccess.ToString())
                    webSshAccess = "None"
                    webRdpAccess = "None"
                }
                virtualMachineProfile = @{
                    createOption = $($VirtualMachineProfileCreateOption.ToString())
                    useSharedPassword = $($VirtualMachineProfileUseSharedPassword.ToString())
                    imageReference = @{
                        offer = $ImageReferenceOffer
                        publisher = $ImageReferencePublisher
                        sku = $ImageReferenceSku
                        version = $ImageReferenceVersion
                    }
                    sku = @{
                        name = $SkuName
                        capacity = $SkuCapacity
                    }
                    additionalCapabilities = @{
                        installGpuDrivers = $($AdditionalCapabilityInstallGpuDriver.ToString())
                    }
                    adminUser = @{
                        username = $AdminUserUsername
                        password = $psAdminTxt
                    }
                }
                securityProfile = @{
                    openAccess = $($SecurityProfileOpenAccess.ToString())
                }
                title = $Title
            }
            location = $Location
        }
        return $labBody | ConvertTo-Json -Depth 10
    }
}
