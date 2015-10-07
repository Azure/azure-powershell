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
      throw "Administrator rights are required to install or uninstall Microsoft Azure modules"
    }
  }
}

function Install-ModuleWithVersionCheck([string]$Name,[string]$MajorVersion,[string]$Repository,[string]$Scope)
{
  $_MinVer = "$MajorVersion.0.0.0"
  $_MaxVer = "$MajorVersion.9999.9999.9999"
  try {
    $_ExistingModule = Get-Module -ListAvailable -Name $Name
    $_ModuleAction = "installed"
    if ($_ExistingModule -ne $null)
    {
      Update-Module -Name $Name -MaximumVersion $_MaxVer -ErrorAction Stop
      $_ModuleAction = "updated"
    }
    else 
    {
      Install-Module -Name $Name -Repository $Repository -Scope $Scope -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Stop
    }
    $v = (Get-InstalledModule -Name $Name -ErrorAction Ignore)[0].Version.ToString()
    Write-Output "$Name $v $_ModuleAction..." 
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

  $_InstallationPolicy = (Get-PSRepository -Name PSGallery).InstallationPolicy

  try 
  {
    Set-PSRepository -Name PSGallery -InstallationPolicy Trusted

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
  } finally {
    # Clean up
    Set-PSRepository -Name PSGallery -InstallationPolicy $_InstallationPolicy
    $AzureRMModules | ForEach {Get-Job -Name $_ | Remove-Job}
  }
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

  $_MinVer = "$MajorVersion.0.0.0"
  $_MaxVer = "$MajorVersion.9999.9999.9999"

  $AzureRMModules | ForEach {
    $moduleName = $_
    $_MatchedModule = Get-InstalledModule -Name $moduleName -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Ignore | where {$_.Name -eq $moduleName}
    if ($_MatchedModule -ne $null) {
      try {
        Import-Module -Name $_MatchedModule.Name -RequiredVersion $_MatchedModule.Version -ErrorAction Stop
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
  $_MinVer = "$MajorVersion.0.0.0"
  $_MaxVer = "$MajorVersion.9999.9999.9999"
  # This is a workaround for a bug in PowerShellGet that uses "start with" matching for module name
  $_MatchedModule = Get-InstalledModule -Name $Name -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Ignore | where {$_.Name -eq $Name}
  if ($_MatchedModule -ne $null) {
    try {
      Remove-Module -Name $_MatchedModule.Name -Force -ErrorAction Ignore
      Uninstall-Module -Name $_MatchedModule.Name -RequiredVersion $_MatchedModule.Version -Confirm:$false -ErrorAction Stop
      if ((Get-Module -Name $_MatchedModule.Name | where {$_.Version -eq $_MatchedModule.Version}) -eq $null)
      {
        Write-Output "$Name version $($_MatchedModule.Version) uninstalled..." 
      }
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

  Uninstall-ModuleWithVersionCheck "Azure.Storage" $MajorVersion
  Uninstall-ModuleWithVersionCheck "AzureRM.Profile" $MajorVersion
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *