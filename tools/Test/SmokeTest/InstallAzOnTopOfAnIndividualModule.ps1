[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery,
    [bool]
    [Parameter(Mandatory = $false, Position =1)]
    $allowEquality = $false
)
# Get previous version of Az.Compute
. "$PSScriptRoot/Common.ps1"
$previousVersion = Get-ModulePreviousVersion $gallery "Az.Compute"

# Install previous version of Az.Compute
Write-Host "Installing previous version of Az.Compute:", $previousVersion
Install-Module -Name Az.Compute -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force

#Install Az
Write-Host "Installing latest version of Az"
Install-Module -Name Az -Repository $gallery -Scope CurrentUser -AllowClobber -Force
     
Write-Host "Running Get-AzVM to load Az.Compute..."
Get-AzVM

# Check version
$azComputeVersion = (Get-Module Az.Compute).Version
Write-Host "Az.Compute version before updated", $previousVersion
Write-Host "Current version of Az.Compute", $azComputeVersion

Write-Host "Checking Az details..."
Get-Module -Name Az.* -ListAvailable

if ([System.Version]$azComputeVersion -gt [System.Version]$previousVersion) {
    Write-Host "Install Az on top of Az.Compute successfully"
}elseif(([System.Version]$azComputeVersion -eq [System.Version]$previousVersion) -and $allowEquality){
    Write-Warning "Az.Compute did not update"
}else{
    throw "Install Az on top of Az.Compute failed"
}
