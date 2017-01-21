$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://profile.azureedge.net/powershell/ProfileMap.json"
$PSModule = $ExecutionContext.SessionState.Module
$script:BootStrapRepo = "BootStrap"
$AllProfilesInstalled = New-Object System.Collections.ArrayList
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

# Get profile cache path
function Get-ProfileCachePath
{
  $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
  return $ProfileCache
}

# Make Rest-Call
function Get-RestResponse
{
  try 
  {
    $ProfileMap = Invoke-RestMethod -ea SilentlyContinue -Uri $PSProfileMapEndpoint -ErrorVariable RestError -ContentType application/json 
    return $ProfileMap
  }
  catch 
  {
    $HttpStatusCode = $RestError.ErrorRecord.Exception.Response.StatusCode.value__
    $HttpStatusDescription = $RestError.ErrorRecord.Exception.Response.StatusDescription
    
    Throw "Http Status Code: $($HttpStatusCode) `nHttp Status Description: $($HttpStatusDescription)"
  }
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

  # Get online profile data using Rest method
  $OnlineProfileMap = Get-RestResponse  

  # Get Hash value for $OnlineProfileMap
  $OnlineProfileMapHash = (Get-FileHashProfileMap $OnlineProfileMap)

  # If profilemap.json exists, compare online hash and cached hash; if not different, don't replace cache.
  if (Test-Path "$ProfileCache\ProfileMap.json")
  {
    [string]$ProfilePath = (Get-ChildItem "$ProfileCache\ProfileMap.json").Target
    [string]$ProfileMapHash = [System.IO.Path]::GetFileNameWithoutExtension($ProfilePath)
    if (($ProfileMapHash -eq $OnlineProfileMapHash) -and (Test-Path $ProfilePath))
    {
      return $OnlineProfileMap
    }
  }

  # If profilemap.json doesn't exist, or if online hash and cached hash are different, replace cached with online profile map
  $ChildPathName = ($OnlineProfileMapHash) + ".json"
  $CacheFilePath = (Join-Path $ProfileCache -ChildPath $ChildPathName)
  $OnlineProfileMap | ConvertTo-Json -Compress | Out-File -FilePath $CacheFilePath
   
  # No edit symlink cmd available. So delete it and create a new one with the same name.
  if (Test-Path "$ProfileCache\ProfileMap.json")
  {
    RemoveWithRetry -Path "$ProfileCache\ProfileMap.json" -Force
  }

  # create/Update symlink
  Invoke-Expression -Command "cmd /c mklink $ProfileCache\ProfileMap.json $CacheFilePath"
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
  param([string] $Module, [string] $Profile, [PSCustomObject] $ProfileMap)
  $versions = $ProfileMap.$Profile.$Module
  $versionEnum = $versions.GetEnumerator()
  $toss = $versionEnum.MoveNext()
  $version = $versionEnum.Current
  Install-Module $Module -RequiredVersion $version -Repository $BootStrapRepo
}

# Create a hash table for module dependency wrt profiles @{'Module.Version' = @(profile)} across all profilemaps cached.
function Test-Dependencies
{
  $ProfileCache = Get-ProfileCachePath
  $ProfileMapFiles = Get-ChildItem $ProfileCache
  $dependencyIndex = @{} 
  foreach($ProfileMapPath in $ProfileMapFiles)
  {
    $ProfileMap = Get-Content -Raw -Path (Join-Path $ProfileCache $ProfileMapPath) |  ConvertFrom-json
    $Profiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    foreach ($profile in $Profiles)
    {
      foreach ($Module in ($ProfileMap.$profile | Get-Member -MemberType NoteProperty).Name)
      {
        $versionList = $ProfileMap.$Profile.$Module
        foreach ($version in $versionList)
        {
          if ($dependencyIndex.ContainsKey(($Module + $version)))
          {
            if ($profile -notin $dependencyIndex[($Module + $version)])
            {
              $dependencyIndex[($Module + $version)] += $Profile
            }
          }
          else {
            $dependencyIndex.Add(($Module + $version), @($Profile))
          }
        }
      }
    }
  }
  $dependencyIndex
}

