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
Write-Host '$previousVersion:', $previousVersion
Write-Host "Installed previous version of Az.Compute"

Install-Module -Name Az.Compute -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force

#Install Az
Install-Module -Name Az -Repository $gallery -Scope CurrentUser -AllowClobber -Force
        
Write-Host "Installed latest version of Az"
Get-AzVM
Get-Module

# Check version
$azComputeVersion = (Get-Module Az.Compute).Version
Write-Host "Current version of Az.Compute", $azComputeVersion

if ([System.Version]$azComputeVersion -lt [System.Version]$previousVersion) {
 throw "Install Az on top of Az.Compute failed"
}else if([System.Version]$azComputeVersion -eq [System.Version]$previousVersion){
    Write-Warning "Az did not update"
}
