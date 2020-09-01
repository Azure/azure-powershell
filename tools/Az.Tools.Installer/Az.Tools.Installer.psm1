# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.internal
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

$getModule = Get-Module -Name "PowerShellGet"
if ($null -ne $getModule -and $getModule.Version -lt [System.Version]"2.1.3") { 
    Write-Error "This module requires PowerShellGet version 2.1.3. An earlier version of PowerShellGet is imported in the current PowerShell session. Please open a new session before importing this module." -ErrorAction Stop 
} 
elseif ($null -eq $module) { 
    Import-Module PowerShellGet -MinimumVersion 2.1.3 -Scope Global 
}

$exportedPS1Files = Get-ChildItem -Path $PSScriptRoot/exports -Recurse -Include '*.ps1' -File
$internalPS1Files = Get-ChildItem -Path $PSScriptRoot/internal -Recurse -Include '*.ps1' -File
$exportedPS1Files | ForEach-Object { . $_.FullName }
$internalPS1Files | ForEach-Object { . $_.FullName }
Export-ModuleMember -Function $exportedPS1Files.Basename