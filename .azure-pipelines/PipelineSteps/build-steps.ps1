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
[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [string]$Configuration = 'Debug',
    [string]$PowerShellPlatform,
    [string]$FilesChangedOutputPath,
    [boolean]$ForceRegenerate = $false,
    [string]$SubTasksFilePath,
    [boolean]$IsSecurityCheck,
    [string]$BuildReason,
    [string]$Trigger
)

# filter changed files
Write-Host -ForegroundColor Green "-------------------- Start filtering changed files ... --------------------"
$buildProjPath = Join-Path $RepoRoot 'build.proj'
if ($PowerShellPlatform) {
    $Env:PowerShellPlatform = $PowerShellPlatform
}
dotnet msbuild $buildProjPath /t:FilterBuild "/p:FilesChangedOutputPath=$FilesChangedOutputPath;SubTasksFilePath=$SubTasksFilePath;IsSecurityCheck=$IsSecurityCheck"
Write-Host -ForegroundColor DarkGreen "-------------------- End filtering changed files ... --------------------`n`n`n`n`n"

# Set subtasks
if (Test-Path $SubTasksFilePath) {
    Write-Host -ForegroundColor Green "-------------------- Start setting subtasks ... --------------------"
    Get-Content $SubTasksFilePath | ForEach-Object {
      if ($_ && 'Predictor' -eq $_) {
        $subTaskPredictor = $true
      } elseif ($_ && 'Installer' -eq $_) {
        Write-Host "##vso[task.setvariable variable=SubTaskInstaller]true"
        $subTaskInstaller = $true
      } elseif ($_ && 'all' -eq $_) {
        $subTaskAll = $true
      }
    }
    Write-Host -ForegroundColor DarkGreen "-------------------- End setting subtasks ... --------------------`n`n`n`n`n"
}

# Analyze changed files
Write-Host -ForegroundColor Green "-------------------- Start Analyzing changed files ... --------------------"
Write-Host "##1. Check generate-info.json for autorest generated modules" -ForegroundColor Magenta
$noGenerateInfo = @()
$modules = Get-Content $FilesChangedOutputPath -OutVariable paths | Foreach-Object { if($_ -match "^src.*\.Autorest"){ Write-Output $Matches[0] } } | Select-Object -Unique
foreach ($module in $modules) {
$hasGenerateInfo = $false
$pattern = "^$module/generate-info.json"
foreach ($path in $paths) {
    if ($path -match $pattern) {
    $hasGenerateInfo = $true
    }
}
if (-not $hasGenerateInfo) {
    $noGenerateInfo += $module
}
}
if ($noGenerateInfo -and $noGenerateInfo.Count -gt 0) {
$noGenerateInfo | Foreach-Object { Write-Warning "No generate-info.json detected for $_." }
}

# this might not be true, for example when release branch or preview branch merge back to main branch, it's possible changes present in both /src and /generated
Write-Host "##2. PR should contain changes from either /src or /generated only" -ForegroundColor Magenta
$content = Get-Content $FilesChangedOutputPath
$srcFiles = $content | Where-Object { $_ -match "^src.*" }
$generatedFiles = $content | Where-Object { $_ -match "^generated.*" }
if ($srcFiles -and $srcFiles.Count -gt 0  -and $generatedFiles -and $generatedFiles.Count -gt 0) {
Write-Warning "PR should contain changes from either /src or /generated only."
}
Write-Host -ForegroundColor DarkGreen "-------------------- End Analyzing changed files ... --------------------`n`n`n`n`n"

# Check ignored files
Write-Host -ForegroundColor Green "-------------------- Start checking ignored files ... --------------------"
$checkIgnoreFilesScriptPath = Join-Path $RepoRoot 'tools' 'CheckIgnoredFile.ps1'
& $checkIgnoreFilesScriptPath
Write-Host -ForegroundColor DarkGreen "-------------------- End checking ignored files ... --------------------`n`n`n`n`n"

# Build
Write-Host -ForegroundColor Green "-------------------- Start building modules ... --------------------"
$buildScriptPath = Join-Path $RepoRoot 'tools' 'BuildScripts' 'BuildModules.ps1'
if ('Manual' -eq $BuildReason -and $ForceRegenerate) {
& $buildScriptPath -CIPlan -RepoRoot $RepoRoot -Configuration $Configuration -ForceRegenerate -InvokedByPipeline
} else {
& $buildScriptPath -CIPlan -RepoRoot $RepoRoot -Configuration $Configuration -InvokedByPipeline
}
Write-Host -ForegroundColor DarkGreen "-------------------- End building modules ... --------------------`n`n`n`n`n"

# Write pipeline result
Write-Host -ForegroundColor Green "-------------------- Start writing pipeline result ... --------------------"
$pipelineScript = Join-Path $RepoRoot 'tools' 'ExecuteCIStep.ps1'
$repoArtifact = Join-Path $RepoRoot 'artifacts'
& $pipelineScript -Build -TriggerType $BuildReason -Trigger $Trigger -RepoArtifacts $repoArtifact -Configuration $Configuration
Write-Host -ForegroundColor DarkGreen "-------------------- End writing pipeline result ... --------------------`n`n`n`n`n"

# Build Az.Tools.Predictor
if ($subTaskPredictor -or $subTaskAll) {
    Write-Host -ForegroundColor Green "-------------------- Start building Az.Tools.Predictor ... --------------------"
    dotnet msbuild $buildProjPath /t:AzToolsPredictor
    Write-Host -ForegroundColor DarkGreen "-------------------- End building Az.Tools.Predictor ... --------------------`n`n`n`n`n"
}

# Build Az.Tools.Installer
if ($subTaskInstaller -or $subTaskAll) {
    Write-Host -ForegroundColor Green "-------------------- Start building Az.Tools.Installer ... --------------------"
    dotnet msbuild $buildProjPath /t:AzToolsInstaller
    Write-Host -ForegroundColor DarkGreen "-------------------- End building Az.Tools.Installer ... --------------------`n`n`n`n`n"
}