# Gets hash value for profilemap
function Get-FileHashProfileMap
{
  param([PSObject]$profilemap)
  $mapstr = Get-ProfilesAvailable $profilemap
  $bytearr = [System.Text.Encoding]::UTF8.GetBytes($mapstr)
  $stream = [System.Io.MemoryStream]::New($bytearr)
  $ProfileMapHash = (Get-FileHash -InputStream $stream -Algorithm MD5)
  return $ProfileMapHash.Hash
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

# Checks if the profiles associated with the module version in dependencyIndex are installed.
function Test-ProfilesInstalled
{
  param([String]$Module, [String]$Profile, [PSObject]$PMap)

  # Get the dependencyIndex @{"Module.Version": @(Profile)}: This is to skip uninstalling modules that are part of other profiles.
  $dependencyIndex = Test-Dependencies

  # Get-Profiles installed across all hashes. Do this once and update it every time a profile is uninstalled.
  if($AllProfilesInstalled.Count -eq 0)
  {
    $AllProfilesInstalled = Get-AllProfilesInstalled
  }

  # Profiles associated with the particular module version - installed?
  $profilesAssociated = @()
  $versionList = $PMap.$Profile.$Module
  foreach ($version in $versionList)
  {
    foreach ($profileInDepIndex in $dependencyIndex[$Module + $version])
    {
      if ($profileInDepIndex -in $AllProfilesInstalled)
      {
        $profilesAssociated += $profileInDepIndex
      }
    }
  }
  return $profilesAssociated
}

# Function to uninstall module
function Uninstall-ModuleHelper
{
  param([String]$Module, [System.Version]$version)
  Do
  {
    $moduleInstalled = Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} 
    if ($moduleInstalled -ne $null) 
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
  }
  While($moduleInstalled -ne $null);        
}

# Help function to uninstall a profile
function Uninstall-ProfileHelper
{
  param([String]$Profile, [PSObject]$PMap)

  PROCESS {
    $Profile = $PSBoundParameters.Profile
    $modules = ($PMap.$Profile | Get-Member -MemberType NoteProperty).Name

    foreach ($module in $modules)
    {
      Invoke-UninstallModule -PMap $PMap -Profile $Profile -Module $module
    }
    # Remove this profile from $AllProfilesInstalled
    if ($Profile -in $AllProfilesInstalled)
    {
      $AllProfilesInstalled.Remove($Profile)
    }
  }
}

function Invoke-UninstallModule
{
  param([String]$Profile, [PSObject]$PMap, [String]$Module)
      
  # Check if the profiles associated with the module version are installed.
  $profilesAssociated = Test-ProfilesInstalled -Module $Module -Profile $Profile -PMap $PMap
      
  # If more than one profile is installed for the same version of the module, do not uninstall; skip if none installed
  if (($profilesAssociated.Count -ne 1) -and ($profilesAssociated -ne $Profile))
  {
    continue
  }

  # Uninstall module
  $versionList = $PMap.$Profile.$module
  foreach ($version in $versionList)
  {
    Uninstall-ModuleHelper -Module $module -version $version
  } 
}

# Helps to uninstall previous versions of the profile
function Remove-PreviousVersions
{
  param([String]$Profile, [PSObject]$PreviousMap, [PSObject]$LatestMap)
  $PreviousProfiles = ($PreviousMap | Get-Member -MemberType NoteProperty).Name
  $LatestProfiles = ($LatestMap | Get-Member -MemberType NoteProperty).Name
  
  # If the profile was not in $PreviousProfiles, return
  if($Profile -notin $PreviousProfiles)
  {
    return
  }
    
  foreach ($module in ($PreviousMap.$Profile | Get-Member -MemberType NoteProperty).Name)
  {
    # If the latest version is same as the previous version, do not uninstall.
    if (($PreviousMap.$Profile.$module | Out-String) -eq ($LatestMap.$Profile.$module | Out-String))
    {
      continue
    }
      
    # Is that module installed? If not return
    $versionList = $PreviousMap.$Profile.$module
    foreach ($version in $versionList)
    {
      if ((Get-Module -Name $Module -ListAvailable | Where-Object { $_.Version -eq $version} ) -ne $null)
      {
        # Modules are different. Uninstall previous version.
        Invoke-UninstallModule -PMap $PreviousMap -Profile $Profile -Module $module
      }
    }
  }
}

