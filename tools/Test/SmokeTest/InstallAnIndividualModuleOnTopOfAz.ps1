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

# Get previous version of Az.Compute
$azComputePreviousVersion = (Get-Module Az.Compute -ListAvailable).Version
Write-Host "Current version of Az.Compute,", $azComputePreviousVersion

#Install Az.Compute
Write-Host "Installing latest Az.Compute"
Install-Module -Name Az.Compute -Repository $gallery -Scope CurrentUser -AllowClobber -Force        

# Load Az.Compute
Write-Host "Running Get-AzVM to load Az.Compute..."
Get-AzVM

# Check version
$azComputeVersion = (Get-Module Az.Compute).Version
Write-Host "Az.Compute version before updated", $azComputePreviousVersion
Write-Host "Current version of Az.Compute,", $azComputeVersion

if ([System.Version]$azComputeVersion -gt [System.Version]$azComputePreviousVersion) {
    Write-Host "Install Az.Compute on top of Az successfully"
}elseif(([System.Version]$azComputeVersion -eq [System.Version]$azComputePreviousVersion) -and $allowEquality){
    Write-Warning "Az.Compute did not update"
}else{
    throw "Install Az.Compute on top of Az failed"
}
 
