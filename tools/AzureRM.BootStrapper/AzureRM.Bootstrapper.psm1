$RollUpModule = "AzureRM"

$PSModule = $ExecutionContext.SessionState.Module
$script:BootStrapRepo = "BootStrap"
$RepoLocation = "\\aaptfile01\adxsdk\PowerShell\bootstrapper"
$existingRepos = Get-PSRepository | Where {$_.SourceLocation -eq $RepoLocation}
if ($existingRepos -eq $null)
{
  Register-PSRepository -Name $BootStrapRepo -SourceLocation $RepoLocation -PublishLocation $RepoLocation -ScriptSourceLocation $RepoLocation -ScriptPublishLocation $RepoLocation -InstallationPolicy Trusted -PackageManagementProvider NuGet
}
else
{
  $script:BootStrapRepo = $existingRepos[0].Name
}


function Get-AzProfile 
{
  @{
    '2015-05' = 
    @{
        'AzureRM' = @('1.2.4');
        'AzureRM.Storage' = @('1.2.4');
        'Azure.Storage' = @('1.2.4');
        'AzureRM.Profile' = @('1.2.4');
     }; 
     '2016-09' = 
     @{
        'AzureRM' = @('2.0.1');
        'AzureRM.Storage' = @('2.0.1')
        'Azure.Storage' = @('2.0.1');
        'AzureRM.Profile' = @('2.0.1');
     }
   }
}



function Add-ProfileParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $AllProfiles = $ProfileMap.Keys
  $profileAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $profileAttribute.ParameterSetName = $set
  $profileAttribute.Mandatory = $true
  $profileAttribute.Position = 0
  $validateProfileAttribute = New-Object -Type System.Management.Automation.ValidateSetAttribute($AllProfiles)
  $profileCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $profileCollection.Add($profileAttribute)
  $profileCollection.Add($validateProfileAttribute)
  $profileParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Profile", [string], $profileCollection)
  $params.Add("Profile", $profileParam)
}

function Add-ForceParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  Add-SwitchParam $params "Force" $set
  
}

function Add-SwitchParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$name, [string] $set = "__AllParameterSets")
  $newAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $newAttribute.ParameterSetName = $set
  $newAttribute.Mandatory = $false
  $newCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $newCollection.Add($newAttribute)
  $newParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter($name, [switch], $newCollection)
  $params.Add($name, $newParam)
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Get-AzureRmModule 
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    $enum = $ProfileMap.Values.GetEnumerator()
    $toss = $enum.MoveNext()
    $moduleValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($enum.Current.Keys)
    $moduleAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
    $moduleAttribute.ParameterSetName = 
    $moduleAttribute.Mandatory = $true
    $moduleAttribute.Position = 1
    $moduleCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
    $moduleCollection.Add($moduleValid)
    $moduleCollection.Add($moduleAttribute)
    $moduleParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Module", [string], $moduleCollection)
    $params.Add("Module", $moduleParam)
    return $params
  }
  
  PROCESS
  {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = $ProfileMap.Keys
    $Profile = $PSBoundParameters.Profile
    $Module = $PSBoundParameters.Module
    $versionList = $ProfileMap[$Profile][$Module]
    $moduleList = Get-Module -Name $Module -ListAvailable | where {$_.RepositorySourceLocation -ne $null}
    foreach ($version in $versionList)
    {
      foreach ($module in $moduleList)
      {
        if ($version -eq $module.Version)
        {
          return $version
        }
      }
    }

    return $null
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Get-AzureRmProfile
{
  [CmdletBinding(DefaultParameterSetName="ListAvailableParameterSet")]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-SwitchParam $params "ListAvailable" "ListAvailableParameterSet"
    return $params
  }
  PROCESS
  {
    [switch]$ListAvailable = $PSBoundParameters.ListAvailable
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = $ProfileMap.Keys
    if ($ListAvailable.IsPresent)
    {
      $AllProfiles
    }
    else
    {
      $result = @()
      foreach ($key in $AllProfiles)
      {
        if ((Get-AzureRmModule -Profile $key -Module $RollUpModule) -ne $null)
        {
          $result += $key
        }
      }

      $result
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Use-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess=$true)] 
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    return $params
  }
  PROCESS 
  {
    $Force = $PSBoundParameters.Force
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = $ProfileMap.Keys
    $Profile = $PSBoundParameters.Profile
    if ($PSCmdlet.ShouldProcess($Profile, "Loading modules for profile in the current scope"))
    {
      $version = Get-AzureRmModule -Profile $Profile -Module $RollUpModule
      if (($version -eq $null) -and ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Modules for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
      {
        $versions = $ProfileMap[$Profile][$RollUpModule]
        $versionEnum = $versions.GetEnumerator()
        $toss = $versionEnum.MoveNext()
        $version = $versionEnum.Current
        Install-Module $RollUpModule -RequiredVersion $version -Repository $BootStrapRepo
      }

      Write-Host "Loading Profile $Profile, $RollUpModule Module version $version"
      Import-Module -Name $RollUpModule -RequiredVersion $version -Global
    }
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Install-AzureRmProfile
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = $ProfileMap.Keys
    $Profile = $PSBoundParameters.Profile
    $versions = $ProfileMap[$Profile][$RollUpModule]
    $versionEnum = $versions.GetEnumerator()
    $toss = $versionEnum.MoveNext()
    $version = $versionEnum.Current
	Write-Verbose "Using bootstrap repo $BootStrapRepo"
    Install-Module -Name $RollUpModule -RequiredVersion $version -Repository $script:BootStrapRepo
  }
}

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Uninstall-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    return $params
  }

  PROCESS {
    $Force = $PSBoundParameters.Force
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = $ProfileMap.Keys
    $Profile = $PSBoundParameters.Profile
    $versions = $ProfileMap[$Profile]
    foreach ($module in $versions.Keys)
    {
     $canceled = $false
     Do
     {
       $version = (Get-AzureRmModule -Profile $Profile -Module $module)
       if ($PSCmdlet.ShouldProcess("$module version $version", "Remove module"))
       {
         if (($version -ne $null) -and ($Force -or $PSCmdlet.ShouldContinue("Remove module $module version $version", "Removing Modules for profile $Profile")))
         {
           Remove-Module -Name $module -Force -ErrorAction "SilentlyContinue"
           try 
           {
             Uninstall-Module -Name $module -RequiredVersion $version -Force -ErrorAction Stop
           }
           catch
           {
             break
           }
         }
         else
         {
           break
         }
       }
       else
       {
         break
       }
     }
     While($version -ne $null);
    }
  }
}

function Set-BootstrapRepo
{
	[CmdletBinding()]
	param([string]$Repo)
	$script:BootStrapRepo = $Repo
}