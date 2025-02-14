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
    [Parameter(ParameterSetName="AllSet")]
    [string]$TestsToRun = 'All',
    [Parameter(ParameterSetName="CIPlanSet", Mandatory=$true)]
    [switch]$CIPlan,
    [Parameter(ParameterSetName="ModifiedModuleSet", Mandatory=$true)]
    [switch]$ModifiedModule,
	[Parameter(ParameterSetName="TargetModuleSet", Mandatory=$true)]
    [string[]]$TargetModule,
    [switch]$ForceRegenerate,
    [switch]$InvokedByPipeline,
    [switch]$GenerateDocumentationFile,
    [switch]$EnableTestCoverage,
    [string]$Scope = 'Netcore',
    [boolean]$CodeSign = $false

)
if (($null -eq $RepoRoot) -or (0 -eq $RepoRoot.Length)) {
    $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot '..' '..')

}

$notModules = @('lib', 'shared', 'helpers')
$coreTestModule = @('Compute', 'Network', 'Resources', 'Sql', 'Websites')
$RepoArtifacts = Join-Path $RepoRoot "Artifacts"

$csprojFiles = @()
$testModule = @()
$toolDirectory = Join-Path $RepoRoot "tools"
$sourceDirectory = Join-Path $RepoRoot "src"
$generatedDirectory = Join-Path $RepoRoot "generated"

$BuildScriptsModulePath = Join-Path $toolDirectory 'BuildScripts' 'BuildScripts.psm1'
Import-Module $BuildScriptsModulePath

if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

# Add Accounts to target module by default, this is to ensure accounts is always built when target/modified module parameter sets
$TargetModule += 'Accounts'
$testModule += 'Accounts'

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
            $testModule = $coreTestModule
        } elseif ('NonCore') {
            $testModule = $TargetModule | Where-Object { $_ -notin $coreTestModule}
        } else {
            $testModule = $TargetModule
        }
    }
    'CIPlanSet' {
        $CIPlanPath = Join-Path $RepoArtifacts "PipelineResult" "CIPlan.json"
        If (Test-Path $CIPlanPath) {
            $CIPlanContent = Get-Content $CIPlanPath | ConvertFrom-Json
            foreach($build in $CIPlanContent.build) {
                $TargetModule += $build
            }
            foreach($test in $CIPlanContent.test) {
                $testModule += $test
            }
        }
        Write-Host "----------Start building modules from $CIPlanPath----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
    'ModifiedModuleSet' {
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
        $testModule = $TargetModule
        Write-Host  "----------Start building modified modules----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
    'TargetModuleSet' {
        $testModule = $TargetModule
        Write-Host  "----------Start building target modules----------`r`n$($TargetModule | Join-String -Separator "`r`n")" -ForegroundColor DarkYellow
    }
}

$TargetModule = $TargetModule | Select-Object -Unique
$testModule = $testModule | Select-Object -Unique

# Prepare autorest based modules
$prepareScriptPath = Join-Path $toolDirectory 'BuildScripts' 'PrepareAutorestModule.ps1'

$isInvokedByPipeline = $false
if ($InvokedByPipeline) {
    $isInvokedByPipeline = $true
}
foreach ($moduleRootName in $TargetModule) {
    Write-Host "Preparing $moduleRootName ..." -ForegroundColor DarkGreen
    & $prepareScriptPath -ModuleRootName $moduleRootName -RepoRoot $RepoRoot -ForceRegenerate:$ForceRegenerate -InvokedByPipeline:$isInvokedByPipeline
}

$buildCsprojFiles = Get-CsprojFromModule -BuildModuleList $TargetModule -RepoRoot $RepoRoot -Configuration $Configuration

Set-Location $RepoRoot
$buildSln = Join-Path $RepoArtifacts "Azure.PowerShell.sln"

& dotnet --version
if (Test-Path $buildSln) {
    Remove-Item $buildSln -Force
}
& dotnet new sln -n Azure.PowerShell -o $RepoArtifacts --force

foreach ($file in $buildCsprojFiles) {
    & dotnet sln $buildSln add "$file"
}
Write-Output "Modules are added to build sln file"

$LogFile = Join-Path $RepoArtifacts 'Build.log'
if ('Release' -eq $Configuration) {
    $BuildAction = 'publish'
} else {
    $BuildAction = 'build'

    $testCsprojFiles = Get-CsprojFromModule -TestModuleList $testModule -RepoRoot $RepoRoot -Configuration $Configuration
    $testSln = Join-Path $RepoArtifacts "Azure.PowerShell.Test.sln"
    if (Test-Path $testSln) {
        Remove-Item $testSln -Force
    }
    & dotnet new sln -n Azure.PowerShell.Test -o $RepoArtifacts --force
    foreach ($file in $testCsprojFiles) {
        & dotnet sln $testSln add "$file"
    }
    Write-Output "Modules are added to test sln file"
}

$buildCmdResult = "dotnet $BuildAction $Buildsln -c $Configuration -fl '/flp1:logFile=$LogFile;verbosity=quiet'"
If ($GenerateDocumentationFile -eq "false")
{
    $buildCmdResult += " -p:GenerateDocumentationFile=false"
}
if ($EnableTestCoverage -eq "true")
{
    $buildCmdResult += " -p:TestCoverage=TESTCOVERAGE"
}
Invoke-Expression -Command $buildCmdResult

$versionControllerCsprojPath = Join-Path $toolDirectory 'VersionController' 'VersionController.Netcore.csproj'
dotnet build $versionControllerCsprojPath -c $Configuration

$removeScriptPath = Join-Path $toolDirectory 'BuildScripts' 'RemoveUnwantedFiles.ps1'
& $removeScriptPath -RootPath (Join-Path $RepoArtifacts $Configuration) -CodeSign $CodeSign

$updateModuleScriptPath = Join-Path $toolDirectory 'UpdateModules.ps1'
pwsh $updateModuleScriptPath -BuildConfig $Configuration -Scope $Scope