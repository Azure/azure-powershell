[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)
# Install Az.Compute
Write-Host "Installing Az.Compute..."
Install-Module -Name Az.Compute -Repository $gallery -Scope CurrentUser -AllowClobber -Force 

# Load Az.Compute
Write-Host "Running Get-AzVM to load Az.Compute..."
Get-AzVM

# Check Az.Compute version
$azComputeVersion = (Get-Module Az.Compute).Version
Write-Host "Current version of Az.Compute", $azComputeVersion

if (!$azComputeVersion) {
    throw "No Az.Compute is installed"
}
