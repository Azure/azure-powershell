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
$modules = Get-SubModuleWithAutorestV4 -srcPath $srcPath
$modules = $modules.GetEnumerator() | ForEach-Object {
    [PSCustomObject]@{
        ModuleName = $_.Key
        SubModules = ($_.Value | Sort-Object)
    }
} | Sort-Object -Property ModuleName


# $subModules = @(
#     # V3
#     @("Cdn","Cdn.Autorest"),
#     @("ImageBuilder", "ImageBuilder.Autorest"),

#     # V4
#     @("Chaos", "Chaos.Autorest"),
#     @("DeviceRegistry", "DeviceRegistry.Autorest"),
#     @("Astro", "Astro.Autorest"),
    
#     # V4 Multi sub-modules
#     @("Communication","EmailService.Autorest")
#     # @("Communication", "EmailServicedata.Autorest")
# )

# Write-Host "Total matched sub modules: $($subModules.Count)"

function Group-List {
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

$groupedModules = Group-List -modules $modules -maxParallelJobs $MaxParallelJobs
Write-Host "Total module groups: $($groupedModules.Count)"

$index = 0
foreach ($moduleGroup in $groupedModules) {
    Write-Host "##vso[task.loggroup name=ModuleGroup_$($index + 1)]"
    $mergedModules = @{}
    foreach ($moduleObj in $moduleGroup) {
        Write-Host "Module $($moduleObj.ModuleName): $($moduleObj.SubModules -join ',')"
        $mergedModules[$moduleObj.ModuleName] = @($moduleObj.SubModules)
        $subIndex++
    }

    $moduleStr = $mergedModules | ConvertTo-Json -Depth 3 -Compress
    $key = ($index + 1).ToString() + "-" + $moduleGroup.Count
    $MatrixStr = "$MatrixStr,'$key':{'Target':'$moduleStr','MatrixKey':'$key'}"
    Write-Host "##vso[task.loggroup]"
    $index++
}

if ($MatrixStr -and $MatrixStr.Length -gt 1) {
    $MatrixStr = $MatrixStr.Substring(1)
}
Write-Host "##vso[task.setVariable variable=generateTargets;isOutput=true]{$MatrixStr}"
