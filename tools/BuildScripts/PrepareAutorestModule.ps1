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
    [switch]$ForceRegenerate
)
<#
    for:
        src/Storage/Storage.Management
        src/Storage/Storage.Autorest
    ModuleRootName = Storage
    ParentModuleName = Storage.Management
    SubModuleName = Storage.Autorest
#>
<#
    TODO: add comment, add log
#>
$BuildScriptsModulePath = Join-Path $PSScriptRoot "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath

$succeeded = $true
$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

$AutorestOutputDir = Join-Path $RepoRoot "artifacts" "autorest"
New-Item -ItemType Directory -Force -Path $AutorestOutputDir
$moduleRootSource = Join-Path $sourceDirectory $ModuleRootName
$moduleRootGenerated = Join-Path $generatedDirectory $ModuleRootName
Write-Host "Calculating outdated submodules for $ModuleRootName ..." -ForegroundColor DarkGreen
$outdatedSubModule = Get-OutdatedSubModule -SourceDirectory $moduleRootSource -GeneratedDirectory $moduleRootGenerated -ForceRegenerate:$ForceRegenerate
$jobs = @()
foreach ($subModuleName in $outdatedSubModule) {
    $jobs += (Start-Job {
        param(
            [string]$SourceDirectory,
            [string]$GeneratedDirectory,
            [string]$ModuleRootName,
            [string]$SubModuleName
        )
        $subModuleSourceDirectory = Join-Path $SourceDirectory $ModuleRootName $SubModuleName
        $generatedLog = Join-Path $AutorestOutputDir $ModuleRootName "$SubModuleName.log"
        if (-not (Invoke-SubModuleGeneration -GenerateDirectory $subModuleSourceDirectory -GeneratedLog $generatedLog)) {
            Write-Error "Failed to generate code for module: $ModuleRootName, $subModuleName"
            Write-Error "========= Start of error log for $ModuleRootName, $subModuleName ========="
            Write-Error "log can be found at $generatedLog"
            Get-Content $generatedLog | Foreach-Object { Write-Error $_ }
            Write-Error "========= End of error log for $ModuleRootName, $SubModuleName"
            return $false
        }
        $subModuleGeneratedDirectory = Join-Path $GeneratedDirectory $ModuleRootName $SubModuleName
        if (-not (Test-Path $subModuleGeneratedDirectory)) {
            New-Item -ItemType Directory -Force -Path $subModuleGeneratedDirectory
        }
        Update-GeneratedSubModule -ModuleRootName $ModuleRootName -SubModuleName $SubModuleName -SourceDirectory $SourceDirectory -GeneratedDirectory $GeneratedDirectory
        return $true
    } -ArgumentList $sourceDirectory, $generatedDirectory, $ModuleRootName, $subModuleName)
}
$jobs | Foreach-Object -Parallel {
    if (-not ($_ | Wait-Job | Receive-Job)) {
        $succeeded = $false
    }
    $_ | Remove-Job
}
return $succeeded