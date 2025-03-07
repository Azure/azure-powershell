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

#This script will expand Az.*.nupkg under "artifacts" to a temporary folder "artifacts/tmp"

param(
    [Parameter(Mandatory = $false, Position = 1)]
    [string]$Artifacts
)

<###################################
#
#           Setup/Execute
#
###################################>

if ([string]::IsNullOrEmpty($Artifacts)) {
    Write-Verbose "Artifacts was not provided, use default $PSScriptRoot\..\artifacts"
    $Artifacts = Join-Path $PSScriptRoot -ChildPath ".." | Join-Path -ChildPath "artifacts"
}

New-Item -Path (Get-Item $Artifacts).FullName -Name "tmp" -ItemType "directory"
$tmp = Join-Path -Path (Get-Item $Artifacts).FullName -ChildPath "tmp"

$TargetModulePath = Join-Path $Artifacts -ChildPath "TargetModule.txt"
$TargetModule = @()
if (Test-Path $TargetModulePath) {
    $TargetModule = Get-Content $TargetModulePath
}
Write-Host $TargetModule
try {
    $AllPackages = Get-ChildItem -Path $Artifacts -Filter "*.nupkg"

    if ($TargetModule.Length -eq 0) {
        Write-Error "No target modules found."
        exit 1
    }
    foreach ($package in $AllPackages) {
        foreach ($module in $TargetModule) {
            if (($package.Name -like "Az.$module.*.nupkg") -or ($package.Name -match '^Az(Preview)?\.\d+\.\d+\.\d+\.nupkg$')) { 
                $module_name = $package.Name
                $zip_artifact = $package.FullName -replace ".nupkg$",".zip"
                Write-Output "Renaming $package to zip archive $zip_artifact"
                Rename-Item $package.FullName $zip_artifact
                Write-Output "Expanding $zip_artifact to $tmp\$module_name"
                Expand-Archive $zip_artifact -DestinationPath "$tmp\$module_name"
                Remove-Item -Recurse $zip_artifact -Force -ErrorAction Stop
                break
            }
        }
    }
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
}
