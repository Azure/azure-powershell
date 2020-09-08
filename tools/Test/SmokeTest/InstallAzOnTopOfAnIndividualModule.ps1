[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)
# Get previous version of Az.Compute
$versions = (find-module Az.Compute -Repository $gallery -AllVersions).Version |
% { [system.version]$_ } | Sort-Object -Descending | % { [System.String]$_ }

if ($versions.Count -ge 2) {
    # Install previous version of Az.Compute        
    $previousVersion = $versions[1]
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
    if ($azComputeVersion -ne $versions[0]) {
        throw "Install Az on top of Az.Compute failed"
    }
}