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
	[Parameter(ParameterSetName="TargetModuleSet")]
    [string[]]$TargetModule,
    [switch]$GenerateDocumentationFile,
    [switch]$EnableTestCoverage

)
function Get-CsprojFromModule {
    param (
        [string[]]$BuildModuleList,
        [string]$SourceDirectory,
        [string]$GeneratedDirectory
    )

    $modulePath = @()
    foreach ($moduleName in $BuildModuleList) {
        if ($SourceDirectory) {
            $modulePath += Join-Path $SourceDirectory $moduleName
        }
        if ($GeneratedDirectory) {
            $modulePath += Join-Path $GeneratedDirectory $moduleName
        }
    }
    return Get-ChildItem -Path $modulePath -Filter "*.csproj" -Recurse | foreach-object { $_.FullName }
}

<################################################
#  Main
#################################################>
<#
    TODO: add comments
#>
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
if (-not (Test-Path $sourceDirectory)) {
    Write-Warning "Cannot find source directory: $sourceDirectory"
} elseif (-not (Test-Path $generatedDirectory)) {
    Write-Warning "Cannot find generated directory: $generatedDirectory"
}

switch ($PSCmdlet.ParameterSetName) {
    'AllSet' {
        $TargetModule = Get-Childitem -Path $sourceDirectory -Directory | ForEach-Object {$_.Name} | Where-Object { $_ -notin $notModules}
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
            $CIPlan = Get-Content $CIPlanPath | ConvertFrom-Json
            $TargetModule = $CIPlan.build
            $testModules = $CIPlan.test
        }
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
    }
    'TargetModuleSet' {
        $testModules = $TargetModule
    }
}

$csprojFiles = Get-CsprojFromModule -BuildModuleList $TargetModule -SourceDirectory $sourceDirectory -GeneratedDirectory $generatedDirectory
$testCsprojPattern = @()
foreach ($testModule in $testModules) {
    if ($testModule -in $renamedModules) {
        foreach ($renamedTestModule in $renamedModules[$testModule]) {
            $testCsprojPattern += "^*.$renamedTestModule.Test.csproj$"
        }
    }
    $testCsprojPattern += "^*.$testModule.Test.csproj$"
}
$testCsprojPattern = ($testCsprojPattern | Join-String -Separator '|')
$testCsproj = $csprojFiles | Where-Object { $_ -match $testCsprojPattern }
# can be simplified by more complex regex maybe
$csprojFiles | Where-Object { ($_ -notmatch '^*.test.csproj$') -or $_ -in $testCsproj }
if ($testModule -and $testModule.Length -ne 0) {
    $csprojFiles += Join-Path $RepoRoot "tools" "TestFx" "TestFx.csproj"
}
if ('Release' -eq $Configuration) {
    $csprojFiles | Where-Object { $_ -notmatch '^*.test.csproj$' }
}
$csprojFiles | Select-Object -Unique

$TargetModule | Foreach-Object {
    . "$toolDirectory/PrepareAutorestModule.ps1" -ModuleRootName $_ -RepoRoot $RepoRoot
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