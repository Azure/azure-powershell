[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [int]$MaxParallelJobs = 3
)

$utilFilePath = Join-Path $RepoRoot '.azure-pipelines' 'PipelineSteps' 'BatchGeneration' 'util.psm1'
Import-Module $utilFilePath -Force

$srcPath = Join-Path $RepoRoot 'src'
$moduleMap = Get-AutorestV4ModuleMap -srcPath $srcPath
Write-Host "Total matched modules: $($moduleMap.Count)"

$modules = @($moduleMap.Keys | Sort-Object)
$groupedModules = Group-Modules -modules $modules -maxParallelJobs $MaxParallelJobs
Write-Host "Total module groups: $($groupedModules.Count)"

$index = 0
$generationTargets = @{}
foreach ($moduleGroup in $groupedModules) {
    Write-Host "##[group]Preparing module group $($index + 1) with $($moduleGroup.Count) modules"
    $mergedModules = @{}
    foreach ($moduleName in $moduleGroup) {
        Write-Host "Module $($moduleName): $($moduleMap[$moduleName] -join ',')"
        $mergedModules[$moduleName] = @($moduleMap[$moduleName])
        $subIndex++
    }

    $key = ($index + 1).ToString() + "-" + $moduleGroup.Count
    $generationTargets[$key] = $mergedModules
    $MatrixStr = "$MatrixStr,'$key':{'MatrixKey':'$key'}"
    Write-Host "##[endgroup]"
    Write-Host
    $index++
}

$generationTargetsOutputDir = Join-Path $RepoRoot "artifacts"
if (-not (Test-Path -Path $generationTargetsOutputDir)) {
    New-Item -ItemType Directory -Path $generationTargetsOutputDir
}
$generationTargetsOutputFile = Join-Path $generationTargetsOutputDir "generationTargets.json"
$generationTargets | ConvertTo-Json -Depth 5 | Out-File -FilePath $generationTargetsOutputFile -Encoding utf8

if ($MatrixStr -and $MatrixStr.Length -gt 1) {
    $MatrixStr = $MatrixStr.Substring(1)
}
Write-Host "##vso[task.setVariable variable=generationTargets;isOutput=true]{$MatrixStr}"
