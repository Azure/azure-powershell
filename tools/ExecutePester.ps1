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

param(
    [Parameter(Mandatory = $false, Position = 0)]
    [switch]$IsNetCore
)

# All admin modules
$All = @(
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
)

# These are broken.
$Ignored = @()

$Scheduled = $All | Where-Object { !($_ -in $Ignored) }

# Simple test incase someone tries to get clever.
foreach ($module in $Scheduled) {
    if ( !($module -in $All) ) {
        throw "The module '$module' is not in All."
    }
}

function Start-Tests {
    param(
        [switch]$IsNetCore
    )
    # Create test output
    $TestFolder = "$($PSSCriptRoot)\..\src\Stack\"
    New-Item -Path $TestFolder -ItemType Directory -Force -ErrorAction SilentlyContinue | Out-Null

    # Root folder where modules are located
    $rootFolder = "$($PSSCriptRoot)\..\src\StackAdmin\"

    # Number of failures we have seen
    [int]$Failures = 0
    $adminModules = Get-ChildItem -Path $rootFolder -Directory -Filter Azs.*
    foreach ($module in $adminModules) {
        $testDir = $module.FullName + "\Tests"
        $module = $module.FullName | Split-Path -Leaf
        if ( $module -in $Scheduled ) {
            Push-Location $testDir | Out-Null
            try {
                $OutputXML = "$($TestFolder)\$($module).xml"
                Invoke-Pester "src" -OutputFile $OutputXML -OutputFormat NUnitXml | Out-Null
                [xml]$result = Get-Content -Path $OutputXML
                $Failures += ($result."test-results".failures)
            } catch {
                Write-Error "Pester Test failure, $_"
                break
            }
            Pop-Location | Out-Null
            # Fail fast
            if($Failures -gt 0) {
                break
            }
        }
    }
    return $Failures
}

exit (Start-Tests -BuildConfig $BuildConfig -IsNetCore:$IsNetCore)
