$AzureRMDependencies = @{
  "Azure.Storage" = "1.0.4";
  "AzureRM.Profile" = "1.0.4";
}

$AzureRMModules = @{
  "AzureRM.ApiManagement" = "1.0.4";
  "AzureRM.Automation" = "1.0.4";
  "AzureRM.Backup" = "1.0.4";
  "AzureRM.Batch" = "1.0.4";
  "AzureRM.Compute" = "1.2.2";
  "AzureRM.DataFactories" = "1.0.4";
  "AzureRM.DataLakeAnalytics" = "1.0.4";
  "AzureRM.DataLakeStore" = "1.0.4";
  "AzureRM.Dns" = "1.0.4";
  "AzureRM.HDInsight" = "1.0.5";
  "AzureRM.Insights" = "1.0.4";
  "AzureRM.KeyVault" = "1.1.3";
  "AzureRM.Network" = "1.0.4";
  "AzureRM.NotificationHubs" = "1.0.4";
  "AzureRM.OperationalInsights" = "1.0.4";
  "AzureRM.RecoveryServices" = "1.0.5";
  "AzureRM.RedisCache" = "1.1.2";
  "AzureRM.Resources" = "1.0.4";
  "AzureRM.SiteRecovery" = "1.1.3";
  "AzureRM.Sql" = "1.0.4";
  "AzureRM.Storage" = "1.0.4";
  "AzureRM.StreamAnalytics" = "1.0.4";
  "AzureRM.Tags" = "1.0.4";
  "AzureRM.TrafficManager" = "1.0.4";
  "AzureRM.UsageAggregates" = "1.0.4";
  "AzureRM.Websites" = "1.0.4";
  "AzureRM.LogicApp" = "1.0.0";
}

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

function CheckIncompatibleVersion([bool]$Force)
{
  $message = "An incompatible version of Azure Resource Manager PowerShell cmdlets is installed.  Please uninstall Microsoft Azure PowerShell using the 'Control Panel' before installing these cmdlets. To install these cmdlets regardless of compatibility issues, execute 'Install-AzureRM -Force'."
  $path = ${env:ProgramFiles(x86)}
  if ($path -eq $null)
  {
    $path = ${env:ProgramFiles}
  }

  if ( Test-Path "$path\Microsoft SDKs\Azure\PowerShell\ResourceManager\AzureResourceManager\AzureResourceManager.psd1")
  {
    if ($Force)
    {
      Write-Warning $message
    }
    else
    {
      throw $message
    }
  }
}

function Install-ModuleWithVersionCheck([string]$Name,[string]$MinimumVersion,[string]$Repository,[string]$Scope,[switch]$Force)
{
  $_MinVer = $MinimumVersion
  $_MaxVer = "$($_MinVer.Split(".")[0]).9999.9999.9999"
  $script:InstallCounter ++
  try {
    $_ExistingModule = Get-Module -ListAvailable -Name $Name
    $_ModuleAction = "installed"
    if ($_ExistingModule -ne $null)
    {
      Install-Module -Name $Name -Repository $Repository -Scope $Scope -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -Force:$force -ErrorAction Stop
      $_ModuleAction = "updated"
    }
    else 
    {
      Install-Module -Name $Name -Repository $Repository -Scope $Scope -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Stop
    }
    $v = (Get-InstalledModule -Name $Name -ErrorAction Ignore)[0].Version.ToString()
    Write-Output "$Name $v $_ModuleAction [$script:InstallCounter/$($AzureRMModules.Count + $AzureRMDependencies.Count)]..." 
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

  Test-AdminRights $Scope
  CheckIncompatibleVersion($Force.IsPresent)

  Write-Output "Installing AzureRM modules."

  $_InstallationPolicy = (Get-PSRepository -Name $Repository).InstallationPolicy
  $script:InstallCounter = 0

  try 
  {
    Set-PSRepository -Name $Repository -InstallationPolicy Trusted

    # Update Profile and Storage
    Install-ModuleWithVersionCheck "AzureRM.Profile" $AzureRMDependencies["AzureRM.Profile"] $Repository $Scope -Force:$force
    Install-ModuleWithVersionCheck "Azure.Storage" $AzureRMDependencies["Azure.Storage"] $Repository $Scope -Force:$force

    # Start new job
    $AzureRMModules.Keys | ForEach {
      $_MinVer = $MajorVersion 
      if(!$MajorVersion) {
        $_MinVer = $AzureRMModules[$_]
      }
      Install-ModuleWithVersionCheck $_ $_MinVer $Repository $Scope -Force:$force
    }    
  } finally {
    # Clean up
    Set-PSRepository -Name $Repository -InstallationPolicy $_InstallationPolicy
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
  $MajorVersion )
  Write-Output "Importing AzureRM modules."

  $AzureRMModules.Keys | ForEach {
    $moduleName = $_
    $_MinVer = $MajorVersion 
    if(!$MajorVersion) {
      $_MinVer = $AzureRMModules[$_]
    }
    $_MaxVer = "$($_MinVer.Split(".")[0]).9999.9999.9999"

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

function Uninstall-ModuleWithVersionCheck([string]$Name,[string]$MinVersion)
{
  $_MinVer = $MinVersion
  $_MaxVer = "$($_MinVer.Split(".")[0]).9999.9999.9999"
  # This is a workaround for a bug in PowerShellGet that uses "start with" matching for module name
  $_MatchedModule = Get-InstalledModule -Name $Name -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Ignore | where {$_.Name -eq $Name}
  if ($_MatchedModule -ne $null) {
    try {
      Remove-Module -Name $Name -Force -ErrorAction Ignore
      Uninstall-Module -Name $Name -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -Confirm:$false -ErrorAction Stop
      if ((Get-Module -Name $Name -ListAvailable) -eq $null)
      {
        Write-Output "$Name uninstalled..." 
      } 
      else 
      {
        Write-Output "$Name partially uninstalled..." 
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
  $MinVersion)

  Test-AdminRights "AllUsers"

  Write-Output "Uninstalling AzureRM modules."

  $AzureRMModules.Keys | ForEach {
    $moduleName = $_
    $_MinVer = $MinVersion 
    if(!$MinVersion) {
      $_MinVer = $AzureRMModules[$_]
    }
    Uninstall-ModuleWithVersionCheck $_ $_MinVer
  }

  Uninstall-ModuleWithVersionCheck "Azure.Storage" $AzureRMDependencies["Azure.Storage"]
  Uninstall-ModuleWithVersionCheck "AzureRM.Profile" $AzureRMDependencies["AzureRM.Profile"]
}

New-Alias -Name Install-AzureRM -Value Update-AzureRM
Export-ModuleMember -function * -Alias *