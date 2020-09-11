[cmdletbinding()]
param(
    [string]
    [Parameter(Mandatory = $true, Position=0)]
    $gallery
)

switch ($gallery) {
    'PSGallery' 
    {   
        Write-Host "Setting $gallery Trusted..."
        Set-PSRepository -Name $gallery -InstallationPolicy Trusted
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
        Write-Host "Registering $gallery Trusted..."
        $sourceLocation = Join-Path -Path $env:PIPELINE.WORKSPACE -ChildPath "LocalRepo"
        Register-PSRepository -Name $gallery -SourceLocation $sourceLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted
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