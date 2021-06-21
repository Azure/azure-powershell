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

#Update Az.Compute
Write-Host "Updating latest version of Az.Compute"
Update-Module -Name Az.Compute -Scope CurrentUser -Force

# Load Az.Compute 
Write-Host "Running Get-AzVM to load Az.Compute..."
Get-AzVM
        
# Check Az.Compute version
$azComputeVersion = (Get-Module Az.Compute).Version | Sort-Object -Descending
Write-Host "Az.Compute version before updated", $previousVersion
Write-Host "Current version of Az.Compute", $azComputeVersion

if ([System.Version]$azComputeVersion -gt [System.Version]$previousVersion) {
    Write-Host "Update Az.Compute successfully"
}elseif(([System.Version]$azComputeVersion -eq [System.Version]$previousVersion) -and $allowEquality){
    Write-Warning "Az.Compute did not update"
}else{
    throw "Update Az.Compute failed"
}
