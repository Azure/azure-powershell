$RollUpModule = "AzureRM"
$PSProfileMapEndpoint = "https://profile.azureedge.net/powershell/ProfileMap.json"
$PSModule = $ExecutionContext.SessionState.Module
# $Global:dependencyIndex 
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

# Get profile cache path
function Get-ProfileCachePath
{
  $ProfileCache = Join-Path -path $env:LOCALAPPDATA -childpath "Microsoft\AzurePowerShell\ProfileCache"
  return $ProfileCache
}

# Make Rest-Call
function Get-RestResponse
{
  try {
    $ProfileMap = Invoke-RestMethod -ea SilentlyContinue -Uri $PSProfileMapEndpoint -ErrorVariable RestError -ContentType application/json 
    return $ProfileMap
  }
  catch {
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
  $OnlineProfileMapHash = (Get-FileHashProfileMap $OnlineProfileMap).Hash

  # If profilemap.json exists, compare online hash and cached hash; if not different, don't replace cache.
  if (Test-Path "$ProfileCache\ProfileMap.json")
  {
    [string]$ProfilePath = (Get-ChildItem "$ProfileCache\ProfileMap.json").Target
    [string]$ProfileMapHash = [System.IO.Path]::GetFileNameWithoutExtension($ProfilePath)
    if ($ProfileMapHash -eq $OnlineProfileMapHash)
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
  param([PSCustomObject] $ProfileMap)
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
  param([PSCustomObject] $ProfileMap, [REF]$IncompleteProfiles)
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
  <#
  https://msdn.microsoft.com/powershell/reference/5.1/microsoft.powershell.utility/Get-FileHash
  http://stackoverflow.com/questions/8047064/convert-string-to-system-io-stream
  #>
  $mapstr = Get-ProfilesAvailable $profilemap
  $bytearr = [System.Text.Encoding]::UTF8.GetBytes($mapstr)
  $stream = [System.Io.MemoryStream]::New($bytearr)
  Get-FileHash -InputStream $stream -Algorithm MD5
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
      $result = Get-ProfilesInstalled -ProfileMap $ProfileMap ([REF]$IncompleteProfiles)
      foreach ($key in $result.Keys)
      {
        Write-Host "Profile : $key"
        Write-Host "-----------------"
        $result.$key | Format-Table -HideTableHeaders 
      }
      if ($IncompleteProfiles -ne $null)
      {
        Write-Warning "Some modules from profile(s) $IncompleteProfiles were not installed. Use Install-AzureRmProfile to install missing modules."
      }
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
    $profilesInstalled = Get-ProfilesInstalled -ProfileMap $ProfileMap

    # Return if the profile specified is not installed.
    if ($Profile -notin $profilesInstalled)
    {
      return
    }

    # Get the dependencyIndex @{"Module.Version": @(Profile)}
    $dependencyIndex = Test-Dependencies
    Uninstall-ProfileHelper -PMap $ProfileMap -pInstalled $profilesInstalled -dependencyIndex $dependencyIndex @PSBoundParameters
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

    $ProfileCache = Get-ProfileCachePath
    $ProfileMapHashes = Get-ChildItem $ProfileCache 
    $latestProfileMapHash = (Get-ChildItem "$ProfileCache\ProfileMap.json").Target

    foreach ($ProfileMapHash in $ProfileMapHashes)
    {
      # We have already handled the target; so do not process for symlink "ProfileMap.Json"
      if ($ProfileMapHash.Name -eq "ProfileMap.json")
      {
        continue
      }

      $previousProfileMap = Get-Content -Raw -Path (Join-Path $profilecache $ProfileMapHash) |  ConvertFrom-json
      $PreviousProfiles = ($previousProfileMap | Get-Member -MemberType NoteProperty).Name
      $profilesInstalled = Get-ProfilesInstalled -ProfileMap $previousProfileMap

      # Get the dependencyIndex @{"Module.Version": @(Profile)}
      $dependencyIndex = Test-Dependencies

      foreach($PreviousProfile in $PreviousProfiles)
      {
        # Do not remove the current installed profile or if its latest or if its a greater version
        if (($PreviousProfile -eq $profile) -or ($PreviousProfile -eq 'Latest') -or ($PreviousProfile -gt $profile))
        {
          continue
        }
        
        if ($PreviousProfile -in $profilesInstalled.Keys)
        {
          # Uninstall the previous profile
          $removeHash = (Uninstall-ProfileHelper -Profile $PreviousProfile -PMap $previousProfileMap -pInstalled $profilesInstalled -dependencyIndex $dependencyIndex $PSBoundParameters.RemovePreviousVersions )
        }
      }

      # Delete hash file if profile uninstall was not denied; Do not remove the latest profilemap hash
      if (($removeHash -ne $false) -and ($ProfileMapHash.FullName -ne $latestProfileMapHash))
      {
        Remove-ProfileMapFile -ProfileMapPath (Join-Path $profilecache $ProfileMapHash)
      }
    }

    # Install & import the required version
    Use-AzureRmProfile @PSBoundParameters
  }
}


function Uninstall-ProfileHelper
{
  [CmdletBinding(SupportsShouldProcess = $true)]
	param([PSObject]$PMap, [array]$pInstalled, [hashtable]$dependencyIndex)
  DynamicParam
  {
    $params = New-Object -Type System.Management.Automation.RuntimeDefinedParameterDictionary
    Add-ProfileParam $params
    Add-ForceParam $params
    Add-RemoveParam $params
    return $params
  }

  PROCESS {
    $Force = $PSBoundParameters.Force
    $Remove = $PSBoundParameters.RemovePreviousVersions
    $Profile = $PSBoundParameters.Profile
    $modules = ($PMap.$Profile | Get-Member -MemberType NoteProperty).Name
    if ($PSCmdlet.ShouldProcess("$Profile", "Uninstall Profile")) 
    {
      if (($Force -or $Remove -or $PSCmdlet.ShouldContinue("Uninstall Profile $Profile", "Removing Modules for profile $Profile")))
      {
        foreach ($module in $modules)
        {
          # Check if the profiles associated with the module version are installed.
          $profilesAssociated = @()
          $versionList = $PMap.$Profile.$module
          foreach ($version in $versionList)
          {
            foreach ($profileInDepIndex in $dependencyIndex[$module + $version])
            {
              if ($profileInDepIndex -in $pInstalled.Keys)
              {
                $profilesAssociated += $profileInDepIndex
              }
            }
          }
      
          # If more than one profile is installed for the same version of the module, do not uninstall; skip if none installed
          if ($profilesAssociated.Count -ne 1)
          {
            continue
          }

          # Ask to uninstall. If denied, do not delete the hash
          foreach ($version in $versionList)
          {
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
        }
      }
      else
      {
        if ($moduleInstalled -ne $null)
        {
          $removeHash = $false
        }
        break
      }
    }
    else
    {
      break
    }
    return $removeHash
  }
}



function Remove-ProfileMapFile
{
  [CmdletBinding()]
	param([string]$ProfileMapPath)

  if (Test-Path -Path $ProfileMapPath)
  {
    RemoveWithRetry -Path $ProfileMapPath -Force
  }
}

function RemoveWithRetry
{
    param ([string]$Path)
    
    # $args.ErrorAction = "Stop"
    $retries = 3
    $secondsDelay = 2
    $retrycount = 0
    $completedSuccessfully = $false

    while (-not $completedSuccessfully) {
        try {
            Remove-Item @PSBoundParameters -ErrorAction Stop
            $completedSuccessfully = $true
        } catch {
            if ($retrycount -ge $retries) {
                throw
            } else {
                Start-Sleep $secondsDelay
                $retrycount++
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
