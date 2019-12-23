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

New-Item -Path $Artifacts -Name "tmp" -ItemType "directory"
$tmp = Join-Path -Path $Artifacts -ChildPath "tmp"

try {
    foreach ($artifact in Get-ChildItem -Path $Artifacts -Filter "*.nupkg") {
        Write-Output "##############################################$artifact#############################################"
        $module_name = (((Get-Item -Path $artifact).Name) -split("\.([0-9])+"))[0]
        Write-Output "Expanding $artifact to $tmp\$module_name"
        Expand-Archive $artifact -DestinationPath $tmp"\"$module_name 
        Remove-Item -Recurse $artifact -Force -ErrorAction Stop
    }
} catch {
    $Errors = $_
    Write-Error ($_ | Out-String)
}