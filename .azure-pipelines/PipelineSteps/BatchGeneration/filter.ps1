[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [int]$MaxParallelBuildJobs = 3,
    [int]$MaxParallelAnalyzeJobs = 3,
    [int]$MaxParallelTestWindowsJobs = 3,
    [int]$MaxParallelTestLinuxJobs = 3,
    [int]$MaxParallelTestMacJobs = 3,
    [string[]]$ChangedFiles,
    [string]$RepoRoot
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force
$artifactsDir = Join-Path $RepoRoot 'artifacts'

$changedModulesDict = @{}
$changedSubModulesDict = @{}
if ($env:RUN_TEST_ON_ALL_MODULES -eq "True") {
    Write-Host "Run test on all modules"
    $V4ModulesFile = Join-Path $artifactsDir "generationTargets.json"
    $V4ModuleMaps = Get-Content -Raw -Path $V4ModulesFile | ConvertFrom-Json

    foreach ($matrixKey in $V4ModuleMaps.PSObject.Properties.Name) {
        $moduleMap = $V4ModuleMaps.$matrixKey
        foreach ($moduleName in $moduleMap.PSObject.Properties.Name) {
            foreach ($subModuleName in $moduleMap.$moduleName) {
                $subModule = "$moduleName/$subModuleName"
                $changedModulesDict[$moduleName] = $true
                $changedSubModulesDict[$subModule] = $true
            }
        }
    }
}
else {
    Write-Host "Run test on generated folder changed modules"
    # Only generated folder change should trigger the test 
    for ($i = 0; $i -lt $ChangedFiles.Count; $i++) {
        if ($ChangedFiles[$i] -match '^generated/([^/]+)/([^/]+\.autorest)/') {
            $moduleName = $Matches[2]
            $subModuleName = $Matches[3]
            $subModule = "$moduleName/$subModuleName"
            
            $changedModulesDict[$moduleName] = $true
            $changedSubModulesDict[$subModule] = $true
        }
    }
}

$changedModules = $changedModulesDict.Keys | Sort-Object
$changedSubModules = $changedSubModulesDict.Keys | Sort-Object

Write-Host "##[group]Changed modules: $($changedModules.Count)"
foreach ($module in $changedModules) {
    Write-Host $module
}
Write-Host "##[endgroup]"
    Write-Host

Write-Host "##[group]Changed sub modules: $($changedSubModules.Count)"
foreach ($subModule in $changedSubModules) {
    Write-Host $subModule
}
Write-Host "##[endgroup]"
Write-Host

$groupedBuildModules = Group-Modules -Modules $changedModules -MaxParallelJobs $MaxParallelBuildJobs
Write-Matrix -GroupedModules $groupedBuildModules -VariableName 'buildTargets' -RepoRoot $RepoRoot

$groupedAnalyzeModules = Group-Modules -Modules $changedModules -MaxParallelJobs $MaxParallelAnalyzeJobs
Write-Matrix -GroupedModules $groupedAnalyzeModules -VariableName 'analyzeTargets' -RepoRoot $RepoRoot

$groupedTestWindowsModules = Group-Modules -Modules $changedSubModules -MaxParallelJobs $MaxParallelTestWindowsJobs
Write-Matrix -GroupedModules $groupedTestWindowsModules -VariableName 'testWindowsTargets' -RepoRoot $RepoRoot

$groupedTestLinuxModules = Group-Modules -Modules $changedSubModules -MaxParallelJobs $MaxParallelTestLinuxJobs
Write-Matrix -GroupedModules $groupedTestLinuxModules -VariableName 'testLinuxTargets' -RepoRoot $RepoRoot

$groupedTestMacModules = Group-Modules -Modules $changedSubModules -MaxParallelJobs $MaxParallelTestMacJobs
Write-Matrix -GroupedModules $groupedTestMacModules -VariableName 'testMacOSTargets' -RepoRoot $RepoRoot
