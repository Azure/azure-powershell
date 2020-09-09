[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery
)
# Update PowershellGet 
Install-Module -Name PowerShellGet -Scope CurrentUser -Force

# Get previous version of az
$versions = (find-module Az -Repository $gallery -AllVersions).Version | Sort-Object -Descending
Write-Host 'az versions:', $versions

Get-Module PowerShellGet -ListAvailable

# if ($versions.Count -ge 2) {
#     # Install previous version of Az
#     $previousVersion = $versions[1]
#     Write-Host '$previousVersion:', $previousVersion

#     Install-Module -Name Az -Repository $gallery -RequiredVersion $previousVersion -Scope CurrentUser -AllowClobber -Force

#     #Update Az
#     Update-Module -Name Az -Scope CurrentUser -Force
        
#     # Check Az
#     Write-Host "Get latest version of Az"
#     Get-Module -Name Az.* -ListAvailable

#     # Check version
#     Import-Module -MinimumVersion '2.6.0' -Name 'Az' -Force -Scope 'Global'
#     $azVersion = (get-module Az).Version
#     Write-Host "Current version of Az", $azVersion

#     if ($azVersion -ne $versions[0]) {
#         throw "Update Az failed"
#     }
        
#     # Reuse connected account and select subscription for test
#     Enable-AzureRmAlias
#     Set-AzContext -Subscription "Azure SDK Powershell Test"
# }else{
#     Write-Warning "Only one version available for Az"
#     Write-Host 'az versions:', $versions
#     get-help find-module
#     get-command find-module
#     throw "Update Az failed"
# }
