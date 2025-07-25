Param(
    [Parameter()]
    [ValidateSet("Major", "MINOR", "PATCH", "NONE")]
    [System.String]
    $VersionBump = "MINOR",
    [Parameter()]
    [System.String]
    $MinimalVersionFilePath = "$PSScriptRoot/../VersionController/MinimalVersion.csv"
)
Import-Module -Name "$PSScriptRoot/VersionBumpUtils.psm1" -Force

if(-not (Test-Path -Path $MinimalVersionFilePath)){
    throw "$MinimalVersionFilePath does not exist"
}
$file = [System.IO.File]::ReadAllLines($MinimalVersionFilePath)
$header = $file[0]
$lines = $file | Select-Object -Skip 1 | Where-Object {-not [System.String]::IsNullOrWhiteSpace($_)}
$minimalVersionContent = @($header)

# Read existing minimal versions
$minimalVersionHashTable = @{}
foreach ($line in $lines)
{
    $cols = $line.Split(",")
    if($cols.Count -ge 2){
        # Remove the first and last quote
        $key = $cols[0].Substring(1, $cols[0].Length - 2)
        $value = $cols[1].Substring(1, $cols[1].Length - 2)
        $minimalVersionHashTable[$key] = $value
    }
}

$az = Import-PowerShellDataFile -Path "$PSScriptRoot/../Az/Az.psd1"
foreach ($module in $az.RequiredModules)
{
    $moduleName = $module.ModuleName
    $moduleVersion = $module.RequiredVersion
    # Az.Accounts uses ModuleVersion to annote Version
    if ([string]::IsNullOrEmpty($moduleVersion))
    {
        $moduleVersion = $module.ModuleVersion
    }
    $minimalModuleVersion = Get-BumpedVersion -Version $moduleVersion -VersionBump $VersionBump
   
    if($minimalVersionHashTable.Contains($moduleName) -and [System.Version]$minimalVersionHashTable[$moduleName] -gt [System.Version]$minimalModuleVersion)
    {
        $minimalModuleVersion = $minimalVersionHashTable[$moduleName]
    }

    $minimalVersionHashTable[$moduleName] = $minimalModuleVersion
}
$minimalVersionHashTable.GetEnumerator() | ForEach-Object {
    $minimalVersionContent += """$($_.Key)"",""$($_.Value)"""
}
Set-Content -Path $MinimalVersionFilePath -Value $minimalVersionContent  -Encoding UTF8