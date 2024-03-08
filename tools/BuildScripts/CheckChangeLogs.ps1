# ----------------------------------------------------------------------------------
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
    [Parameter(Mandatory=$True)]
    [string] $rootPath,
    [Parameter(Mandatory=$True)]
    [string] $outputFile,
    [Parameter(Mandatory=$false)]
    [string] $TargetModuleList = ""
)

# Read the content of changelog.md into a variable
$content = Get-Content -Path "$rootPath/tools/AzPreview/ChangeLog.md" 

$continueReading = $false
$modules = @()
foreach ($line in $content) {
    if ($line -match "^##\s\d+\.\d+\.\d+") {
        if ($continueReading) {
            break
        } else {
            $continueReading = $true
        }
    }
    elseif ($continueReading -and $line -match "^####\sAz\.(\w+)") {
        $modules += $matches[1]
    }
}

# If TargetModuleList is not empty, overwrite the $modules array with it
if (-not [string]::IsNullOrEmpty($TargetModuleList) -and $TargetModuleList -ne "null") {
    $modules = $TargetModuleList -split ':'
}

# Check if $modules contains "Accounts", if not, add it at the beginning
if (-not $modules.Contains("Accounts")) {
    $modules = @("Accounts") + $modules
}
# Write the module names to modifiedmodule.txt
$modules | Out-File -Path $outputFile
