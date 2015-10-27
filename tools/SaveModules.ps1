# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

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
param(
  [Parameter(Position = 0, Mandatory = $false)]
  [string]
  $BuildConfig = "Release",
  [Parameter(Position = 1, Mandatory = $false)]
  [string]
  $Repository = "PSGallery")

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

$AzurePSPath = "$PSScriptRoot\..\src\Package\$BuildConfig"

function Save-ModuleWithVersionCheck([string]$Name,[string]$MajorVersion,[string]$Repository,[string]$Path)
{
  $_MinVer = "$MajorVersion.0.0.0"
  $_MaxVer = "$MajorVersion.9999.9999.9999"
  $script:InstallCounter ++
  try {
    Save-Module -Name $Name -Repository $Repository -MinimumVersion $_MinVer -MaximumVersion $_MaxVer -ErrorAction Stop -Path $Path
    $versionFolder = Get-ChildItem "$Path\$Name\" | Select-Object -First 1
    $v = $versionFolder.Name
    Write-Output "$Name $v..." 
  } catch {
    Write-Warning "Skipping $Name package..."
    Write-Warning $_
  }
}

function Save-AzureModule
{
  Write-Output "Saving Azure PowerShell modules."

  $_InstallationPolicy = (Get-PSRepository -Name $Repository).InstallationPolicy
  $script:InstallCounter = 0

  try 
  {
    Remove-Item -Recurse -Force $AzurePSPath -ErrorAction SilentlyContinue
    New-Item -ItemType Directory -Force -Path $AzurePSPath
    
    Set-PSRepository -Name $Repository -InstallationPolicy Trusted
    Write-Output "Using Repository $Repository..."
    
    $MajorVersion = $AzureMajorVersion
    
    # Start new job
    $AzureRMModules | ForEach {
      Save-ModuleWithVersionCheck $_ $MajorVersion $Repository $AzurePSPath
    }

    Save-ModuleWithVersionCheck "Azure" $MajorVersion $Repository $AzurePSPath
    Save-ModuleWithVersionCheck "Azure.Storage" $MajorVersion $Repository $AzurePSPath
    Save-ModuleWithVersionCheck "AzureRM.Profile" $MajorVersion $Repository $AzurePSPath
    
  } finally {
    # Clean up
    Set-PSRepository -Name $Repository -InstallationPolicy $_InstallationPolicy
    Get-ChildItem -Path $AzurePSPath -Include PSGetModuleInfo.xml -Recurse -Force | Foreach { $_.Delete() }
  }
}

Save-AzureModule