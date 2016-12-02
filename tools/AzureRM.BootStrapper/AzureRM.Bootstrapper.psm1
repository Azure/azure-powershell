$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://profile.azureedge.net/powershell/ProfileMap.json"
$PSModule = $ExecutionContext.SessionState.Module
$script:BootStrapRepo = "BootStrap"
$RepoLocation = "https://www.powershellgallery.com/api/v2/"
$existingRepos = Get-PSRepository | Where {$_.SourceLocation -eq $RepoLocation}
if ($existingRepos -eq $null)
{
  Register-PSRepository -Name $BootStrapRepo -SourceLocation $RepoLocation -PublishLocation $RepoLocation -ScriptSourceLocation $RepoLocation -ScriptPublishLocation $RepoLocation -InstallationPolicy Trusted -PackageManagementProvider NuGet
}
else
{
  $script:BootStrapRepo = $existingRepos[0].Name
}

function Get-ProfileCachePath
{
  $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
  return $ProfileCache
}

# Make Rest-Call
function Get-RestResponse
{
  $response = Invoke-RestMethod -ea SilentlyContinue -Uri $PSProfileMapEndpoint -ErrorVariable RestError -OutFile "$ProfileCache\ProfileMap.Json"
  return $RestError
}

# Get-ProfileMap from Azure Endpoint
function Get-AzureProfileMap
{
  $ProfileCache = Get-ProfileCachePath
  if(-Not (Test-Path $ProfileCache))
  {
    New-Item -ItemType Directory -Force -Path $ProfileCache | Out-Null
  }

  $RestError = Get-RestResponse  

  if ($RestError)
  {
    $HttpStatusCode = $RestError.ErrorRecord.Exception.Response.StatusCode.value__
    $HttpStatusDescription = $RestError.ErrorRecord.Exception.Response.StatusDescription
    
	Throw "Http Status Code: $($HttpStatusCode) `nHttp Status Description: $($HttpStatusDescription)"
  }

  $ProfileMap = Get-Content -Raw -Path "$ProfileCache\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json 

  return $ProfileMap
}


function Get-AzProfile
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-SwitchParam $params "Update"
    Add-SwitchParam $params "ListAvailable" "ListAvailableParameterSet"
    return $params
  }

  PROCESS
  {
    $Update = $PSBoundParameters.Update
    # If Update is present, download ProfileMap from Storage blob endpoint
    if ($Update.IsPresent)
    {
      return (Get-AzureProfileMap)
    }

    # Check the cache
    $ProfileCache = Get-ProfileCachePath
    if(Test-Path $ProfileCache)
    {
        $ProfileMap = Get-Content -Raw -Path "$ProfileCache\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json 
       
        if ($ProfileMap -ne $null)
        {
           return $ProfileMap
        }
    }
     
    # If cache doesn't exist, Check embedded source
    $defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
    $ProfileMap = Get-Content -Raw -Path "$defaults\ProfileMap.json" -ErrorAction SilentlyContinue | ConvertFrom-Json
    if($ProfileMap -eq $null)
    {
        # Cache & Embedded source empty; Return error and stop
        throw [System.IO.FileNotFoundException] "$ProfileMap not found."
    }

    return $ProfileMap
  }
}


function Add-ProfileParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
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

function Add-RemoveParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $name = "RemovePreviousVersions" 
  $newAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $newAttribute.ParameterSetName = $set
  $newAttribute.Mandatory = $false
  $newCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $newCollection.Add($newAttribute)
  $newParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter($name, [switch], $newCollection)
  $params.Add($name, [Alias("r")]$newParam)
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
    $ProfileMap = (Get-AzProfile)
    $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $enum = $Profiles.GetEnumerator()
    $toss = $enum.MoveNext()
    $Current = $enum.Current
    $Keys = ($($ProfileMap.$Current) | Get-Member -MemberType NoteProperty).Name
    $moduleValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
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
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $Module = $PSBoundParameters.Module
    $versionList = $ProfileMap.$Profile.$Module
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
    Add-SwitchParam $params "Update"
    return $params
  }
  PROCESS
  {
    [switch]$ListAvailable = $PSBoundParameters.ListAvailable
    $ProfileMap = (Get-AzProfile @PSBoundParameters)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    if ($ListAvailable.IsPresent)
    {
        foreach ($Profile in $ProfileMap) 
        { 
            foreach ($Module in ($Profile | get-member -MemberType NoteProperty).Name)
            {  
                Write-Output "Profile: $Module"
                Write-Output "----------------"
                $Profile.$Module | fl
            } 
        }
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
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    if ($PSCmdlet.ShouldProcess($Profile, "Loading modules for profile in the current scope"))
    {
      $version = Get-AzureRmModule -Profile $Profile -Module $RollUpModule
      if (($version -eq $null) -and ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Modules for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
      {
        $versions = $ProfileMap.$Profile.$RollUpModule
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
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $versions = $ProfileMap.$Profile.$RollUpModule
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
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $versions = ($ProfileMap.$profile | Get-Member -MemberType NoteProperty).Name
    foreach ($module in $versions)
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

<#
.ExternalHelp help\AzureRM.Bootstrapper-help.xml 
#>
function Update-AzureRmProfile
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params 
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile -Update)
    Use-AzureRmProfile @PSBoundParameters
    $profile = $PSBoundParameters.Profile

    # Remove old profiles?
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $installedProfiles = Get-AzureRmProfile
    foreach ($installedProfile in $installedProfiles)
    {
      if ($installedProfile -ne $profile)
      {
        if ($PSCmdlet.ShouldProcess("Profile $installedProfile", "Remove Profile"))
        {
          if (($Remove.IsPresent -or $PSCmdlet.ShouldContinue("Remove Profile $installedProfile", "Removing profile $installedProfile")))
          {
             Uninstall-AzureRmProfile -Profile $installedProfile -Force
          }
        }
      }
    }
  }
}

function Set-BootstrapRepo
{
	[CmdletBinding()]
	param([string]$Repo)
	$script:BootStrapRepo = $Repo
}
