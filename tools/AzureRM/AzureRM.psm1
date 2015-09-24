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
function Update-AzureRM
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

    Install-Module AzureRM.Profile -Repository $Repository
    if ([string]::IsNullOrWhiteSpace($Repository)) 
    {
      $modules = Find-Module -Name AzureRM.* | Where-Object {$_.Name -ne "AzureRM" -and $_.Name -ne "AzureRM.Profile"}
    } else {
      $modules = Find-Module -Repository $Repository | Where-Object {$_.Name -like "AzureRM.*" -and $_.Name -ne "AzureRM" -and $_.Name -ne "AzureRM.Profile"}
    }

    Write-Output "Installing $($modules.Length) AzureRM modules. This may take a few minutes."

    $result = $modules | ForEach {
        Start-Job -Name $_.Name -ScriptBlock {
          Install-Module -Name $args[0] -Repository $args[1] -Scope $args[2]
          Write-Output "$($args[0]) installed..."
        } -ArgumentList $_.Name, $Repository, $Scope }
    
    $modules | ForEach {Get-Job -Name $_.Name | Wait-Job | Receive-Job }
}