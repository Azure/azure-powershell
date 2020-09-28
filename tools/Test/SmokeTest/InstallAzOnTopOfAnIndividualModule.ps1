[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
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
Write-Host "Current version of Az.Compute", $azComputeVersion

Write-Host "Checking Az details..."
Get-Module -Name Az.* -ListAvailable

if ([System.Version]$azComputeVersion -lt [System.Version]$previousVersion) {
 throw "Install Az on top of Az.Compute failed"
}elseif([System.Version]$azComputeVersion -eq [System.Version]$previousVersion){
    Write-Warning "Az.Compute did not update"
}else{
    Write-Host "Install Az on top of Az.Compute successfully"
}
