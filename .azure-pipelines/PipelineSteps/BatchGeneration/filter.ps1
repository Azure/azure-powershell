[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [int]$MaxParallelJobs = 3,
    [string[]]$ChangedFiles
)

$autorestFolders = @{}

foreach ($file in $changedFiles) {
    if ($file -match '^(src|generated)/([^/]+)/([^/]+\.autorest)/') {
        $parent = $Matches[2]
        $child = $Matches[3]
        $key = "$parent/$child"

        $autorestFolders[$key] = $true
    }
}

$subModules = $autorestFolders.Keys
Write-Host "Outer Group ${subModules}:"

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
    $sizePerGroup = [Math]::Ceiling($count / $n)

    for ($i = 0; $i -lt $count; $i += $sizePerGroup) {
        $group = $subModules[$i..([Math]::Min($i + $sizePerGroup - 1, $count - 1))]
        $result += ,$group
    }

    return $result
}

$devidedSubModules = Split-List -subModules $subModules -maxParallelJobs $MaxParallelJobs

$index = 0
foreach ($subModules in $devidedSubModules) {
    Write-Host "Outer Group ${index}:"
    $subIndex = 0
    foreach ($subModule in $subModules) {
        Write-Host "Inner Group ${subIndex}: $($subModule -join ',')"
        $subIndex++
    }

    $moduleNamesStr = $subModules -join ','
    $key = ($index + 1).ToString() + "-" + $subModules.Count
    $MatrixStr = "$MatrixStr,'$key':{'Target':'$moduleNamesStr','MatrixKey':'$key'}"
    $index++
}

if ($MatrixStr -and $MatrixStr.Length -gt 1) {
    $MatrixStr = $MatrixStr.Substring(1)
}
Write-Host "##vso[task.setVariable variable=analyzeTargets;isOutput=true]{$MatrixStr}"
