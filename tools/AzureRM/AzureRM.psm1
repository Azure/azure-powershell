


<#
 .Synopsis
  DEPRECATED - Installing the AzureRM module installs all AzureRM cmdlets.

 .Description
  DEPRECATED - Installing the AzureRM module installs all AzureRM cmdlets.

 .Parameter MajorVersion
  DEPRECATED -Specifies the major version.

 .Parameter Repository
  DEPRECATED - Limit the search for "AzureRM" cmdlets in a specific repository.
 
 .Parameter Scope
  DEPRECATED - Specifies the parameter scope.

 .Parameter Force
  DEPRECATED - Force download and installation of modules already installed.
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

 
  Write-Output "DEPRECATED - This cmdlet is no longer necessary - installing the AzureRM module installs all AzureRM cmdlets."

  
}

<#
 .Synopsis
  DEPRECATED - If using WMF5, you can run Import-Module AzureRM to load all AzureRM modules.

 .Description
  DEPRECATED - If using WMF5, you can run Import-Module AzureRM to load all AzureRM modules.

 .Parameter MajorVersion
  DEPRECATED - Specifies the major version.
#>
function Import-AzureRM
{
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MajorVersion )
  Write-Output "DEPRECATED - If using Windows Management Framework 5, you can load all modules using 'Import-Module AzureRM'."

  
}



<#
 .Synopsis
  DEPRECATED - please uninstall each module using 'Uninstall-Module Azure* -Force'

 .Description
  DEPRECATED - this cmdlet has no effect on installed modules

 .Parameter MajorVersion
  DEPRECATED - Specifies the major version.
#>
function Uninstall-AzureRM
{
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MinVersion)

  

  Write-Output "DEPRECATED - to uninstall azure modules, remove or uninstall each module using 'Uninstall-Module'."

 
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function Uninstall-AzureRM, Update-AzureRM, Import-AzureRM -Alias Install-AzureRM
