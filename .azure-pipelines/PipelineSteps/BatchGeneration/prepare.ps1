[CmdletBinding(DefaultParameterSetName="AllSet")]
param (
    [string]$RepoRoot,
    [int]$MaxParallelJobs = 3
)

$srcPath = Join-Path $RepoRoot 'src'
function Get-SubModuleWithAutorestV4 {
    param (
        [string]$srcPath
    )
    
    $result = @{}

    Get-ChildItem -Path $srcPath -Directory | ForEach-Object {
        $module = $_

        Get-ChildItem -Path $module.FullName -Directory | Where-Object { 
            $_.Name -like '*.autorest'
        } | ForEach-Object {
            $subModule = $_
            
            $readmePath = Join-Path $subModule.FullName 'README.md'

            if (Test-Path $readmePath) {
                $readmeContent = Get-Content -Path $readmePath -Raw

                if ($readmeContent -notmatch 'use-extension:\s+"@autorest/powershell":\s+"3.x"') {
                    if ($result.ContainsKey($module.Name)) {
                        $result[$module.Name] += $subModule.Name
                    } else {
                        $result[$module.Name] = @($subModule.Name) 
                    }
                }
            }
        }
    }

    return $result
}
# TODO(Bernard): Use real function after test
# $modules = Get-SubModuleWithAutorestV4 -srcPath $srcPath
$modules = @{
    "DeviceRegistry" = @("DeviceRegistry.Autorest")
    "ArcGateway" = @("ArcGateway.Autorest")
    "Chaos" = @("Chaos.Autorest")
    "Cdn" = @("Cdn.Autorest")
    "Communication" = @("EmailService.Autorest", "EmailServicedata.Autorest")
    "Astro" = @("Astro.Autorest")
    "ImageBuilder" = @("ImageBuilder.Autorest")
}
$modules = $modules.GetEnumerator() | ForEach-Object {
    [PSCustomObject]@{
        ModuleName = $_.Key
        SubModules = ($_.Value | Sort-Object)
    }
} | Sort-Object -Property ModuleName

Write-Host "Total matched modules: $($modules.Count)"

function Group-Modules {
    param (
        [array]$modules,
        [int]$maxParallelJobs
    )

    $count = $modules.Count
    $n = [Math]::Min($count, $maxParallelJobs)
    if ($n -eq 0) {
        return @()
    }

    $result = @()
    $sizePerGroup = [Math]::Ceiling($count / $n)

    for ($i = 0; $i -lt $count; $i += $sizePerGroup) {
        $group = $modules[$i..([Math]::Min($i + $sizePerGroup - 1, $count - 1))]
        $result += ,$group
    }

    return $result
}

$groupedModules = Group-Modules -modules $modules -maxParallelJobs $MaxParallelJobs
Write-Host "Total module groups: $($groupedModules.Count)"

$index = 0
$generateTargets = @{}
foreach ($moduleGroup in $groupedModules) {
    Write-Host "##[group]Prepareing module group $($index + 1)"
    $mergedModules = @{}
    foreach ($moduleObj in $moduleGroup) {
        Write-Host "Module $($moduleObj.ModuleName): $($moduleObj.SubModules -join ',')"
        $mergedModules[$moduleObj.ModuleName] = @($moduleObj.SubModules)
        $subIndex++
    }

    $key = ($index + 1).ToString() + "-" + $moduleGroup.Count
    $generateTargets[$key] = $mergedModules
    $MatrixStr = "$MatrixStr,'$key':{'MatrixKey':'$key'}"
    Write-Host "##[endgroup]"
    Write-Host
    $index++
}

$generateTargetsOutputDir = Join-Path $RepoRoot "artifacts"
if (-not (Test-Path -Path $generateTargetsOutputDir)) {
    New-Item -ItemType Directory -Path $generateTargetsOutputDir
}
$generateTargetsOutputFile = Join-Path $generateTargetsOutputDir "generateTargets.json"
$generateTargets | ConvertTo-Json -Depth 5 | Out-File -FilePath $generateTargetsOutputFile -Encoding utf8

if ($MatrixStr -and $MatrixStr.Length -gt 1) {
    $MatrixStr = $MatrixStr.Substring(1)
}
Write-Host "##vso[task.setVariable variable=generateTargets;isOutput=true]{$MatrixStr}"
