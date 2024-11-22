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
[CmdletBinding(DefaultParameterSetName="ModuleNameSet")]
param (
    [Parameter(Mandatory=$true)]
    [string]$RepoRoot,
    [Parameter(ParameterSetName="ModuleNameSet", Mandatory=$true)]
    [string]$ModuleRootName,
    [switch]$ForceRegenerate,
    [switch]$InvokedByPipeline
)
<#
    for:
        src/Storage/Storage.Management
        src/Storage/Storage.Autorest
    ModuleRootName = Storage
    ParentModuleName = Storage.Management
    SubModuleName = Storage.Autorest
#>
$BuildScriptsModulePath = Join-Path $PSScriptRoot "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath
$FilesChangedScriptModulePath = Join-Path $PSScriptRoot "FilesChangedScript.psm1"
Import-Module $FilesChangedScriptModulePath

$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

$isInvokedByPipeline = $false
if ($InvokedByPipeline) {
    $isInvokedByPipeline = $true
}

$AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
New-Item -ItemType Directory -Force -Path $AutorestOutputDir
$moduleRootSource = Join-Path $sourceDirectory $ModuleRootName
$moduleRootGenerated = Join-Path $generatedDirectory $ModuleRootName
Write-Host "Calculating outdated submodules for $ModuleRootName ..." -ForegroundColor DarkGreen
$outdatedSubModule = Get-OutdatedSubModule -SourceDirectory $moduleRootSource -GeneratedDirectory $moduleRootGenerated -ForceRegenerate:$ForceRegenerate
foreach ($subModuleName in $outdatedSubModule) {
    $generateLog = Join-Path $AutorestOutputDir $ModuleRootName "$subModuleName.log"
    if (Test-Path $generateLog) {
        Remove-Item -Path $generateLog -Recurse -Force
    }
    New-Item -ItemType File -Force -Path $generateLog
    if (-not (Update-GeneratedSubModule -ModuleRootName $ModuleRootName -SubModuleName $subModuleName -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory -GenerateLog $generateLog -IsInvokedByPipeline $isInvokedByPipeline)) {
        Write-Error "Failed to generate code for module: $ModuleRootName, $subModuleName"
        Write-Error "========= Start of error log for $ModuleRootName, $subModuleName ========="
        Write-Error "log can be found at $generateLog"
        Get-Content $generateLog | Foreach-Object { Write-Error $_ }
        Write-Error "========= End of error log for $ModuleRootName, $subModuleName"
        Exit 1
    }
}