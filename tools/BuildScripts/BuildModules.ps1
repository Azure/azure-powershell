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
    [Parameter(Mandatory=$true)]
    [string]$RepoRoot,
    [string]$Configuration = 'Debug',
    [Parameter(ParameterSetName="AllSet")]
    [string]$TestsToRun = 'All',
    [Parameter(ParameterSetName="CIPlanSet", Mandatory=$true)]
    [switch]$CIPlan,
    [Parameter(ParameterSetName="ModifiedBuildSet", Mandatory=$true)]
    [switch]$ModifiedModuleBuild,
	[Parameter(ParameterSetName="TargetModuleSet", Mandatory=$true)]
    [string[]]$TargetModule,
    [switch]$ForceRegenerate,
    [switch]$GenerateDocumentationFile,
    [switch]$EnableTestCoverage

)
$BuildScriptsModulePath = Join-Path $PSScriptRoot "BuildScripts.psm1"
Import-Module $BuildScriptsModulePath

$notModules = @('lib', 'shared')
$coreTestModules = @('Compute', 'Network', 'Resources', 'Sql', 'Websites')
$renamedModules = @{
    'Storage' = @('Storage.Management');
    'DataFactory' = @('DataFactoryV1', 'DataFactoryV2')
}
$RepoArtifacts = Join-Path $RepoRoot "Artifacts"

$csprojFiles = @()
$testModules = @()
$toolDirectory = Join-Path $RepoRoot "tools"
$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"
$isPipeline = $false
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

switch ($PSCmdlet.ParameterSetName) {
    'AllSet' {
        Write-Host "----------Start building all modules----------" -ForegroundColor DarkYellow
        foreach ($module in (Get-Childitem -Path $sourceDirectory -Directory)) {
            $moduleName = $module.Name
            if ($moduleName -in $notModules) {
                continue
            }
            $TargetModule += $moduleName
            Write-Host "$moduleName" -ForegroundColor DarkYellow
        }
        if ('Core' -eq $TestsToRun) {
            $testModules = $coreTestModules
        } elseif ('NonCore') {
            $testModules = $TargetModule | Where-Object { $_ -notin $coreTestModules}
        } else {
            $testModules = $TargetModule
        }
    }
    'CIPlanSet' {
        $CIPlanPath = Join-Path $RepoArtifacts "PipelineResult" "CIPlan.json"
        If (Test-Path $CIPlanPath) {
            $CIPlanContent = Get-Content $CIPlanPath | ConvertFrom-Json
            $TargetModule = $CIPlanContent.build
            $testModules = $CIPlanContent.test
        }
        $isPipeline = $true
        Write-Host "----------Start building modules from $CIPlanPath----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
    'ModifiedBuildSet' {
        $changelogPath = Join-Path $RepoRoot "tools" "Azpreview" "changelog.md"
        if (Test-Path $changelogPath) {
            $content = Get-Content -Path $changelogPath
            $continueReading = $false
            foreach ($line in $content) {
                if ($line -match "^##\s\d+\.\d+\.\d+") {
                    if ($continueReading) {
                        break
                    } else {
                        $continueReading = $true
                    }
                }
                elseif ($continueReading -and $line -match "^####\sAz\.(\w+)") {
                    $TargetModule += $matches[1]
                }
            }
        }
        $testModules = $TargetModule
        Write-Host  "----------Start building modified modules----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
    'TargetModuleSet' {
        $testModules = $TargetModule
        Write-Host  "----------Start building target modules----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
}

$csprojFiles = Get-CsprojFromModule -BuildModuleList $TargetModule -TestModuleList $testModules -RepoRoot $RepoRoot -Configuration $Configuration
# Prepare autorest based modules
$prepareScriptPath = Join-Path $PSScriptRoot "PrepareAutorestModule.ps1"

foreach ($moduleRootName in $TargetModule) {
    Write-Host "Preparing $moduleRootName ..." -ForegroundColor DarkGreen
    . $prepareScriptPath -ModuleRootName $moduleRootName -RepoRoot $RepoRoot -ForceRegenerate:$ForceRegenerate -Pipeline:$isPipeline
}

& dotnet --version
& dotnet new sln -n Azure.PowerShell -o $RepoArtifacts --force
$sln = Join-Path $RepoArtifacts "Azure.PowerShell.sln"
foreach ($file in $csprojFiles) {
    & dotnet sln $sln add "$file"
}
Write-Output "Modules are added to sln file"

$LogFile = Join-Path $RepoArtifacts 'Build.log'
if ('Release' -eq $Configuration) {
    $BuildAction = 'publish'
} else {
    $BuildAction = 'build'
}

$buildCmdResult = "dotnet $BuildAction $sln -c $Configuration -fl '/flp1:logFile=$LogFile;verbosity=quiet'"
If ($GenerateDocumentationFile -eq "false")
{
    $buildCmdResult += " -p:GenerateDocumentationFile=false"
}
if ($EnableTestCoverage -eq "true")
{
    $buildCmdResult += " -p:TestCoverage=TESTCOVERAGE"
}
Invoke-Expression -Command $buildCmdResult

Remove-Item $sln -Force