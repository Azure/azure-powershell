$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://azureprofile.azureedge.net/powershell/profilemap.json"
$PSModule = $ExecutionContext.SessionState.Module
$script:BootStrapRepo = "BootStrap"
$RepoLocation = "https://www.powershellgallery.com/api/v2/"
$existingRepos = Get-PSRepository | Where-Object {$_.SourceLocation -eq $RepoLocation}
if ($existingRepos -eq $null)
{
  Register-PSRepository -Name $BootStrapRepo -SourceLocation $RepoLocation -PublishLocation $RepoLocation -ScriptSourceLocation $RepoLocation -ScriptPublishLocation $RepoLocation -InstallationPolicy Trusted -PackageManagementProvider NuGet
}
else
{
  $script:BootStrapRepo = $existingRepos[0].Name
}

# Is it Powershell Core edition?
$Script:IsCoreEdition = ($PSVersionTable.PSEdition -eq 'Core')

# Check if current user is Admin to decide on cache path
$script:IsAdmin = $false
if ((-not $Script:IsCoreEdition) -or ($IsWindows))
{
  If (([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator"))
  {
    $script:IsAdmin = $true
  }
}
else {
  # on Linux, tests run via sudo will generally report "root" for whoami
  if ( (whoami) -match "root" ) 
  {
    $script:IsAdmin = $true
  }
}

# Get profile cache path
function Get-ProfileCachePath
{
  if ((-not $Script:IsCoreEdition) -or ($IsWindows))
  {
    $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
    if ($script:IsAdmin)
    {
      $ProfileCache = Join-Path -path $env:ProgramData -ChildPath "Microsoft\AzurePowerShell\ProfileCache"
    }
    return $ProfileCache
  }

  $ProfileCache = "$HOME/.config/Microsoft/AzurePowerShell/ProfileCache" 
  return $ProfileCache
}

# Function to find the latest profile map from cache
function Get-LatestProfileMapPath
{
  $ProfileCache = Get-ProfileCachePath
  if (-Not (Test-Path $ProfileCache))
  {
    return
  }

  $ProfileMapPaths = Get-ChildItem $ProfileCache

  if ($ProfileMapPaths -eq $null)
  {
    return
  }

  $LatestMapPath = $ProfileMapPaths[0]
  foreach ($ProfileMapPath in $ProfileMapPaths)
  {
    if ($LatestMapPath.CreationTime -lt $ProfileMapPath.CreationTime)
    {
      $LatestMapPath = $ProfileMapPath
    }
  }
  return $LatestMapPath
}

# Make Web-Call
function Get-WebResponse
{
  $WebResponse =  Invoke-WebRequest -uri $PSProfileMapEndpoint 
  return $WebResponse
}

# Get-ProfileMap from Azure Endpoint
function Get-AzureProfileMap
{
  $ProfileCache = Get-ProfileCachePath

  # If profile cache directory does not exist, create one.
  if(-Not (Test-Path $ProfileCache))
  {
    New-Item -ItemType Directory -Force -Path $ProfileCache | Out-Null
  }

  # Get online profile data using Web request
  $WebResponse = Get-WebResponse  

  # Get ETag value for OnlineProfileMap
  $OnlineProfileMapETag = $WebResponse.Headers["ETag"]

  # If profilemap json exists, compare online Etag and cached Etag; if not different, don't replace cache.
  $LatestProfileMapPath = Get-LatestProfileMapPath
  if ($LatestProfileMapPath -ne $null)
  {
    [string]$ProfileMapETag = [System.IO.Path]::GetFileNameWithoutExtension($LatestProfileMapPath)
    if (($ProfileMapETag -eq $OnlineProfileMapETag) -and (Test-Path $LatestProfileMapPath.FullName))
    {
      $ProfileMap = Get-Content -Raw -Path $LatestProfileMapPath.FullName -ErrorAction SilentlyContinue | ConvertFrom-Json 
      return $ProfileMap
    }
  }

  # If profilemap json doesn't exist, or if online hash and cached hash are different, cache online profile map
  $ChildPathName = ($OnlineProfileMapETag) + ".json"
  $CacheFilePath = (Join-Path $ProfileCache -ChildPath $ChildPathName)
  $OnlineProfileMap = RetrieveProfileMap -WebResponse $WebResponse
  $OnlineProfileMap | ConvertTo-Json -Compress | Out-File -FilePath $CacheFilePath
   
  return $OnlineProfileMap
}

# Helper to retrieve profile map from http response
function RetrieveProfileMap
{
  param($WebResponse)
  $OnlineProfileMap = ($WebResponse.Content -replace "`n|`r|`t") | ConvertFrom-Json
  return $OnlineProfileMap
}

# Get ProfileMap from Cache, online or embedded source
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
    # If Update is present, download ProfileMap from online source
    if ($Update.IsPresent)
    {
      return (Get-AzureProfileMap)
    }

    # Check the cache
    $LatestProfileMapPath = Get-LatestProfileMapPath
    if(($LatestProfileMapPath -ne $null) -and (Test-Path $LatestProfileMapPath.FullName))
    {
      $ProfileMap = Get-Content -Raw -Path $LatestProfileMapPath.FullName -ErrorAction SilentlyContinue | ConvertFrom-Json 
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
      throw [System.IO.FileNotFoundException] "Profile meta data does not exist. Use 'Get-AzureRmProfile -Update' to download from online source."
    }

    return $ProfileMap
  }
}

# Lists the profiles available for install from gallery
function Get-ProfilesAvailable
{
  param([parameter(Mandatory = $true)] [PSCustomObject] $ProfileMap)
  $ProfileList = ""
  foreach ($Profile in $ProfileMap) 
  {
    foreach ($Module in ($Profile | get-member -MemberType NoteProperty).Name)
    {
      $ProfileList += "Profile: $Module`n"
      $ProfileList += "----------------`n"
      $ProfileList += ($Profile.$Module | Format-List | Out-String)
    } 
  }
  return $ProfileList
}

# Lists the profiles that are installed on the machine
function Get-ProfilesInstalled
{
  param([parameter(Mandatory = $true)] [PSCustomObject] $ProfileMap, [REF]$IncompleteProfiles)
  $result = @{}
  $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name

  foreach ($key in $AllProfiles)
  {
    foreach ($module in ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Name)
    {
      $versionList = $ProfileMap.$key.$module
      foreach ($version in $versionList)
      {
        if ((Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version}) -ne $null)
        {
          if ($result.ContainsKey($key))
          {
            $result[$key] += @{$module = $ProfileMap.$Key.$module}
          }
          else
          {
            $result.Add($key, @{$module = $ProfileMap.$Key.$module})
          }
        }
      }
    }

    # If not all the modules from a profile are installed, add it to $IncompleteProfiles
    if(($result.$key.Count -gt 0) -and ($result.$key.Count -ne ($ProfileMap.$key | Get-Member -MemberType NoteProperty).Count))
    {
      $result.Remove($key)
      if ($IncompleteProfiles -ne $null) 
      {
        $IncompleteProfiles.Value += $key
      }
    }
  }
  return $result
}

