[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $false, Position = 0)]
  $ModuleName = "Az",
  [string]
  [Parameter(Mandatory = $false, Position = 1)]
  $SourceLocation = $PSScriptRoot
)

function Register-Gallery {
  param(
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $GalleryName,
    [string]
    [Parameter(Mandatory = $false, Position = 1)]
    $SourceLocation
  )  
  switch ($GalleryName) {
    'PSGallery' {   
      Write-Host "Setting $GalleryName Trusted..."
      Set-PSRepository -Name $GalleryName -InstallationPolicy Trusted
      break;
    }
    'TestGallery' { 
      Write-Host "Registering $GalleryName Trusted..."
      Register-PSRepository -Name $GalleryName -SourceLocation 'https://www.poshtestgallery.com/api/v2' -PackageManagementProvider NuGet -InstallationPolicy Trusted
      break;
    }
    Default {
      Write-Host "Registering $GalleryName Trusted..."
      Register-PSRepository -Name $GalleryName -SourceLocation $SourceLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted    }
  }
}

$gallery = [guid]::NewGuid().ToString()
Register-Gallery -GalleryName $gallery -SourceLocation $SourceLocation

try {	
	Write-Host "Installing $ModuleName..."
	Install-Module -Name $ModuleName -Repository $gallery -Scope CurrentUser -AllowClobber -Force 
}
finally {
	Write-Host "Unregistering gallery $gallery..."
	Unregister-PSRepository -Name $gallery
}