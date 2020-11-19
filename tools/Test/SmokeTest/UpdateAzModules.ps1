[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery,
    [bool]
    [Parameter(Mandatory = $false, Position =1)]
    $allowEquality = $false
)

# Get previous version of Az
. "$PSScriptRoot/Common.ps1"
$previousVersion = Get-ModulePreviousVersion $gallery "Az"

# Install previous version of Az
Write-Host 'Installing the previous version of Az:', $previousVersion
Install-Module -Name Az -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force

#Update Az
Write-Host "Installing latest Az"
Update-Module -Name Az -Scope CurrentUser -Force
        
# Check details of Az 
Write-Host "Checking latest version of Az"
Get-Module -Name Az.* -ListAvailable

# Check Az version
Import-Module -MinimumVersion '2.6.0' -Name 'Az' -Force -Scope 'Global'
$azVersion = (get-module Az).Version
Write-Host "Az version before updated", $previousVersion
Write-Host "Current version of Az", $azVersion

if ([System.Version]$azVersion -gt [System.Version]$previousVersion) {
    Write-Host "Update Az successfully"
}elseif(([System.Version]$azVersion -eq [System.Version]$previousVersion) -and $allowEquality){
    Write-Warning "Az did not update"
}else{
    throw "Update Az failed"
}