# Install module from the gallery
function Install-ModuleHelper
{
  param([string] $Module, [string] $Profile, [PSCustomObject] $ProfileMap, [String]$Scope)
  $versions = $ProfileMap.$Profile.$Module
  $versionEnum = $versions.GetEnumerator()
  $toss = $versionEnum.MoveNext()
  $version = $versionEnum.Current
  if (-not $Scope)
  {
    Install-Module $Module -RequiredVersion $version -Repository $BootStrapRepo -AllowClobber
  }
  else
  {
    Install-Module $Module -RequiredVersion $version -Repository $BootStrapRepo -scope $Scope -AllowClobber
  }
}

# Function to remove Previous profile map
function Remove-ProfileMapFile
{
  [CmdletBinding()]
	param([string]$ProfileMapPath)

  if (Test-Path -Path $ProfileMapPath)
  {
    RemoveWithRetry -Path $ProfileMapPath -Force
  }
}

# Remove-Item command with Retry
function RemoveWithRetry
{
  param ([string]$Path)

  $retries = 3
  $secondsDelay = 2
  $retrycount = 0
  $completedSuccessfully = $false

  while (-not $completedSuccessfully) 
  {
    try 
    {
      Remove-Item @PSBoundParameters -ErrorAction Stop
      $completedSuccessfully = $true
    } 
    catch 
    {
      if ($retrycount -ge $retries) 
      {
        throw
      } 
      else 
      {
        Start-Sleep $secondsDelay
        $retrycount++
      }
    }
  }
}