# Gets profiles installed from all the profilemaps from cache
function Get-AllProfilesInstalled
{
  $ProfileCache = Get-ProfileCachePath
  $ProfileMapHashes = Get-ChildItem $ProfileCache 
  foreach ($ProfileMapHash in $ProfileMapHashes)
  {
    # Skip the symlink. Target is already handled.
    if ($ProfileMapHash -eq 'ProfileMap.json')
    {
      continue
    }

    $ProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapHash) |  ConvertFrom-json
    $profilesInstalled = (Get-ProfilesInstalled -ProfileMap $ProfileMap)
    foreach ($key in $profilesInstalled.Keys)
    {
      if ($key -notin $AllProfilesInstalled)
      {
        $AllProfilesInstalled.Add($key) | Out-Null
      }
    }
  }
  return $AllProfilesInstalled
}

# Helps to remove-previous versions of the update-profile and clean up cache, if none of the old hash profiles are installed
function Update-ProfileHelper
{
  param([string]$Profile)

  # Get all the hash files (ProfileMaps) from cache
  $ProfileCache = Get-ProfileCachePath
  $ProfileMapHashes = Get-ChildItem $ProfileCache

  # Find the latest ProfileMap 
  $latestProfileMapHash = (Get-ChildItem "$ProfileCache\ProfileMap.json").Target
  $LatestProfileMap = Get-Content -Raw -Path $latestProfileMapHash |  ConvertFrom-json
  $AllProfiles = (Get-ProfilesInstalled -ProfileMap $LatestProfileMap)

  foreach ($ProfileMapHash in $ProfileMapHashes)
  {
    # Do not process the latest hash; we don't want to remove the latest hash
    if (($ProfileMapHash.Name -eq "ProfileMap.json") -or ($ProfileMapHash.Name -eq ([System.IO.Path]::GetFileName($latestProfileMapHash))))
    {
      continue
    }

    # Compare previous & latest map for the update profile. Uninstall previous if they are different
    $previousProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapHash) |  ConvertFrom-json
    Remove-PreviousVersions -Profile $Profile -PreviousMap $previousProfileMap -LatestMap $LatestProfileMap

    # Get the installed profiles from the previous map
    $profilesInstalled = (Get-ProfilesInstalled -ProfileMap $previousProfileMap)
    foreach ($PreviousProfile in $profilesInstalled.Keys)
    {
      # Is it part of the latest hash? If the module versions are different, it would have been uninstalled if prev versions were removed.
      if ($PreviousProfile -in $AllProfiles.Keys)
      {
        continue
      }
      else {
        # do not delete hash; go to next hash
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
    Add-RemoveParam $params
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
      Write-Host "Loading Profile $Profile"
      foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
      {
        $version = Get-AzureRmModule -Profile $Profile -Module $Module
        if (($version -eq $null) -and ($IsConfirmed -or $Force.IsPresent -or $PSCmdlet.ShouldContinue("Install Modules for Profile $Profile from the gallery?", "Installing Modules for Profile $Profile")))
        {
          # Flag to track if the prompt for install module was previously accepted.
          $IsConfirmed = $true
          Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap
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
    return $params
  }

  PROCESS {
    $ProfileMap = (Get-AzProfile)
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name
    $Profile = $PSBoundParameters.Profile
    foreach ($Module in ($ProfileMap.$Profile | Get-Member -MemberType NoteProperty).Name)
    {
      $version = Get-AzureRmModule -Profile $Profile -Module $Module
      if ($version -eq $null) 
      {
        Install-ModuleHelper -Module $Module -Profile $Profile -ProfileMap $ProfileMap
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
    $profilesInstalled = Get-ProfilesInstalled -ProfileMap $ProfileMap

    # Return if the profile specified is not installed.
    if ($Profile -notin $profilesInstalled.Keys)
    {
      return
    }

    if ($PSCmdlet.ShouldProcess("$Profile", "Uninstall Profile")) 
    {
      if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Uninstall Profile $Profile", "Removing Modules for profile $Profile")))
      {
        Uninstall-ProfileHelper -PMap $ProfileMap @PSBoundParameters
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
    # Update Profile cache, if not up-to-date
    $ProfileMap = (Get-AzProfile -Update)
    $profile = $PSBoundParameters.Profile
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $AllProfiles = ($ProfileMap | Get-Member -MemberType NoteProperty).Name

    # Install & import the required version
    Use-AzureRmProfile @PSBoundParameters

    # Remove previous versions of the profile?
    if ($PSCmdlet.ShouldProcess("Remove previous versions")) 
    {
      if (($Remove -or $PSCmdlet.ShouldContinue("Uninstall Previous Module Versions of the profile", "Removing previous versions of the profile")))
      {
        # Remove-PreviousVersions and clean up cache
        Update-ProfileHelper -profile $profile
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
