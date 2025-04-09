[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [int]$MaxParallelJobs = 3
)

$moduleRoot = Join-Path $RepoRoot 'src'
$subModules = @()

Get-ChildItem -Path $moduleRoot -Directory | ForEach-Object {
    $module = $_
    Get-ChildItem -Path $module.FullName -Directory | Where-Object {
        $_.Name -like '*.autorest'
    } | ForEach-Object {
        $sub_module = $_
        $subModules += ,@($module.Name, $sub_module.Name)
    }
}

$subModules = @(
    # V3
    @("Cdn","Cdn.Autorest"),
    @("ImageBuilder", "ImageBuilder.Autorest"),

    # V4
    @("Chaos", "Chaos.Autorest"),
    @("DeviceRegistry", "DeviceRegistry.Autorest"),
    @("Astro", "Astro.Autorest"),
    
    # V4 Multi sub-modules
    @("Communication","EmailService.Autorest"),
    @("Communication", "EmailServicedata.Autorest")
)

Write-Host "Total matched sub modules: $($subModules.Count)"

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

Write-Host "Total matched devides: $($devidedSubModules.Count)"

$index = 0
foreach ($subModules in $devidedSubModules) {
    Write-Host "Outer Group ${index}:"
    $subIndex = 0
    foreach ($subModule in $subModules) {
        Write-Host "Inner Group ${subIndex}: $($subModule -join ',')"
        $subIndex++
    }

    $moduleNames = $subModules | ForEach-Object { $_[0] }

    $MatrixStr="$MatrixStr,'" + $($index + 1) + "-" +  $($subModules.Count) + "':{'Target':$($moduleNames -join ',')}"

    $index++
}

$MatrixStr=$MatrixStr.Substring(1)
Write-Host "##vso[task.setVariable variable=Targets;isOutput=true]{$MatrixStr}"