# Get profiles installed associated with the module version
function Test-ProfilesInstalled
{
  param([String]$Module, [String]$Profile, [PSObject]$PMap, [hashtable]$AllProfilesInstalled)

  # Profiles associated with the particular module version - installed?
  $profilesAssociated = @()
  $versionList = $PMap.$Profile.$Module
  foreach ($version in $versionList)
  {
    foreach ($profileInAllProfiles in $AllProfilesInstalled[$Module + $version])
    {
      $profilesAssociated += $profileInAllProfiles
    }
  }
  return $profilesAssociated
}

# Function to uninstall module
function Uninstall-ModuleHelper
{
  [CmdletBinding(SupportsShouldProcess = $true)] 
  param([PSObject]$PMap, [String]$Module, [System.Version]$version, [hashtable]$AllProfilesInstalled)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-RemoveParam $params
    return $params
  }

  PROCESS
  {
    $Profile = $PSBoundParameters.Profile
    $Remove = $PSBoundParameters.RemovePreviousVersions

    Do
    {
      $moduleInstalled = Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} 
      if ($PSCmdlet.ShouldProcess("$module version $version", "Remove module")) 
      {
        if (($moduleInstalled -ne $null) -and ($Remove.IsPresent -or $PSCmdlet.ShouldContinue("Remove module $Module version $version", "Removing Modules for profile $Profile"))) 
        {
          Remove-Module -Name $module -Force -ErrorAction "SilentlyContinue"
          try 
          {
            Uninstall-Module -Name $module -RequiredVersion $version -Force -ErrorAction Stop
          }
          catch
          {
            Write-Warning $_.Exception.Message
            break
          }
        }
        else {
          break
        }
      }
      else {
        break
      }
    }
    While($moduleInstalled -ne $null);        
  }
}

# Help function to uninstall a profile
function Uninstall-ProfileHelper
{
  [CmdletBinding()]
  param([PSObject]$PMap)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    return $params
  }

  PROCESS {
    $Profile = $PSBoundParameters.Profile
    $Force = $PSBoundParameters.Force
    $modules = ($PMap.$Profile | Get-Member -MemberType NoteProperty).Name

    # Get-Profiles installed across all hashes. This is to avoid uninstalling modules that are part of other installed profiles
    $AllProfilesInstalled = Get-AllProfilesInstalled

    foreach ($module in $modules)
    {
      if ($Force.IsPresent)
      {
        Invoke-UninstallModule -PMap $PMap -Profile $Profile -Module $module -AllProfilesInstalled $AllProfilesInstalled -RemovePreviousVersions
      }
      else {
        Invoke-UninstallModule -PMap $PMap -Profile $Profile -Module $module -AllProfilesInstalled $AllProfilesInstalled 
      }
    }
  }
}

