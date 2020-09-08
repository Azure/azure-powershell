[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position=0)]
    $gallery
)

if( $gallery -eq 'PSGallery' ){
    Write-Host "Setting $gallery Trusted..."
    Set-PSRepository -Name $gallery -InstallationPolicy Trusted
}

if( $gallery -eq 'TestGallery' ){
    Write-Host "Registering $gallery..."
    Register-PSRepository -Name $gallery -SourceLocation 'https://www.poshtestgallery.com/api/v2' -PackageManagementProvider NuGet -InstallationPolicy Trusted
}    

Write-Host "Installing Az..."
Install-Module -Name Az -Repository $gallery -Scope CurrentUser -AllowClobber -Force 
      
# Check version
Import-Module -MinimumVersion '2.6.0' -Name 'Az' -Force
$azVersion = (get-module Az).Version

# Check Az
Get-Module -Name Az.* -ListAvailable
Write-Host "Current version of Az", $azVersion

if(!$azVersion){
    throw "No Az is installed"
}