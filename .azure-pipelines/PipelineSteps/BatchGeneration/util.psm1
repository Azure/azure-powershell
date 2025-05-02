function Group-Modules {
    param (
        [array]$Modules,
        [int]$MaxParallelJobs
    )

    $count = $Modules.Count
    $n = [Math]::Min($count, $MaxParallelJobs)

    if ($n -eq 0) {
        return @()
    }

    $result = @()

    for ($i = 0; $i -lt $n; $i++) {
        $result += ,@()
    }

    for ($i = 0; $i -lt $count; $i++) {
        $groupIndex = $i % $n
        $result[$groupIndex] += $Modules[$i]
    }

    return ,$result
}

function Write-Matrix {
    param (
        [array]$GroupedModules,
        [string]$VariableName,
        [string]$RepoRoot
    )

    Write-Host "Module groups: $($GroupedModules.Count)"
    $GroupedModules | ForEach-Object { $_ -join ', ' } | ForEach-Object { Write-Host $_ }

    $targets = @{}
    $MatrixStr = ""
    $index = 0
    foreach ($modules in $GroupedModules) {
        $key = ($index + 1).ToString() + "-" + $modules.Count
        $MatrixStr = "$MatrixStr,'$key':{'MatrixKey':'$key'}"
        $targets[$key] = $modules
        $index++
    }

    if ($MatrixStr -and $MatrixStr.Length -gt 1) {
        $MatrixStr = $MatrixStr.Substring(1)
    }
    Write-Host "##vso[task.setVariable variable=$VariableName;isOutput=true]{$MatrixStr}"
    Write-Host "variable=$VariableName; value=$MatrixStr"

    $targetsOutputDir = Join-Path $RepoRoot "artifacts"
    if (-not (Test-Path -Path $targetsOutputDir)) {
        New-Item -ItemType Directory -Path $targetsOutputDir -Force | Out-Null
    }
    $targetsOutputFile = Join-Path $targetsOutputDir "$VariableName.json"
    $targets | ConvertTo-Json -Depth 5 | Out-File -FilePath $targetsOutputFile -Encoding utf8
}

function Get-Targets {
    param (
        [string]$RepoRoot,
        [string]$TargetsOutputFileName,
        [string]$MatrixKey
    )

    $targetsOutputFile = Join-Path $RepoRoot "artifacts" $TargetsOutputFileName
    $targetGroups = Get-Content -Path $targetsOutputFile -Raw | ConvertFrom-Json
    $targetGroup = $targetGroups.$MatrixKey
    Write-Host "##[group]Target group: $MatrixKey"
    $targetGroup | ForEach-Object { Write-Host $_ }
    Write-Host "##[endgroup]"
    Write-Host
    return $targetGroup
}