# Checks if the module is part of other installed profiles. Calls Uninstall-ModuleHelper if not.
function Invoke-UninstallModule
{
  [CmdletBinding()]
  param([PSObject]$PMap, [String]$Module, [hashtable]$AllProfilesInstalled)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-RemoveParam $params
    return $params
  }
  
  PROCESS
  {
    $Profile = $PSBoundParameters.Profile

    # Check if the profiles associated with the module version are installed.
    $profilesAssociated = Test-ProfilesInstalled -Module $Module -Profile $Profile -PMap $PMap -AllProfilesInstalled $AllProfilesInstalled
      
    # If more than one profile is installed for the same version of the module, do not uninstall
    if (($profilesAssociated.Count -gt 1) -and ($profilesAssociated -ne $Profile))
    {
      continue
    }

    # Uninstall module
    $versionList = $PMap.$Profile.$module
    foreach ($version in $versionList)
    {
      Uninstall-ModuleHelper -version $version @PSBoundParameters
    } 
  }
}

# Helps to uninstall previous versions of modules in the profile
function Remove-PreviousVersions
{
  [CmdletBinding()]
  param([PSObject]$PreviousMap, [PSObject]$LatestMap, [hashtable]$AllProfilesInstalled)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-RemoveParam $params
    Add-ModuleParam $params
    return $params
  }
  
  PROCESS
  {
    $Profile = $PSBoundParameters.Profile
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $Modules = $PSBoundParameters.Module

    $PreviousProfiles = ($PreviousMap | Get-Member -MemberType NoteProperty).Name
    $LatestProfiles = ($LatestMap | Get-Member -MemberType NoteProperty).Name
  
    # If the profile was not in $PreviousProfiles, return
    if($Profile -notin $PreviousProfiles)
    {
      return
    }

    if ($Modules -eq $null)
    {
      $Modules = ($PreviousMap.$Profile | Get-Member -MemberType NoteProperty).Name
    }

    foreach ($module in $Modules)
    {
      # If the latest version is same as the previous version, do not uninstall.
      if (($PreviousMap.$Profile.$module | Out-String) -eq ($LatestMap.$Profile.$module | Out-String))
      {
        continue
      }
      
      # Is that module installed? If not skip
      $versionList = $PreviousMap.$Profile.$module
      foreach ($version in $versionList)
      {
        if ((Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} ) -eq $null)
        {
          continue
        }

        # Modules are different. Uninstall previous version.
        if ($Remove.IsPresent)
        {
          Invoke-UninstallModule -PMap $PreviousMap -Profile $Profile -Module $module -AllProfilesInstalled $AllProfilesInstalled -RemovePreviousVersions
        }
        else {
          Invoke-UninstallModule -PMap $PreviousMap -Profile $Profile -Module $module -AllProfilesInstalled $AllProfilesInstalled         
        }
      }
    }
  }
}

# Gets profiles installed from all the profilemaps from cache
function Get-AllProfilesInstalled
{
  $AllProfilesInstalled = @{}
  $ProfileCache = Get-ProfileCachePath
  if (-not (Test-Path $ProfileCache))
  {
    return
  }
  $ProfileMapHashes = Get-ChildItem $ProfileCache 
  foreach ($ProfileMapHash in $ProfileMapHashes)
  {
    $ProfileMap = Get-Content -Raw -Path (Join-Path $ProfileCache $ProfileMapHash.Name) |  ConvertFrom-json
    $profilesInstalled = (Get-ProfilesInstalled -ProfileMap $ProfileMap)
    foreach ($Profile in $profilesInstalled.Keys)
    {
      foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
      {
        $versionList = $ProfileMap.$Profile.$Module
        foreach ($version in $versionList)
        {
          if ($AllProfilesInstalled.ContainsKey(($Module + $version)))
          {
            if ($Profile -notin $AllProfilesInstalled[($Module + $version)])
            {
              $AllProfilesInstalled[($Module + $version)] += $Profile
            }
          }
          else {
            $AllProfilesInstalled.Add(($Module + $version), @($Profile))
          }
        }
      }
    }
  }
  return $AllProfilesInstalled
}

