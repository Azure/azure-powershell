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

try {
    foreach ($artifact in (Get-ChildItem -Path $Artifacts -Filter "*.nupkg").FullName) {
        $module_name = (Get-Item -Path $artifact).Name
        $zip_artifact = Join-Path -Path (Get-Item $Artifacts).FullName -ChildPath $module_name".zip"

        Write-Output "Renaming package $artifact to zip archive $zip_artifact"
        Rename-Item $artifact $zip_artifact

        Write-Output "Expanding $zip_artifact to $tmp\$module_name"
        Expand-Archive $zip_artifact -DestinationPath $tmp"\"$module_name 
        Remove-Item -Recurse $zip_artifact -Force -ErrorAction Stop
    }
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
}