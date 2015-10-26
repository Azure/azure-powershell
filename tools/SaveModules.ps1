$AzureMajorVersion = "0"

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

$AzureRMPath = "$PSScriptRoot\..\src\Package\Debug\ResourceManager\AzureResourceManager"

$AzureSMPath = "$PSScriptRoot\..\src\Package\Debug\ServiceManagement"

function Save-ModuleWithVersionCheck([string]$Name,[string]$MajorVersion,[string]$Repository,[string]$Path)
{
  $_MinVer = "$MajorVersion.0.0.0"
  $_MaxVer = "$MajorVersion.9999.9999.9999"
  $script:InstallCounter ++
  try {
    Save-Module -Name $Name -Repository $Repository -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Stop -Path $Path
    $versionFolder = Get-ChildItem "$Path\$Name\" | Select-Object -First 1
    Get-ChildItem $versionFolder.FullName | ForEach { Move-Item -Path $_.FullName -Destination "$Path\$Name\" }
    Remove-Item $versionFolder.FullName -Recurse -Force
    $v = $versionFolder.Name
    Write-Output "$Name $v..." 
  } catch {
    Write-Warning "Skipping $Name package..."
    Write-Warning $_
  }
}

<#
 .Synopsis
  Save Azure Resource Manager cmdlet modules

 .Description
  Installs all the available Azure Resource Manager cmdlet modules that have a matching major version.

 .Parameter MajorVersion
  Specifies the major version.

 .Parameter Repository
  Limit the search for "AzureRM" cmdlets in a specific repository.
#>
function Save-AzureModule
{
  
  param(
  [Parameter(Position=0, Mandatory = $false)]
  [string]
  $MajorVersion = $AzureMajorVersion,
  [Parameter(Position=1, Mandatory = $false)]
  [string]
  $Repository = "PSGallery",
  [switch]
  $Force = $false)

  Write-Output "Saving AzureRM modules."

  $_InstallationPolicy = (Get-PSRepository -Name $Repository).InstallationPolicy
  $script:InstallCounter = 0

  try 
  {
    Remove-Item -Recurse -Force $AzureRMPath -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Force -Path $AzureRMPath
    
    Remove-Item -Recurse -Force $AzureSMPath -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Force -Path $AzureSMPath
    
    Set-PSRepository -Name $Repository -InstallationPolicy Trusted

    # Start new job
    $AzureRMModules | ForEach {
      Save-ModuleWithVersionCheck $_ $MajorVersion $Repository $AzureRMPath
    }

    Save-ModuleWithVersionCheck "Azure" $MajorVersion $Repository $AzureSMPath
    Save-ModuleWithVersionCheck "Azure.Storage" $MajorVersion $Repository $AzureRMPath
    Save-ModuleWithVersionCheck "AzureRM.Profile" $MajorVersion $Repository $AzureRMPath
    
  } finally {
    # Clean up
    Set-PSRepository -Name $Repository -InstallationPolicy $_InstallationPolicy
  }
}

Save-AzureModule