# Helps to remove-previous versions of the update-profile and clean up cache, if none of the old hash profiles are installed
function Update-ProfileHelper
{
  [CmdletBinding()]
  param()
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-RemoveParam $params
    Add-ModuleParam $params
    return $params
  }
  
  PROCESS
  {
    $Profile = $PSBoundParameters.Profile

    # Get all the hash files (ProfileMaps) from cache
    $ProfileCache = Get-ProfileCachePath
    $ProfileMapHashes = Get-ChildItem $ProfileCache

    # Find the latest ProfileMap 
    $LatestProfileMapPath = Get-LatestProfileMapPath
    $LatestProfileMap = Get-Content -Raw -Path $LatestProfileMapPath.FullName |  ConvertFrom-json

    # Get-Profiles installed across all hashes. 
    $AllProfilesInstalled = Get-AllProfilesInstalled

    foreach ($ProfileMapHash in $ProfileMapHashes)
    {
      # Set flag to delete hash
      $deleteHash = $true
    
      # Do not process the latest hash; we don't want to remove the latest hash
      if ($ProfileMapHash.Name -eq $LatestProfileMapPath.Name)
      {
        continue
      }

      # Compare previous & latest map for the update profile. Uninstall previous if they are different
      $previousProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapHash) |  ConvertFrom-json
      Remove-PreviousVersions -PreviousMap $previousProfileMap -LatestMap $LatestProfileMap -AllProfilesInstalled $AllProfilesInstalled @PSBoundParameters

      # If the previous map has profiles installed, do not delete it.
      $profilesInstalled = (Get-ProfilesInstalled -ProfileMap $previousProfileMap)
      foreach ($PreviousProfile in $profilesInstalled.Keys)
      {
        # Map can be deleted if the only profile installed is the updated one.
        if ($PreviousProfile -eq $Profile)
        {
          continue
        }
        else {
          $deleteHash = $false
        }
      }

      # If none were installed, remove the hash
      if ($deleteHash -ne $false)
      {
        Remove-ProfileMapFile -ProfileMapPath (Join-Path $profilecache $ProfileMapHash)
      }
    }
  }
}

# Add Scope parameter to the cmdlet
function Add-ScopeParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$set = "__AllParameterSets")
  $Keys = @('CurrentUser', 'AllUsers')
  $scopeValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
  $scopeAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $scopeAttribute.ParameterSetName = 
  $scopeAttribute.Mandatory = $false
  $scopeAttribute.Position = 1
  $scopeCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $scopeCollection.Add($scopeValid)
  $scopeCollection.Add($scopeAttribute)
  $scopeParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Scope", [string], $scopeCollection)
  $params.Add("Scope", $scopeParam)
}

# Add the profile parameter to the cmdlet
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

