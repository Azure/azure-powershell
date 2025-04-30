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

$changedModulesDict = @{}
$changedSubModulesDict = @{}
for ($i = 0; $i -lt $ChangedFiles.Count; $i++) {
    if ($ChangedFiles[$i] -match '^(src|generated)/([^/]+)/([^/]+\.autorest)/') {
        $parent = $Matches[2]
        $child = $Matches[3]
        $key = "$parent/$child"
        
        $changedModulesDict[$parent] = $true
        $changedSubModulesDict[$key] = $true
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
Write-Matrix -GroupedModules $groupedAnalyzeModules -variableName 'analyzeTargets' -RepoRoot $RepoRoot

# $groupedTestWindowsModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParallelTestWindowsJobs
# Write-Matrix -variableName 'TestWindowsTargets' -groupedSubModules $groupedTestWindowsModules

# $groupedTestLinuxModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParallelTestLinuxJobs
# Write-Matrix -variableName 'TestLinuxTargets' -groupedSubModules $groupedTestLinuxModules

# $groupedTestMacModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParallelTestMacJobs
# Write-Matrix -variableName 'TestMacTargets' -groupedSubModules $groupedTestMacModules
