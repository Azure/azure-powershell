$AzureRMProfileVersion = "0.9.8";

$AzureRMModules = @{
  "AzureRM.ApiManagement" = "0.9.8";
  "AzureRM.Automation" = "0.9.8";
  "AzureRM.Backup" = "0.9.8";
  "AzureRM.Batch" = "0.9.8";
  "AzureRM.Compute" = "0.9.8";
  "AzureRM.DataFactories" = "0.9.8";
  "AzureRM.Dns" = "0.9.8";
  "AzureRM.HDInsight" = "0.9.8";
  "AzureRM.Insights" = "0.9.8";
  "AzureRM.KeyVault" = "0.9.8";
  "AzureRM.Network" = "0.9.8";
  "AzureRM.OperationalInsights" = "0.9.8";
  "AzureRM.RedisCache" = "0.9.8";
  "AzureRM.Resources" = "0.9.8";
  "AzureRM.SiteRecovery" = "0.9.8";
  "AzureRM.Sql" = "0.9.8";
  "AzureRM.Storage" = "0.9.8";
  "AzureRM.StreamAnalytics" = "0.9.8";
  "AzureRM.Tags" = "0.9.8";
  "AzureRM.TrafficManager" = "0.9.8";
  "AzureRM.UsageAggregates" = "0.9.8";
  "AzureRM.Websites" = "0.9.8"
}

function Validate-AdminRights([string]$Scope)
{
  if ($Scope -ne "CurrentUser")
  {
    $user = [Security.Principal.WindowsIdentity]::GetCurrent();
    $isAdmin = (New-Object Security.Principal.WindowsPrincipal $user).IsInRole([Security.Principal.WindowsBuiltinRole]::Administrator)  
    if($isAdmin -eq $false)
    {
      throw "Administrator rights are required to install Microsoft Azure modules"
    }
  }
}

function Import-ModuleWithVersionCheck([string]$Name,[string]$MinimumVersion,[string]$Repository,[string]$Scope)
{
  $minVer = $MinimumVersion
  $maxVer = "$($minVer.Split(".")[0]).9999.0"
  try {
    if ([string]::IsNullOrWhiteSpace($Repository)) 
    {
      Install-Module -Name $Name -Scope $Scope -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Stop
    } else {
      Install-Module -Name $Name -Repository $Repository -Scope $Scope -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Stop
    } 
    $v = (Get-InstalledModule -Name $Name)[0].Version.ToString()
    Write-Output "$Name $v installed..." 
  } catch {
    Write-Warning "Skipping $Name package..."
    Write-Warning $_
  }
}

<#
 .Synopsis
  Install Azure Resource Manager cmdlet modules

 .Description
  Installs all the available Azure Resource Manager cmdlet modules.

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

  Validate-AdminRights $Scope

  Write-Output "Installing AzureRM modules."

  Import-ModuleWithVersionCheck "AzureRM.Profile" $AzureRMProfileVersion $Repository $Scope

  $result = $AzureRMModules.Keys | ForEach {
    Start-Job -Name $_ -ScriptBlock {
      Import-ModuleWithVersionCheck $args[0] $args[1] $args[2] $args[3]
    } -ArgumentList $_, $AzureRMModules[$_], $Repository, $Scope }
  
  $AzureRMModules.Keys | ForEach {Get-Job -Name $_ | Wait-Job | Receive-Job }
}

<#
 .Synopsis
  Remove Azure Resource Manager cmdlet modules

 .Description
  Removes all installed Azure Resource Manager cmdlet modules.
#>
function Uninstall-AzureRM
{
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $Repository)

  Validate-AdminRights "AllUsers"

  Write-Output "Uninstalling AzureRM modules."

  $AzureRMModules.Keys | ForEach {
    $moduleName = $_
    if ((Get-InstalledModule | where {$_.Name -eq $moduleName}) -ne $null) {
      $minVer = $AzureRMModules[$_]
      $maxVer = "$($minVer.Split(".")[0]).9999.0"
      Uninstall-Module -Name $_ -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Stop
      Write-Output "$moduleName uninstalled..." 
    }
  }

  if ((Get-InstalledModule | where {$_.Name -eq "AzureRM.Profile"}) -ne $null) {
    $minVer = $AzureRMProfileVersion
    $maxVer = "$($minVer.Split(".")[0]).9999.0"
    Uninstall-Module -Name "AzureRM.Profile" -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Stop
    Write-Output "AzureRM.Profile uninstalled..." 
  }
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *