[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $false, Position = 0)]
  $ModuleName = "Az",
  [string]
  [Parameter(Mandatory = $false, Position = 1)]
  $SourceLocation = $PSScriptRoot
)

$gallery = [guid]::NewGuid().ToString()
Write-Host "Registering temporary repository $gallery with InstallationPolicy Trusted..."
Register-PSRepository -Name $gallery -SourceLocation $SourceLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted    

try {	
	Write-Host "Installing $ModuleName..."
	Install-Module -Name $ModuleName -Repository $gallery -Scope CurrentUser -AllowClobber -Force 
}
finally {
	Write-Host "Unregistering gallery $gallery..."
	Unregister-PSRepository -Name $gallery
}