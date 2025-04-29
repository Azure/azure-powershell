[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [int]$MaxParalleAnalyzeJobs = 3,
    [int]$MaxParalleTestWindowsJobs = 3,
    [int]$MaxParalleTestLinuxJobs = 3,
    [int]$MaxParalleTestMacJobs = 3,
    [string[]]$ChangedFiles
)

$autorestFolders = @{}
for ($i = 0; $i -lt $ChangedFiles.Count; $i++) {
    if ($ChangedFiles[$i] -match '^(src|generated)/([^/]+)/([^/]+\.autorest)/') {
        $parent = $Matches[2]
        $child = $Matches[3]
        $key = "$parent/$child"

        $autorestFolders[$key] = $true
    }
}

$changedSubModules = $autorestFolders.Keys
# TODO(Bernard) Remove test data after test
# $changedSubModules = @("A", "B", "C", "D", "E", "F", "G")
Write-Host "Chagned sub modules: "
foreach ($subModule in $changedSubModules) {
    Write-Host $subModule
}

function Split-List {
    param (
        [array]$subModules,
        [int]$maxParallelJobs
    )

    $count = $subModules.Count
    $n = [Math]::Min($count, $maxParallelJobs)

    if ($n -eq 0) {
        return @()
    }

    $result = @()

    for ($i = 0; $i -lt $n; $i++) {
        $result += ,@()
    }

    for ($i = 0; $i -lt $count; $i++) {
        $groupIndex = $i % $n
        $result[$groupIndex] += $subModules[$i]
    }

    return ,$result
}

function Write-Matrix {
    param (
        [string]$variableName,
        [array]$groupedSubModules
    )

    $index = 0
    foreach ($subModules in $groupedSubModules) {
        $moduleNamesStr = $subModules -join ','
        $key = ($index + 1).ToString() + "-" + $subModules.Count
        $MatrixStr = "$MatrixStr,'$key':{'Target':'$moduleNamesStr','MatrixKey':'$key'}"
        $index++
    }

    if ($MatrixStr -and $MatrixStr.Length -gt 1) {
        $MatrixStr = $MatrixStr.Substring(1)
    }
    Write-Host "##vso[task.setVariable variable=$variableName;isOutput=true]{$MatrixStr}"
    Write-Host "variable=$variableName; value=$MatrixStr"
    }

$groupedAnalyzeModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParalleAnalyzeJobs
Write-Matrix -variableName 'AnalyzeTargets' -groupedSubModules $groupedAnalyzeModules

$groupedTestWindowsModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParalleTestWindowsJobs
Write-Matrix -variableName 'TestWindowsTargets' -groupedSubModules $groupedTestWindowsModules

$groupedTestLinuxModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParalleTestLinuxJobs
Write-Matrix -variableName 'TestLinuxTargets' -groupedSubModules $groupedTestLinuxModules

# $groupedTestMacModules = Split-List -subModules $changedSubModules -maxParallelJobs $MaxParalleTestMacJobs
# Write-Matrix -variableName 'TestMacTargets' -groupedSubModules $groupedTestMacModules

Write-Host "##vso[task.setVariable variable=TestMacTargets;isOutput=true]{}"