function Add-ModuleParam
{
  param([System.Management.Automation.RuntimeDefinedParameterDictionary]$params, [string]$name, [string] $set = "__AllParameterSets")
  $ProfileMap = (Get-AzProfile)
  $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
  $enum = $Profiles.GetEnumerator()
  $toss = $enum.MoveNext()
  $Current = $enum.Current
  $Keys = ($($ProfileMap.$Current) | Get-Member -MemberType NoteProperty).Name
  $moduleValid = New-Object -Type System.Management.Automation.ValidateSetAttribute($Keys)
  $AllowNullAttribute = New-Object -Type System.Management.Automation.AllowNullAttribute
  $AllowEmptyStringAttribute = New-Object System.Management.Automation.AllowEmptyStringAttribute
  $moduleAttribute = New-Object -Type System.Management.Automation.ParameterAttribute
  $moduleAttribute.ParameterSetName = 
  $moduleAttribute.Mandatory = $false
  $moduleAttribute.Position = 1
  $moduleCollection = New-object -Type System.Collections.ObjectModel.Collection[System.Attribute]
  $moduleCollection.Add($moduleValid)
  $moduleCollection.Add($moduleAttribute)
  $moduleCollection.Add($AllowNullAttribute)
  $moduleCollection.Add($AllowEmptyStringAttribute)
  $moduleParam = New-Object -Type System.Management.Automation.RuntimeDefinedParameter("Module", [array], $moduleCollection)
  $params.Add("Module", $moduleParam)
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
    # ListAvailable helps to display all profiles available from the gallery
    [switch]$ListAvailable = $PSBoundParameters.ListAvailable
    $ProfileMap = (Get-AzProfile @PSBoundParameters)
    if ($ListAvailable.IsPresent)
    {
      Get-ProfilesAvailable $ProfileMap
    }
    else
    {
      # Just display profiles installed on the machine
      $IncompleteProfiles = @()
      $profilesInstalled = Get-ProfilesInstalled -ProfileMap $ProfileMap ([REF]$IncompleteProfiles)
      $Output = @()
      foreach ($key in $profilesInstalled.Keys)
      {
        $Output += "Profile : $key"
        $Output += "-----------------"
        $Output += ($profilesInstalled.$key | Format-Table -HideTableHeaders | Out-String)
      }
      if ($IncompleteProfiles.Count -gt 0)
      {
        Write-Warning "Some modules from profile(s) $IncompleteProfiles were not installed. Use Install-AzureRmProfile to install missing modules."
      }
      $Output
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
    Add-ScopeParam $params
    Add-ModuleParam $params
    return $params
  }
  PROCESS 
  {
    $Force = $PSBoundParameters.Force
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $Scope = $PSBoundParameters.Scope
    $Modules = $PSBoundParameters.Module

    if ($Modules -eq $null)
    {
      $Modules = ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name
    }

    if ($PSCmdlet.ShouldProcess($Profile, "Loading modules for profile in the current scope"))
    {
      Write-Host "Loading Profile $Profile"
      foreach ($Module in $Modules)
      {
        $version = Get-AzureRmModule -Profile $Profile -Module $Module
        if (($version -eq $null) -and ($IsConfirmed -or $Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Module $module for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
        {
          # Flag to track if the prompt for install module was previously accepted.
          $IsConfirmed = $true
          Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap -Scope $Scope
        }
        
        Import-Module -Name $Module -RequiredVersion $version -Global
      }
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
    Add-ScopeParam $params
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    $Scope = $PSBoundParameters.Scope
    foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
    {
      $version = Get-AzureRmModule -Profile $Profile -Module $Module
      if ($version -eq $null) 
      {
        Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap -Scope $Scope
      }
    }
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
    $ProfileMap = (Get-AzProfile)
    $Profile = $PSBoundParameters.Profile
    $Force = $PSBoundParameters.Force

    if ($PSCmdlet.ShouldProcess("$Profile", "Uninstall Profile")) 
    {
      if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Uninstall Profile $Profile", "Removing Modules for profile $Profile")))
      {
        Uninstall-ProfileHelper -PMap $ProfileMap @PSBoundParameters
      }
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
    Add-ModuleParam $params
    Add-ScopeParam $params
    return $params
  }

  PROCESS {
    # Update Profile cache, if not up-to-date
    $ProfileMap = (Get-AzProfile -Update)
    $profile = $PSBoundParameters.Profile
    $Force = $PSBoundParameters.Force
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $Modules = $PSBoundParameters.Module

    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $PSBoundParameters.Remove('RemovePreviousVersions') | Out-Null

    # Install & import the required version
    Use-AzureRmProfile @PSBoundParameters
    
    $PSBoundParameters.Remove('Force') | Out-Null
    $PSBoundParameters.Remove('Scope') | Out-Null

    # Remove previous versions of the profile?
    if ($PSCmdlet.ShouldProcess("Remove previous versions")) 
    {
      if (($Remove -or $PSCmdlet.ShouldContinue("Uninstall Previous Module Versions of the profile", "Removing previous versions of the profile")))
      {
        # Remove-PreviousVersions and clean up cache
        Update-ProfileHelper @PSBoundParameters -RemovePreviousVersions
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
