[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)

# Get previous version of Az.Compute
if($gallery -eq "LocalRepo"){
    $versions = (find-module Az.Compute -Repository PSGallery -AllVersions).Version | Sort-Object -Descending
    $previousVersion = $versions[0]
}else{
    $versions = (find-module Az.Compute -Repository $gallery -AllVersions).Version | Sort-Object -Descending
    $previousVersion = $versions[1]
}

# Install previous version of Az.Compute
$previousVersion = $versions[1]
Write-Host '$previousVersion:', $previousVersion
Install-Module -Name Az.Compute -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force

#Update Az.Compute
Update-Module -Name Az.Compute -Scope CurrentUser -Force
Write-Host "Installed latest version of Az.Compute"

# Check Az.Compute
Get-AzVM
        
# Check version
$azComputeVersion = (Get-Module Az.Compute).Version | Sort-Object -Descending
Write-Host "Current version of Az.Compute", $azComputeVersion

if ([System.Version]$azComputeVersion -le [System.Version]$previousVersion) {
    throw "Update Az.Compute failed"
}
