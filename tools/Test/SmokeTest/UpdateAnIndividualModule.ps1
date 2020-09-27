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

#Update Az.Compute
Write-Host "Updating latest version of Az.Compute"
Update-Module -Name Az.Compute -Scope CurrentUser -Force

# Load Az.Compute 
Write-Host "Running Get-AzVM to load Az.Compute..."
Get-AzVM
        
# Check Az.Compute version
$azComputeVersion = (Get-Module Az.Compute).Version | Sort-Object -Descending
Write-Host "Current version of Az.Compute", $azComputeVersion

if ([System.Version]$azComputeVersion -lt [System.Version]$previousVersion) {
    throw "Update Az.Compute failed"
}elseif([System.Version]$azComputeVersion -eq [System.Version]$previousVersion){
    Write-Warning "Az.Compute did not update"
}else{
    Write-Host "Update Az.Compute successfully"
}
