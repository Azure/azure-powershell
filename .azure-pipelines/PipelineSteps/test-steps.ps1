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
    [string]$PowerShellPlatform,
    [string]$TestFramework,
    [string]$Configuration = 'Debug'
)

# Remove pre-installed Az modules
Write-Host -ForegroundColor Green "-------------------- Start removing pre-installed Az modules ... --------------------"
$commonUtilityScriptPath = Join-Path $RepoRoot "tools" "TestFx" "Utilities" "CommonUtility.ps1"
& $commonUtilityScriptPath
Write-Host -ForegroundColor DarkGreen "-------------------- End removing pre-installed Az modules ... --------------------`n`n`n`n`n"

# Test
Write-Host -ForegroundColor Green "-------------------- Start testing ... --------------------"
if ($PowerShellPlatform) {
    $Env:PowerShellPlatform = $PowerShellPlatform
}
$preference = $ErrorActionPreference
$ErrorActionPreference = 'Continue'
$buildProjPath = Join-Path $RepoRoot 'build.proj'
dotnet msbuild $buildProjPath /t:Test "/p:Configuration=$Configuration;TestFramework=$TestFramework"
Write-Host -ForegroundColor DarkGreen "-------------------- End testing ... --------------------`n`n`n`n`n"

# Test AutoGen Modules With PowerShell Core
Write-Host -ForegroundColor Green "-------------------- Start testing AutoGen modules with PowerShell Core ... --------------------"
$executeCIStepScriptPath = Join-Path $RepoRoot "tools" "ExecuteCIStep.ps1"
$currentPath = $PWD
$debugFolderPath = Join-Path $RepoRoot "artifacts" "Debug"
Set-Location $debugFolderPath

Install-Module -Name Pester -Repository PSGallery -RequiredVersion 4.10.1 -Force
if ($IsWindows) { $sp = ";" } else { $sp = ":" }
$env:PSModulePath = $env:PSModulePath + $sp + (pwd).Path
Get-ChildItem -File -Recurse test-module.ps1 | ForEach-Object {
Write-Host $_.Directory.FullName
$repoArtifact = Join-Path $RepoRoot 'artifacts'
& $executeCIStepScriptPath -TestAutorest -AutorestDirectory $_.Directory.FullName -RepoArtifacts $repoArtifact
}

$ErrorActionPreference = $preference
Set-Location $currentPath
Write-Host -ForegroundColor DarkGreen "-------------------- End testing AutoGen modules with PowerShell Core ... --------------------`n`n`n`n`n"

# Analyze test coverage
Write-Host -ForegroundColor Green "-------------------- Start analyzing test coverage ... --------------------"
$validateTestCoverageScriptPath = Join-Path $RepoRoot 'tools' 'TestFx' 'Coverage' 'ValidateTestCoverage.ps1'
& $validateTestCoverageScriptPath
Write-Host -ForegroundColor DarkGreen "-------------------- End analyzing test coverage ... --------------------`n`n`n`n`n"

# Check test status
Write-Host -ForegroundColor Green "-------------------- Start checking test status ... --------------------"
$currentPath = $PWD
$pipelineResultPath = Join-Path $RepoRoot "artifacts" "PipelineResult"
Set-Location $pipelineResultPath

$PipelineResult = Get-Content PipelineResult.json | ConvertFrom-Json
$FailedModuleList = $PipelineResult.test.Details[0].Modules | Where-Object { $_.Status -eq "Failed" } | ForEach-Object { $_.Module }
if ($FailedModuleList.Length -ne 0)
{
    throw "test fails in module: $FailedModuleList"
}

Set-Location $currentPath
Write-Host -ForegroundColor DarkGreen "-------------------- End checking test status ... --------------------`n`n`n`n`n"