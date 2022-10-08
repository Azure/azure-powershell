[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $true, Position = 0)]
  $gallery,
  [string]
  [Parameter(Mandatory = $false, Position = 1)]
  $localRepoLocation
)
function Register-Gallery {
  param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $gallery,
    [string]
    [Parameter(Mandatory = $false, Position = 1)]
    $localRepoLocation
  )  
  switch ($gallery) {
    'PSGallery' {   
      Write-Host "Setting $gallery Trusted..."
      Set-PSRepository -Name $gallery -InstallationPolicy Trusted
      break;
    }
    'TestGallery' { 
      Write-Host "Registering $gallery Trusted..."
      Register-PSRepository -Name $gallery -SourceLocation 'https://www.poshtestgallery.com/api/v2' -PackageManagementProvider NuGet -InstallationPolicy Trusted
      break;
    }
    'LocalRepo' {
      Write-Host "Registering $gallery Trusted..."
      Register-PSRepository -Name $gallery -SourceLocation $localRepoLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted
      break;
    }
    Default {
      throw "Invalid gallery", $gallery
    }
  }
}

Register-Gallery $gallery $localRepoLocation

Write-Host "Installing Az..."
Install-Module -Name Az -Repository $gallery -Scope CurrentUser -AllowClobber -Force 
      
# Check version
Import-Module -MinimumVersion '2.6.0' -Name 'Az' -Force
$azVersion = (get-module Az).Version
Write-Host "Current version of Az", $azVersion

# Check Az
Write-Host "Listing Az details..."
Get-Module -Name Az.* -ListAvailable

if (!$azVersion) {
  throw "No Az is installed"
}
