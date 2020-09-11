[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position=0)]
    $gallery
)

switch ($gallery) {
    'PSGallery' 
    {  
        break;
    }
    'TestGallery'
    { 
        Write-Host "Registering $gallery..."
        Register-PSRepository -Name $gallery -SourceLocation 'https://www.poshtestgallery.com/api/v2' -PackageManagementProvider NuGet -InstallationPolicy Trusted
        break;
    }
    'LocalRepo'
    {
        Write-Host "Setting $gallery Trusted..."
        Register-PSRepository -Name $gallery -SourceLocation 'https://bezstorage101.file.core.windows.net/localrepo/local repository' -PackageManagementProvider NuGet -InstallationPolicy Trusted
        break;
    }
    Default 
    {
        throw "Invalid gallery"
    }
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