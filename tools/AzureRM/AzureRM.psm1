$AzureMajorVersion = "0";

$AzureRMModules = @(
  "AzureRM.ApiManagement",
  "AzureRM.Automation",
  "AzureRM.Backup",
  "AzureRM.Batch",
  "AzureRM.Compute",
  "AzureRM.DataFactories",
  "AzureRM.Dns",
  "AzureRM.HDInsight",
  "AzureRM.Insights",
  "AzureRM.KeyVault",
  "AzureRM.Network",
  "AzureRM.OperationalInsights",
  "AzureRM.RedisCache",
  "AzureRM.Resources",
  "AzureRM.SiteRecovery",
  "AzureRM.Sql",
  "AzureRM.Storage",
  "AzureRM.StreamAnalytics",
  "AzureRM.Tags",
  "AzureRM.TrafficManager",
  "AzureRM.UsageAggregates",
  "AzureRM.Websites"
)

function Test-AdminRights([string]$Scope)
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

function Install-ModuleWithVersionCheck([string]$Name,[string]$MajorVersion,[string]$Repository,[string]$Scope)
{
  $minVer = "$MajorVersion.0.0.0"
  $maxVer = "$MajorVersion.9999.9999.9999"
  try {
    Install-Module -Name $Name -Repository $Repository -Scope $Scope -MinimumVersion $minVer -MaximumVersion $maxVer -Confirm:$false -Force -ErrorAction Stop
    $v = (Get-InstalledModule -Name $Name -ErrorAction Ignore)[0].Version.ToString()
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
  Installs all the available Azure Resource Manager cmdlet modules that have a matching major version.

 .Parameter MajorVersion
  Specifies the major version.

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
  $MajorVersion = $AzureMajorVersion,
  [Parameter(Position=1, Mandatory = $false)]
  [string]
  $Repository = "PSGallery",
  [Parameter(Position=2, Mandatory = $false)]
  [ValidateSet("CurrentUser","AllUsers")]
  [string]
  $Scope = "AllUsers")

  Test-AdminRights $Scope

  Write-Output "Installing AzureRM modules."

  Install-ModuleWithVersionCheck "AzureRM.Profile" $MajorVersion $Repository $Scope

  # Stop and remove any previous jobs
  $AzureRMModules | ForEach {Get-Job -Name "*$_"} | Stop-Job | Remove-Job

  # Start new job
  $result = $AzureRMModules | ForEach {
    Start-Job -Name $_ -ScriptBlock {
      Install-ModuleWithVersionCheck $args[0] $args[1] $args[2] $args[3]
    } -ArgumentList $_, $MajorVersion, $Repository, $Scope }
  
  # Get results from the jobs
  $AzureRMModules | ForEach {Get-Job -Name $_ | Wait-Job | Receive-Job }

  # Clean up
  $AzureRMModules | ForEach {Get-Job -Name $_ | Remove-Job}
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
  $MajorVersion = $AzureMajorVersion)

  Write-Output "Importing AzureRM modules."

  $minVer = "$MajorVersion.0.0.0"
  $maxVer = "$MajorVersion.9999.9999.9999"

  $AzureRMModules | ForEach {
    $moduleName = $_
    $matchedModule = Get-InstalledModule -Name $moduleName -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Ignore | where {$_.Name -eq $moduleName}
    if ($matchedModule -ne $null) {
      try {
        Import-Module -Name $matchedModule.Name -RequiredVersion $matchedModule.Version -ErrorAction Stop
        Write-Output "$moduleName imported..." 
      } catch {
        Write-Warning "Skipping $Name module..."
        Write-Warning $_
      }
    }
  }
}

function Uninstall-ModuleWithVersionCheck([string]$Name,[string]$MajorVersion)
{
  $minVer = "$MajorVersion.0.0.0"
  $maxVer = "$MajorVersion.9999.9999.9999"
  # This is a workaround for a bug in PowerShellGet that uses "start with" matching for module name
  $matchedModule = Get-InstalledModule -Name $Name -MinimumVersion $minVer -MaximumVersion $maxVer -ErrorAction Ignore | where {$_.Name -eq $Name}
  if ($matchedModule -ne $null) {
    try {
      Remove-Module -Name $matchedModule.Name -Force -ErrorAction Ignore
      Uninstall-Module -Name $matchedModule.Name -RequiredVersion $matchedModule.Version -Confirm:$false -ErrorAction Stop
      Write-Output "$Name uninstalled..." 
    } catch {
      Write-Warning "Skipping $Name package..."
      Write-Warning $_
    }
  }
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
  $MajorVersion = $AzureMajorVersion)

  Test-AdminRights "AllUsers"

  Write-Output "Uninstalling AzureRM modules."

  $AzureRMModules | ForEach {
    $moduleName = $_
    Uninstall-ModuleWithVersionCheck $_ $MajorVersion
  }

  Uninstall-ModuleWithVersionCheck "AzureRM.Profile" $MajorVersion
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *