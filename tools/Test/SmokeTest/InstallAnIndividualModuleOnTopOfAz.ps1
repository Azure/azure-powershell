[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)
# Get previous version of Az
$versions = (find-module Az -Repository PSGallery -AllVersions).Version | Sort-Object -Descending

if ($versions.Count -ge 2) {
    # Install previous version of Az
    $previousVersion = $versions[1]
    Write-Host '$previousVersion:', $previousVersion
    Install-Module -Name Az -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force
    Write-Host 'Installed the previous version of Az'

    # Get previous version of Az.Compute
    $azComputePreviousVersion = (Get-Module Az.Compute -ListAvailable).Version

    #Install Az.Compute
    Install-Module -Name Az.Compute -Repository $gallery -Scope CurrentUser -AllowClobber -Force        
        
    Write-Host "Installed latest Az.Compute"
    Get-AzVM
    Get-Module

    # Check version
    $azComputeVersion = (Get-Module Az.Compute).Version
    Write-Host "Current version of Az.Compute", $azComputeVersion

    if ($azComputeVersion -le $azComputePreviousVersion) {
        throw "Install Az.Compute on top of Az failed"
    }
}else {
    Write-Warning "Only one version available for Az"
    Write-Host 'Az versions:', $versions
    throw "Install Az.Compute on top of Az failed"
}       
