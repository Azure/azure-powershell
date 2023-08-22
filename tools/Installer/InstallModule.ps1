<#
.SYNOPSIS
    .
.DESCRIPTION
    .
.PARAMETER ModuleName
    Name of the module to install. By default all modules are installed.
.PARAMETER SourceLocation
    Specifies the path for discovering and installing modules from.
    Taking current folder as source location by default
.EXAMPLE
    C:\PS> ./InstallModule.ps1 -ModuleName Az.Accounts
.NOTES
    Author: Beisi Zhou
    Date:   July 21, 2021    
#>

[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $false, Position = 0, HelpMessage = "Name of the module to install. By default all modules are installed.")]
  $ModuleName = "Az",
  [string]
  [Parameter(Mandatory = $false, Position = 1, HelpMessage = "Specifies the path for discovering and installing modules from.")]
  $SourceLocation = $PSScriptRoot,
  [string]
  [ValidateSet("CurrentUser", "AllUsers")]
  [Parameter(Mandatory = $false, Position = 2, HelpMessage = "The scope of the installed module")]
  $Scope = "CurrentUser"
)

$gallery = [guid]::NewGuid().ToString()
Write-Host "Registering temporary repository $gallery with InstallationPolicy Trusted..."
Register-PSRepository -Name $gallery -SourceLocation $SourceLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted    

try {
  Write-Host "Installing $ModuleName..."
  Install-Module -Name $ModuleName -Repository $gallery -Scope $Scope -AllowClobber -Force 
}
finally {
  Write-Host "Unregistering gallery $gallery..."
  Unregister-PSRepository -Name $gallery
}
