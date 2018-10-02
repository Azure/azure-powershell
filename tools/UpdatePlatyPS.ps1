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

#Requires -Modules platyPS

<#
.SYNOPSIS Creates or updates markdown files for Azure Stack admin modules.
#>
param(
    [ValidateNotNull()]
    [String[]]$Modules = @(
        "Azs.AzureBridge.Admin",
        "Azs.Backup.Admin",
        "Azs.Commerce.Admin",
        "Azs.Compute.Admin",
        "Azs.Fabric.Admin",
        "Azs.Gallery.Admin",
        "Azs.InfrastructureInsights.Admin",
        "Azs.KeyVault.Admin",
        "Azs.Network.Admin",
        "Azs.Storage.Admin",
        "Azs.Subscriptions.Admin",
        "Azs.Subscriptions",
        "Azs.Update.Admin"
    ),

    [ValidateNotNull()]
    [String[]]$Skipped = @()
)

Import-Module AzureRM.Profile -Force

$Scheduled = $Modules | Where-Object { !($_ -in $Skipped) }

# Simple test incase someone tries to get clever.
foreach ($module in $Scheduled) {
    if ( !($module -in $Modules) ) {
        throw "The module '$module' is not in All."
    }
}

<#
.SYNOPSIS Creates or updates markdown files

#>
function Update-Help {
    [CmdletBinding()]
    param(
        [string]$BuildConfig
    )

    # Root folder where modules are located
    $rootFolder = "$($PSSCriptRoot)\..\src\StackAdmin\"

    # Number of failures we have seen
    [int]$Failures = 0
    $adminModules = Get-ChildItem -Path $rootFolder -Directory -Filter Azs.*
    foreach ($module in $adminModules) {
        $moduleDir = $module.FullName + "\Module"
        $module = $module.FullName | Split-Path -Leaf
        if ( $module -in $Scheduled ) {
            Push-Location $moduleDir | Out-Null
            try {
                Import-Module ".\$module" -Force | Out-Null
                if (Test-Path "..\Help") {
                    Write-Host "Removing old help files"
                    Remove-Item -Path "..\Help" -Force -Recurse
                }

                Write-Host "creating $module..."
                New-MarkdownHelp -Module $module -AlphabeticParamsOrder -OutputFolder ..\Help -WithModulePage
                Update-MarkdownHelpModule -Path ..\Help -RefreshModulePage -AlphabeticParamsOrder
                Write-Host "done..."
            } catch {
                $Failures += 1
                Write-Error "$($_.Exception)"
                break
            } finally {
                Pop-Location | Out-Null
            }
        }
    }
    return $Failures
}

write-Host "Updating markdown modules..."
exit (Update-Help -BuildConfig $BuildConfig)
