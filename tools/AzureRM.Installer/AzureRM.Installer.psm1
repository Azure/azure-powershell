<#
 .Synopsis
  Install Azure Resource Manager cmdlet modules

 .Description
  Installs all the available Azure Resource Manager cmdlet modules that start with "AzureRM".

 .Parameter Repository
  Limit the search for "AzureRM" cmdlets in a specific repository.
 
 .Parameter Scope
  Specifies the parameter scope.
#>
function Install-AzureRM
{
    param(
    [Parameter(Position=0, Mandatory = $false)]
    [string]
    $Repository,

    [Parameter(Position=1, Mandatory = $false)]
    [ValidateSet("CurrentUser","AllUsers")]
    [string]
    $Scope)

    if ([string]::IsNullOrWhiteSpace($Scope))
    {
      $Scope = "AllUsers"
    }

    # Retrieve a list of modules
    if ([string]::IsNullOrWhiteSpace($Repository))
    {
        $modules = Find-Module -Name AzureRM.* | Where-Object {$_.Name -ne "AzureRM.Installer"}
        Install-Module $modules -Scope $Scope
    }
    else
    {
        $modules = Find-Module -Repository $Repository | Where-Object {$_.Name -like "AzureRM.*" -and $_.Name -ne "AzureRM.Installer"}
        Install-Module $modules -Repository $Repository -Scope $Scope
    }
}

<#
 .Synopsis
  Updates Azure Resource Manager cmdlet modules

 .Description
  Updates all installed Azure Resource Manager cmdlet modules that start with "AzureRM".
#>
function Update-AzureRM
{
    $modules = Get-InstalledModule -Name AzureRM.*
    $modules | Update-Module
}