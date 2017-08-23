

function Test-AdminRights([string]$Scope)
{
  Write-Warning "This function is deprecated"
  
}

function CheckIncompatibleVersion([bool]$Force)
{
  Write-Warning "This function is deprecated"

}

function Install-ModuleWithVersionCheck([string]$Name,[string]$MinimumVersion,[string]$Repository,[string]$Scope,[switch]$Force)
{
 Write-Warning "This function is deprecated"
}

<#
 .Synopsis
  Install Azure Resource Manager cmdlet modules

 .Description
  Installs all the available Azure Resource Manager cmdlet modules that have a matching major version.

 .Parameter MajorVersion
  Specifies the major version.

 .Parameter Repository
  Limit the search for "AzureRM" cmdlets in a specific repository.
 
 .Parameter Scope
  Specifies the parameter scope.

 .Parameter Force
  Force download and installation of modules already installed.
#>
function Update-AzureRM
{
  
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MajorVersion,
  [Parameter(Position=1, Mandatory = $false)]
  [string]
  $Repository = "PSGallery",
  [Parameter(Position=2, Mandatory = $false)]
  [ValidateSet("CurrentUser","AllUsers")]
  [string]
  $Scope = "AllUsers",
  [switch]
  $Force = $false)

  Write-Warning "This cmdlet is deprecated"
}

<#
 .Synopsis
  Import Azure Resource Manager cmdlet modules

 .Description
  Imports all the Azure Resource Manager cmdlet modules that have a matching major version.

 .Parameter MajorVersion
  Specifies the major version.
#>
function Import-AzureRM
{
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MajorVersion )
  Write-Warning "This cmdlet is deprecated"
}

function Uninstall-ModuleWithVersionCheck([string]$Name,[string]$MinVersion)
{
  Write-Warning "This functionis deprecated"
}

<#
 .Synopsis
  Remove Azure Resource Manager cmdlet modules

 .Description
  Removes all installed Azure Resource Manager cmdlet modules that have a matching major version.

 .Parameter MajorVersion
  Specifies the major version.
#>
function Uninstall-AzureRM
{
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MinVersion)

  Write-Warning "This cmdlet is deprecated"
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *