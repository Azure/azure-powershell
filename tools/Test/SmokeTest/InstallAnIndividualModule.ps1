[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)
Write-Host "Installing Az.Compute..."
Install-Module -Name Az.Compute -Repository $gallery -Scope CurrentUser -AllowClobber -Force 
Get-AzVM

# Check version
$azComputeVersion = (Get-Module Az.Compute).Version
Write-Host "Current version of Az.Compute", $azComputeVersion

if (!$azComputeVersion) {
    throw "No Az.Compute is installed"
}